using Microsoft.AspNetCore.SignalR;
using Switter.Web.Crocodile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Switter.Web.Crocodile.Hubs
{
    public class ChatHub : Hub
    {
        private static List<Player> players = new List<Player>();

        public async Task Send(string message, string userName)
        {
            await Clients.All.SendAsync("Send", message, userName);
        }

        public async Task Connect(string userName)
        {
            var id = Context.ConnectionId;

            if (!players.Any(x => x.ConnectionId == id))
            {
                players.Add(new Player { ConnectionId = id, Name = userName });
            }

            await Clients.All.SendAsync("Connect", userName);
        }

        public async Task MouseDown(int x, int y)
        {
            await Clients.All.SendAsync("MouseDown", x, y);
        }
        public async Task MouseMove(int x, int y)
        {
            await Clients.All.SendAsync("MouseMove", x, y);
        }
        public async Task MouseUp(int x, int y)
        {
            await Clients.All.SendAsync("MouseUp", x, y);
        }
    }
}
