using System.ComponentModel.DataAnnotations.Schema;

namespace off_chain
{
    [NotMapped]
    public class UserDto
    {
        public string PublicKey { get; set; } = string.Empty;
    }
}
