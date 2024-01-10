using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistribuidoraAlimentos.DTO
{
    public class UsuariosDTO
    {
        public int? Id { get; set; }

        public string? Nombre { get; set; }

        public string Correo { get; set; }

        public int Contrasena { get; set; }

        public int Telefono { get; set; }

        public int? IdRol { get; set; }

        public string? RolDescripcion { get; set; }

        public string? Estatus { get; set; }
    }
}
