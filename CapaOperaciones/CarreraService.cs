using CapaDato.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaOperaciones
{
    public class CarreraService : CRUDService<Carrera>
    {
        private ComputacionContext db;

        public CarreraService(ComputacionContext db) : base(db)
        {
            if (db == null)
                this.db = new ComputacionContext();
            else
                this.db = db;
        }

        #region Valiciones del CRUD

        /// <summary>
        /// Validaciones antes de crear un neuvo registro
        /// </summary>
        /// <param name="carrera"></param>
        /// <returns></returns>
        public string ValidarAntesCrear(Carrera carrera)
        {
            if (db.Carreras.Any(x => x.Codigo.Trim().ToLower() == carrera.Codigo.Trim().ToLower()))
                return "existe un codigo igual en las carreras";

            return string.Empty;
        }

        /// <summary>
        /// Validaciones antes de actualizar un registro
        /// </summary>
        /// <param name="carrera"></param>
        /// <returns></returns>
        public string ValidarAntesActualizar(Carrera carrera)
        {
            var carreraDb = db.Carreras.Find(carrera.Id);

            if (carreraDb == null)
                return "La carrera a modificar ya no existe en el sistema";

            if (carreraDb.Codigo == carrera.Codigo)
                return string.Empty;

            return ValidarAntesCrear(carrera);
        }

        /// <summary>
        /// Validaciones antes de elimar un registro
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string ValidarAntesEliminar(int id)
        {
            var carreraDb = db.Carreras.Find(id);

            if (carreraDb == null)
                return "La carrera a modificar ya no existe en el sistema";
            
            if (carreraDb.Estudiantes.Count > 0)
                return "El registro no se puede eliminar por que esta siendo usado por otras entidades";
           
            return string.Empty;
        }
        #endregion
    }
}
