using SSWebScraper.Models;

namespace SSWebScraper.ScraperService
{
    public static class PostMap
    {
        public static Vehicle MapPost(PostObjectMappings postMappings, CallerRequest request)
        {
/*            var attributes = postMappings.Attributes;

            if (postMappings.Price != "ELSE")
            {
                vehicleObject.Make = attributes.GetValueOrDefault("Marka ");
                vehicleObject.ReleaseDate = attributes.GetValueOrDefault("Izlaiduma gads:");
                vehicleObject.EngineDisplacement = attributes.GetValueOrDefault("Motors:");
                vehicleObject.Transmission = attributes.GetValueOrDefault("Ātr.kārba:");
                vehicleObject.Mileage = attributes.GetValueOrDefault("Nobraukums, km:");
                vehicleObject.Color = attributes.GetValueOrDefault("Krāsa:");
                vehicleObject.BodyType = attributes.GetValueOrDefault("Virsbūves tips:");
                vehicleObject.TIEndDate = attributes.GetValueOrDefault("Tehniskā apskate:");
            }*/
            var vehicle = new Vehicle
            {
                Price = null,
                Title = null,
                Desription = null,
                ModelId = 0,
                ReleaseDate = null,
                EngineDisplacementTypeId = 0,
                TransmissionTypeId = 0,
                Mileage = null,
                Color = null,
                FuelTypeId = 0,
                BodyTypeId = 0,
                TIendDate = null,
                Link = postMappings.Link,
                PostTypeId = 0,
                CategoryId = 0,
                Views = null,
                PublishedDate = DateTime.Now,
                StorageDate = DateTime.Now,
            };

            return vehicle;
        }
    }
}
