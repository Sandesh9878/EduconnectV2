using System.Security.Claims;

namespace Educonnect.Core.Sessions
{
    public static class AppClaimTypes
    {
        /// <summary>
        /// UserId.
        /// Default: <see cref="ClaimTypes.Name"/>
        /// </summary>
        public static string UserName { get; set; } = ClaimTypes.Name;

        /// <summary>
        /// UserId.
        /// Default: <see cref="ClaimTypes.NameIdentifier"/>
        /// </summary>
        public static string UserId { get; set; } = ClaimTypes.NameIdentifier;

        /// <summary>
        /// UserId.
        /// Default: <see cref="ClaimTypes.Role"/>
        /// </summary>
        public static string Role { get; set; } = ClaimTypes.Role;

        /// <summary>
        /// TenantId.
        /// Default: http://www.educonnect.com/identity/claims/tenantId
        /// </summary>
        public static string TenantId { get; set; } = "http://www.educonnect.com/identity/claims/tenantId";

        /// <summary>
        /// TenantId.
        /// Default: http://www.educonnect.com/identity/claims/tenantside
        /// </summary>
        public static string TenantSide { get; set; } = "http://www.educonnect.com/identity/claims/tenantside";
        /// <summary>
        /// TenantId.
        /// Default: http://www.educonnect.com/identity/claims/RoleId
        /// </summary>
        public static string RoleId { get; set; } = "http://www.educonnect.com/identity/claims/RoleId";
        public static string ProfilePicture { get; set; } = "http://www.educonnect.com/identity/claims/ProfilePic";
    }

}
