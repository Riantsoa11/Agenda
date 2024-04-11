using System;
using System.Collections.Generic;

namespace Agenda_V1_mety.Agenda_tsiory;

public partial class Contact
{
    public int Idcontact { get; set; }

    public string Nom { get; set; } = null!;

    public string Prenom { get; set; } = null!;

    public int Age { get; set; }

    public string Sexe { get; set; } = null!;

    public DateOnly Datenaissance { get; set; }

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Ville { get; set; } = null!;

    public string Statut { get; set; } = null!;

    public string Reseau { get; set; } = null!;

    public virtual ICollection<ReseauSociaux> ReseauSociauxes { get; set; } = new List<ReseauSociaux>();

    public virtual ICollection<Status> Statuses { get; set; } = new List<Status>();
}
