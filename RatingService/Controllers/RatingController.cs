using Microsoft.AspNetCore.Mvc;
using DatabaseLibrary;
using DatabaseLibrary.Models;
using SSWebScraper.Contexts;
using DatabaseLibrary.DataTransferObjects;

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
            try
            {
                var lookupService = new LookupService();
                var ratingVariations = lookupService.GetRatingDistinctCombinations();
                var ratingList = ProcessRatings(ratingVariations);
            
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
            catch (Exception ex)
            {
                throw new AggregateException("RatingService failure - ", ex);
            }
        }

        private List<Rating> ProcessRatings(List<RatingCombinationsDTO> ratingVariations)
        {
            var lookupService = new LookupService();

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
                    if (ratingValue.Price != 0 || ratingValue.Mileage != 0)
                    {
                        price += ratingValue.Price;
                        mileage += ratingValue.Mileage;
                    }
                }

                if (price != 0 || mileage != 0)
                {
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
            }

            return ratingList;
        }

        [HttpGet]
        [Route("GetRating")]
        public ActionResult<IEnumerable<Rating>> GetRating(string model)
        {
            var lookupService = new LookupService();
            var modelId = lookupService.GetLookupItemIdByValue("ModelLanguage", model);

            if(modelId == -1)
            {
                return NotFound($"Model {model} not found in the Database");
            }

            var ratings = lookupService.GetRatingsByModelId(modelId);
            foreach(var rating in ratings)
            {
                rating.Model = _resourceContext.Lumodels.FirstOrDefault(x => x.ModelId == rating.ModelId);
                rating.EngineDisplacementType = _resourceContext.LuengineDisplacementTypes.FirstOrDefault(x => x.EngineDisplacementTypeId == rating.EngineDisplacementTypeId);
                rating.TransmissionType = _resourceContext.LutransmissionTypes.FirstOrDefault(x => x.TransmissionTypeId == rating.TransmissionTypeId);
                rating.FuelType = _resourceContext.LufuelTypes.FirstOrDefault(x => x.FuelTypeId == rating.FuelTypeId);
                rating.BodyType = _resourceContext.LubodyTypes.FirstOrDefault(x => x.BodyTypeId == rating.BodyTypeId);
            }

            return Ok(ratings);
        }
    }
}
