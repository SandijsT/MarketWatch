using System;
using System.Collections.Generic;

namespace DatabaseLibrary.Models;

public partial class LuengineDisplacementType
{
    public int EngineDisplacementTypeId { get; set; }

    public string EngineDisplacementType { get; set; }

    public decimal EngineDisplacement { get; set; }

    public virtual ICollection<EngineDisplacementTypeLanguage> EngineDisplacementTypeLanguages { get; } = new List<EngineDisplacementTypeLanguage>();

    public virtual ICollection<Rating> Ratings { get; } = new List<Rating>();

    public virtual ICollection<Vehicle> Vehicles { get; } = new List<Vehicle>();
}
