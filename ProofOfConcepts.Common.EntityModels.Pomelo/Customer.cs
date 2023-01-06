using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProofOfConcept.Shared;

[Table("customer")]
[Index("AddressId", Name = "idx_fk_address_id")]
[Index("StoreId", Name = "idx_fk_store_id")]
[Index("LastName", Name = "idx_last_name")]
public partial class Customer
{
    [Key]
    [Column("customer_id")]
    public ushort CustomerId { get; set; }

    [Column("store_id")]
    public byte StoreId { get; set; }

    [Column("first_name")]
    [StringLength(45)]
    public string FirstName { get; set; } = null!;

    [Column("last_name")]
    [StringLength(45)]
    public string LastName { get; set; } = null!;

    [Column("email")]
    [StringLength(50)]
    public string? Email { get; set; }

    [Column("address_id")]
    public ushort AddressId { get; set; }

    [Required]
    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "datetime")]
    public DateTime CreateDate { get; set; }

    [Column("last_update", TypeName = "timestamp")]
    public DateTime? LastUpdate { get; set; }

    [ForeignKey("AddressId")]
    [InverseProperty("Customers")]
    public virtual Address Address { get; set; } = null!;

    [InverseProperty("Customer")]
    public virtual ICollection<Payment> Payments { get; } = new List<Payment>();

    [InverseProperty("Customer")]
    public virtual ICollection<Rental> Rentals { get; } = new List<Rental>();

    [ForeignKey("StoreId")]
    [InverseProperty("Customers")]
    public virtual Store Store { get; set; } = null!;
}
