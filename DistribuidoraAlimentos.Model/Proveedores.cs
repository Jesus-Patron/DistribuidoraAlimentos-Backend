using System;
using System.Collections.Generic;

namespace DistribuidoraAlimentos.Model;

public partial class Proveedores
{
    public int IdUsuario { get; set; }

    public string? Nombre { get; set; }

    public int? IdVehiculo { get; set; }

    public virtual Usuarios IdUsuarioNavigation { get; set; } = null!;

    public virtual Vehiculos? IdVehiculoNavigation { get; set; }
}
