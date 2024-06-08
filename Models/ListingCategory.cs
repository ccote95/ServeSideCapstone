using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServerSideCapstone.Models;

public class ListingCategory
{
    [Required]
    public int ListingId { get; set; }

    [Required]
    public int CategoryId { get; set; }

    public Listing Listing { get; set; }
    public Category Category { get; set; }
}