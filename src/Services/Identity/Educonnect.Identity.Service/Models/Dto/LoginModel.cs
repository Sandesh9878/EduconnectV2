using Educonnect.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace Educonnect.Identity.Service.API.Models.Dto
{
    public class LoginModel
    {
        [Required(ErrorMessage = "User Name is required")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }


        public TenantSide TenantSide { get; set; }
    }
}
