using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ServerSideCapstone.Models.DTOs;
public class UpdateListingDTO
{
    public byte[] ImageBlob { get; set; }
    public string Title { get; set; }
    public decimal Price { get; set; }
    public string Content { get; set; }
    public List<ListingCategoryDTO> ListingCategories { get; set; }
}