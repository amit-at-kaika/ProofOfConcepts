using ProofOfConcepts.Shared; //Actor

namespace ProofOfConcepts.WebApi.Repositories;

public interface IActorRepository
{
    Task<Actor?> CreateAsync(Actor actor);
    Task<IEnumerable<Actor>> RetrieveAllAsync();
    Task<Actor?> RetrieveAsync(ushort actorId);
    Task<Actor?> UpdateAsync(ushort actorId, Actor actor);
    Task<bool?> DeleteAsync(ushort actorId);
}
