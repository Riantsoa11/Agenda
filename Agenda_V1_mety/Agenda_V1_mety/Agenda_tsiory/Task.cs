using System;
using System.Collections.Generic;

namespace Agenda_V1_mety.Agenda_tsiory;

public partial class Task
{
    public int Idtask { get; set; }

    public string Nomtask { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int TodolistIdtodolist { get; set; }

    public int TodolistContactIdcontact { get; set; }

    public virtual Todolist Todolist { get; set; } = null!;
}
