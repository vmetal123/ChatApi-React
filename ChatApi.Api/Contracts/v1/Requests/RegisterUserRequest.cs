using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApi.Api.Contracts.v1.Requests
{
    public class RegisterUserRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
