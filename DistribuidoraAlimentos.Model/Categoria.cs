using System;
using System.Collections.Generic;

namespace DistribuidoraAlimentos.Model;

public partial class Categoria
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Productos> Productos { get; set; } = new List<Productos>();
}
