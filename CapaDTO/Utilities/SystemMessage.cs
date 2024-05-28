using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDTO.Utilities
{
    public static class SystemMessage
    {
        /// <summary>
        /// Retorna un string con el valor: "¡Se ha creado con éxito el registro!".
        /// </summary>
        public static string CreateSuccessful
        {
            get
            {
                return "¡Se ha creado con éxito el registro!";
            }
        }

        /// <summary>
        /// Retorna un string con el valor: "¡Se ha actualizado con éxito el registro!".
        /// </summary>
        public static string UpdateSuccessful
        {
            get
            {
                return "¡Se ha actualizado con éxito el registro!";
            }
        }

        /// <summary>
        /// Retorna un string con el valor: "¡Se ha eliminado con éxito el registro!".
        /// </summary>
        public static string DeleteSuccessfull
        {
            get
            {
                return "¡Se ha eliminado con éxito el registro!";
            }
        }

        /// <summary>
        /// Retorna un string con el valor: "¡Se ha procesado con éxito la operación!".
        /// </summary>
        public static string OperationSuccessfull
        {
            get
            {
                return "¡Se ha procesado con éxito la operación!";
            }
        }

        /// <summary>
        /// Retorna un string con el valor "No se ha encontrado un recurso con la URL especificada.".
        /// </summary>
        public static string HttpNotFound
        {
            get { return "No se ha encontrado un recurso con la URL especificada."; }
        }

        /// <summary>
        /// Retorna un string con el valor: "¡No se ha encontrado ningún registro!".
        /// </summary>
        public static string RecordNotFound
        {
            get
            {
                return "¡No se ha encontrado ningún registro!";
            }
        }

        /// <summary>
        /// Retorna un string con el valor:  "No se ha enviado el parámetro obligatorio".
        /// </summary>
        public static string RequeriedParameterMissing
        {
            get
            {
                return "No se ha enviado el parámetro obligatorio";
            }
        }

        /// <summary>
        /// Retorna un string con el valor: "¡Ha ocurrido un error de validación procesando la operación!"
        /// </summary>
        public static string ValidateOperationError
        {
            get
            {
                return "¡Ha ocurrido un error de validación procesando la operación!"; ;
            }
        }

        /// <summary>
        /// Retorna un string con el valor: "¡Ha ocurrido un error validando la Propiedad!".
        /// </summary>
        public static string ValidatePropertyError
        {
            get
            {
                return "¡Ha ocurrido un error validando la Propiedad!";
            }
        }

        /// <summary>
        /// Retorna un string con el valor: "¡Se ha agregado con éxito la opción de menú a tus favoritas!".
        /// </summary>
        public static string AddedToFavoriteSuccessfull
        {
            get
            {
                return "¡Se ha agregado con éxito la opción de menú a tus favoritas!";
            }
        }

        /// <summary>
        /// Retorna un string con el valor: "¡Se ha removido la opción de menú de tus favoritas!".
        /// </summary>
        public static string RemovedFavoriteSuccessful
        {
            get
            {
                return "¡Se ha removido la opción de menú de tus favoritas!";
            }
        }

        /// <summary>
        /// Retorna un string con el valor: "Ha ocurrido un error procesando su petición, intente nuevamente y de persistir el problema contacte con el administrador del sistema.".
        /// </summary>
        public static string ServerError { get { return "Ha ocurrido un error procesando su petición, intente nuevamente y de persistir el problema contacte con el administrador del sistema."; } }

    }
}
