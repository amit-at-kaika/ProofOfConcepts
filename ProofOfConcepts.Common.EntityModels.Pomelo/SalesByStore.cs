using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProofOfConcepts.Shared;

[Keyless]
public partial class SalesByStore
{
    [Column("store")]
    [StringLength(101)]
    public string? Store { get; set; }

    [Column("manager")]
    [StringLength(91)]
    public string? Manager { get; set; }

    [Column("total_sales")]
    [Precision(27, 2)]
    public decimal? TotalSales { get; set; }
}
