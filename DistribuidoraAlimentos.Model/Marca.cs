using System;
using System.Collections.Generic;

namespace DistribuidoraAlimentos.Model;

public partial class Marca
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Productos> Productos { get; set; } = new List<Productos>();
}
