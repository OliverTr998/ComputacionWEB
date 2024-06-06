using CapaDato.Models;
using CapaDTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDTO.ViewModel
{
    public class IndexEstudianteVM
    {
        public IndexEstudianteVM()
        {
            EstudianteM = new Estudiante();
            OperadoraTelefonos = new List<OperadoraTelefonoDTO>();
            Carreras = new List<CarreraDTO>();
            Estudiantes = new List<EstudianteDTO>();
        }
        public Estudiante EstudianteM { get; set; }
        public List<OperadoraTelefonoDTO> OperadoraTelefonos { get; set; }
        public List<CarreraDTO> Carreras { get; set; }
        public List<EstudianteDTO> Estudiantes { get; set; }
    }

    public class FiltrosEstudianteVM
    {
        public string Carnet { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Carrera { get; set; }
    }
}
