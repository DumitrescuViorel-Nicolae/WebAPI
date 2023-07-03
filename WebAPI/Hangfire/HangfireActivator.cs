using Hangfire;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using System;
using WebAPI.Services;
using WebAPI.Services.Interfaces;

namespace WebAPI.Hangfire
{
    public class HangfireActivator : IHangfireActivator
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ISensorService _sensorService;
        private readonly ICheckerService _checkerService;

        public HangfireActivator(IServiceProvider serviceProvider, ISensorService sensorService, ICheckerService checkerService)
        {
            this._serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
            _sensorService = sensorService ?? throw new ArgumentNullException();
            _checkerService = checkerService ?? throw new ArgumentNullException(nameof(checkerService));
        }

        public async Task Run(IJobCancellationToken token)
        {
            token.ThrowIfCancellationRequested();
            await RunAtTimeOf(DateTime.Now);
        }

        public Task RunAtTimeOf(DateTime now)
        {
            var isOverheat = _checkerService.IsOverheat().Result;

            if (isOverheat)
            {
                _checkerService.EmergencyTrigger();
            }

            return _sensorService.ReadEnvironment();

        }
    }
}
