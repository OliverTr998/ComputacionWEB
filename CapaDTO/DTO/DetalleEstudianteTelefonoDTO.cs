using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDTO.DTO
{
    public class DetalleEstudianteTelefonoDTO
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public int EstudianteId { get; set; }
        public int OperadoraTelefonoId { get; set; }

        //propiedades extras 
        public string DescripcionOperadora { get; set; }
    }
}
