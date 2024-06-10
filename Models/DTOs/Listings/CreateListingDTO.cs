using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ServerSideCapstone.Models;
public class CreateListingDTO
{
    [Required]
    public int UserProfileId { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public decimal Price { get; set; }

    public string ProductImg { get; set; }
    public FormFile FormFile { get; set; }

    [Required]
    public string Content { get; set; }

    [Required]
    public DateTime CreatedOn { get; set; }

    public List<ListingCategory> ListingCategories { get; set; }
}