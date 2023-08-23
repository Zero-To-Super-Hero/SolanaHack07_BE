using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace off_chain.Models
{
    public class TicketPurchased
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Seat { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string EventTitle { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
        [Required]
        public string Address  { get; set; }
        [ForeignKey("PaymentId")]
        public string PaymentId { get; set; }
        public Payment Payment { get; set; }

    }
}
