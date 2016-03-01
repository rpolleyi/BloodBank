using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LifeLine.Core.Models;

namespace LifeLine.Core.Interfaces
{
    /// <summary>
    /// currently Online Users reporsitory interface for DB CRUD(SignalR)
    /// </summary>
    public interface IOnlineUserRepository
    {
        void Add(UserModel user);
        void Edit(UserModel user);
        void Remove(string userName);

        IEnumerable<UserModel> GetOnlineUsers();
        IEnumerable<UserModel> FindByName(string userName);
        IEnumerable<UserModel> FindOnlineUsersByPageName(string pageName,int donorId);

    }
}
