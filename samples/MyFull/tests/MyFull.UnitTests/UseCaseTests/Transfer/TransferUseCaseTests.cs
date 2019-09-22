namespace MyFull.UnitTests.UseCaseTests.Transfer
{
    using System.Linq;
    using System.Threading.Tasks;
    using MyFull.Application.Boundaries.Transfer;
    using MyFull.Application.UseCases;
    using MyFull.Domain.ValueObjects;
    using MyFull.UnitTests.TestFixtures;
    using Xunit;

    public sealed class TransferUseCaseTests : IClassFixture<StandardFixture>
    {
        private readonly StandardFixture _fixture;
        public TransferUseCaseTests(StandardFixture fixture)
        {
            _fixture = fixture;
        }

        [Theory]
        [ClassData(typeof(PositiveDataSetup))]
        public async Task Transfer_ChangesBalance_WhenAccountExists(
            decimal amount,
            decimal expectedOriginBalance)
        {
            var sut = new Transfer(
                _fixture.EntityFactory,
                _fixture.Presenter,
                _fixture.AccountRepository,
                _fixture.UnitOfWork
            );

            await sut.Execute(
                new TransferInput(
                    _fixture.Context.DefaultAccountId,
                    _fixture.Context.SecondAccountId,
                    new PositiveMoney(amount)));

            var actual = _fixture.Presenter.Transfers.Last();
            Assert.Equal(expectedOriginBalance, actual.UpdatedBalance);
        }
    }
}