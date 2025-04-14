using TWD.Rarity.Db.Core.Entities;

namespace TWD.Rarity.Db.Core.Repositories;

public interface IRarityRepository
{
    public Task<IEnumerable<ItemRarity>> GetAll();
    public Task<ItemRarity?> Get(int id);

    public Task Create(ItemRarity rarity);
    public Task Update(ItemRarity rarity);
    public Task Delete(int id);
}
