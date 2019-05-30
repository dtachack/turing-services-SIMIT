using System;

namespace Utilities.Library.Const
{
    /// <summary>
    /// Provee acceso a las constantes globales del sistema
    /// </summary>
    public static class Globals
    {
        #region Cache

        /// <summary>
        /// Obtiene el proveedor de servicio global
        /// </summary>
        public static IServiceProvider ServiceProvider { get; set; }

        #endregion
    }
}
