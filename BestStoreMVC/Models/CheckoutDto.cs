using System.ComponentModel.DataAnnotations;

namespace BestStoreMVC.Models
{
    public class CheckoutDto
    {
        [Required(ErrorMessage = "The Delivery Address is Required.")]
        [MaxLength(200)]
        public string DeliveryAddress { get; set; } = "";
        public string PaymentMethod { get; set; } = "";
    }
}
