using System;
using System.Collections.Generic;

namespace DistribuidoraAlimentos.Model;

public partial class Vehiculos
{
    public int Id { get; set; }

    public int? IdProveedor { get; set; }

    public string? Marca { get; set; }

    public string? Modelo { get; set; }

    public string? Matricula { get; set; }

    public string? Estatus { get; set; }

    public virtual ICollection<Proveedores> Proveedores { get; set; } = new List<Proveedores>();
}
