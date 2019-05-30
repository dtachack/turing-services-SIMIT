using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtilitiesLibrary.Models;

namespace ServicesSIMIT.DataAccess
{
    /// <summary>
    /// Set context data base.
    /// </summary>
    public static class SetContextDataBase
    {
        /// <summary>
        /// Sets the context.
        /// </summary>
        /// <returns>The context.</returns>
        /// <param name="dbSettings">Db settings.</param>
        /// <param name="supportedAction">Supported action.</param>
        public static SimitContext SetContext(List<DbSettings> dbSettings, SupportedAction supportedAction)
        => new SimitContext(dbSettings.Where(x => x.SupportedAction == supportedAction).FirstOrDefault());
        
    }
}
