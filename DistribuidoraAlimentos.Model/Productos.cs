using System;
using System.Collections.Generic;

namespace DistribuidoraAlimentos.Model;

public partial class Productos
{
    public int Id { get; set; }

    public int? IdCategoria { get; set; }

    public int? IdMarca { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public int? Stock { get; set; }

    public int? Costo { get; set; }

    public virtual ICollection<DetalleVenta> DetalleVenta { get; set; } = new List<DetalleVenta>();

    public virtual Categoria? IdCategoriaNavigation { get; set; }

    public virtual Marca? IdMarcaNavigation { get; set; }
}
