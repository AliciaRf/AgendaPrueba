using System;
using System.Collections.Generic;

namespace AgendaMedica.Models;

public partial class Especialidad
{
    public int IdEsp { get; set; }

    public string NombreEsp { get; set; } = null!;

    public int IdeAte { get; set; }

    public virtual ICollection<Agendum> Agenda { get; set; } = new List<Agendum>();

    public virtual TipoAtencion IdeAteNavigation { get; set; } = null!;

    public virtual ICollection<Profesional> Profesionals { get; set; } = new List<Profesional>();
}
