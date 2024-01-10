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
    public class MarcaService : IMarcaService
    {
        private readonly IGenericRepository<Marca> _marcaRepositorio;
        private readonly IMapper _mapper;

        public MarcaService(IGenericRepository<Marca> marcaRepositorio, IMapper mapper)
        {
            _marcaRepositorio = marcaRepositorio;
            _mapper = mapper;
        }

        public async Task<List<MarcasDTO>> Lista()
        {
            try
            {
                var listaMarcas = await _marcaRepositorio.Consultar();
                return _mapper.Map<List<MarcasDTO>>(listaMarcas.ToList());
            }
            catch
            {
                throw;
            }
        }
    }
}
