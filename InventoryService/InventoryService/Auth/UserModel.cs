using System.ComponentModel.DataAnnotations;

namespace InventoryService.Auth
{
    public class UserModel
    {
        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
