using System;
using System.Collections.Generic;

namespace DatabaseLibrary.Models;

public partial class BodyTypeLanguage
{
    public int BodyTypeId { get; set; }

    public int LanguageId { get; set; }

    public string Description { get; set; }

    public virtual LubodyType BodyType { get; set; }
}
