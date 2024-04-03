using System;
using System.Collections.Generic;

namespace Agenda_V1_mety.Agenda_tsiory;

public partial class ReseauSociaux
{
    public int IdreseauSociaux { get; set; }

    public string? ReseauSociaux1 { get; set; }

    public string? Liens { get; set; }

    public string? Profil { get; set; }

    public int ContactIdcontact { get; set; }

    public virtual Contact ContactIdcontactNavigation { get; set; } = null!;

    public virtual ICollection<Profilsreseau> Profilsreseaus { get; set; } = new List<Profilsreseau>();
}
