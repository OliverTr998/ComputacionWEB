﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDTO.DTO
{
    public class RptGrEstudiantesXCarreraDTO
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string AnioOfertada { get; set; }
        public string Descripcion { get; set; }
        public int TotalEstudiante { get; set; }
    }
}
