namespace TWD.Rarity.Db.Core.Entities;

public class ItemRarity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Chance { get; set; }
}
