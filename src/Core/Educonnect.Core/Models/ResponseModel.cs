using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educonnect.Core.Models
{
    public class ResponseModel
    {
        public string Status { get; set; } = ResponseStatus.Success;
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
