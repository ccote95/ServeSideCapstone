using Microsoft.AspNetCore.Identity;

namespace ServerSideCapstone.Models.DTOs;

public class UserProfileForShoppingCartDTO
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public string FullName
    {
        get
        {
            return $"{FirstName} {LastName}";
        }
    }




}