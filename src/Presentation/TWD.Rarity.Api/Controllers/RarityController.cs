using Microsoft.AspNetCore.Mvc;
using TWD.Rarity.Db.Core.Entities;
using TWD.Rarity.Db.Core.Repositories;

namespace TWD.Rarity.Api.Controllers;

[Route("api/rarity")]
[ApiController]
public class RarityController(IRepositoryManager repositoryManager) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> SetRarity(string name, int count)
    {
        await repositoryManager.RarityRepository.Create(new ItemRarity { Name = name, Chance = count });
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllRarity()
    {
        var result = await repositoryManager.RarityRepository.GetAll();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetRarityById(int id)
    {
        var result = await repositoryManager.RarityRepository.Get(id);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRarity(int id)
    {
        await repositoryManager.RarityRepository.Delete(id);
        return Ok();
    }
}
