using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using ServerSideCapstone.Models.DTOs;

namespace ServerSideCapstone.Models;

public class PaymentDetailsDTO
{
    public int Id { get; set; }
    public int UserProfileId { get; set; }
    public UserProfileDTO UserProfile { get; set; }
    public string CreditCardNumber { get; set; }
    public DateTime CreditCardExpiration { get; set; }
    public string FormattedCreateDateTime => CreditCardExpiration.Date.ToString("MM-dd-yyyy");
}