using System;
using System.Collections.Generic;

namespace AgendaMedica.Models;

public partial class LoginUsuario
{
    public string RutUs { get; set; } = null!;

    public string NombreUs { get; set; } = null!;

    public string ApellidoUs { get; set; } = null!;

    public string Contraseña { get; set; } = null!;

    public virtual ICollection<Agendum> Agenda { get; set; } = new List<Agendum>();
}
