using System;
using System.Collections.Generic;

namespace AgendaMedica.Models;

public partial class Profesional
{
    public string RutPro { get; set; } = null!;

    public string NombrePro { get; set; } = null!;

    public string ApellidoPro { get; set; } = null!;

    public int IdEsp { get; set; }

    public string EmailPro { get; set; } = null!;

    public string FonoPro { get; set; } = null!;

    public virtual ICollection<Agendum> Agenda { get; set; } = new List<Agendum>();

    public virtual Especialidad IdEspNavigation { get; set; } = null!;
}
