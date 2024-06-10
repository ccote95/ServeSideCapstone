using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ServerSideCapstone.Models;
public class Listing
{
    public int Id { get; set; }
    [Required]
    public int UserProfileId { get; set; }
    public string Title { get; set; }
    public decimal Price { get; set; }

    public string ProductImg { get; set; }
    public byte[] ImageBlob { get; set; }

    [Required]
    public string Content { get; set; }

    [Required]
    public DateTime CreatedOn { get; set; }

    public UserProfile UserProfile { get; set; }
    public List<ListingCategory> ListingCategories { get; set; }
}