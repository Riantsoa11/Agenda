using System;
using System.Collections.Generic;

namespace Agenda_V1_mety.Agenda_tsiory;

public partial class Profilsreseau
{
    public int Idprofilsreseau { get; set; }

    public DateOnly? Datecreation { get; set; }

    public string? Namereseau { get; set; }

    public int ReseauSociauxIdreseauSociaux { get; set; }

    public virtual ReseauSociaux ReseauSociauxIdreseauSociauxNavigation { get; set; } = null!;
}
