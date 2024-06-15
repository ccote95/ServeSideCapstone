using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ServerSideCapstone.Models;

public class PaymentDetailsDTO
{
    public int Id { get; set; }
    public int UserProfileId { get; set; }
    public int CreditCardNumber { get; set; }
    public DateTime CreditCardExpiration { get; set; }
}