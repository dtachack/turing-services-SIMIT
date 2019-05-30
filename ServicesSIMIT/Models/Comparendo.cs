using ServicesSIMIT.Enums;
using System;

namespace ServicesSIMIT.Models
{
   /// <summary>
   /// Comparendo.
   /// </summary>
    public class Comparendo
    {
        /// <summary>
        /// Gets or sets the numero comparendo.
        /// </summary>
        /// <value>The numero comparendo.</value>
        public string NumeroComparendo { get; set; }

       /// <summary>
       /// Gets or sets the fecha imposicion.
       /// </summary>
       /// <value>The fecha imposicion.</value>
        public DateTime FechaImposicion { get; set; }

        /// <summary>
        /// Gets or sets the codigo barras.
        /// </summary>
        /// <value>The codigo barras.</value>
        public string CodigoBarras { get; set; }

        /// <summary>
        /// Gets or sets the estado.
        /// </summary>
        /// <value>The estado.</value>
        public SubpoenaState Estado { get; set; }

        /// <summary>
        /// Gets or sets the foto.
        /// </summary>
        /// <value>The foto.</value>
        public string Foto { get; set; }

        /// <summary>
        /// Gets or sets the valor.
        /// </summary>
        /// <value>The valor.</value>
        public double Valor { get; set; }
    }
}
