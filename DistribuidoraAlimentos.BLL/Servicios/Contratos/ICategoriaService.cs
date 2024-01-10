using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DistribuidoraAlimentos.DTO;

namespace DistribuidoraAlimentos.BLL.Servicios.Contratos
{
    public interface ICategoriaService
    {
        Task<List<CategoriaDTO>> Lista();
    }
}
