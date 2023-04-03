using Business.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Persistence.Options;
using System.Data.SqlClient;
using Types.Models;
using Types.Requests;

namespace Persistence
{
    public class DummyRepository : IDummyRepository
    {
        private readonly ILogger<DummyRepository> _logger;
        private readonly DummyRepositoryOptions _options;

        public DummyRepository(ILogger<DummyRepository> logger, IOptions<DummyRepositoryOptions> options)
        {
            _logger = logger;
            _options = options.Value;
        }

        public async Task<ItemEntity> GetItem(ItemModel itemModel)
        {

                //Retrieve data from actual SQL Server
                //using var connection = new SqlConnection(_options.ConnectionString);
                //await connection.OpenAsync();

            return await Task.Run(() => new ItemEntity { ItemId = itemModel.ItemId });
        }
    }
}