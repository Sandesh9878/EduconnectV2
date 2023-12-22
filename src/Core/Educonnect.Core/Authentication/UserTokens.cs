using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educonnect.Core.Authentication
{
    public class UserTokens
    {
        public string? token { get; set; }
        public DateTime expiration { get; set; }
        public TimeSpan validity { get; set; }
        public string? token_type { get; set; }
        public string? userId { get; set; }
        public string? userName { get; set; }
        public string? email { get; set; }
    }
}
