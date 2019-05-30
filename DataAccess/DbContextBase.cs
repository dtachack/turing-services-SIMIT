using Microsoft.EntityFrameworkCore;
using UtilitiesLibrary.Helper;
using UtilitiesLibrary.Models;

namespace UtilitiesLibrary
{
    /// <summary>
    /// Contexto base de acceso a datos
    /// </summary>
    public abstract class DbContextBase : DbContext
    {
        #region Properties

        /// <summary>
        /// Obtiene el objeto de configuración del contexto
        /// </summary>
        protected DbSettings DbSettings { get; private set; }

        #endregion

        #region Builders

        /// <summary>
        /// Inicializa una nueva instancia de la clase
        /// </summary>
        /// <param name="dbSettings">Objeto de configuración del contexto</param>
        public DbContextBase(DbSettings dbSettings) : base()
        {
            DbSettings = dbSettings.NotNull(nameof(dbSettings));
            DbSettings.ConnectionString = DbSettings.ConnectionString.NotNullOrEmpty(nameof(DbSettings.ConnectionString)).Trim();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Aqui se usar el proveedor de conexion que esté configurado
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                switch (DbSettings.Provider)
                {
                    case SupportedProvider.SqlServer:
                        optionsBuilder.UseSqlServer(DbSettings.ConnectionString);
                        break;
                    //case SupportedProvider.Oracle:
                    //    optionsBuilder.UseOracle(DbSettings.ConnectionString);
                    //    break;
                    default:
                        optionsBuilder.UseSqlServer(DbSettings.ConnectionString);
                        break;
                }
            }
        }

        #endregion
    }
}
