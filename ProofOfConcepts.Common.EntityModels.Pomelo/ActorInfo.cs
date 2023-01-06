using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProofOfConcept.Shared;

[Keyless]
public partial class ActorInfo
{
    [Column("actor_id")]
    public ushort ActorId { get; set; }

    [Column("first_name")]
    [StringLength(45)]
    public string FirstName { get; set; } = null!;

    [Column("last_name")]
    [StringLength(45)]
    public string LastName { get; set; } = null!;

    [Column("film_info", TypeName = "text")]
    public string? FilmInfo { get; set; }
}
