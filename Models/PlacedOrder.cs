using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ServerSideCapstone.Models;

public class PlacedOrder
{
    public int Id { get; set; }
    public int ShoppingCartId { get; set; }
    public int UserPaymentDetailsId { get; set; }
    public DateTime PlacedOn { get; set; }

}