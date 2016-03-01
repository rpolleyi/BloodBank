using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using LifeLine.Core.Models;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using LifeLine.Core.Interfaces;
using LifeLine.Infrastructure;
using TrackerEnabledDbContext.Common.Interfaces;

namespace LifeLine.Web
{
    [Authorize]
    public class SiteActivityHub : Hub
    {
        public override Task OnConnected()
        {
            BloodDonorContext context = new BloodDonorContext();

            Clients.All.loadCampDetails(context.Camps.Count());
            Clients.All.loadDonorStatNumber(context.Persons.Count());
            return base.OnConnected();
        }

    }
}