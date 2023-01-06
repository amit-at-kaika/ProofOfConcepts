using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProofOfConcept.Shared;

[Table("country")]
public partial class Country
{
    [Key]
    [Column("country_id")]
    public ushort CountryId { get; set; }

    [Column("country")]
    [StringLength(50)]
    public string Country1 { get; set; } = null!;

    [Column("last_update", TypeName = "timestamp")]
    public DateTime LastUpdate { get; set; }

    [InverseProperty("Country")]
    public virtual ICollection<City> Cities { get; } = new List<City>();
}
