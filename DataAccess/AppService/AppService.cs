using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using Utilities.Library.Const;
using UtilitiesLibrary.Helper;

namespace Utilities.Library.AppService
{
    /// <summary>
    /// Clase base de los servicios de aplicación
    /// </summary>
    public abstract class AppService : IAppService
    {
        #region Properties

        /// <summary>
        /// Contexto de datos
        /// </summary>
        public DbContext Context { get; private set; }

        /// <summary>
        /// Contexto Http
        /// </summary>
        public IHttpContextAccessor HttpAppContext { get; private set; }

        #endregion

        #region Builders

        /// <summary>
        /// Inicializa una nueva instancia de la clase
        /// </summary>
        /// <param name="context">Contexto de datos</param>
        /// <param name="logger">Regitrador de eventos</param>
        public AppService(DbContext context)
        {
            Context = context.NotNull(nameof(context));
            if (Globals.ServiceProvider != null)
                HttpAppContext = (Globals.ServiceProvider.GetService(typeof(IHttpContextAccessor)).NotNull() as IHttpContextAccessor);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Da manejo a un excepción
        /// </summary>
        /// <param name="ex">Excepción a manejar</param>
        protected virtual string HandleException<TResult>(Exception ex)
        {

            if (ex.GetType().Name == "UnauthorizedException")
            {
                if (HttpAppContext != null && HttpAppContext?.HttpContext != null && HttpAppContext?.HttpContext?.Request != null)
                {
                    HttpAppContext.HttpContext.Response.StatusCode = 401;
                    return null;
                }

                throw ex;
            }

            return ex.Message;
        }

        #endregion
    }
}
