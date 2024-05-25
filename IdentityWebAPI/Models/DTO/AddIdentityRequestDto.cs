using IdentityWebAPI.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace IdentityWebAPI.Models.DTO
{
    public class AddIdentityRequestDto
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Name has 50 characters maximum !")]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "City has 50 characters maximum !")]
        public string City { get; set; }

        [Required]
        public int ImageId { get; set; }

        [Required] 
        public Image Image { get; set; }
    }
}
