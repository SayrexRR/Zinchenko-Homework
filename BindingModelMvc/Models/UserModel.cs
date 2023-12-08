using System.ComponentModel.DataAnnotations;

namespace BindingModelMvc.BusinessLayer.Models
{
    public class UserModel
    {
        public int UserId { get; set; }

        [Required]
        [StringLength(75)]
        [MinLength(3)]
        [RegularExpression(@"^[a-zA-Z0-9\S]*$")]
        public string UserName { get; set; }

        [EmailAddress]
        [MinLength(5)]
        public string? Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}
