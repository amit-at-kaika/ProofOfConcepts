using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProofOfConcepts.Shared;

[Table("category")]
public partial class Category
{
    [Key]
    [Column("category_id")]
    public byte CategoryId { get; set; }

    [Column("name")]
    [StringLength(25)]
    public string Name { get; set; } = null!;

    [Column("last_update", TypeName = "timestamp")]
    public DateTime LastUpdate { get; set; }

    [InverseProperty("Category")]
    public virtual ICollection<FilmCategory> FilmCategories { get; } = new List<FilmCategory>();
}
