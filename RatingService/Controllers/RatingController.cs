using Microsoft.AspNetCore.Mvc;
using DatabaseLibrary;
using DatabaseLibrary.Models;
using SSWebScraper.Contexts;

namespace RatingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly resourceContext _resourceContext;
        private readonly IConfiguration _configuration;

        public RatingController(resourceContext context, IConfiguration configuration)
        {
            _resourceContext = context;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("CalculateAverage")]
        public async Task<ActionResult> CalculateAverage()
        {
            var lookupService = new LookupService();
            var ratingVariations = lookupService.GetRatingDistinctCombinations();

            List<Rating> ratingList = new List<Rating>();

            foreach (var ratingVariation in ratingVariations)
            {
                var modelId = ratingVariation.ModelId;
                var engineDisplacementTypeId = ratingVariation.EngineDisplacementTypeId;
                var transmissionTypeId = ratingVariation.TransmissionTypeId;
                var fuelTypeId = ratingVariation.FuelTypeId;
                var bodyTypeId = ratingVariation.BodyTypeId;
                var categoryId = ratingVariation.CategoryId;

                var ratingValues = lookupService.GetRatingValues(
                    modelId,
                    engineDisplacementTypeId,
                    transmissionTypeId,
                    fuelTypeId,
                    bodyTypeId,
                    categoryId);

                decimal price = 0;
                var mileage = 0;
                var sampleCount = ratingValues.Count;
                foreach (var ratingValue in ratingValues)
                {
                    price += ratingValue.Price;
                    mileage += ratingValue.Mileage;
                }

                var averagePrice = price / sampleCount;
                var averageMileage = mileage / sampleCount;

                var rating = new Rating()
                {
                    SampleCount = sampleCount,
                    AveragePrice = averagePrice,
                    AverageMileage = averageMileage,
                    ModelId = modelId,
                    EngineDisplacementTypeId = engineDisplacementTypeId,
                    TransmissionTypeId = transmissionTypeId,
                    FuelTypeId = fuelTypeId,
                    BodyTypeId = bodyTypeId,
                    StorageDate = DateTime.Now
                };
                ratingList.Add(rating);
            }

            foreach (Rating rating in ratingList)
            {
                var storedRating = _resourceContext.Ratings.FirstOrDefault(x =>
                        x.ModelId == rating.ModelId &&
                        x.EngineDisplacementTypeId == rating.EngineDisplacementTypeId &&
                        x.TransmissionTypeId == rating.TransmissionTypeId &&
                        x.FuelTypeId == rating.FuelTypeId &&
                        x.BodyTypeId == rating.BodyTypeId);

                if (storedRating != null)
                {
                    _resourceContext.Ratings.Remove(storedRating);
                    await _resourceContext.Ratings.AddAsync(rating);
                }
                else
                {
                    await _resourceContext.Ratings.AddAsync(rating);
                }
            }

            await _resourceContext.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        [Route("GetRating")]
        public async Task<ActionResult> GetRating(string model)
        {
            return Ok();
        }
    }
}
