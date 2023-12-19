using Sharlink.Client.Cli.Utilities;
using Sharlink.Client.Hub;
using Sharlink.Client.Hub.Models;
using System.Text;

Console.OutputEncoding = Encoding.Unicode;
Console.InputEncoding = Encoding.Unicode;

Console.Write("Enter your name : ");
var userName = Console.ReadLine() ?? "Guest";
var viewer = new ConsoleViewer(userName);

var chatHub = new ClientChatHub(
    serverUrl: "https://sharlink.liara.run/chathub");
await chatHub.Start(viewer.ShowMessage);

Console.Clear();

viewer.ShowInput();

while (true)
{
    var content = Console.ReadLine();

    if (!string.IsNullOrWhiteSpace(content))
    {
        chatHub.SendMessage(new Message
        {
            UserName = userName,
            Content = content
        });
    }
}