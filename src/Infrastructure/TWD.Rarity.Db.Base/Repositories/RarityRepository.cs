using Dapper;
using Npgsql;
using System.Data;
using TWD.Rarity.Db.Core.Entities;
using TWD.Rarity.Db.Core.Repositories;

namespace TWD.Rarity.Db.Base.Repositories;

public class RarityRepository(string connectionString) : IRarityRepository
{
    private const string TABLE_NAME = "item_rarities";

    public async Task<ItemRarity?> Get(int id)
    {
        using IDbConnection db = new NpgsqlConnection(connectionString);
        return await db.QueryFirstOrDefaultAsync<ItemRarity>(
            $"SELECT * FROM {TABLE_NAME} WHERE id = @id",
            new { id });
    }

    public async Task<IEnumerable<ItemRarity>> GetAll()
    {
        using IDbConnection db = new NpgsqlConnection(connectionString);
        return await db.QueryAsync<ItemRarity>($"SELECT * FROM {TABLE_NAME}");
    }

    public async Task Create(ItemRarity rarity)
    {
        using IDbConnection db = new NpgsqlConnection(connectionString);
        var sqlQuery = $"INSERT INTO {TABLE_NAME} (name, chance) VALUES(@Name, @Chance)";
        await db.ExecuteAsync(sqlQuery, rarity);
    }

    public async Task Delete(int id)
    {
        using IDbConnection db = new NpgsqlConnection(connectionString);
        var sqlQuery = $"DELETE FROM {TABLE_NAME} WHERE Id = @id";
        await db.ExecuteAsync(sqlQuery, new { id });
    }

    public async Task Update(ItemRarity rarity)
    {
        using IDbConnection db = new NpgsqlConnection(connectionString);
        var sqlQuery = $"UPDATE {TABLE_NAME} SET name = @Name, chance = @Chance WHERE id = @Id";
        await db.ExecuteAsync(sqlQuery, rarity);
    }
}
