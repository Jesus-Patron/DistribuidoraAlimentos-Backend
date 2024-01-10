using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistribuidoraAlimentos.DTO
{
    public class ProductosDTO
    {
        public int Id { get; set; }

        public int? IdCategoria { get; set; }

        public string? DescripcionCategoria { get; set; }

        public int? IdMarca { get; set; }

        public string? NombreMarca { get; set; }

        public string? Nombre { get; set; }

        public string? Descripcion { get; set; }

        public int? Stock { get; set; }

        public int? Costo { get; set; }
    }
}
