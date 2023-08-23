using System.ComponentModel.DataAnnotations;

namespace off_chain.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string PublicKey { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public ICollection<Event> Events { get; set; }

    }
}
