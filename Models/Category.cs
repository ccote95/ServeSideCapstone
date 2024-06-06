using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ServerSideCapstone.Models;
public class Category
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    public List<ListingCategory> ListingCategories { get; set; }
}