using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ServerSideCapstone.Models;

public class UserProfile
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    [NotMapped]
    public string UserName { get; set; }
    [NotMapped]
    public string Email { get; set; }
    public string IdentityUserId { get; set; }
    public IdentityUser IdentityUser { get; set; }
    public string? ImgLocation { get; set; }
    public string FullName
    {
        get
        {
            return $"{FirstName} {LastName}";
        }
    }

    public ShoppingCart ShoppingCart { get; set; }
}