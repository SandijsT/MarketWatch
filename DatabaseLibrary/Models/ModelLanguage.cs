using System;
using System.Collections.Generic;

namespace DatabaseLibrary.Models;

public partial class ModelLanguage
{
    public int ModelId { get; set; }

    public int LanguageId { get; set; }

    public string Description { get; set; }

    public virtual Lumodel Model { get; set; }
}
