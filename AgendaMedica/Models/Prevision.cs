using System;
using System.Collections.Generic;

namespace AgendaMedica.Models;

public partial class Prevision
{
    public int IdPrev { get; set; }

    public string NombrePrev { get; set; } = null!;

    public virtual ICollection<Agendum> Agenda { get; set; } = new List<Agendum>();
}
