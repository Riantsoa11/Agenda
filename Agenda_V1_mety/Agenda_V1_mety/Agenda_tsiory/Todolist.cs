using System;
using System.Collections.Generic;

namespace Agenda_V1_mety.Agenda_tsiory;

public partial class Todolist
{
    public int Idtodolist { get; set; }

    public DateOnly? Date { get; set; }

    public string? Descriptionl { get; set; }

    public int ContactIdcontact { get; set; }

    public virtual Contact ContactIdcontactNavigation { get; set; } = null!;

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
