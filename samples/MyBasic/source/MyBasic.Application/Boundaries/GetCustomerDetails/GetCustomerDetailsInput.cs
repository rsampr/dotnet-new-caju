namespace MyBasic.Application.Boundaries.GetCustomerDetails
{
    using System;
    using MyBasic.Application.Exceptions;

    public sealed class GetCustomerDetailsInput
    {
        public Guid CustomerId { get; }

        public GetCustomerDetailsInput(Guid customerId)
        {
            if (customerId == Guid.Empty)
            {
                throw new InputValidationException($"{nameof(customerId)} cannot be empty.");
            }

            CustomerId = customerId;
        }
    }
}