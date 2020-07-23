using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApi.Api.Contracts.v1.Responses
{
    public class LoginUserResponse: RegisterUserResponse
    {
        public string Token { get; set; }
        public string Email { get; set; }
    }
}
