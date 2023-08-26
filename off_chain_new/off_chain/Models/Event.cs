using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace off_chain.Models
{
    public class Event
    {
        [Key] 
        public int Id { get; set; }
        [Required]
        public string CollectionAddress { get; set; }
        [Required]
        public string WalletAddress { get; set; }
       
    }
}
