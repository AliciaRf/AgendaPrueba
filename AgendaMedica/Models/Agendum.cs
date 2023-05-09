using System;
using System.Collections.Generic;

namespace AgendaMedica.Models;

public partial class Agendum
{
    public int IdAgen { get; set; }

    public DateTime FechaAgen { get; set; }

    public TimeSpan HoraAgen { get; set; }

    public string RutPac { get; set; } = null!;

    public int IdPrev { get; set; }

    public string RutPro { get; set; } = null!;

    public string RutUs { get; set; } = null!;

    public int IdSector { get; set; }

    public int? IdeEsp { get; set; }

    public virtual Prevision IdPrevNavigation { get; set; } = null!;

    public virtual Sector IdSectorNavigation { get; set; } = null!;

    public virtual Especialidad? IdeEspNavigation { get; set; }

    public virtual Paciente RutPacNavigation { get; set; } = null!;

    public virtual Profesional RutProNavigation { get; set; } = null!;

    public virtual LoginUsuario RutUsNavigation { get; set; } = null!;
}
