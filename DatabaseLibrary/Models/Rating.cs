using System;
using System.Collections.Generic;

namespace DatabaseLibrary.Models;

public partial class Rating
{
    public int RatingId { get; set; }

    public int SampleCount { get; set; }

    public decimal? AveragePrice { get; set; }

    public int? AverageMileage { get; set; }

    public int ModelId { get; set; }

    public int EngineDisplacementTypeId { get; set; }

    public int TransmissionTypeId { get; set; }

    public int FuelTypeId { get; set; }

    public int BodyTypeId { get; set; }

    public DateTime StorageDate { get; set; }

    public virtual LubodyType BodyType { get; set; }

    public virtual LuengineDisplacementType EngineDisplacementType { get; set; }

    public virtual LufuelType FuelType { get; set; }

    public virtual Lumodel Model { get; set; }

    public virtual LutransmissionType TransmissionType { get; set; }
}
