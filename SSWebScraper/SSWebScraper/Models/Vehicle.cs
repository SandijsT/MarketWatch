using System;
using System.Collections.Generic;

namespace SSWebScraper.Models
{
    public partial class Vehicle
    {
        public int PostId { get; set; }
        public decimal? Price { get; set; }
        public string? Title { get; set; }
        public string? Desription { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public DateTime? TIendDate { get; set; }
        public int? Mileage { get; set; }
        public string? Color { get; set; }
        public int ModelId { get; set; }
        public int EngineDisplacementTypeId { get; set; }
        public int TransmissionTypeId { get; set; }
        public int FuelTypeId { get; set; }
        public int BodyTypeId { get; set; }
        public int PostTypeId { get; set; }
        public int CategoryId { get; set; }
        public string? Link { get; set; }
        public int? Views { get; set; }
        public DateTime? PublishedDate { get; set; }
        public DateTime StorageDate { get; set; }

        public virtual LUBodyType BodyType { get; set; } = null!;
        public virtual LUCategory Category { get; set; } = null!;
        public virtual LUEngineDisplacementType EngineDisplacementType { get; set; } = null!;
        public virtual LUFuelType FuelType { get; set; } = null!;
        public virtual LUModel Model { get; set; } = null!;
        public virtual LUPostType PostType { get; set; } = null!;
        public virtual LUTransmissionType TransmissionType { get; set; } = null!;
    }
}
