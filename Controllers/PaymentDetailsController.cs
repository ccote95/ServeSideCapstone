using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServerSideCapstone.Data;
using ServerSideCapstone.Models;
using ServerSideCapstone.Models.DTOs;

[ApiController]
[Route("api/[controller]")]
public class PaymentDetailsController : ControllerBase
{
    private ServerSideCapstoneDbContext _dbContext;

    public PaymentDetailsController(ServerSideCapstoneDbContext context)
    {
        _dbContext = context;
    }

    [HttpPost]
    [Authorize]
    public IActionResult AddNewCard(PaymentDetailsForAddingCardDTO newCard)
    {
        PaymentDetails addCard = new PaymentDetails()
        {
            UserProfileId = newCard.UserProfileId,
            CreditCardNumber = newCard.CreditCardNumber,
            CreditCardExpiration = newCard.CreditCardExpiration
        };

        _dbContext.PaymentDetails.Add(addCard);
        _dbContext.SaveChanges();

        return Ok(addCard);
    }

    [HttpGet]
    [Authorize]
    public IActionResult GetAllByUserId(int id)
    {
        return Ok(_dbContext.PaymentDetails
        .Include(pd => pd.UserProfile)
        .Where(pd => pd.UserProfileId == id)
        .Select(pd => new PaymentDetailsDTO()
        {
            Id = pd.Id,
            UserProfileId = pd.UserProfileId,
            UserProfile = new UserProfileDTO()
            {
                Id = pd.UserProfile.Id,
                FirstName = pd.UserProfile.FirstName,
                LastName = pd.UserProfile.LastName,
                Address = pd.UserProfile.Address
            },
            CreditCardNumber = pd.CreditCardNumber,
            CreditCardExpiration = pd.CreditCardExpiration
        }).ToList());

    }

    [HttpGet("{id}")]
    [Authorize]
    public IActionResult GetCardById(int id)
    {
        return Ok(_dbContext.PaymentDetails
        .Select(pd => new PaymentDetailsDTO()
        {
            Id = pd.Id,
            UserProfileId = pd.UserProfileId,
            CreditCardNumber = pd.CreditCardNumber,
            CreditCardExpiration = pd.CreditCardExpiration
        })

        .FirstOrDefault(pd => pd.Id == id));
    }

    [HttpPut("{id}")]
    [Authorize]
    public IActionResult UpdateCardDetails(int id, PaymentDetailsDTO updateCard)
    {
        PaymentDetails cardToUpdate = _dbContext.PaymentDetails.FirstOrDefault(pd => pd.Id == id);

        cardToUpdate.CreditCardNumber = updateCard.CreditCardNumber;
        cardToUpdate.CreditCardExpiration = updateCard.CreditCardExpiration;

        _dbContext.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize]
    public IActionResult RemoveCard(int id)
    {
        PaymentDetails foundCard = _dbContext.PaymentDetails.FirstOrDefault(pd => pd.Id == id);

        _dbContext.PaymentDetails.Remove(foundCard);
        _dbContext.SaveChanges();

        return NoContent();
    }
}