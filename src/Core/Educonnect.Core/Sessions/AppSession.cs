using Educonnect.Core.Enums;
using Microsoft.AspNetCore.Http;

namespace Educonnect.Core.Sessions
{
    public class AppSession : IAppSession
    {
        private IHttpContextAccessor _httpContextAccessor;
        public AppSession(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public string UserId
        {

            get
            {
                var userIdClaim = _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == "Id");
                if (string.IsNullOrEmpty(userIdClaim?.Value))
                {
                    return null;
                }
                return userIdClaim.Value;

            }
        }
        public string Role
        {

            get
            {

                var userIdClaim = _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == AppClaimTypes.Role);
                if (string.IsNullOrEmpty(userIdClaim?.Value))
                {
                    return null;
                }
                return userIdClaim.Value;

            }
        }
        public string RoleId
        {

            get
            {
                //var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
                //var userIdClaim = identity.Claims.FirstOrDefault(c => c.Type == AppClaimTypes.RoleId);
                var userIdClaim = _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == AppClaimTypes.RoleId);
                if (string.IsNullOrEmpty(userIdClaim?.Value))
                {
                    return null;
                }
                return userIdClaim.Value;

            }
        }
        public int? TenantId
        {
            get
            {
                //var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
                //var tenantIdClaim = identity.Claims.FirstOrDefault(c => c.Type == AppClaimTypes.TenantId);
                var tenantIdClaim = _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == AppClaimTypes.TenantId);
                if (!string.IsNullOrEmpty(tenantIdClaim?.Value))
                {
                    return Convert.ToInt32(tenantIdClaim.Value);
                }
                return null;
            }
        }


        public TenantSide? TenantSide
        {
            get
            {
                //var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
                //var tenantIdClaim = identity.Claims.FirstOrDefault(c => c.Type == AppClaimTypes.TenantSide);
                var tenantIdClaim = _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == AppClaimTypes.TenantSide);
                if (!string.IsNullOrEmpty(tenantIdClaim?.Value))
                {
                    return (TenantSide)Convert.ToInt32((tenantIdClaim.Value));
                }
                return null;
            }
        }
        public string ProfilePicture
        {
            get
            {
                //var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
                //var tenantIdClaim = identity.Claims.FirstOrDefault(c => c.Type == AppClaimTypes.ProfilePicture);
                var tenantIdClaim = _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == AppClaimTypes.ProfilePicture);
                if (!string.IsNullOrEmpty(tenantIdClaim?.Value))
                {
                    return tenantIdClaim.Value;
                }
                return null;
            }
        }
        //for email of user
        public string UserName
        {

            get
            {
                var userIdClaim = _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == AppClaimTypes.UserName);
                if (string.IsNullOrEmpty(userIdClaim?.Value))
                {
                    return null;
                }
                return userIdClaim.Value;

            }
        }
    }

}
