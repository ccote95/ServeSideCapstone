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
    public IFormFile FormFile { get; set; }
    [Required]
    public string Content { get; set; }
    public List<int> CategoryIds { get; set; }


}