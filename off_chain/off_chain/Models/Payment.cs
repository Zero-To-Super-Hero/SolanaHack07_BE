using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace off_chain.Models
{
    public class Payment
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public DateTime PayTime { get; set; }
        [Required]
        public string Status { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public User User { get; set; }

        public ICollection<PaymentDetails> PaymentDetails { get; set; }
        
    }
}
