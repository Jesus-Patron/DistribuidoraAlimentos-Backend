using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistribuidoraAlimentos.DTO
{
    public class SesionDTO
    {
        public int Id { get; set; }

        public string? Nombre { get; set; }

        public string? Correo { get; set; }

        public int? Contrasena { get; set; }

        public string? RolDescripcion { get; set; }
    }
}
