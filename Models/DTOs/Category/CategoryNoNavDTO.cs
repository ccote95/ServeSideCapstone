using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ServerSideCapstone.Models.DTOs;
public class CategoryNoNavDTO
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

}