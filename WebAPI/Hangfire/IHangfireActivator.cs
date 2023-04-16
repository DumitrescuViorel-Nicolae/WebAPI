using Hangfire;
using System;
using System.Threading.Tasks;

namespace WebAPI.Hangfire
{
    public interface IHangfireActivator
    {
        Task Run(IJobCancellationToken token);
        Task RunAtTimeOf(DateTime now);
    }
}