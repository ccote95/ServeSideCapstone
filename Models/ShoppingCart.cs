using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ServerSideCapstone.Models;

public class ShoppingCart
{
    public int Id { get; set; }
    public int listingId { get; set; }
    public Listing listings { get; set; }
    public decimal Total { get; set; }
}