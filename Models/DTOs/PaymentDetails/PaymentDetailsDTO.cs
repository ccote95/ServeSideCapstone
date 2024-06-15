using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ServerSideCapstone.Models;

public class PaymentDetailsDTO
{
    public int UserProfileId { get; set; }
    public string CreditCardNumber { get; set; }
    public DateTime CreditCardExpiration { get; set; }
}