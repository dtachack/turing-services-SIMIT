namespace ServicesSIMIT.Models
{
   /// <summary>
   /// Respuesta consulta comparendo.
   /// </summary>
    public class RespuestaConsultaComparendo
    {
        /// <summary>
        /// Gets or sets the comparendo.
        /// </summary>
        /// <value>The comparendo.</value>
        public Comparendo Comparendo { get; set; }

        /// <summary>
        /// Gets or sets the infraccion.
        /// </summary>
        /// <value>The infraccion.</value>
        public Infraccion Infraccion { get; set; }

        /// <summary>
        /// Gets or sets the persona.
        /// </summary>
        /// <value>The persona.</value>
        public Persona Persona { get; set; }

        /// <summary>
        /// Gets or sets the vehiculo.
        /// </summary>
        /// <value>The vehiculo.</value>
        public Vehiculo Vehiculo { get; set; }

        /// <summary>
        /// Gets or sets the agente detector infraccion.
        /// </summary>
        /// <value>The agente detector infraccion.</value>
        public AgenteDetector AgenteDetectorInfraccion { get; set; }

        /// <summary>
        /// Gets or sets the agente registro comparendo.
        /// </summary>
        /// <value>The agente registro comparendo.</value>
        public AgenteRegistro AgenteRegistroComparendo { get; set; }
    }
}
