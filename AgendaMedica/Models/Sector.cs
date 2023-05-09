﻿using System;
using System.Collections.Generic;

namespace AgendaMedica.Models;

public partial class Sector
{
    public int IdSector { get; set; }

    public string Sector1 { get; set; } = null!;

    public virtual ICollection<Agendum> Agenda { get; set; } = new List<Agendum>();
}
