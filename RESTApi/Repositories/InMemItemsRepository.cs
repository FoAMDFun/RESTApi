using RESTApi.Entities;

namespace RESTApi.Repositories
{
    public class InMemItemsRepository : IItemsRepository
    {
        private readonly List<Item> items = new()
        {
            new Item { Id = Guid.NewGuid(), Name = "Potion", Price = 9, CreatedDate = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "Iron Sword", Price = 20, CreatedDate = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "Bronze Shield", Price = 18, CreatedDate = DateTimeOffset.UtcNow }
        };

        public async Task<IEnumerable<Item>> GetItemsAsync()
        {
            return await Task.FromResult(items);
        }

        public async Task<Item?> GetItemAsync(Guid id)
        {
            return await Task.FromResult(items.SingleOrDefault(item => item.Id == id));
        }

        public async Task CreateItemAsync(Item item)
        {
            items.Add(item);
            await Task.CompletedTask;
        }

        public async Task UpdateItemAsync(Item item)
        {
            int index = items.FindIndex(existingItem => existingItem.Id == item.Id);
            if (index >= 0)
            {
                items[index] = item;
            }

            await Task.CompletedTask;
        }

        public async Task DeleteItemAsync(Guid id)
        {
            var index = items.FindIndex(item => item.Id == id);
            if (index < 0)
            {
                return;
            }
            items.RemoveAt(index);

            await Task.CompletedTask;
        }
    }
}
