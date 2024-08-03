using WebApplication3.Data;
using WebApplication3.Interfaces;
using WebApplication3.Models;

namespace WebApplication3.Repository;

public class OwnerRepository : IOwnerRepository
{
    private readonly DataContext _context;
    public OwnerRepository(DataContext context)
    {
        _context = context;
    }

    public ICollection<Owner> GetOwners()
    {
        return _context.Owners.ToList();
    }

    public Owner GetOwner(int ownerId)
    {
        return _context.Owners.Where(o => o.Id == ownerId).FirstOrDefault();
    }

    public ICollection<Owner> GetOwnerOfPokemon(int pokeId)
    {
        return _context.PokemonOwners.Where(po => po.PokemonId == pokeId).Select(o => o.Owner).ToList();
    }

    public ICollection<Pokemon> GetPokemonByOwner(int ownerId)
    {
        return _context.PokemonOwners.Where(po => po.OwnerId == ownerId).Select(p => p.Pokemon).ToList();
    }

    public bool OwnerExists(int ownerId)
    {
        return _context.Owners.Any(o => o.Id == ownerId);
    }

    public bool CreateOwner(Owner owner)
    {
        _context.Add(owner);
        return Save();
    }

    public bool UpdateOwner(Owner owner)
    {
        _context.Update(owner);
        return Save();
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();

        return saved > 0 ? true : false;
    }
}