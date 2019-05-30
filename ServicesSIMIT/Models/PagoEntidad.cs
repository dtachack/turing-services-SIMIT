using System;

namespace ServicesSIMIT.Models
{
    /// <summary>
    /// Pago entidad.
    /// </summary>
    public class PagoEntidad
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the estado.
        /// </summary>
        /// <value>The estado.</value>
        public string Estado { get; set; }

        /// <summary>
        /// Gets or sets the cus.
        /// </summary>
        /// <value>The cus.</value>
        public string CUS { get; set; }

        /// <summary>
        /// Gets or sets the banco.
        /// </summary>
        /// <value>The banco.</value>
        public string Banco { get; set; }

        /// <summary>
        /// Gets or sets the descripcion.
        /// </summary>
        /// <value>The descripcion.</value>
        public string Descripcion { get; set; }

        /// <summary>
        /// Gets or sets the valor.
        /// </summary>
        /// <value>The valor.</value>
        public double Valor { get; set; }

        /// <summary>
        /// Gets or sets the fecha.
        /// </summary>
        /// <value>The fecha.</value>
        public DateTime Fecha { get; set; }
    }
}
