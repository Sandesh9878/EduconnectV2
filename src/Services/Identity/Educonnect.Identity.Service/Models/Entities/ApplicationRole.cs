using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Educonnect.Identity.Service.Models.Entities
{
    [Table("Roles")]
    public class ApplicationRole : IdentityRole
    {
        public bool Active { get; set; }
        public bool IsSystemRole { get; set; }
        public string? Description { get; set; }
        public int? Type { get; set; }
        public int? TenantId { get; set; }
        public string? DisplayName { get; set; }
    }
}
