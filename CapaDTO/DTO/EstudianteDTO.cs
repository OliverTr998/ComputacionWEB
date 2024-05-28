using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDTO.DTO
{
    public class EstudianteDTO
    {
        public int Id { get; set; }
        public string Carnet { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Edad { get; set; }
        public int CarreraId { get; set; }

        //Propiedades Extras
        public string DescripcionCarrera { get; set; }
        public List<DetalleEstudianteTelefonoDTO> DetalleEstudianteTelefonos { get; set; }
    }
}
