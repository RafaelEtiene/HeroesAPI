using HeroesAPI.Data;
using HeroesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HeroesAPI.Services.SuperHeroService
{
    public class SuperHeroService : ISuperHeroService
    {
        private readonly HeroesContext _context;
        public SuperHeroService(HeroesContext context)
        {
            _context = context;
        }

        public async Task<SuperHero> AddHero(SuperHero request)
        {
            var result = _context.superHeroes.AddAsync(request);
            await _context.SaveChangesAsync();
            return request;
        }

        public async Task DeleteHero(int id)
        {
            var hero = await _context.superHeroes.FindAsync(id);

            if (hero is null)
            {
                throw new Exception("This hero doesn't exist.");
            }
            _context.superHeroes.Remove(hero);

            await _context.SaveChangesAsync();
        }

        public async Task<List<SuperHero>> GetAllHeroes()
        {
            var heroes = await _context.superHeroes.ToListAsync();
            return heroes;
        }

        public async Task<SuperHero> GetSingleSuperHero(int id)
        {
            var hero = await _context.superHeroes.FindAsync(id);

            if (hero is null)
            {
                throw new Exception("This hero doesn't exist.");
            }

            return hero;
        }

        public async Task<SuperHero> UpdateHero(SuperHero request)
        {
            var hero = await _context.superHeroes.FindAsync(request.Id);

            if (hero is null)
            {
                throw new Exception("This hero doesn't exist.");
            }

            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Name = request.Name;
            hero.Place = request.Place;

            await _context.SaveChangesAsync();

            return hero;
        }
    }
}
