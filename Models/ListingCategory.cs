using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServerSideCapstone.Models;

public class ListingCategory
{
    [Required]
    public int ForsalePostId { get; set; }

    [Required]
    public int CategoryId { get; set; }

    public Listing ForsalePost { get; set; }
    public Category Category { get; set; }
}