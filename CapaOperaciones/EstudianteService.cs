using CapaDato.Models;
using CapaOperaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaOperaciones
{
    public class EstudianteService : CRUDService<Estudiante>
    {
        private ComputacionContext db;

        public EstudianteService(ComputacionContext db) : base(db)
        {
            if (db == null)
                this.db = new ComputacionContext();
            else
                this.db = db;
        }

        //public List<Estudiante> GetAll()
        //{
        //    return db.Estudiantes.ToList();
        //}

        //public bool Crear(Estudiante estudiante)
        //{
        //    db.Entry(estudiante).State = System.Data.Entity.EntityState.Added;
        //    //db.Estudiantes.Add(estudiante);
        //    return db.SaveChanges() > 0;
        //}

        //public bool Eliminar(int id)
        //{
        //    var estudiantedb = db.Estudiantes.Find(id);

        //    db.Entry(estudiantedb).State = System.Data.Entity.EntityState.Deleted;

        //    return db.SaveChanges() > 0;
        //}

        //public void Actualizar(Estudiante estudiante)
        //{
        //    db.Entry(estudiante).State = System.Data.Entity.EntityState.Modified;

        //    db.SaveChanges();
        //}

        /// <summary>
        /// Validaciones antes de crear un nuevo registro
        /// </summary>
        /// <param name="estudiante"></param>
        /// <returns></returns>
        public string ValidarAntesCrear(Estudiante estudiante)
        {
            if(db.Estudiantes.Any(x=> x.Carnet == estudiante.Carnet))
                return "Ya existe un estudiante con el mismo carnet, Verifique y Vuelva a intentar";
            
            return string.Empty;
        }

        /// <summary>
        /// Validaciones antes de actualizar un registro
        /// </summary>
        /// <param name="estudiante"></param>
        /// <returns></returns>
        public string ValidarAntesActualizar(Estudiante estudiante)
        {
            var estudianteDb = db.Estudiantes.Find(estudiante.Id);

            if(estudianteDb == null)
                return "El estudiante a modificar ya no existe en el sistema";
            
            if (estudiante.Carnet == estudianteDb.Carnet)
                return string.Empty;

            return ValidarAntesCrear(estudiante);
        }

        /// <summary>
        /// Validacion antes de eliminar un registro
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string ValidarAntesEliminar(int id)
        {
            var estudianteDb = db.Estudiantes.Find(id);

            if (estudianteDb == null)
                return "El estudiante a modificar ya no existe en el sistema";
            
            if(estudianteDb.DetalleEstudianteTelefonos.Count > 0)
                return "El registro no se puede eliminar por que esta siendo usado por otras entidades";

            return string.Empty;
        }
    }
}
