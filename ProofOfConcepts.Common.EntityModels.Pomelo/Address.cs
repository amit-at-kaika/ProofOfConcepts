using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProofOfConcept.Shared;

[Table("address")]
[Index("CityId", Name = "idx_fk_city_id")]
public partial class Address
{
    [Key]
    [Column("address_id")]
    public ushort AddressId { get; set; }

    [Column("address")]
    [StringLength(50)]
    public string Address1 { get; set; } = null!;

    [Column("address2")]
    [StringLength(50)]
    public string? Address2 { get; set; }

    [Column("district")]
    [StringLength(20)]
    public string District { get; set; } = null!;

    [Column("city_id")]
    public ushort CityId { get; set; }

    [Column("postal_code")]
    [StringLength(10)]
    public string? PostalCode { get; set; }

    [Column("phone")]
    [StringLength(20)]
    public string Phone { get; set; } = null!;

    [Column("last_update", TypeName = "timestamp")]
    public DateTime LastUpdate { get; set; }

    [ForeignKey("CityId")]
    [InverseProperty("Addresses")]
    public virtual City City { get; set; } = null!;

    [InverseProperty("Address")]
    public virtual ICollection<Customer> Customers { get; } = new List<Customer>();

    [InverseProperty("Address")]
    public virtual ICollection<Staff> Staff { get; } = new List<Staff>();

    [InverseProperty("Address")]
    public virtual ICollection<Store> Stores { get; } = new List<Store>();
}
