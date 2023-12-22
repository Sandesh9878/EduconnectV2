using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Educonnect.Core.Authentication
{
    public static class IdentityConstants
    {
        const string _connectionStringKey = "ConnectionStringKey";
        const string _name = ClaimTypes.Name;
        const string _email = ClaimTypes.Email;
        const string _role = ClaimTypes.Role;
        public static string ConnectionStringKey => _connectionStringKey;
        public static string Name => _name;
        public static string Email => _email;
        public static string Role => _role;
    }
}
