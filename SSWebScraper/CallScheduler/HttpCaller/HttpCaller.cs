using CallScheduler.HttpCaller.Requests;
using System.Net.Http.Headers;

namespace CallScheduler.HttpCaller
{
    public static class HttpCaller
    {
        static async Task<VehicleResponse> PostAsync(string path, VehicleRequest vehicleRequest)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44333/");
                var response = await client.PostAsJsonAsync("api/Analytics/CreatePosts", vehicleRequest);

                var vehicleResponse = new VehicleResponse();
                if (response.IsSuccessStatusCode)
                {
                    vehicleResponse = await response.Content.ReadAsAsync<VehicleResponse>();
                }
                return vehicleResponse;
            }
        }

        public static async Task RunAsync(List<VehicleRequest> vehicleRequest)
        {
            try
            {
                var url = new Uri($"https://localhost:44333/api/Analytics/CreatePosts");

                foreach(var request in vehicleRequest)
                {
                    _ = await PostAsync(url.OriginalString, request).ConfigureAwait(false);
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return;
        }
    }
}
