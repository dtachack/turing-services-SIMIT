namespace UtilitiesLibrary.Models
{
    /// <summary>
    /// Encapsula las propiedades de configuración de una
    /// conexión a una base de datos Sql
    /// </summary>
    public sealed class DbSettings
    {
        #region Properties

        /// <summary>
        /// Obtiene o asigna la cadena de conexión a la base de datos Sql
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Obtiene o asigna el tipo de proveedor Sql
        /// </summary>
        public SupportedProvider Provider { get; set; }

        public SupportedAction SupportedAction { get; set; }

        #endregion
    }

    /// <summary>
    /// Tipo de provedores Sql soportados
    /// </summary>
    public enum SupportedProvider
    {
        /// <summary>
        /// Motor de bases de datos Microsoft Sql Server
        /// </summary>
        SqlServer,
        /// <summary>
        /// Motor de bases de datos Oracle Sql
        /// </summary>
        Oracle
    }

    public enum SupportedAction
    {
        Read,

        Write
    }
}
