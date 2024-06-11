using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServerSideCapstone.Models.DTOs;

public class UpdateListingCategoryDTO
{
    public int ListingId { get; set; }
    public int CategoryId { get; set; }
}