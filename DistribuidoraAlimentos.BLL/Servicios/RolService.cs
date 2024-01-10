using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using DistribuidoraAlimentos.BLL.Servicios.Contratos;
using DistribuidoraAlimentos.DAL.Repositorios.Contratos;
using DistribuidoraAlimentos.DTO;
using DistribuidoraAlimentos.Model;

namespace DistribuidoraAlimentos.BLL.Servicios
{
    public class RolService : IRolService
    {
        private readonly IGenericRepository<Roles> _rolesRepositorio;
        private readonly IMapper _mapper;

        public RolService(IGenericRepository<Roles> rolesRepositorio, IMapper mapper)
        {
            _rolesRepositorio = rolesRepositorio;
            _mapper = mapper;
        }

        public async Task<List<RolesDTO>> Lista()
        {
            try
            {
                var listaRoles = await _rolesRepositorio.Consultar();
                return _mapper.Map<List<RolesDTO>>(listaRoles.ToList());
            }
            catch
            {
                throw;
            }
        }
    }
}
