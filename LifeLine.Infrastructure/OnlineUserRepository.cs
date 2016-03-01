using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LifeLine.Core.Interfaces;
using LifeLine.Core.Models;

namespace LifeLine.Infrastructure
{
    public class OnlineUserRepository : IOnlineUserRepository
    {
        BloodDonorContext context = new BloodDonorContext();
        public void Add(UserModel user)
        {
            context.OnlineUsers.Add(user);
            context.SaveChanges();
        }

        public void Edit(UserModel user)
        {
            context.SaveChanges(user);
        }

        public void Remove(string userName)
        {
            var b = (from r in context.OnlineUsers where r.Name == userName select r);
            context.OnlineUsers.RemoveRange(b);
            context.SaveChanges();
        }

        public IEnumerable<UserModel> GetOnlineUsers()
        {
            return context.OnlineUsers;
        }

        public IEnumerable<UserModel> FindByName(string userName)
        {
            var user = (from r in context.OnlineUsers where r.Name == userName select r);
            return user;
        }

        public IEnumerable<UserModel> FindOnlineUsersByPageName(string pageName, int donorId)
        {
            var user = (from r in context.OnlineUsers where r.PageName == pageName && r.DonorId == donorId && r.IsActive == true select r);
            return user;
        }
    }
}
