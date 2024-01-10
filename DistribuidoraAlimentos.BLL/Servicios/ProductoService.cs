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
using Microsoft.EntityFrameworkCore;

namespace DistribuidoraAlimentos.BLL.Servicios
{
    public class ProductoService : IProductoService
    {
        private readonly IGenericRepository<Productos> _productosRepositorio;
        private readonly IMapper _mapper;

        public ProductoService(IGenericRepository<Productos> productosRepositorio, IMapper mapper)
        {
            _productosRepositorio = productosRepositorio;
            _mapper = mapper;
        }
        
        public async Task<List<ProductosDTO>> Lista()
        {
            try
            {
                var queryProducto = await _productosRepositorio.Consultar();

                var listaProducto = queryProducto
                    .Include(prod => prod.IdCategoriaNavigation)
                    .Include(prod => prod.IdMarcaNavigation)
                    .ToList();

                return _mapper.Map<List<ProductosDTO>>(listaProducto.ToList());
            }
            catch
            {
                throw;
            }
        }

        public async Task<ProductosDTO> Crear(ProductosDTO modelo)
        {
            try
            {
                var productoCreado = await _productosRepositorio.Crear(_mapper.Map<Productos>(modelo));

                if (productoCreado.Id == 0)
                    throw new TaskCanceledException("No se puede crear");

                var query = await _productosRepositorio.Consultar(u => u.Id == productoCreado.Id);

                productoCreado = query.Include(Categoria => Categoria.IdCategoriaNavigation).First();
                productoCreado = query.Include(Marcas => Marcas.IdMarcaNavigation).First();

                return _mapper.Map<ProductosDTO>(productoCreado);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(ProductosDTO modelo)
        {
            try
            {
                var productoModelo = _mapper.Map<Productos>(modelo);
                var productoEncontrado = await _productosRepositorio.Obtener(u =>
                  u.Id == productoModelo.Id
                );

                if (productoEncontrado == null)
                    throw new TaskCanceledException("El producto no existe");

                productoEncontrado.Nombre = productoModelo.Nombre;
                productoEncontrado.IdMarca = productoModelo.IdMarca;
                productoEncontrado.IdCategoria = productoModelo.IdCategoria;
                productoEncontrado.Descripcion = productoModelo.Descripcion;
                productoEncontrado.Stock = productoModelo.Stock;
                productoEncontrado.Costo = productoModelo.Costo;

                bool respuesta = await _productosRepositorio.Editar(productoEncontrado);

                if (!respuesta)
                    throw new TaskCanceledException("No se pudo editar");

                return respuesta;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                var productoEncontrado = await _productosRepositorio.Obtener(p => p.Id == id);

                if (productoEncontrado == null)
                    throw new TaskCanceledException("El producto no existe");

                bool respuesta = await _productosRepositorio.Eliminar(productoEncontrado);

                if (!respuesta)
                    throw new TaskCanceledException("No se pudo eliminar");

                return respuesta;
            }
            catch
            {
                throw;
            }
        }
    }
}
