using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using DistribuidoraAlimentos.BLL.Servicios.Contratos;
using DistribuidoraAlimentos.DTO;
using DistribuidoraAlimentos.API.Utilidad;

namespace DistribuidoraAlimentos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly IRolService _rolServicio;

        public RolController(IRolService rolServicio)
        {
            _rolServicio = rolServicio;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var rsp = new Response<List<RolesDTO>>();

            try
            {
                rsp.status = true;
                rsp.value = await _rolServicio.Lista();
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
