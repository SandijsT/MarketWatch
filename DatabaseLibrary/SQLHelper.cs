using DatabaseLibrary.DataTransferObjects;
using System.Data;
using System.Data.SqlClient;

namespace DatabaseLibrary
{
    public static class SqlHelper
    {
        public static object GetLUValueById(SqlConnection connection, string procedure, params object[] parameterValues)
        {
            var command = new SqlCommand(procedure, connection);
            command.Parameters.Add("@Category", SqlDbType.VarChar).Value = parameterValues[0];
            command.Parameters.Add("@LanguageId", SqlDbType.Int).Value = parameterValues[1];
            command.Parameters.Add("@Description", SqlDbType.VarChar).Value = parameterValues[2];
            command.CommandType = CommandType.StoredProcedure;

            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            var result = command.ExecuteScalar();

            connection.Close();

            return result;
        }

        public static List<RatingCombinationsDTO> GetRatingDistinctCombinations(SqlConnection connection)
        {
            var command = new SqlCommand("SELECT * FROM dbo.GetRatingDistinctCombinations()", connection);

            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            var reader = command.ExecuteReader();

            List<RatingCombinationsDTO> result = new List<RatingCombinationsDTO>();
            while (reader.Read())
            {
                RatingCombinationsDTO ratingCombinationsDTO = new RatingCombinationsDTO();
                ratingCombinationsDTO.ModelId = Convert.ToInt32(reader.GetValue(0));
                ratingCombinationsDTO.EngineDisplacementTypeId = Convert.ToInt32(reader.GetValue(1));
                ratingCombinationsDTO.TransmissionTypeId = Convert.ToInt32(reader.GetValue(2));
                ratingCombinationsDTO.FuelTypeId = Convert.ToInt32(reader.GetValue(3));
                ratingCombinationsDTO.BodyTypeId = Convert.ToInt32(reader.GetValue(4));
                ratingCombinationsDTO.CategoryId = Convert.ToInt32(reader.GetValue(5));
                result.Add(ratingCombinationsDTO);
            }

            reader.Close();
            connection.Close();

            return result;
        }

        public static List<RatingValuesDTO> GetRatingValues(SqlConnection connection, params object[] parameterValues)
        {
            var cmdText = $"SELECT* FROM dbo.GetRatingValues({parameterValues[0]}, {parameterValues[1]}, {parameterValues[2]}, {parameterValues[3]}, {parameterValues[4]}, {parameterValues[5]})";
            var command = new SqlCommand(cmdText, connection);

            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            var reader = command.ExecuteReader();

            List<RatingValuesDTO> result = new List<RatingValuesDTO>();
            while (reader.Read())
            {
                RatingValuesDTO ratingValuesDTO = new RatingValuesDTO();
                if(reader.GetValue(0) is not DBNull && reader.GetValue(1) is not DBNull)
                {
                    ratingValuesDTO.Price = Convert.ToDecimal(reader.GetValue(0));
                    ratingValuesDTO.Mileage = Convert.ToInt32(reader.GetValue(1));
                }
                result.Add(ratingValuesDTO);
            }

            reader.Close();
            connection.Close();

            return result;
        }
    }
}
