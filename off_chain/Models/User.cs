using System.ComponentModel.DataAnnotations;

namespace off_chain.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string PublicKey { get; set; }
        public byte[] PublicKeyHash { get; set; }
        public byte[] PublicKeySalt { get; set; }
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime TokenCreated { get; set; }
        public DateTime TokenExpires { get; set; }
        

    }
}
