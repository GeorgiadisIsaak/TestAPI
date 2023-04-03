using Business.Interfaces;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Types.Requests;
using Types.Models;
using Persistence;
using Microsoft.Extensions.Options;
using Persistence.Options;
using Types.Responses;

namespace Business.IntegrationTests
{
    public class DummyServiceTests
    {
        private DummyService _sut;
        private Mock<ILogger<DummyService>> _servicelogger;
        private Mock<ILogger<DummyRepository>> _repositorylogger;


        [SetUp]
        public void Setup()
        {
            _servicelogger = new Mock<ILogger<DummyService>>();
            _repositorylogger = new Mock<ILogger<DummyRepository>>();

            // Since these are integration tests, we create an actual repository(not a mock repository)
            var repositoryOptions = Options.Create(new DummyRepositoryOptions() { ConnectionString = "MyConnectionString" });
            var repository = new DummyRepository(_repositorylogger.Object, repositoryOptions);

            _sut = new DummyService(_servicelogger.Object, repository);
        }

        [Test]
        public async Task GetItem_ExistingItem_ReturnsItem()
        {
            // Arrange
            var itemId = 1;
            var itemRequest = new ItemRequest() { ItemId = itemId };

            // Act
            var item = await _sut.GetItem(itemRequest);

            // Assert
            item.Should().BeOfType<ItemResponse>();
            item.ItemId.Should().Be(itemId);
        }
    }
}