using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ServerSideCapstone.Models.DTOs;
public class ListingDTO
{
    public int Id { get; set; }

    [Required]
    public int UserProfileId { get; set; }

    public string ProductImg { get; set; }
    public int CategoryId { get; set; }
    public CategoryDTO category { get; set; }
    public string Title { get; set; }

    [Required]
    public string Content { get; set; }

    [Required]
    public DateTime CreatedOn { get; set; }

    public UserProfileDTO UserProfile { get; set; }
    public List<ListingCategoryDTO> ListingCategories { get; set; }
}