using System;
using System.Collections.Generic;
using System.Text;

namespace UtilitiesLibrary.Exceptions
{
    /// <summary>
    /// Encapsula los datos de la excepción que ocurre
    /// cuando al validar un objeto, éste se encuentra NULO o VACÍO
    /// </summary>
    public class ValidateNotNullOrEmpty : Exception
    {
        #region Builders

        /// <summary>
        /// Inicializa una nueva instancia de la clase
        /// </summary>
        /// <param name="name">Nombre de la variable del objeto</param>
        /// <param name="typeName">Nombre del tipo validado</param>
        /// <param name="invokerName">Nombre del método invocador</param>
        /// <param name="lineNumber">linea donde ocurre la validación</param>
        public ValidateNotNullOrEmpty(string name, string typeName, string invokerName, int lineNumber) : base(Strings.ValidateNotNulOrEmptyException(name, typeName, invokerName, lineNumber)) { }

        #endregion
    }
}
