using System;

namespace ServicesSIMIT.Domain.Entities
{
    /// <summary>
    /// Payment subpoena.
    /// </summary>
    public class PaymentSubpoena
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the cus.
        /// </summary>
        /// <value>The cus.</value>
        public int Cus { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>The state.</value>
        public int State { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the date payment.
        /// </summary>
        /// <value>The date payment.</value>
        public DateTime DatePayment { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public decimal Value { get; set; }

        /// <summary>
        /// Gets or sets the identifier subpoena.
        /// </summary>
        /// <value>The identifier subpoena.</value>
        public Guid IdSubpoena { get; set; }

        /// <summary>
        /// Gets or sets the identifier bank.
        /// </summary>
        /// <value>The identifier bank.</value>
        public Guid IdBank { get; set; }

        /// <summary>
        /// Gets or sets the identifier person.
        /// </summary>
        /// <value>The identifier person.</value>
        public Guid IdPerson { get; set; }
    }
}
