using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProofOfConcept.Shared;

[Table("language")]
public partial class Language
{
    [Key]
    [Column("language_id")]
    public byte LanguageId { get; set; }

    [Column("name")]
    [StringLength(20)]
    public string Name { get; set; } = null!;

    [Column("last_update", TypeName = "timestamp")]
    public DateTime LastUpdate { get; set; }

    [InverseProperty("Language")]
    public virtual ICollection<Film> FilmLanguages { get; } = new List<Film>();

    [InverseProperty("OriginalLanguage")]
    public virtual ICollection<Film> FilmOriginalLanguages { get; } = new List<Film>();
}
