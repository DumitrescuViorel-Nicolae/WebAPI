using DataAccess.Repositories.Interfaces;
using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Services.Interfaces;

namespace WebAPI.Services
{
    public class CheckerService : ICheckerService
    {
            private readonly ISavedReadingsRepository _savedReadingsRepository;
            private readonly IServoStateRepository _servoStateRepository;
            private readonly IServoService _servoService;
            private string body;

            public CheckerService(ISavedReadingsRepository savedReadingsRepository, IServoStateRepository servoStateRepository, IServoService servoService)
            {
                _savedReadingsRepository = savedReadingsRepository;
                _servoStateRepository = servoStateRepository;
                _servoService = servoService;
            }

            /// Check if there are considerable variations in parameters
            /// Initiate reporting
            public async Task<bool> IsOverheat()
            {
                var result = await Task.Run(() => _savedReadingsRepository.Read());
                var temperature = result.Where(item => item.Type == "temperature");
                var mean = temperature.OrderByDescending(item => item.Id)
                          .Skip(5)
                          .Select(item => float.TryParse(item.Value, out float value) ? value : 0)
                          .Average();
                var lastEntry = float.Parse(temperature.LastOrDefault().Value);

                // takes the entries existing in DB without the last 5 of them meaning that it skips the last 5minutes
                var temperatureDiff = lastEntry - mean;
                if(temperatureDiff > 7.5)
                {   
                    body += $"The value {lastEntry} of the temperature was";
                }
                return temperatureDiff > 7.5;
            }      
            public async Task<bool> IsOverheat(double value)
            {
                var result = await Task.Run(() => _savedReadingsRepository.Read());
                var temperature = result.Where(item => item.Type == "temperature");
                var mean = temperature.OrderByDescending(item => item.Id)
                          .Skip(5)
                          .Select(item => float.TryParse(item.Value, out float value) ? value : 0)
                          .Average();

                // takes the entries existing in DB without the last 5 of them meaning that it skips the last 5minutes
                var temperatureDiff = value - mean;
                if(temperatureDiff >= 7.5)
                {   
                    body += $"The value {value} of the temperature was {temperatureDiff} degrees higher that the mean({mean}). ";
                }
                return temperatureDiff > 7.5;
            }

            /// Manage the automatic servo trigger (checkbox in client)
            public async Task ChangeServoState(bool state)
            {
                var servoState = _servoStateRepository.Read().FirstOrDefault();
                servoState.IsOn = state;

                await Task.Run(() => _servoStateRepository.Update(servoState));
            }

            public string EmergencyTrigger()
            {
                if (_servoStateRepository.Read().FirstOrDefault().IsOn)
                {
                    _servoService.AutomaticTrigger();
                    body += $"Servo triggered at {DateTime.Now}.";
                }

                return body;
            }

            public async Task<string> Simulate()
            {
                var result = _savedReadingsRepository.Read();
                var temperature = result.Where(item => item.Type == "temperature");
                var value = temperature.OrderByDescending(item => item.Id)
                          .Skip(5)
                          .Select(item => float.TryParse(item.Value, out float value) ? value : 0)
                          .Average() + 7.5;
                await IsOverheat(value);

                return EmergencyTrigger();
            }

    }
}
