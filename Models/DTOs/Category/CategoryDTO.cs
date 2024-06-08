using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ServerSideCapstone.Models.DTOs;
public class CategoryDTO
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    public List<ListingCategoryDTO> ListingCategories { get; set; }
}