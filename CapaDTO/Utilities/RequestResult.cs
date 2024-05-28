using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDTO.Utilities
{
    public class RequestResult
    {
        /// <summary>
        /// Bandera: Resultado de éxito de la petición.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Mensaje a mostrar como resultado de la petición.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Registro, opcional y útil cuando un método de acción retorna un registro único al cliente.
        /// </summary>
        public object Record { get; set; }

        /// <summary>
        /// Crea una nueva instancia de RequestResult con los párametros especificados.
        /// </summary>
        /// <param name="message">Mensaje a mostrar como resultado de la petición.</param>
        /// <param name="success">Resultado de la petición.</param>
        public RequestResult(string message, bool success = true)
        {
            Success = success;
            Message = message;
        }

        /// <summary>
        /// Crea una nueva instancia de RequestResult con los párametros especificados.
        /// </summary>
        /// <param name="message">Mensaje a mostrar como resultado de la petición.</param>
        /// <param name="success">Resultado de la petición.</param>
        public RequestResult(object record, string message = "", bool success = true)
        {
            Success = success;
            Record = record;
            Message = message;
        }

        /// <summary>
        /// retorna  Success = true si todo fue exito
        /// </summary>
        public RequestResult()
        {
            Success = true;
        }

        /// <summary>
        /// retorna success como verdadero y mensaje vacio si solo se pasa el objeto
        /// </summary>
        /// <param name="record"></param>
        public RequestResult(object record)
        {
            Record = record;
            Success = true;
            Message = "";
        }
    }
}
