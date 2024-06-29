using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDTO.ViewModel
{
    public class RptEstudianteFacultadVM
    {

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name ="Facultades")]
        public int FacultadId { get; set; }
    }
}
