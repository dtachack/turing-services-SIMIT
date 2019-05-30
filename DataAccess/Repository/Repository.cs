using Microsoft.EntityFrameworkCore;
using UtilitiesLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace UtilitiesLibrary.Repository
{
    /// <summary>
    /// Implementación de un repositorio genérico
    /// </summary>
    /// <typeparam name="TEntity">Tipo de la entidad de negocio</typeparam>
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        #region Properties

        /// <summary>
        /// Obtiene el contexto de datos
        /// </summary>
        public DbContext Context { get;  set; }
        /// <summary>
        /// Obtiene la entidad que da acceso al contexto
        /// </summary>
        public DbSet<TEntity> Entity { get;  set; }

        DbSet<TEntity> IRepository<TEntity>.Entity => throw new NotImplementedException();
        #endregion

        #region Builders

        /// <summary>
        /// Inicializa una nueva instancia de la clase
        /// </summary>
        public Repository() { }

        #endregion

        #region Implements

        /// <summary>
        /// Inicializa el repositorio con el contexto
        /// </summary>
        /// <param name="context">Contexto al que pertenece el repositorio</param>
        public void Initialize(DbContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
            Entity = Context.Set<TEntity>();
        }

        /// <summary>
        /// Inserta una nueva entidad en el repositorio de datos
        /// </summary>
        /// <param name="entity">Entidad a insertar</param>
        /// <returns>Entidad insertada</returns>
        public TEntity Insert(TEntity entity)
        {
            EnsureInitialized();
            var resEntity = Entity.Add(entity);
            return resEntity.Entity;
        }

        /// <summary>
        /// Actualiza una entidad en el repositorio de datos
        /// </summary>
        /// <param name="entity">Entidad a actualizar</param>
        /// <returns>Entidad actualizada</returns>
        public TEntity Update(TEntity entity)
        {
            EnsureInitialized();
            var resEntity = Entity.Update(entity);
            return resEntity.Entity;
        }

        /// <summary>
        /// Elimina una entidad en el repositorio de datos
        /// </summary>
        /// <param name="entity">Entidad a eliminar</param>
        /// <returns>Entidad eliminada</returns>
        public TEntity Delete(TEntity entity)
        {
            EnsureInitialized();
            var resEntity = Entity.Remove(entity);
            return resEntity.Entity;
        }

        /// <summary>
        /// Lista las entidades que cumplen con la expresión
        /// </summary>
        /// <param name="expression">Expresión de búsqueda</param>
        /// <returns>Enumeración de entidades resultado</returns>
        public ICollection<TEntity> List(Expression<Func<TEntity, bool>> expression = null)
        {
            EnsureInitialized();
            if (expression == null)
                return Entity.ToList();

            return Entity.Where(expression).ToList();
        }

        /// <summary>
        /// Lista las entidades que cumplen con la expresión incluyendo sus agregados
        /// </summary>
        /// <param name="expression">Expresión de búsqueda</param>
        /// <returns>Enumeración de entidades resultado</returns>
        /// <param name="properties">Rutas a las propiedades a incluir como agregados</param>
        public ICollection<TEntity> ListInclude(Expression<Func<TEntity, bool>> expression, params string[] properties)
        {
            EnsureInitialized();
            if (properties.Length > 0)
            {
                var query = Entity.Include(properties[0]);
                if (properties.Length > 1)
                    for (int i = 1; i < properties.Length; i++)
                        query = query.Include(properties[i]);

                return query.Where(expression).ToList();
            }
            return Entity.Where(expression).ToList();
        }

        /// <summary>
        /// Inserta una nueva entidad en el repositorio de datos de forma asíncrona
        /// </summary>
        /// <param name="entity">Entidad a insertar</param>
        /// <returns>Entidad insertada</returns>
        public Task<TEntity> InsertAsync(TEntity entity) => Task.Factory.StartNew(() => Insert(entity));

        /// <summary>
        /// Actualiza una entidad en el repositorio de datos de forma asíncrona
        /// </summary>
        /// <param name="entity">Entidad a actualizar</param>
        /// <returns>Entidad actualizada</returns>
        public Task<TEntity> UpdateAsync(TEntity entity) => Task.Factory.StartNew(() => Update(entity));

        /// <summary>
        /// Elimina una entidad en el repositorio de datos de forma asíncrona
        /// </summary>
        /// <param name="entity">Entidad a eliminar</param>
        /// <returns>Entidad eliminada</returns>
        public Task<TEntity> DeleteAsync(TEntity entity) => Task.Factory.StartNew(() => Delete(entity));

        /// <summary>
        /// Lista las entidades que cumplen con la expresión de forma asíncrona
        /// </summary>
        /// <param name="expression">Expresión de búsqueda</param>
        /// <returns>Enumeración de entidades resultado</returns>
        public async Task<ICollection<TEntity>> ListAsync(Expression<Func<TEntity, bool>> expression)
        {
            EnsureInitialized();
            if (expression == null)
                return await Entity.ToListAsync();

            return await Entity.Where(expression).ToListAsync();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Asegura que el repositorio haya sido
        /// inicializado
        /// </summary>
        private void EnsureInitialized()
        {
            if (Context == null) throw new RepositoryNotInitialized(GetType().Name);
        }

        /// <summary>
        /// Destruye la instancia de la clase
        /// </summary>
        public void Dispose()
        {
            Context?.Dispose();
        }


        Task<TEntity> IRepository<TEntity>.InsertAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        Task<TEntity> IRepository<TEntity>.UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        Task<TEntity> IRepository<TEntity>.DeleteAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
