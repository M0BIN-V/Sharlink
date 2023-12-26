using Microsoft.AspNetCore.SignalR;
using Sharlink.Server.Models;

namespace Sharlink.Server;

public class ServerChatHub : Hub
{
    private readonly ILogger<ServerChatHub> _logger;

    public ServerChatHub(ILogger<ServerChatHub> logger)
    {
        _logger = logger;
    }

    public override Task OnConnectedAsync()
    {
        _logger.LogInformation($"New Uesr => {Context.ConnectionId}");
        return base.OnConnectedAsync();
    }

    public async Task SendMessage(MessageModel message)
    {
        await Clients.All.SendAsync("ReciveMessage", message);
    }
}
