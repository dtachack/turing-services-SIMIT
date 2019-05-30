using System;

namespace Utilities.Library.Exceptions
{
    /// <summary>
    /// Encapsula los datos de la excepción que ocurre
    /// cuando al validar un objeto, éste se encuentra NULO
    /// </summary>
    public class ValidateNotNullExceptionMessage : Exception
    {
        #region Builders

        /// <summary>
        /// Inicializa una nueva instancia de la clase
        /// </summary>
        public ValidateNotNullExceptionMessage(string message) : base(message) { }

        #endregion

    }
}
