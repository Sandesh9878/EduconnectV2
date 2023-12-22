using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;

namespace Educonnect.Identity.Service.API.Models.Entities
{
    [Table("Users")]
    public class ApplicationUser : IdentityUser
    {

        public bool Active { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? LastActiveDate { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsSystemUser { get; set; }
        public string? LastLoginIp { get; set; }
        public bool IsDeleted { get; set; }
        public string? ProfilePic { get; set; }
        public int? Gender { get; set; }
        public int? CountryId { get; set; }
        public string? Title { get; set; }
       
        [NotMapped]
        public string FullName
        {
            get
            {
                var name = FirstName + " " + LastName;
                if (string.IsNullOrWhiteSpace(name))
                {
                    return Email;
                }
                else
                {
                    return name;
                }
            }
        }

        public int? Type { get; set; }
        public int? TenantId { get; set; }

        public int? SignUpPlatform { get; set; }
        public bool IsLead { get; set; }
        [NotMapped]
        public string? RefreshToken { get; set; }
        [NotMapped]
        public DateTime? RefreshTokenExpiryTime { get; set; }
        //[NotMapped]
        //public override string NormalizedUserName
        //{
        //    get
        //    {
        //        return null;
        //    }
        //}

    }
}
