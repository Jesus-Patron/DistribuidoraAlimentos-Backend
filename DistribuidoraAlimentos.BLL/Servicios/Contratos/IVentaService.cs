using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DistribuidoraAlimentos.DTO;

namespace DistribuidoraAlimentos.BLL.Servicios.Contratos
{
    public interface IVentaService
    {
        Task<VentasDTO> Registrar(VentasDTO modelo);
        Task<List<VentasDTO>> Historial(string buscarPor, string numeroVenta, string fechaInicio, string fechaFin);
        Task<List<ReportesVentaDTO>> Reporte(string fechaInicio, string fechaFin);
    }
}
