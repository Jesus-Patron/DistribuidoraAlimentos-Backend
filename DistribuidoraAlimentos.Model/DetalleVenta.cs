using System;
using System.Collections.Generic;

namespace DistribuidoraAlimentos.Model;

public partial class DetalleVenta
{
    public int IdDetalleVenta { get; set; }

    public int? IdVenta { get; set; }

    public int? IdProducto { get; set; }

    public int? Cantidad { get; set; }

    public decimal? Precio { get; set; }

    public decimal? Total { get; set; }

    public virtual Productos? IdProductoNavigation { get; set; }

    public virtual Venta? IdVentaNavigation { get; set; }
}
