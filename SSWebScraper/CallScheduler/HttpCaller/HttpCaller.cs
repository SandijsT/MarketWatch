using CallScheduler.HttpCaller.Requests;

namespace CallScheduler.HttpCaller
{
    public static class HttpCaller
    {
        static async Task<VehicleResponse> ScrapeAsync(VehicleRequest vehicleRequest)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7101/");
                var response = await client.PostAsJsonAsync("api/Scraper/ScrapePosts", vehicleRequest);

                var vehicleResponse = new VehicleResponse();
                if (response.IsSuccessStatusCode)
                {
                    vehicleResponse = await response.Content.ReadAsAsync<VehicleResponse>();
                }
                return vehicleResponse;
            }
        }

        public static async Task RunScraperAsync(List<VehicleRequest> vehicleRequest)
        {
            try
            {
                foreach(var request in vehicleRequest)
                {
                    _ = await ScrapeAsync(request).ConfigureAwait(false);
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return;
        }

        public static async Task RateAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7172/");
                var response = await client.PostAsync("api/Rating/CalculateAverage", null);

                if (response.IsSuccessStatusCode)
                {
                    return;
                }
                else
                {
                    throw new HttpRequestException();
                }
            }
        }
    }
}
