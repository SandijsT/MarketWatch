using System;
using System.Collections.Generic;

namespace DatabaseLibrary.Models;

public partial class Vehicle
{
    public int PostId { get; set; }

    public decimal? Price { get; set; }

    public string Title { get; set; }

    public string Desription { get; set; }

    public DateTime? ReleaseDate { get; set; }

    public DateTime? TiendDate { get; set; }

    public int? Mileage { get; set; }

    public string Color { get; set; }

    public int ModelId { get; set; }

    public int EngineDisplacementTypeId { get; set; }

    public int TransmissionTypeId { get; set; }

    public int FuelTypeId { get; set; }

    public int BodyTypeId { get; set; }

    public int PostTypeId { get; set; }

    public int CategoryId { get; set; }

    public string Link { get; set; }

    public int? Views { get; set; }

    public DateTime? PublishedDate { get; set; }

    public DateTime StorageDate { get; set; }

    public virtual LubodyType BodyType { get; set; }

    public virtual Lucategory Category { get; set; }

    public virtual LuengineDisplacementType EngineDisplacementType { get; set; }

    public virtual LufuelType FuelType { get; set; }

    public virtual Lumodel Model { get; set; }

    public virtual LupostType PostType { get; set; }

    public virtual LutransmissionType TransmissionType { get; set; }
}
