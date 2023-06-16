using DataAccess.Repositories.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Services.Interfaces;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using System;
using System.IO;
using System.Net.Mail;
using System.Text;
using Newtonsoft.Json.Linq;

namespace WebAPI.Services
{
    public class CheckerService : ICheckerService
    {
        private readonly ISavedReadingsRepository _savedReadingsRepository;
        private readonly IServoStateRepository _servoStateRepository;
        private readonly IServoService _servoService;

        public CheckerService(ISavedReadingsRepository savedReadingsRepository, IServoStateRepository servoStateRepository, IServoService servoService)
        {
            _savedReadingsRepository = savedReadingsRepository;
            _servoStateRepository = servoStateRepository;
            _servoService = servoService;
        }

        /// Check if there are considerable variations in parameters
        /// Manage the automatic servo trigger (checkbox in client)
        /// Initiate reporting
        public async Task<bool> IsOverheat()
        {
            var result = await Task.Run(() => _savedReadingsRepository.Read());
            var mean = result.OrderByDescending(item => item.Id).Skip(5).Sum(item => int.Parse(item.Value)) / result.ToList().Count - 1;
            var lastEntry = int.Parse(result.LastOrDefault().Value);

            // takes the entries existing in DB without the last 5 of them meaning that it skips the last 5minutes
            // de vorbit ce inseamna Task and shit like that

            return lastEntry - mean > 7.5;
        }

        public async Task HandleAutomaticServoTrigger(bool state)
        {
            var servoState = _servoStateRepository.Read().FirstOrDefault();
            servoState.IsOn = state;

            await Task.Run(() => _servoStateRepository.Update(servoState));
        }


        public void EmergencyTrigger()
        {
            if (_servoStateRepository.Read().FirstOrDefault().IsOn)
            {
                _servoService.ControlServo(90);
            } 
            
        }

        public async Task SendEmailAsync()
        {
            string[] Scopes = { GmailService.Scope.GmailSend };
            string ApplicationName = "NumeleAplicatiei";

            GoogleCredential credential;
            using (var stream = new FileStream("C:\\Users\\Nick\\Downloads\\credentials.json", FileMode.Open, FileAccess.Read))
            {
                credential = GoogleCredential.FromStream(stream).CreateScoped(Scopes);
            }

            var service = new GmailService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            var email = new MailMessage
            {
                From = new MailAddress("dterminator2020@gmail.com"),
                Subject = "Subiectul emailului",
                Body = "Corpul emailului",
                IsBodyHtml = true
            };
            email.To.Add("arrow6660675dumitrescu@gmail.com");

            var mimeMessage = MimeKit.MimeMessage.CreateFromMailMessage(email);

            var msg = new Message
            {
                Raw = Base64UrlEncode(mimeMessage.ToString())
            };

            await service.Users.Messages.Send(msg, "me").ExecuteAsync();
        }

        private static string Base64UrlEncode(string input)
        {
            var inputBytes = Encoding.UTF8.GetBytes(input);
            return Convert.ToBase64String(inputBytes)
                .Replace('+', '-')
                .Replace('/', '_')
                .Replace("=", "");
        }

    }
}
