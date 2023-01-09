using DatabaseLibrary.DataTransferObjects;
using DatabaseLibrary.Models;

namespace DatabaseLibrary
{
    public class LookupService : ILookupService
    {
        protected static int GetLuItemIdByValue(string lookupcategory, int languageId, string description)
        {
            using var dbcResource = DbConnector.DbResourceConnection;
            var result = SqlHelper.GetLUValueById(dbcResource, "LUGetLookupItemIdByValue",
                lookupcategory,
                languageId,
                description);

            if (result == null)
            {
                return -1;
            }

            return (int)result;
        }

        public int GetLookupItemIdByValue(string lookupName, string description)
        {
            var lookupCategory = FortmatLookupName(lookupName);

            return GetLuItemIdByValue(lookupCategory, 1, description);
        }

        private static string FortmatLookupName(string category)
        {
            var formattedName = category.ToLower();
            if (!formattedName.EndsWith("language"))
            {
                formattedName = "language" + formattedName;
            }

            return formattedName;
        }

        public List<RatingCombinationsDTO> GetRatingDistinctCombinations()
        {
            using var dbcResource = DbConnector.DbResourceConnection;
            var result = SqlHelper.GetRatingDistinctCombinations(dbcResource);

            return result;
        }

        public List<RatingValuesDTO> GetRatingValues(int modelId, int engineDisplacementTypeId, int transmissionTypeId, int fuelTypeId, int bodyTypeId, int categoryId)
        {
            using var dbcResource = DbConnector.DbResourceConnection;
            var result = SqlHelper.GetRatingValues(dbcResource,
                modelId,
                engineDisplacementTypeId,
                transmissionTypeId,
                fuelTypeId,
                bodyTypeId,
                categoryId);

            return result;
        }

        public List<Rating> GetRatingsByModelId(int modelId)
        {
            using var dbcResource = DbConnector.DbResourceConnection;
            var result = SqlHelper.GetRatingsByModelId(dbcResource, modelId);

            return result;
        }
    }
}
