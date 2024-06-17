using CapaDato.Models;
using CapaDTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaOperaciones
{
    public class FacultadService : CRUDService<Facultad>
    {
        private ComputacionContext db;

        public FacultadService(ComputacionContext db) : base(db)
        {
            if (db == null)
                this.db = new ComputacionContext();
            else
                this.db = db;
        }

        public List<RptTotalTelefonoXFacultadDTO> RptTotalTelefonoXFacultad()
        {
            var facultad = db.Database.SqlQuery<RptTotalTelefonoXFacultadDTO>("[dbo].[RptTotalTelefonoXFacultad]").ToList();

            return facultad;
        }

        #region Valiciones del CRUD

        /// <summary>
        /// Validaciones antes de crear un neuvo registro
        /// </summary>
        /// <param name="facultad"></param>
        /// <returns></returns>
        public string ValidarAntesCrear(Facultad facultad)
        {
            if (db.Facultades.Any(x => x.Codigo.Trim().ToLower() == facultad.Codigo.Trim().ToLower()))
                return "Ya existe un codigo igual en las Facultades";

            return string.Empty;
        }

        /// <summary>
        /// Validaciones antes de actualizar un registro
        /// </summary>
        /// <param name="facultad"></param>
        /// <returns></returns>
        public string ValidarAntesActualizar(Facultad facultad)
        {
            var facultadDb = db.Facultades.Find(facultad.Id);
            db.Entry(facultadDb).State = System.Data.Entity.EntityState.Detached;

            if (facultadDb == null)
                return "La facultad a modificar ya no existe en el sistema";

            if (facultadDb.Codigo == facultad.Codigo)
                return string.Empty;

            return ValidarAntesCrear(facultad);
        }

        /// <summary>
        /// Validaciones antes de elimar un registro
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string ValidarAntesEliminar(int id)
        {
            var facultadDb = db.Facultades.Find(id);
            db.Entry(facultadDb).State = System.Data.Entity.EntityState.Detached;

            if (facultadDb == null)
                return "La facultad a modificar ya no existe en el sistema";

            if (facultadDb.Carreras.Count > 0)
                return "El registro no se puede eliminar por que esta siendo usado por otras entidades";

            return string.Empty;
        }
        #endregion
    }
}
