using System.Data;

namespace DatabaseLibrary.DataTransferObjects
{
    public class RatingCombinationsDTO
    {
        public int ModelId { get; set; }

        public int EngineDisplacementTypeId { get; set; }

        public int TransmissionTypeId { get; set; }

        public int FuelTypeId { get; set; }

        public int BodyTypeId { get; set; }

        public int CategoryId { get; set; }
    }
}
