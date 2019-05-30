using ServicesSIMIT.Enums;

namespace ServicesSIMIT.Models
{
    /// <summary>
    /// Persona.
    /// </summary>
    public class Persona
    {
        /// <summary>
        /// Gets or sets the numero documento.
        /// </summary>
        /// <value>The numero documento.</value>
        public string NumeroDocumento { get; set; }

        /// <summary>
        /// Gets or sets the nombrey apellidos.
        /// </summary>
        /// <value>The nombrey apellidos.</value>
        public string NombreyApellidos { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the tipo documento.
        /// </summary>
        /// <value>The tipo documento.</value>
        public TipoDocumento TipoDocumento { get; set; }

        /// <summary>
        /// Gets or sets the tipo persona.
        /// </summary>
        /// <value>The tipo persona.</value>
        public TipoPersona TipoPersona { get; set; }
    }
}
