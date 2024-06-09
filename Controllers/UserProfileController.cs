using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServerSideCapstone.Data;
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
}