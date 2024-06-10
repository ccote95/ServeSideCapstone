using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ServerSideCapstone.Models.DTOs;
public class ListingsListDTO
{
    public int Id { get; set; }

    [Required]
    public int UserProfileId { get; set; }
    public string Title { get; set; }
    public decimal Price { get; set; }
    public string ProductImg { get; set; }
    public List<CategoryNoNavDTO> Categories { get; set; }

    [Required]
    public string Content { get; set; }

    [Required]
    public DateTime CreatedOn { get; set; }
    public string FormattedDate
    {
        get
        {
            return CreatedOn.ToString("MMMM dd, yyyy");
        }
    }

    public UserProfileForListingsDTO UserProfile { get; set; }
    public List<ListingCategoryDTO> ListingCategories { get; set; }
}