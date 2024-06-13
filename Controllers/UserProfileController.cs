using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServerSideCapstone.Data;
using ServerSideCapstone.Models;
using ServerSideCapstone.Models.DTOs;

[ApiController]
[Route("api/[controller]")]
public class UserProfileController : ControllerBase
{
    private ServerSideCapstoneDbContext _dbContext;

    public UserProfileController(ServerSideCapstoneDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    // [Authorize]
    public IActionResult GetById(int id)
    {
        return Ok(_dbContext.UserProfiles
        .Include(up => up.IdentityUser)
        .FirstOrDefault(up => up.Id == id));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProfile(int id, [FromForm] IFormFile image, [FromForm] string firstName, [FromForm] string lastName, [FromForm] string address)
    {
        UserProfile userProfile = _dbContext.UserProfiles
        .Include(up => up.IdentityUser)
        .SingleOrDefault(up => up.Id == id);
        if (userProfile == null)
        {
            return NotFound();
        }

        userProfile.FirstName = firstName;
        userProfile.LastName = lastName;
        userProfile.Address = address;

        if (image != null && image.Length > 0)
        {
            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "client", "public", "uploads");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            var filePath = Path.Combine(uploadsFolder, image.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(stream);
            }

            userProfile.ImgLocation = $"/uploads/{image.FileName}";
            await _dbContext.SaveChangesAsync();

        }
        return Ok(userProfile);

    }
}