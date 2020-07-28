using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApi.Api.Models.Hub
{
    public class UserConnected
    {
        public string ConnectionId { get; set; }
        public string UserName { get; set; }
    }
}
