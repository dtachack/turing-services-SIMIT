using System;

namespace UtilitiesLibrary.Exceptions
{
    /// <summary>
    /// Encapsula la excepciones que ocurren cuando
    /// un repositorio aún no ha sido inicializado
    /// </summary>
    public class RepositoryNotInitialized : Exception
    {
        #region Properties

        /// <summary>
        /// Obtiene el nombre del repositorio
        /// que no se ha inicializado
        /// </summary>
        public string RepositoryName { get; }

        #endregion

        #region Builders

        /// <summary>
        /// Inicializa una nueva instancia de la clase
        /// </summary>
        /// <param name="repositoryName">Nombre del repositorio que no ha sido inicializado</param>
        public RepositoryNotInitialized(string repositoryName) : base(Strings.RepositoryNotInitialized(repositoryName))
        {
            RepositoryName = repositoryName;
        }

        #endregion
    }
}
