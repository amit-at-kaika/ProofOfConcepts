using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProofOfConcept.Shared;

[Keyless]
public partial class SalesByFilmCategory
{
    [Column("category")]
    [StringLength(25)]
    public string Category { get; set; } = null!;

    [Column("total_sales")]
    [Precision(27, 2)]
    public decimal? TotalSales { get; set; }
}
