using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using DistribuidoraAlimentos.BLL.Servicios.Contratos;
using DistribuidoraAlimentos.DTO;
using DistribuidoraAlimentos.API.Utilidad;

namespace DistribuidoraAlimentos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        private readonly IMarcaService _marcaServicio;

        public MarcaController(IMarcaService marcaServicio)
        {
            _marcaServicio = marcaServicio;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var rsp = new Response<List<MarcasDTO>>();

            try
            {
                rsp.status = true;
                rsp.value = await _marcaServicio.Lista();
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
