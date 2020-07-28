using ChatApi.Api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ChatApi.Api.Services
{
    public class CurrentUserService: ICurrentUserService
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public CurrentUserService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public string GetUserId() => _contextAccessor.HttpContext.User.FindFirst(x => x.Value == "Id").Value;

        public string GetUserName() => _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email).Value;
    }
}
