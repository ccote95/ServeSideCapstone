using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using ServerSideCapstone.Models.DTOs;

namespace ServerSideCapstone.Models;

public class ShoppingCartDTO
{
    public int Id { get; set; }
    public int UserProfileId { get; set; }
    public UserProfileForShoppingCartDTO UserProfile { get; set; }
    public int ListingId { get; set; }
    public ListingDTO Listing { get; set; }
    public decimal Total { get; set; }
}