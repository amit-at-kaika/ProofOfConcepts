using Microsoft.EntityFrameworkCore.ChangeTracking; // EntityEntry<T>
using ProofOfConcepts.Shared; // Actor
using System.Collections.Concurrent; // ConcurrentDictionary

namespace ProofOfConcepts.WebApi.Repositories;

public class ActorRepository : IActorRepository
{
    private static ConcurrentDictionary<ushort, Actor>? _actorsCache;
    private SakilaContext _database;

    public ActorRepository(SakilaContext database)
    {
        _database = database;

        if (_actorsCache is null)
        {
            _actorsCache = new ConcurrentDictionary<ushort, Actor>(_database.Actors.ToDictionary(a => a.ActorId));
        }
    }

    public async Task<Actor?> CreateAsync(Actor actor)
    {
        EntityEntry<Actor> added = await _database.Actors.AddAsync(actor);
        int affected = await _database.SaveChangesAsync();
        if (affected == 1)
        {
            if (_actorsCache is null) 
                return actor;
            // If the customer is new, add it to cache, else call UpdateCache method.
            return _actorsCache.AddOrUpdate(actor.ActorId, actor, UpdateCache);
        }
        else
        {
            return null;
        }
    }

    public async Task<bool?> DeleteAsync(ushort actorId)
    {
        Actor ? actor = _database.Actors.Find(actorId);
        if(actor is null)
            return null;
        
        _database.Actors.Remove(actor);
        int affected = await _database.SaveChangesAsync();
        if (affected == 1)
        {
            if(_actorsCache is null)
                return null;

            return _actorsCache.TryRemove(actorId, out actor);
        }
        else 
        {
            return null;
        }
    }

    public Task<IEnumerable<Actor>> RetrieveAllAsync()
    {
        IEnumerable<Actor> actors = Enumerable.Empty<Actor>();
        if(_actorsCache is not null)
            actors = _actorsCache.Values;

        return  Task.FromResult(actors);
    }

    public Task<Actor?> RetrieveAsync(ushort actorId)
    {
        if (_actorsCache is null)
            return null!;
        _actorsCache.TryGetValue(actorId, out Actor ? actor);
        return Task.FromResult(actor);        
    }

    public async Task<Actor?> UpdateAsync(ushort actorId, Actor actor)
    {
        _database.Actors.Update(actor);
        int affected = await _database.SaveChangesAsync();
        if(affected == 1)
        {
            return UpdateCache(actorId, actor);
        }
        return null;
    }

    private Actor UpdateCache(ushort actorId, Actor actor)
    {
        Actor? old;
        if (_actorsCache is not null)
        {
            if (_actorsCache.TryGetValue(actorId, out old))
            {
                if (_actorsCache.TryUpdate(actorId, actor, old))
                {
                    return actor;
                }
            }
        }
        return null!;
    }
}