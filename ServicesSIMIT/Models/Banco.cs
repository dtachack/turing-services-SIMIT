namespace ServicesSIMIT.Models
{
    /// <summary>
    /// Banco.
    /// </summary>
    public class Banco
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the nombre.
        /// </summary>
        /// <value>The nombre.</value>
        public string Nombre { get; set; }
    }

    /// <summary>
    /// Registro banco.
    /// </summary>
    public class RegistroBanco
    {
        /// <summary>
        /// Gets or sets the nombre.
        /// </summary>
        /// <value>The nombre.</value>
        public string Nombre { get; set; }
    }
}
