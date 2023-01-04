using DatabaseLibrary;
using DatabaseLibrary.Models;
using System.Globalization;

namespace SSWebScraper.ScraperService
{
    // Refactor and organize!!
    public class PostMapper
    {
        public Vehicle MapPost(PostObjectMappings postMappings, CallerRequest request)
        {
            var attributes = postMappings.Attributes;
            if (attributes == null)
            {
                throw new NullReferenceException();
            }

            var motorValue = attributes.GetValueOrDefault("Motors:");
            string? engineDisplacement = null;
            string? fuelType = null;
            if(motorValue != null)
            {
                var motorValues = motorValue.Split();
                engineDisplacement = motorValues[0];
                if (motorValues.Length > 1)
                {
                    fuelType = motorValues[1];
                }
            }

            var price = FormatPrice(postMappings.Price);
            var modelId = FormatModelId(attributes.GetValueOrDefault("Marka "));
            var releaseDate = FormatReleaseDate(attributes.GetValueOrDefault("Izlaiduma gads:"));
            var engineDisplacementTypeId = FormatEngineDisplacementTypeId(engineDisplacement);
            var fuelTypeId = FormatFuelTypeId(fuelType);
            var color = FormatColor(attributes.GetValueOrDefault("Krāsa:"));
            var mileage = FormatMileage(attributes.GetValueOrDefault("Nobraukums, km:"));
            var technicalInspectionEndDate = FormatTIEndDate(attributes.GetValueOrDefault("Tehniskā apskate:"));
            var bodyTypeId = FormatBodyTypeId(attributes.GetValueOrDefault("Virsbūves tips:"));
            var transmissionTypeId = FormatTransmissionTypeId(attributes.GetValueOrDefault("Ātr.kārba:"));

            var vehicle = new Vehicle
            {
                Price = price,
                Title = null,
                Desription = postMappings.Desription,
                ModelId = modelId,
                ReleaseDate = releaseDate,
                EngineDisplacementTypeId = engineDisplacementTypeId,
                TransmissionTypeId = transmissionTypeId,
                Mileage = mileage,
                Color = color,
                FuelTypeId = fuelTypeId,
                BodyTypeId = bodyTypeId,
                TiendDate = technicalInspectionEndDate,
                Link = postMappings.Link,
                PostTypeId = MapPostType(request.PostType),
                CategoryId = MapCategory(request.Category),
                Views = null,
                PublishedDate = DateTime.Now,
                StorageDate = DateTime.Now,
            };

            return vehicle;
        }

        private int MapCategory(string category)
        {
            var lookupName = "CategoryLanguage";
            var lookupService = new LookupService();
            return lookupService.GetLookupItemIdByValue(lookupName, category);
        }

        private int MapBodyType(string bodyType)
        {
            var lookupName = "BodyTypeLanguage";
            var lookupService = new LookupService();
            return lookupService.GetLookupItemIdByValue(lookupName, bodyType);
        }

        private int MapTransmissionType(string transmissionType)
        {
            var lookupName = "TransmissionTypeLanguage";
            var lookupService = new LookupService();
            return lookupService.GetLookupItemIdByValue(lookupName, transmissionType);
        }

        private int MapPostType(string postType)
        {
            var lookupName = "PostTypeLanguage";
            var lookupService = new LookupService();
            return lookupService.GetLookupItemIdByValue(lookupName, postType);
        }

        private int MapModel(string model)
        {
            var lookupName = "ModelLanguage";
            var lookupService = new LookupService();
            return lookupService.GetLookupItemIdByValue(lookupName, model);
        }

        private int MapFuelType(string fuelType)
        {
            var lookupName = "FuelTypeLanguage";
            var lookupService = new LookupService();
            return lookupService.GetLookupItemIdByValue(lookupName, fuelType);
        }

        private int MapEngineDisplacementType(string engineDisplacementType)
        {
            var lookupName = "EngineDisplacementTypeLanguage";
            var lookupService = new LookupService();
            return lookupService.GetLookupItemIdByValue(lookupName, engineDisplacementType);
        }

        private decimal? FormatPrice(string price)
        {
            price = price.Trim('€');
            if (price == null || price == "ELSE")
            {
                price = "0";
            }
            price = price.Replace(" ", string.Empty);
            var priceDecimal = Convert.ToDecimal(price);

            return priceDecimal;
        }

        private int FormatModelId(string model)
        {
            var modelId = model != null ? MapModel(model) : 1;
            modelId = modelId != -1 ? modelId : 1;

            return modelId;
        }

        private DateTime? FormatReleaseDate(string releaseDateString)
        {
            var cultureInfo = new CultureInfo("es-ES");
            DateTime? releaseDate = null;
            if (releaseDateString != null)
            {
                var releaseDates = releaseDateString.Split();
                var releaseMonth = releaseDates.Length == 2 ? releaseDates[1] : null;

                switch (releaseMonth)
                {
                    case "janvāris":
                        releaseMonth = "01.01.";
                        break;
                    case "februāris":
                        releaseMonth = "01.02.";
                        break;
                    case "marts":
                        releaseMonth = "01.03.";
                        break;
                    case "aprīlis":
                        releaseMonth = "01.04.";
                        break;
                    case "maijs":
                        releaseMonth = "01.05.";
                        break;
                    case "jūnijs":
                        releaseMonth = "01.06.";
                        break;
                    case "jūlijs":
                        releaseMonth = "01.07.";
                        break;
                    case "augusts":
                        releaseMonth = "01.08.";
                        break;
                    case "septembris":
                        releaseMonth = "01.09.";
                        break;
                    case "oktobris":
                        releaseMonth = "01.10.";
                        break;
                    case "novembris":
                        releaseMonth = "01.11.";
                        break;
                    case "decembris":
                        releaseMonth = "01.12.";
                        break;

                    default:
                        releaseMonth = "01.01.";
                        break;
                }

                releaseDateString = releaseMonth + releaseDates[0];

                releaseDate = DateTime.ParseExact(releaseDateString, "dd.MM.yyyy", cultureInfo);
            }
            
            return releaseDate;
        }

        private int FormatEngineDisplacementTypeId(string? engineDisplacement)
        {
            var engineDisplacementTypeId = engineDisplacement != null ? MapEngineDisplacementType(engineDisplacement) : 1;
            engineDisplacementTypeId = engineDisplacementTypeId != -1 ? engineDisplacementTypeId : 1;

            return engineDisplacementTypeId;
        }

        private int FormatFuelTypeId(string? fuelType)
        {
            var fuelTypeId = fuelType != null ? MapFuelType(fuelType) : 1;
            fuelTypeId = fuelTypeId != -1 ? fuelTypeId : 1;

            return fuelTypeId;
        }

        private string? FormatColor(string? color)
        {
            if (color != null)
            {
                color = color.Replace(" &nbsp;", string.Empty);
            }

            return color;
        }

        private int? FormatMileage(string? mileage)
        {
            int? mileageInt = null;
            if (mileage != null)
            {
                mileage = mileage.Replace(" ", string.Empty);
                mileageInt = Convert.ToInt32(mileage);
            }

            return mileageInt;
        }

        private DateTime? FormatTIEndDate(string? tiEndDateString)
        {
            DateTime? tiEndDate = null;
            DateTime parsedDate;
            var isCorrectDate = DateTime.TryParse(tiEndDateString, out parsedDate);
            if (isCorrectDate)
            {
                tiEndDate = parsedDate;
            }

            return tiEndDate;
        }

        private int FormatBodyTypeId(string? bodyType)
        {
            var bodyTypeId = bodyType != null ? MapBodyType(bodyType) : 1;
            bodyTypeId = bodyTypeId != -1 ? bodyTypeId : 1;

            return bodyTypeId;
        }

        private int FormatTransmissionTypeId(string? transmissionType)
        {
            var transmissionTypeId = transmissionType != null ? MapTransmissionType(transmissionType) : 1;
            transmissionTypeId = transmissionTypeId != -1 ? transmissionTypeId : 1;

            return transmissionTypeId;
        }
    }
}
