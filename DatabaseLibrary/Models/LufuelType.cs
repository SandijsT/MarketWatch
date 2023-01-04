using System;
using System.Collections.Generic;

namespace DatabaseLibrary.Models;

public partial class LufuelType
{
    public int FuelTypeId { get; set; }

    public string FuelType { get; set; }

    public virtual ICollection<FuelTypeLanguage> FuelTypeLanguages { get; } = new List<FuelTypeLanguage>();

    public virtual ICollection<Rating> Ratings { get; } = new List<Rating>();

    public virtual ICollection<Vehicle> Vehicles { get; } = new List<Vehicle>();
}
