using System;

namespace ServicesSIMIT.Models
{
   /// <summary>
   /// Infraccion.
   /// </summary>
    public class Infraccion
    {
       /// <summary>
       /// Gets or sets the codigo infraccion.
       /// </summary>
       /// <value>The codigo infraccion.</value>
        public string CodigoInfraccion { get; set; }

       /// <summary>
       /// Gets or sets the descipcion infraccion.
       /// </summary>
       /// <value>The descipcion infraccion.</value>
        public string DescipcionInfraccion { get; set; }
        
       /// <summary>
       /// Gets or sets the fechayhora infraccion.
       /// </summary>
       /// <value>The fechayhora infraccion.</value>
        public DateTime FechayhoraInfraccion { get; set; }

      /// <summary>
      /// Gets or sets the direccion infraccion.
      /// </summary>
      /// <value>The direccion infraccion.</value>
        public string DireccionInfraccion { get; set; }

       /// <summary>
       /// Gets or sets the observaciones.
       /// </summary>
       /// <value>The observaciones.</value>
        public string Observaciones { get; set; }
    }
}
