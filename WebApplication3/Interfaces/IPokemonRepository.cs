using WebApplication3.Models;

namespace WebApplication3.Interfaces;

public interface IPokemonRepository
{
    ICollection<Pokemon> GetPokemons();
    Pokemon GetPokemon(int id);
    Pokemon GetPokemon(string name);
    decimal GetPokemonRating(int pokeId);
    bool PokemonExists(int pokemonId);
    bool CreatePokemon(int ownerId, int categoryId, Pokemon pokemon);
    bool Save();
}