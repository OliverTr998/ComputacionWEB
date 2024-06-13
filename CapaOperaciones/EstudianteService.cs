using CapaDato.Models;
using CapaDTO.DTO;
using CapaDTO.ViewModel;
using CapaOperaciones;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        public List<EstudianteDTO> GetEstudiantes()
        {
            var query = db.Estudiantes.Select(x => new EstudianteDTO
            {
                Id = x.Id,
                Carnet = x.Carnet,
                Nombre = x.Nombre,
                Apellido = x.Apellido,
                Edad = x.Edad,
                CarreraId = x.CarreraId,

                //propiedad extra
                DescripcionCarrera = x.Carrera.Descripcion,
                DetalleEstudianteTelefonos = x.DetalleEstudianteTelefonos.Select(z => new DetalleEstudianteTelefonoDTO
                {
                    Id = z.Id,
                    Numero = z.Numero,
                    EstudianteId = z.EstudianteId,
                    OperadoraTelefonoId = z.OperadoraTelefonoId,
                    DescripcionOperadora = z.OperadoraTelefono.Descripcion
                }).ToList()

            }).ToList();

            return query;
        }

        public List<EstudianteDTO> GetEstudiantesFilter(FiltrosEstudianteVM viewModel)
        {
            var paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@Carnet", string.IsNullOrEmpty(viewModel.Carnet) ? DBNull.Value : (object)viewModel.Carnet));
            paramList.Add(new SqlParameter("@Nombre", string.IsNullOrEmpty(viewModel.Nombre) ? DBNull.Value : (object)viewModel.Nombre));
            paramList.Add(new SqlParameter("@Apellido", string.IsNullOrEmpty(viewModel.Apellido) ? DBNull.Value : (object)viewModel.Apellido));
            paramList.Add(new SqlParameter("@Carrera", string.IsNullOrEmpty(viewModel.Carrera) ? DBNull.Value : (object)viewModel.Carrera));

            var paremsName = string.Join(",", paramList.Select(x => x.ParameterName));

            var estudiantes = db.Database.SqlQuery<EstudianteDTO>("[dbo].[GetEstudiantesFilter] " + paremsName, paramList.ToArray()).ToList();

            return estudiantes;
        }

        public List<RptGrEstudiantesXCarreraDTO> RptGrEstudiantesXCarrera()
        {
            var estudiantes = db.Database.SqlQuery<RptGrEstudiantesXCarreraDTO>("[dbo].[RptGrEstudiantesXCarrera]").ToList();

            return estudiantes;
        }

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
