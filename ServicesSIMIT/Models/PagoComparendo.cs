using ServicesSIMIT.Enums;
using System;

namespace ServicesSIMIT.Models
{
    /// <summary>
    /// Pago comparendo.
    /// </summary>
    public class PagoComparendo
    {
        /// <summary>
        /// Gets or sets the numerocomparendo.
        /// </summary>
        /// <value>The numerocomparendo.</value>
        public string Numerocomparendo { get; set; }

        /// <summary>
        /// Gets or sets the banco.
        /// </summary>
        /// <value>The banco.</value>
        public Banco Banco { get; set; }

        /// <summary>
        /// Gets or sets the persona.
        /// </summary>
        /// <value>The persona.</value>
        public Persona Persona { get; set; }

        /// <summary>
        /// Gets or sets the valor.
        /// </summary>
        /// <value>The valor.</value>
        public decimal Valor { get; set; }

        /// <summary>
        /// Gets or sets the estado.
        /// </summary>
        /// <value>The estado.</value>
        public PaymentState Estado { get; set; }

        /// <summary>
        /// Gets or sets the descripcion.
        /// </summary>
        /// <value>The descripcion.</value>
        public string Descripcion { get; set; }

        /// <summary>
        /// Gets or sets the cus.
        /// </summary>
        /// <value>The cus.</value>
        public int Cus { get; set; }

        /// <summary>
        /// Gets or sets the fecha pago.
        /// </summary>
        /// <value>The fecha pago.</value>
        public DateTime FechaPago { get; set; }

        /// <summary>
        /// Gets or sets the payment identifier.
        /// </summary>
        /// <value>The payment identifier.</value>
        public string IdPago { get; set; }
    }
}
