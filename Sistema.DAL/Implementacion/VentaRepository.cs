using Sistema.DAL.DBContext;
using Sistema.DAL.Interfaces;
using Sistema.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.DAL.Implementacion
{
    public class VentaRepository : GenericRepository<Venta>, IVentaRepository
    {

        protected readonly DbventaContext _context;

        public VentaRepository(DbventaContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Venta> Registrar(Venta entidad)
        {
            Venta VentaGenerada = new Venta();

            using (var Transaction = _context.Database.BeginTransaction() ) {
                try
                {

                    foreach (DetalleVenta detalleVenta in entidad.DetalleVenta)
                    {
                        Producto producto_encontrado = _context.Productos.Where(p => p.IdProducto == detalleVenta.IdProducto).First(); // similar al FirstOrDefault 
                        producto_encontrado.Stock = producto_encontrado.Stock - detalleVenta.Cantidad;
                        _context.Productos.Update(producto_encontrado);
                        
                    }
                    await _context.SaveChangesAsync();

                    NumeroCorrelativo correlativo = _context.NumeroCorrelativos.Where(n => n.Gestion == "venta").First();

                    correlativo.UltimoNumero++;
                    correlativo.FechaActualizacion = DateTime.Now;

                    _context.NumeroCorrelativos.Update(correlativo);
                    await _context.SaveChangesAsync();

                    string ceros = string.Concat(Enumerable.Repeat("0",correlativo.CantidadDigitos!.Value));
                    string numeroVenta = ceros + correlativo.UltimoNumero.ToString();
                    numeroVenta = numeroVenta.Substring(numeroVenta.Length - correlativo.CantidadDigitos.Value, correlativo.CantidadDigitos.Value);

                    entidad.NumeroVenta = numeroVenta;

                    await _context.Venta.AddAsync(entidad);
                    await _context.SaveChangesAsync();

                    VentaGenerada = entidad;

                    Transaction.Commit();
                    return VentaGenerada;
                }
                catch
                {
                    Transaction.Rollback();   
                    throw;
                }
                
            }

        }

        public Task<List<Venta>> Reporte(DateTime FechaInicio, DateTime FechaFin)
        {
            throw new NotImplementedException();
        }
    }
}
