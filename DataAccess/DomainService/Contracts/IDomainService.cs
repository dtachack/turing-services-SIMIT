﻿using Microsoft.EntityFrameworkCore;
using System;

namespace Utilities.Library.DomainService
{
    /// <summary>
    /// Define los atributos y métodos de un servicio de dominio
    /// </summary>
    public interface IDomainService : IDisposable
    {
        /// <summary>
        /// Asigna el contexto de datos a todos los repositorios del servicio
        /// </summary>
        /// <param name="context">Contexto de datos</param>
        void SetContext(DbContext context);
    }
}
