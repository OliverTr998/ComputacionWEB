//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CapaDato.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DetalleEstudianteTelefono
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public int EstudianteId { get; set; }
        public int OperadoraTelefonoId { get; set; }
    
        public virtual Estudiante Estudiante { get; set; }
        public virtual OperadoraTelefono OperadoraTelefono { get; set; }
    }
}