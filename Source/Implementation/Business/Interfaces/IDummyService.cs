using Types.Requests;
using Types.Responses;

namespace Business.Interfaces
{
    public interface IDummyService
    {
        public Task<ItemResponse> GetItem(ItemRequest itemRequest);
    }
}