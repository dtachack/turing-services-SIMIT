using ServicesSIMIT.Enums;

namespace ServicesSIMIT.Models
{
    /// <summary>
    /// Consulta comparendo.
    /// </summary>
    public class ConsultaComparendo
    {
        /// <summary>
        /// Gets or sets the tipo documento.
        /// </summary>
        /// <value>The tipo documento.</value>
        public TipoDocumento TipoDocumento { get; set; }

        /// <summary>
        /// Gets or sets the no documento.
        /// </summary>
        /// <value>The no documento.</value>
        public string NoDocumento { get; set; }

        /// <summary>
        /// Gets or sets the numero placa.
        /// </summary>
        /// <value>The numero placa.</value>
        public string NumeroPlaca { get; set; }

        /// <summary>
        /// Gets or sets the numero comparendo.
        /// </summary>
        /// <value>The numero comparendo.</value>
        public string NumeroComparendo { get; set; }

    }
}
