using ChatApi.Api.Models.Hub;
using ChatApi.Api.Services.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApi.Api.Services
{
    public class TrackingUsersService: ITrackingUsersService
    {
        private ConcurrentDictionary<string, UserConnected> UsersConnected { get; set; } = new ConcurrentDictionary<string, UserConnected>();

        public bool AddOrUpdate(string name, string connectionId)
        {
            var userAlreadyExists = UsersConnected.ContainsKey(name);

            var userConnected = new UserConnected { ConnectionId = connectionId, UserName = name };

            UsersConnected.AddOrUpdate(name, userConnected, (key, value) => userConnected);

            return userAlreadyExists;
        }

        public void Remove(string name)
        {
            UserConnected userConnected;
            UsersConnected.Remove(name, out userConnected);
        }

        public IEnumerable<UserConnected> GetAllUsersExceptThis(string name)
        {
            return UsersConnected.Values.Where(x => x.UserName != name);
        }

        public UserConnected GetUserInfo(string name)
        {
            UserConnected userConnected;
            UsersConnected.TryGetValue(name, out userConnected);
            return userConnected;
        }

    }
}
