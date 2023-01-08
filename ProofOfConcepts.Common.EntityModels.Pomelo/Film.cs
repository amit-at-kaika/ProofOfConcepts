using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProofOfConcepts.Shared;

[Table("film")]
[Index("LanguageId", Name = "idx_fk_language_id")]
[Index("OriginalLanguageId", Name = "idx_fk_original_language_id")]
[Index("Title", Name = "idx_title")]
public partial class Film
{
    [Key]
    [Column("film_id")]
    public ushort FilmId { get; set; }

    [Column("title")]
    [StringLength(128)]
    public string Title { get; set; } = null!;

    [Column("description", TypeName = "text")]
    public string? Description { get; set; }

    [Column("release_year", TypeName = "year")]
    public short? ReleaseYear { get; set; }

    [Column("language_id")]
    public byte LanguageId { get; set; }

    [Column("original_language_id")]
    public byte? OriginalLanguageId { get; set; }

    [Column("rental_duration")]
    public byte RentalDuration { get; set; }

    [Column("rental_rate")]
    [Precision(4, 2)]
    public decimal RentalRate { get; set; }

    [Column("length")]
    public ushort? Length { get; set; }

    [Column("replacement_cost")]
    [Precision(5, 2)]
    public decimal ReplacementCost { get; set; }

    [Column("rating", TypeName = "enum('G','PG','PG-13','R','NC-17')")]
    public string? Rating { get; set; }

    [Column("last_update", TypeName = "timestamp")]
    public DateTime LastUpdate { get; set; }

    [InverseProperty("Film")]
    public virtual ICollection<FilmActor> FilmActors { get; } = new List<FilmActor>();

    [InverseProperty("Film")]
    public virtual ICollection<FilmCategory> FilmCategories { get; } = new List<FilmCategory>();

    [InverseProperty("Film")]
    public virtual ICollection<Inventory> Inventories { get; } = new List<Inventory>();

    [ForeignKey("LanguageId")]
    [InverseProperty("FilmLanguages")]
    public virtual Language Language { get; set; } = null!;

    [ForeignKey("OriginalLanguageId")]
    [InverseProperty("FilmOriginalLanguages")]
    public virtual Language? OriginalLanguage { get; set; }
}
