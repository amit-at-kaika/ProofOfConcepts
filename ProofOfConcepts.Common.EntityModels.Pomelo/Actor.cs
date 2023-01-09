using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization; // [XmlIgnore]
using Microsoft.EntityFrameworkCore;

namespace ProofOfConcepts.Shared;

[Table("actor")]
[Index("LastName", Name = "idx_actor_last_name")]
public partial class Actor
{
    [Key]
    [Column("actor_id")]
    public ushort ActorId { get; set; }

    [Column("first_name")]
    [StringLength(45)]
    public string FirstName { get; set; } = null!;

    [Column("last_name")]
    [StringLength(45)]
    public string LastName { get; set; } = null!;

    [Column("last_update", TypeName = "timestamp")]
    public DateTime LastUpdate { get; set; }

    [InverseProperty("Actor")]
    public virtual ICollection<FilmActor> FilmActors { get; } = new List<FilmActor>();
}
