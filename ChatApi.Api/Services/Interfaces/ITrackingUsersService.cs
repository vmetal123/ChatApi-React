using ChatApi.Api.Models.Hub;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApi.Api.Services.Interfaces
{
    public interface ITrackingUsersService
    {
        bool AddOrUpdate(string name, string connectionId);
        void Remove(string name);
        IEnumerable<UserConnected> GetAllUsersExceptThis(string name);
        UserConnected GetUserInfo(string name);
    }
}
