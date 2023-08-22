using HeroesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace HeroesAPI.Services.SuperHeroService
{
    public interface ISuperHeroService
    {
        Task<List<SuperHero>> GetAllHeroes();

        Task<SuperHero> GetSingleSuperHero(int id);

        Task<SuperHero> AddHero(SuperHero request);

        Task<SuperHero> UpdateHero(SuperHero request);

        Task DeleteHero(int id);
    }
}
