﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProofOfConcepts.Shared;

[Keyless]
public partial class CustomerList
{
    [Column("ID")]
    public ushort Id { get; set; }

    [Column("name")]
    [StringLength(91)]
    public string? Name { get; set; }

    [Column("address")]
    [StringLength(50)]
    public string Address { get; set; } = null!;

    [Column("zip code")]
    [StringLength(10)]
    public string? ZipCode { get; set; }

    [Column("phone")]
    [StringLength(20)]
    public string Phone { get; set; } = null!;

    [Column("city")]
    [StringLength(50)]
    public string City { get; set; } = null!;

    [Column("country")]
    [StringLength(50)]
    public string Country { get; set; } = null!;

    [Column("notes")]
    [StringLength(6)]
    public string Notes { get; set; } = null!;

    [Column("SID")]
    public byte Sid { get; set; }
}
