using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProofOfConcepts.Shared;

[Table("film_text")]
public partial class FilmText
{
    [Key]
    [Column("film_id")]
    public short FilmId { get; set; }

    [Column("title")]
    public string Title { get; set; } = null!;

    [Column("description", TypeName = "text")]
    public string? Description { get; set; }
}
