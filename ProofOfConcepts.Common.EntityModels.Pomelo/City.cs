using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProofOfConcept.Shared;

[Table("city")]
[Index("CountryId", Name = "idx_fk_country_id")]
public partial class City
{
    [Key]
    [Column("city_id")]
    public ushort CityId { get; set; }

    [Column("city")]
    [StringLength(50)]
    public string City1 { get; set; } = null!;

    [Column("country_id")]
    public ushort CountryId { get; set; }

    [Column("last_update", TypeName = "timestamp")]
    public DateTime LastUpdate { get; set; }

    [InverseProperty("City")]
    public virtual ICollection<Address> Addresses { get; } = new List<Address>();

    [ForeignKey("CountryId")]
    [InverseProperty("Cities")]
    public virtual Country Country { get; set; } = null!;
}
