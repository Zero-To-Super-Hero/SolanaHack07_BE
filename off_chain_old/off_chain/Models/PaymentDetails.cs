using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace off_chain.Models
{
    public class PaymentDetails
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        public string Total { get; set; }
        [ForeignKey("PaymentId")]
        public string PaymentId { get; set; }
        public Payment Payment { get; set; }
    }
}
