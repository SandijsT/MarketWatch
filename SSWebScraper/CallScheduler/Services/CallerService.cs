using CallScheduler.HttpCaller.CallEnrichment;

namespace CallScheduler.Services
{
    class CallerService
    {
        private static int ScraperDelay = 900000;
        private static int RatingDelay = 600000;
        private readonly ILogger<CallerService> _logger;

        public CallerService(ILogger<CallerService> logger)
        {
            _logger = logger;
        }

        public async Task CallScraperServiceAsync()
        {
            await Task.Delay(ScraperDelay);
            CallEnrichment.EnrichCall().GetAwaiter().GetResult();
            _logger.LogInformation(
                "Scraper Service called successfully - " + DateTime.Now.ToString());
        }

        public async Task CallRatingServiceAsync()
        {
            await Task.Delay(RatingDelay);
            try
            {
                HttpCaller.HttpCaller.RateAsync().GetAwaiter().GetResult();
            }
            catch(Exception ex)
            {
                _logger.LogInformation(
                    "Rating Service call Failed!" + ex.Message);
            }
            
            _logger.LogInformation(
                "Rating Service called successfully - " + DateTime.Now.ToString());
        }
    }
}
