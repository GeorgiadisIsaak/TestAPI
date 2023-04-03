using Business.Interfaces;
using Microsoft.Extensions.Logging;
using Types.Requests;
using Types.Responses;

namespace Business
{
    public class DummyService : IDummyService
    {
        private readonly ILogger<DummyService> _logger;
        private readonly IDummyRepository _dummyRepository;

        public DummyService(ILogger<DummyService> logger, IDummyRepository dummyRepository)
        {
            _logger = logger;
            _dummyRepository = dummyRepository;
        }

        public async Task<ItemResponse> GetItem(ItemRequest item)
        {
            // Map Request to Model
            var itemModel = new ItemModel
            {
                ItemId = item.ItemId
            };

            // Retrieve Data from DB
            var itemEntity = await _dummyRepository.GetItem(itemModel);

            // Map Entity to Response
            var response = new ItemResponse
            {
                ItemId = itemEntity.ItemId,
                Description = "Dummy Description"
            };

            return response;
        }
    }
}