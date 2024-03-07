using Agenda.Service.DAO;
using System;
using System.Collections.Generic;

namespace Agenda.agenda_tsiory;

public partial class Contact
{
    public int IdContact { get; set; }

    public string NomContact { get; set; } = null!;

    public string PrenomContact { get; set; } = null!;

    public string? AdressContact { get; set; }

    public string? EmailContact { get; set; }

    public string? PhoneContact { get; set; }

    public string? DateDeNaissanceContact { get; set; }

    public string? SitewebContact { get; set; }

    public virtual ICollection<ReseauSociaux> ReseauSociauxes { get; set; } = new List<ReseauSociaux>();

  
    
}
