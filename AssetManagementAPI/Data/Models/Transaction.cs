using System;
using System.Collections.Generic;

namespace AssetManagementAPI.Data.Models;

public partial class Transaction
{
    public int Id { get; set; }

    public int? AssetId { get; set; }

    public int? BuyerId { get; set; }

    public int? SellerId { get; set; }

    public string? TransactionType { get; set; }

    public DateTime? TransactionDate { get; set; }

    public virtual Asset? Asset { get; set; }

    public virtual User? Buyer { get; set; }

    public virtual User? Seller { get; set; }
}
