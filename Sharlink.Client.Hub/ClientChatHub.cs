using Sharlink.Client.Hub.Models;
using Microsoft.AspNetCore.SignalR.Client;

namespace Sharlink.Client.Hub;

public class ClientChatHub
{
    readonly HubConnection _connection;
    public ClientChatHub()
    {
        string serverUrl;

#if DEBUG
        serverUrl = "https://localhost:7236/chathub";
#else
        serverUrl = "https://sharlink.liara.run/chathub";
#endif
        _connection =
       new HubConnectionBuilder().WithUrl(serverUrl).Build();
    }

    public async Task StartAsync(Action<Message> action)
    {
        await _connection.StartAsync();

        _connection.On("ReciveMessage", action);
    }

    public async void SendMessage(Message message)
    {
        await _connection.InvokeAsync("SendMessage", message);
    }
}
