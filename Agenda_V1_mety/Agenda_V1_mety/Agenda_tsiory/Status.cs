using System;
using System.Collections.Generic;

namespace Agenda_V1_mety.Agenda_tsiory;

public partial class Status
{
    public int IdStatus { get; set; }

    public string Status1 { get; set; } = null!;

    public int ContactIdcontact { get; set; }

    public int ContactIdcontact1 { get; set; }

    public virtual Contact ContactIdcontact1Navigation { get; set; } = null!;
}
