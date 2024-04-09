using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CapaOperaciones
{
    public class CRUDService <T> where T : class
    {
        /// <summary>
        /// Conexion a la BD
        /// </summary>
        private DbContext db;
        public CRUDService(DbContext db)
        {
            this.db = db;
        }

        /// <summary>
        /// Funcion para listar todos los registros de una entidad
        /// </summary>
        /// <returns></returns>
        public List<T> GetAll()
        {
            return db.Set<T>().ToList();
        }

        public List<T> GetAll(Expression<Func<T, bool>> expression)
        {
            return db.Set<T>().Where(expression).ToList();
        }

        /// <summary>
        /// Funcion para crear una registro de una entidad
        /// </summary>
        /// <param name="entidad"></param>
        /// <returns></returns>
        public bool Crear(T entidad)
        {
            db.Entry(entidad).State = EntityState.Added;
            return db.SaveChanges() > 0;
        }

        /// <summary>
        /// Funcion para actualizar un registro de una entidad
        /// </summary>
        /// <param name="entidad"></param>
        public void Actualizar(T entidad)
        {
            db.Entry(entidad).State = EntityState.Modified;

            db.SaveChanges();

        }

        /// <summary>
        /// Funicon para eliminar un registro de una entidad
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Eliminar(int id)
        {
            var entidad = db.Set<T>().Find(id);

            db.Entry(entidad).State = EntityState.Deleted;

            return db.SaveChanges() > 0;
        }

        /// <summary>
        /// Funicon para eliminar un registro de una entidad
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T BuscarId(int id)
        {
            var entidad = db.Set<T>().Find(id);
            return entidad;
        }
    }
}
