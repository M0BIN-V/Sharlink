using Microsoft.AspNetCore.SignalR;
using Sharlink.Server.Models;

namespace Sharlink.Server;

public class ChatHub : Hub
{
    public async Task SendMessage(MessageModel message)
    {
        await Clients.All.SendAsync("ReciveMessage", message);
    }
}
