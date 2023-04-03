using Business.Interfaces;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Types.Models;
using Types.Requests;
using Types.Responses;

namespace Business.UnitTests
{
    public class DummyServiceTests
    {
        private DummyService _sut;
        private Mock<ILogger<DummyService>> _logger;
        private Mock<IDummyRepository> _repository;

        [SetUp]
        public void Setup()
        {
            _logger = new Mock<ILogger<DummyService>>();
            _repository = new Mock<IDummyRepository>();

            _sut = new DummyService(_logger.Object, _repository.Object);
        }

        [Test]
        public async Task GetItem_ExistingItem_ReturnsItem()
        {
            // Arrange
            var itemId = 1;
            var itemRequest = new ItemRequest() { ItemId = itemId };
            _repository.Setup(_ => _.GetItem(It.IsAny<ItemModel>())).ReturnsAsync(new ItemEntity() { ItemId = itemId });

            // Act
            var item = await _sut.GetItem(itemRequest);

            // Assert
            item.Should().BeOfType<ItemResponse>();
            item.ItemId.Should().Be(itemId);
        }
    }
}