using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApi.Api.Services.Interfaces
{
    public interface ICurrentUserService
    {
        string GetUserId();
        string GetUserName();
    }
}
