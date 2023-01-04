using System;
using System.Collections.Generic;

namespace DatabaseLibrary.Models;

public partial class EngineDisplacementTypeLanguage
{
    public int EngineDisplacementTypeId { get; set; }

    public int LanguageId { get; set; }

    public string Description { get; set; }

    public virtual LuengineDisplacementType EngineDisplacementType { get; set; }
}
