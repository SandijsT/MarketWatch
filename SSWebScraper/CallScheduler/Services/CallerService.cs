using CallScheduler.HttpCaller.CallEnrichment;
using System;

namespace CallScheduler.Services
{
    class CallerService
    {
        private readonly ILogger<CallerService> _logger;

        public CallerService(ILogger<CallerService> logger)
        {
            _logger = logger;
        }

        public async Task CallServiceAsync()
        {
            await Task.Delay(900000);
            CallEnrichment.EnrichCall().GetAwaiter().GetResult();
            _logger.LogInformation(
                "Service called " + DateTime.Now.ToString());
        }
    }
}
