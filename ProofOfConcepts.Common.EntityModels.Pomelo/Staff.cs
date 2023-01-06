using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProofOfConcept.Shared;

[Table("staff")]
[Index("AddressId", Name = "idx_fk_address_id")]
[Index("StoreId", Name = "idx_fk_store_id")]
public partial class Staff
{
    [Key]
    [Column("staff_id")]
    public byte StaffId { get; set; }

    [Column("first_name")]
    [StringLength(45)]
    public string FirstName { get; set; } = null!;

    [Column("last_name")]
    [StringLength(45)]
    public string LastName { get; set; } = null!;

    [Column("address_id")]
    public ushort AddressId { get; set; }

    [Column("picture", TypeName = "blob")]
    public byte[]? Picture { get; set; }

    [Column("email")]
    [StringLength(50)]
    public string? Email { get; set; }

    [Column("store_id")]
    public byte StoreId { get; set; }

    [Required]
    [Column("active")]
    public bool? Active { get; set; }

    [Column("username")]
    [StringLength(16)]
    public string Username { get; set; } = null!;

    [Column("password")]
    [StringLength(40)]
    [MySqlCollation("utf8mb4_bin")]
    public string? Password { get; set; }

    [Column("last_update", TypeName = "timestamp")]
    public DateTime LastUpdate { get; set; }

    [ForeignKey("AddressId")]
    [InverseProperty("Staff")]
    public virtual Address Address { get; set; } = null!;

    [InverseProperty("Staff")]
    public virtual ICollection<Payment> Payments { get; } = new List<Payment>();

    [InverseProperty("Staff")]
    public virtual ICollection<Rental> Rentals { get; } = new List<Rental>();

    [ForeignKey("StoreId")]
    [InverseProperty("Staff")]
    public virtual Store Store { get; set; } = null!;

    [InverseProperty("ManagerStaff")]
    public virtual Store? StoreNavigation { get; set; }
}
