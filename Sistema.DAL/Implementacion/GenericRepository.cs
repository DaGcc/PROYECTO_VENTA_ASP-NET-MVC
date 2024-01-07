using Microsoft.EntityFrameworkCore;
using Sistema.DAL.DBContext;
using Sistema.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.DAL.Implementacion
{
    internal class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {

        protected readonly DbventaContext _context;

        public GenericRepository(DbventaContext Context)
        {
           _context = Context;
        }


        public async Task<TEntity?> Obtener(Expression<Func<TEntity, bool>> filtro)
        {

            try
            {
                TEntity? entidad = await _context.Set<TEntity>().FirstOrDefaultAsync(filtro);
                return entidad;
            }
            catch
            {
                throw;
            }

        }

        public async Task<TEntity> Crear(TEntity entidad)
        {
            try
            {
               await _context.Set<TEntity>().AddAsync(entidad);
               await _context.SaveChangesAsync();
               return entidad;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(TEntity entidad)
        {
            try
            {
                _context.Set<TEntity>().Update(entidad);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(TEntity entidad)
        {
            try
            {
                _context.Set<TEntity>().Remove(entidad);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }



        public async Task<IQueryable<TEntity>> Consultar(Expression<Func<TEntity, bool>> filtro)
        {
           
            IQueryable<TEntity> QueryEntidad = filtro is null ?  _context.Set<TEntity>() : _context.Set<TEntity>().Where( filtro );
            return QueryEntidad;    
        }


    }
}
