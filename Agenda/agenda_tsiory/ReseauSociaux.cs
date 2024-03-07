using System;
using System.Collections.Generic;

namespace Agenda.agenda_tsiory;

public partial class ReseauSociaux
{
    public int IdReseauSociaux { get; set; }

    public string Profil { get; set; } = null!;

    public string NomReseauSociaux { get; set; } = null!;

    public string LiensReseauSociaux { get; set; } = null!;

    public string? ReseauReseauSociaux { get; set; }

    public int ContactIdContact { get; set; }

    public string ContactPrenomContact { get; set; } = null!;

    public virtual Contact Contact { get; set; } = null!;
}
