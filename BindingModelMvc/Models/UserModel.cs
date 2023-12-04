using System.ComponentModel.DataAnnotations;

namespace BindingModelMvc.BusinessLayer.Models
{
    public class UserModel
    {
        public int UserId { get; set; }

        [Required]
        public string UserName { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
