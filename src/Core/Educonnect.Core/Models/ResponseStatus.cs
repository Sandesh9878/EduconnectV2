using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educonnect.Core.Models
{
    public class ResponseStatus
    {
        const string _success = "success";
        const string _error = "error";
        public static string Success => _success;
        public static string Error => _error;
    }
}
