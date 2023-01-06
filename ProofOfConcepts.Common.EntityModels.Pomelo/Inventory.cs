using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProofOfConcept.Shared;

[Table("inventory")]
[Index("FilmId", Name = "idx_fk_film_id")]
[Index("StoreId", "FilmId", Name = "idx_store_id_film_id")]
public partial class Inventory
{
    [Key]
    [Column("inventory_id", TypeName = "mediumint unsigned")]
    public uint InventoryId { get; set; }

    [Column("film_id")]
    public ushort FilmId { get; set; }

    [Column("store_id")]
    public byte StoreId { get; set; }

    [Column("last_update", TypeName = "timestamp")]
    public DateTime LastUpdate { get; set; }

    [ForeignKey("FilmId")]
    [InverseProperty("Inventories")]
    public virtual Film Film { get; set; } = null!;

    [InverseProperty("Inventory")]
    public virtual ICollection<Rental> Rentals { get; } = new List<Rental>();

    [ForeignKey("StoreId")]
    [InverseProperty("Inventories")]
    public virtual Store Store { get; set; } = null!;
}
