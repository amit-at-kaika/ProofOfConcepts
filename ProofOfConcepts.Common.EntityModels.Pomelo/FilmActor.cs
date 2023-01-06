using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProofOfConcept.Shared;

[PrimaryKey("ActorId", "FilmId")]
[Table("film_actor")]
[Index("FilmId", Name = "idx_fk_film_id")]
public partial class FilmActor
{
    [Key]
    [Column("actor_id")]
    public ushort ActorId { get; set; }

    [Key]
    [Column("film_id")]
    public ushort FilmId { get; set; }

    [Column("last_update", TypeName = "timestamp")]
    public DateTime LastUpdate { get; set; }

    [ForeignKey("ActorId")]
    [InverseProperty("FilmActors")]
    public virtual Actor Actor { get; set; } = null!;

    [ForeignKey("FilmId")]
    [InverseProperty("FilmActors")]
    public virtual Film Film { get; set; } = null!;
}
