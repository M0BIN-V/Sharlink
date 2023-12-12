using Microsoft.AspNetCore.SignalR.Client;
using Sharlink.Client;

var hubConnection = new HubConnectionBuilder()
    .WithUrl("https://localhost:7236/chatHub")
    .Build();

await hubConnection.StartAsync();

hubConnection.On("ReciveMessage", (MessageModel message) =>
{
    Console.WriteLine(message.UserName);
});

await hubConnection.InvokeAsync("SendMessage", new MessageModel
{
    UserName = "testUser",
    Content = "testcontent"
});

Console.ReadLine();