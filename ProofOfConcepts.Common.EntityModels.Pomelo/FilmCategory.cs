using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProofOfConcept.Shared;

[PrimaryKey("FilmId", "CategoryId")]
[Table("film_category")]
[Index("CategoryId", Name = "fk_film_category_category")]
public partial class FilmCategory
{
    [Key]
    [Column("film_id")]
    public ushort FilmId { get; set; }

    [Key]
    [Column("category_id")]
    public byte CategoryId { get; set; }

    [Column("last_update", TypeName = "timestamp")]
    public DateTime LastUpdate { get; set; }

    [ForeignKey("CategoryId")]
    [InverseProperty("FilmCategories")]
    public virtual Category Category { get; set; } = null!;

    [ForeignKey("FilmId")]
    [InverseProperty("FilmCategories")]
    public virtual Film Film { get; set; } = null!;
}
