using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace off_chain.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Seat { get; set; }
        [ForeignKey("EventId")]
        public int EventId { get; set; }
        public Event Event { get; set; }

        [ForeignKey("TicketCategoryId")]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // Tùy chọn này ngăn chặn auto-increment
        public int TicketCategoryId { get; set; }
        public TicketCategory TicketCategory { get; set; }



    }
}
