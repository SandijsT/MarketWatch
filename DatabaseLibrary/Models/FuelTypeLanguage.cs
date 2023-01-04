using System;
using System.Collections.Generic;

namespace DatabaseLibrary.Models;

public partial class FuelTypeLanguage
{
    public int FuelTypeId { get; set; }

    public int LanguageId { get; set; }

    public string Description { get; set; }

    public virtual LufuelType FuelType { get; set; }
}
