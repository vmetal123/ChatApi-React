using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApi.Api.Contracts.v1.Responses
{
    public class SendMessageResponse
    {
        public bool Success { get; set; }
        public string Error { get; set; }
        public string User { get; set; }
        public string UserId { get; set; }
    }
}
