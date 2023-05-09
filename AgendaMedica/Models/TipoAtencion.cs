using System;
using System.Collections.Generic;

namespace AgendaMedica.Models;

public partial class TipoAtencion
{
    public int IdAte { get; set; }

    public string DescripcionAte { get; set; } = null!;

    public virtual ICollection<Especialidad> Especialidads { get; set; } = new List<Especialidad>();
}
