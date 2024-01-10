using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DistribuidoraAlimentos.DAL.DBContext;
using DistribuidoraAlimentos.DAL.Repositorios.Contratos;
using DistribuidoraAlimentos.Model;
using Microsoft.EntityFrameworkCore;

namespace DistribuidoraAlimentos.DAL.Repositorios
{
    public class VentaRepository : GenericRepository<Venta>, IVentaRepository
    {
        private readonly DistribuidoraAlimentosContext _dbContext;

        public VentaRepository(DistribuidoraAlimentosContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Venta> Registrar(Venta modelo)
        {
            Venta ventaGenerada = new Venta();

            using (var trasaction = _dbContext.Database.BeginTransaction())
            {
                try
                {

                    foreach (DetalleVenta dv in modelo.DetalleVenta)
                    {

                        Productos producto_encontrado = _dbContext.Productos.Where(p => p.Id == dv.IdProducto).First();

                        producto_encontrado.Stock = producto_encontrado.Stock - dv.Cantidad;
                        _dbContext.Productos.Update(producto_encontrado);
                    }
                    await _dbContext.SaveChangesAsync();

                    NumeroDocumento correlativo = _dbContext.NumeroDocumentos.First();

                    correlativo.UltimoNumero = correlativo.UltimoNumero + 1;
                    correlativo.FechaRegistro = DateTime.Now;

                    _dbContext.NumeroDocumentos.Update(correlativo);
                    await _dbContext.SaveChangesAsync();

                    int CantidadDigitos = 4;
                    string ceros = string.Concat(Enumerable.Repeat("0", CantidadDigitos));
                    string numeroVenta = ceros + correlativo.UltimoNumero.ToString();
                    //00001
                    numeroVenta = numeroVenta.Substring(numeroVenta.Length - CantidadDigitos, CantidadDigitos);

                    modelo.NumeroDocumento = numeroVenta;

                    await _dbContext.Venta.AddAsync(modelo);
                    await _dbContext.SaveChangesAsync();

                    ventaGenerada = modelo;

                    trasaction.Commit();

                }
                catch (DbUpdateException ex)
                {
                    // Manejo específico de excepciones relacionadas con la base de datos
                    trasaction.Rollback();
                    Console.WriteLine("Error de base de datos:", ex.Message);
                    throw;
                }

                return ventaGenerada;

            }
        }
    }
}
