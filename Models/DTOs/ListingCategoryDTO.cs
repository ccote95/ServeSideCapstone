using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServerSideCapstone.Models.DTOs;

public class ListingCategoryDTO
{
    [Required]
    public int ListingId { get; set; }

    [Required]
    public int CategoryId { get; set; }

    public Listing Listing { get; set; }
    public Category Category { get; set; }
}