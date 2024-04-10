using CapaDato.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaOperaciones
{
    public class OperadoraTelefonoService : CRUDService<OperadoraTelefono>
    {
        private ComputacionContext db;

        public OperadoraTelefonoService(ComputacionContext db) : base(db)
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
        /// <param name="operadoraTelefono"></param>
        /// <returns></returns>
        public string ValidarAntesCrear(OperadoraTelefono operadoraTelefono)
        {
            if (db.OperadoraTelefonos.Any(x => x.Codigo.Trim().ToLower() == operadoraTelefono.Codigo.Trim().ToLower()))
                return "Ya existe un codigo igual en las Operadoras";

            return string.Empty;
        }

        /// <summary>
        /// Validaciones antes de actualizar un registro
        /// </summary>
        /// <param name="operadoraTelefono"></param>
        /// <returns></returns>
        public string ValidarAntesActualizar(OperadoraTelefono operadoraTelefono)
        {
            var operadoraDb = db.OperadoraTelefonos.Find(operadoraTelefono.Id);
            db.Entry(operadoraDb).State = EntityState.Detached;

            if (operadoraDb == null)
                return "La operadora a modificar ya no existe en el sistema";

            if (operadoraDb.Codigo == operadoraTelefono.Codigo)
                return string.Empty;

            return ValidarAntesCrear(operadoraTelefono);
        }

        /// <summary>
        /// Validaciones antes de elimar un registro
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string ValidarAntesEliminar(int id)
        {
            var operadoraDb = db.OperadoraTelefonos.Find(id);

            if (operadoraDb == null)
                return "La facultad a modificar ya no existe en el sistema";

            if (operadoraDb.DetalleEstudianteTelefonos.Count > 0)
                return "El registro no se puede eliminar por que esta siendo usado por otras entidades";

            return string.Empty;
        }
        #endregion
    }
}
