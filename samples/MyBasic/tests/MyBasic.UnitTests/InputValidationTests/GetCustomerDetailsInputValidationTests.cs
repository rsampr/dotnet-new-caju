namespace MyBasic.UnitTests.InputValidationTests
{
    using System;
    using MyBasic.Application.Boundaries.GetCustomerDetails;
    using MyBasic.Application.Exceptions;
    using Xunit;

    public sealed class GetCustomerDetailsInputValidationTests
    {
        [Fact]
        public void GivenEmptyAccountId_InputNotCreated_ThrowsInputValidationException()
        {
            var actualEx = Assert.Throws<InputValidationException>(
                () => new GetCustomerDetailsInput(
                    Guid.Empty
                ));
            Assert.Contains("customerId", actualEx.Message);
        }

        [Fact]
        public void GivenValidData_InputCreated()
        {
            var actual = new GetCustomerDetailsInput(
                Guid.NewGuid()
            );
            Assert.NotNull(actual);
        }
    }
}