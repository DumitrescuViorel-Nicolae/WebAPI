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

        public HangfireActivator(IServiceProvider serviceProvider, ISensorService sensorService)
        {
            this._serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
            _sensorService = sensorService ?? throw new ArgumentNullException();
        }

        public async Task Run(IJobCancellationToken token)
        {
            token.ThrowIfCancellationRequested();
            await RunAtTimeOf(DateTime.Now);
        }

        public Task RunAtTimeOf(DateTime now)
        {
           return _sensorService.ReadEnvironment();
        }
    }
}
