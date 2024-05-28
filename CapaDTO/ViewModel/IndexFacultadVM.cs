using CapaDato.Models;
using CapaDTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDTO.ViewModel
{
    public class IndexFacultadVM
    {
        public IndexFacultadVM()
        {
            FacultadM = new Facultad();
            Facultades = new List<FacultadDTO>();
        }
        public Facultad FacultadM { get; set; }
        public List<FacultadDTO> Facultades { get; set; }
    }
}
