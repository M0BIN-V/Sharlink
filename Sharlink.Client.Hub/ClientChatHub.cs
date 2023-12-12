using Sharlink.Client.Hub.Models;
using Microsoft.AspNetCore.SignalR.Client;

namespace Sharlink.Client.Hub;

public class ClientChatHub(string serverUrl)
{
    readonly HubConnection _connection =
        new HubConnectionBuilder().WithUrl(serverUrl).Build();

    public async Task Start(Action<Message> action)
    {
        await _connection.StartAsync();

        _connection.On("ReciveMessage", action);
    }

    public async void SendMessage(Message message)
    {
        await _connection.InvokeAsync("SendMessage", message);
    }
}
