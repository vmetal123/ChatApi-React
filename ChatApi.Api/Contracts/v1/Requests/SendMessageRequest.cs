using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApi.Api.Contracts.v1.Requests
{
    public class SendMessageRequest
    {
        public string Text { get; set; }
        public string To { get; set; }
    }
}
