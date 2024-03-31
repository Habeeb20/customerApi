using Dotnet.models;
using Dotnet.Controllers;
namespace Dotnet.Service.superHeroService;

public interface ISuperHeroService
{
    Task<List<SuperHero>> GetAllHeroes();

    Task<SuperHero?> GetSingleHero(int id);

    Task<List<SuperHero>> AddHero(SuperHero hero);

    Task<List<SuperHero>?> updateHero(int id, SuperHero request);

    Task<List<SuperHero>?> DeleteHero(int id);
    
}