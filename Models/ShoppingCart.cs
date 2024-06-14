using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ServerSideCapstone.Models;

public class ShoppingCart
{
    public int Id { get; set; }
    [ForeignKey("UserProfile")]
    public int UserProfileId { get; set; }
    public UserProfile UserProfile { get; set; }
    public int ListingId { get; set; }
    public List<Listing> Listing { get; set; }
    public decimal Total { get; set; }
}