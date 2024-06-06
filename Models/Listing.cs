using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ServerSideCapstone.Models;
public class Listing
{
    public int Id { get; set; }

    [Required]
    public int UserProfileId { get; set; }

    public byte[] ProductImg { get; set; }

    [Required]
    public string Content { get; set; }

    [Required]
    public DateTime CreatedOn { get; set; }

    public UserProfile UserProfile { get; set; }
    public List<ListingCategory> ForsalePostCategories { get; set; }
}