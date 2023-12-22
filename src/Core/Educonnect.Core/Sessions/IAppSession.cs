using Educonnect.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educonnect.Core.Sessions
{
    public interface IAppSession
    {
        string UserId { get; }
        int? TenantId { get; }
        TenantSide? TenantSide { get; }
        string RoleId { get; }
        string ProfilePicture { get; }
        string UserName { get; }
    }
}
