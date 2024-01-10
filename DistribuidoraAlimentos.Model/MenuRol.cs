using System;
using System.Collections.Generic;

namespace DistribuidoraAlimentos.Model;

public partial class MenuRol
{
    public int Id { get; set; }

    public int? IdMenu { get; set; }

    public int? IdRol { get; set; }

    public virtual Menu? IdMenuNavigation { get; set; }

    public virtual Roles? IdRolNavigation { get; set; }
}
