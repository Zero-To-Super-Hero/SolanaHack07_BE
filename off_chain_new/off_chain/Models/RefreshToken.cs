using System.ComponentModel.DataAnnotations.Schema;

namespace off_chain
{

    [NotMapped]
    public class RefreshToken
    {
        public string Token { get; set; } = string.Empty;
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Expires { get; set; }
    }
}
