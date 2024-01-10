using System;
using System.Collections.Generic;

namespace DistribuidoraAlimentos.Model;

public partial class Usuarios
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Correo { get; set; }

    public int? Contrasena { get; set; }

    public int? Telefono { get; set; }

    public int? IdRol { get; set; }

    public string? Estatus { get; set; }

    public virtual Roles? IdRolNavigation { get; set; }

    public virtual Proveedores? Proveedore { get; set; }
}
