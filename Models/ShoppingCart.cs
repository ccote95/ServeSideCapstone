using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ServerSideCapstone.Models;

public class ShoppingCart
{
    [Key]
    public int Id { get; set; }
    public int UserProfileId { get; set; }
    public UserProfile UserProfile { get; set; }
    public int ListingId { get; set; }
    public Listing Listing { get; set; }
    public decimal Total { get; set; }
}