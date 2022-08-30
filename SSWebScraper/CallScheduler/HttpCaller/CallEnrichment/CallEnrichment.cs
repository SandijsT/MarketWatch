
using CallScheduler.HttpCaller.Requests;
using SSWebScraper.ScraperService;

namespace CallScheduler.HttpCaller.CallEnrichment
{
    public static class CallEnrichment
    {
        public static Task EnrichCall()
        {
            var config = TempVehicleConfig.GetConfig();
            var vehicleRequests = new List<VehicleRequest>();
            foreach(var type in config)
            {
                var vehicleRequest = new VehicleRequest
                {
                    Category = "cars",
                    Make = type
                };
                vehicleRequests.Add(vehicleRequest);
            }

            if (vehicleRequests != null)
            {
                HttpCaller.RunAsync(vehicleRequests).GetAwaiter().GetResult();
            }

            return Task.CompletedTask;
        }
    }
}
