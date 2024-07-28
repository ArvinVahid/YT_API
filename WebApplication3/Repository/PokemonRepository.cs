using WebApplication3.Data;
using WebApplication3.Interfaces;
using WebApplication3.Models;

namespace WebApplication3.Repository;

public class PokemonRepository : IPokemonRepository
{
    private readonly DataContext _context;
    public PokemonRepository(DataContext context)
    {
        _context = context;
    }

    public Pokemon GetPokemon(int id)
    {
        return _context.Pokemons.Where(p => p.Id == id).FirstOrDefault();
    }

    public Pokemon GetPokemon(string name)
    {
        return _context.Pokemons.FirstOrDefault(p => p.Name == name);
    }

    public decimal GetPokemonRating(int pokeId)
    {
        var rating = _context.Reviews.Where(r => r.Pokemon.Id == pokeId);

        if (rating.Count() <= 0)
            return 0;

        return ((decimal)rating.Sum(r => r.Rating) / rating.Count());
    }
    public ICollection<Pokemon> GetPokemons()
    {
        return _context.Pokemons.OrderBy(p => p.Id).ToList();
    }

    public bool PokemonExists(int pokemonId)
    {
        return _context.Pokemons.Any(p => p.Id == pokemonId);
    }

    public bool CreatePokemon(int ownerId, int categoryId, Pokemon pokemon)
    {
        var pokemonOwnerEntity = _context.Owners.Where(o => o.Id == ownerId).FirstOrDefault();
        var category = _context.Categories.Where(c => c.Id == categoryId).FirstOrDefault();

        var pokemonOwner = new PokemonOwner()
        {
            Owner = pokemonOwnerEntity,
            Pokemon = pokemon,
        };

        _context.Add(pokemonOwner);

        var pokemonCategory = new PokemonCategory()
        {
            Category = category,
            Pokemon = pokemon
        };

        _context.Add(pokemonCategory);
        _context.Add(pokemon);

        return Save();
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0 ? true : false;
    }
}