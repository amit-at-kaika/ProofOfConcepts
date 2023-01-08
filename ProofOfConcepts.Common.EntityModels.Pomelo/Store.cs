using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProofOfConcepts.Shared;

[Table("store")]
[Index("AddressId", Name = "idx_fk_address_id")]
[Index("ManagerStaffId", Name = "idx_unique_manager", IsUnique = true)]
public partial class Store
{
    [Key]
    [Column("store_id")]
    public byte StoreId { get; set; }

    [Column("manager_staff_id")]
    public byte ManagerStaffId { get; set; }

    [Column("address_id")]
    public ushort AddressId { get; set; }

    [Column("last_update", TypeName = "timestamp")]
    public DateTime LastUpdate { get; set; }

    [ForeignKey("AddressId")]
    [InverseProperty("Stores")]
    public virtual Address Address { get; set; } = null!;

    [InverseProperty("Store")]
    public virtual ICollection<Customer> Customers { get; } = new List<Customer>();

    [InverseProperty("Store")]
    public virtual ICollection<Inventory> Inventories { get; } = new List<Inventory>();

    [ForeignKey("ManagerStaffId")]
    [InverseProperty("StoreNavigation")]
    public virtual Staff ManagerStaff { get; set; } = null!;

    [InverseProperty("Store")]
    public virtual ICollection<Staff> Staff { get; } = new List<Staff>();
}
