
using CallScheduler.HttpCaller.Requests;
using SSWebScraper.ScraperService;

namespace CallScheduler.HttpCaller.CallEnrichment
{
    public static class CallEnrichment
    {
        public static Task EnrichCall()
        {
            var config = TempVehicleConfig.GetConfig();
            var postType = TempVehicleConfig.PostType;
            var category = TempVehicleConfig.Category;

            var vehicleRequests = new List<VehicleRequest>();
            foreach(var type in config)
            {
                var vehicleRequest = new VehicleRequest
                {
                    PostType = postType,
                    Category = category,
                    Make = type
                };
                vehicleRequests.Add(vehicleRequest);
            }

            if (vehicleRequests != null)
            {
                HttpCaller.RunScraperAsync(vehicleRequests).GetAwaiter().GetResult();
            }

            return Task.CompletedTask;
        }
    }
}
