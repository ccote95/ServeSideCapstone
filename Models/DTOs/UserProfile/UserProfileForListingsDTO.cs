using Microsoft.AspNetCore.Identity;

namespace ServerSideCapstone.Models.DTOs;

public class UserProfileForListingsDTO
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ImgLocation { get; set; }
    public string FullName
    {
        get
        {
            return $"{FirstName} {LastName}";
        }
    }




}