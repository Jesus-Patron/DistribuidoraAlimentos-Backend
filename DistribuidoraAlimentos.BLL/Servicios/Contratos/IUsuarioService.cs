using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DistribuidoraAlimentos.DTO;

namespace DistribuidoraAlimentos.BLL.Servicios.Contratos
{
    public interface IUsuarioService
    {
        Task<List<UsuariosDTO>> Lista();
        Task<SesionDTO> ValidarCredenciales(string correo, int contrasena);
        Task<UsuariosDTO> Crear(UsuariosDTO modelo);
        Task<bool> Editar(UsuariosDTO modelo);
        Task<bool> Eliminar(int id);
    }
}
