using System;
using System.Collections.Generic;

namespace DatabaseLibrary.Models;

public partial class TransmissionTypeLanguage
{
    public int TransmissionTypeId { get; set; }

    public int LanguageId { get; set; }

    public string Description { get; set; }

    public virtual LutransmissionType TransmissionType { get; set; }
}
