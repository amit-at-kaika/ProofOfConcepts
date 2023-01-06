using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProofOfConcept.Shared;

[Keyless]
public partial class FilmList
{
    [Column("FID")]
    public ushort? Fid { get; set; }

    [Column("title")]
    [StringLength(128)]
    public string? Title { get; set; }

    [Column("description", TypeName = "text")]
    public string? Description { get; set; }

    [Column("category")]
    [StringLength(25)]
    public string Category { get; set; } = null!;

    [Column("price")]
    [Precision(4, 2)]
    public decimal? Price { get; set; }

    [Column("length")]
    public ushort? Length { get; set; }

    [Column("rating", TypeName = "enum('G','PG','PG-13','R','NC-17')")]
    public string? Rating { get; set; }

    [Column("actors", TypeName = "text")]
    public string? Actors { get; set; }
}
