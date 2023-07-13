using System;
using System.Collections.Generic;

namespace AssetManagementAPI.Data.Models;

public partial class Asset
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public decimal? Price { get; set; }

    public int? OwnerId { get; set; }

    public virtual User? Owner { get; set; }

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
