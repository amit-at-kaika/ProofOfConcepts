using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProofOfConcept.Shared;

[Table("rental")]
[Index("CustomerId", Name = "idx_fk_customer_id")]
[Index("InventoryId", Name = "idx_fk_inventory_id")]
[Index("StaffId", Name = "idx_fk_staff_id")]
[Index("RentalDate", "InventoryId", "CustomerId", Name = "rental_date", IsUnique = true)]
public partial class Rental
{
    [Key]
    [Column("rental_id")]
    public int RentalId { get; set; }

    [Column("rental_date", TypeName = "datetime")]
    public DateTime RentalDate { get; set; }

    [Column("inventory_id", TypeName = "mediumint unsigned")]
    public uint InventoryId { get; set; }

    [Column("customer_id")]
    public ushort CustomerId { get; set; }

    [Column("return_date", TypeName = "datetime")]
    public DateTime? ReturnDate { get; set; }

    [Column("staff_id")]
    public byte StaffId { get; set; }

    [Column("last_update", TypeName = "timestamp")]
    public DateTime LastUpdate { get; set; }

    [ForeignKey("CustomerId")]
    [InverseProperty("Rentals")]
    public virtual Customer Customer { get; set; } = null!;

    [ForeignKey("InventoryId")]
    [InverseProperty("Rentals")]
    public virtual Inventory Inventory { get; set; } = null!;

    [InverseProperty("Rental")]
    public virtual ICollection<Payment> Payments { get; } = new List<Payment>();

    [ForeignKey("StaffId")]
    [InverseProperty("Rentals")]
    public virtual Staff Staff { get; set; } = null!;
}
