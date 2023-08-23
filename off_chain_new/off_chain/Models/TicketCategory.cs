using System.ComponentModel.DataAnnotations;

namespace off_chain.Models
{
    public class TicketCategory
    {
        [Key]
        public int Id { get; set; }

        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Area { get; set; }


    }
}
