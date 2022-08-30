using CallScheduler.HttpCaller.CallEnrichment;

namespace CallScheduler.Services
{
    class CallerService
    {
        private readonly ILogger<CallerService> _logger;

        public CallerService(ILogger<CallerService> logger)
        {
            _logger = logger;
        }

        public async Task DoSomethingAsync()
        {
            await Task.Delay(900000);
            CallEnrichment.EnrichCall().GetAwaiter().GetResult();
            _logger.LogInformation(
                "Sample Service did something.");
        }
    }
}
