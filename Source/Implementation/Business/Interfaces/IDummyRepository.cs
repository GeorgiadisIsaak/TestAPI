using Types.Models;
using Types.Requests;

namespace Business.Interfaces
{
    public interface IDummyRepository
    {
        public Task<ItemEntity> GetItem(ItemModel itemModel);
    }
}