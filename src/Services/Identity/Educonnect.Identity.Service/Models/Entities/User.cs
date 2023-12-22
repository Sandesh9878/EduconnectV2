namespace Educonnect.Identity.Service.Models.Entities
{
    public class User
    {
        public string Id { get; set; }
        public bool Active { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Nullable<System.DateTime> LastActiveDate { get; set; }
        public System.DateTime CreateDate { get; set; }
        public bool IsSystemUser { get; set; }
        public string LastLoginIp { get; set; }
        public bool IsDeleted { get; set; }
        public Nullable<int> Type { get; set; }
        public Nullable<int> TenantId { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public Nullable<System.DateTime> LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string UserName { get; set; }
        public string ProfilePic { get; set; }
        public string Title { get; set; }
        public Nullable<int> Gender { get; set; }
        public Nullable<int> CountryId { get; set; }
        public Nullable<int> SignUpPlatform { get; set; }
        public bool IsLead { get; set; }
        public string NormalizedUserName { get; set; }
        public Nullable<System.DateTime> LockoutEnd { get; set; }
        public string NormalizedEmail { get; set; }
        public string ConcurrencyStamp { get; set; }
    }
}
