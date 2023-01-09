using Microsoft.AspNetCore.Mvc; // [Route], [ApiController], ControllerBase
using ProofOfConcepts.Shared;
using ProofOfConcepts.WebApi.Repositories; // IActorRepository, ActorRepository

namespace ProofOfConcepts.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ActorsController : ControllerBase
{
    private readonly IActorRepository _repo;

    [HttpPost]
    [ProducesResponseType(201, Type = typeof(Actor))]
    [ProducesResponseType(400)]
    public async Task<IActionResult> Create([FromBody] Actor actor)
    {
        if (actor == null)
        {
            return BadRequest(); // 400 Bad request
        }
        Actor? addedActor = await _repo.CreateAsync(actor);
        if (addedActor == null)
        {
            return BadRequest("Repository failed to create customer.");
        }
        else
        {
            return CreatedAtRoute(routeName: nameof(GetActor), routeValues: new { actorId = addedActor.ActorId }, value: addedActor);  // 201 Created
        }
    }


    public ActorsController(IActorRepository repository)
    {
        _repo = repository;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Actor>))]
    public async Task<IEnumerable<Actor>> GetActors()
    {
        return await _repo.RetrieveAllAsync();
    }

    [HttpGet("{actorId}", Name = nameof(GetActor))] // named route
    [ProducesResponseType(200, Type = typeof(Actor))]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetActor(ushort actorId)
    {
        Actor? actor = await _repo.RetrieveAsync(actorId);
        if (actor == null)
        {
            return NotFound(); // 404 Resource not found
        }
        return Ok(actor); // 200 OK with customer in body
    }

    
    [HttpPut("{actorId}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Update(ushort actorId, [FromBody] Actor actor)
    {
        if (actor == null || actor.ActorId != actorId)
        {
            return BadRequest(); // 400 Bad request
        }
        Actor? existing = await _repo.RetrieveAsync(actorId);
        if (existing == null)
        {
            return NotFound(); // 404 Resource not found
        }
        await _repo.UpdateAsync(actorId, actor);
        return new NoContentResult(); // 204 No content
    }

    [HttpDelete("{actorId}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Delete(ushort actorId)
    {
        Actor? existing = await _repo.RetrieveAsync(actorId);
        if (existing == null)
        {
            return NotFound(); // 404 Resource not found
        }
        bool? deleted = await _repo.DeleteAsync(actorId);
        if (deleted.HasValue && deleted.Value)
        {
            return new NoContentResult(); // 204 No content
        }
        else
        {
            return BadRequest($"Customer {actorId} was found but failed to delete."); // 400 Bad request
        }
    }

}