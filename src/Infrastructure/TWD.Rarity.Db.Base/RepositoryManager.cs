using TWD.Rarity.Db.Base.Repositories;
using TWD.Rarity.Db.Core.Repositories;

namespace TWD.Rarity.Db.Base;

public class RepositoryManager(string connectionString) : IRepositoryManager
{
    public IRarityRepository RarityRepository { get; } = new RarityRepository(connectionString);
}
