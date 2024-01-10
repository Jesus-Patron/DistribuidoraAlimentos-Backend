using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using DistribuidoraAlimentos.BLL.Servicios.Contratos;
using DistribuidoraAlimentos.DTO;
using DistribuidoraAlimentos.API.Utilidad;

namespace DistribuidoraAlimentos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly IVentaService _ventaServicio;

        public VentaController(IVentaService ventaServicio)
        {
            _ventaServicio = ventaServicio;
        }

        [HttpPost]
        [Route("Registrar")]
        public async Task<IActionResult> Registrar([FromBody] VentasDTO venta)
        {
            var rsp = new Response<VentasDTO>();

            try
            {
                rsp.status = true;
                rsp.value = await _ventaServicio.Registrar(venta);

            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = ex.Message;

            }
            return Ok(rsp);

        }


        [HttpGet]
        [Route("Historial")]
        public async Task<IActionResult> Historial(string buscarPor, string? numeroVenta, string? fechaInicio, string? fechaFin)
        {
            var rsp = new Response<List<VentasDTO>>();
            numeroVenta = numeroVenta is null ? "" : numeroVenta;
            fechaInicio = fechaInicio is null ? "" : fechaInicio;
            fechaFin = fechaFin is null ? "" : fechaFin;


            try
            {
                rsp.status = true;
                rsp.value = await _ventaServicio.Historial(buscarPor, numeroVenta, fechaInicio, fechaFin);

            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = ex.Message;

            }
            return Ok(rsp);
        }


        [HttpGet]
        [Route("Reporte")]
        public async Task<IActionResult> Reporte(string? fechaInicio, string? fechaFin)
        {
            var rsp = new Response<List<ReportesVentaDTO>>();

            try
            {
                rsp.status = true;
                rsp.value = await _ventaServicio.Reporte(fechaInicio, fechaFin);

            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = ex.Message;

            }
            return Ok(rsp);
        }
    }
}
