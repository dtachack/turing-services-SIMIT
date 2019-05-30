using UtilitiesLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace UtilitiesLibrary.Helper
{
    /// <summary>
    /// Provee métodos extendidos para distintos tipos
    /// a nivel de la solución
    /// </summary>
    public static class Extensions
    {
        #region Validators

        /// <summary>
        /// Valida que el objeto de tipo <typeparamref name="T"/> 
        /// no se encuentre nulo, de lo contrario lanza una excepción
        /// </summary>
        /// <typeparam name="T">Tipo del objeto a validar</typeparam>
        /// <param name="obj">Objeto que extiende el método</param>
        /// <param name="name">Nombre de la variable del objeto</param>
        /// <returns>El objeto validado</returns>
        public static T NotNull<T>(this T obj, string name = "", [CallerMemberName] string invokerName = "", [CallerLineNumber] int lineNumber = 0)
        {
            if (obj == null) throw new ValidateNotNullException(name, typeof(T).Name, invokerName, lineNumber);

            return obj;
        }

        /// <summary>
        /// Valida que el objeto no se encuentre nulo o vacío, de lo contrario
        /// lanza una excepción
        /// </summary>
        /// <param name="obj">Objeto que extiende el método</param>
        /// <param name="name">Nombre de la variable del objeto</param>
        /// <returns>El objeto validado</returns>
        public static string NotNullOrEmpty(this string obj, string name = "", [CallerMemberName] string invokerName = "", [CallerLineNumber] int lineNumber = 0)
        {
            if (obj == null) throw new ValidateNotNullOrEmpty(name, typeof(string).Name, invokerName, lineNumber);
            if (obj.Trim() == string.Empty) throw new ValidateNotNullOrEmpty(name, typeof(string).Name, invokerName, lineNumber);

            return obj;
        }

        #endregion
    }
}
