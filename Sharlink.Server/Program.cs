using Sharlink.Server;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();

var app = builder.Build();

app.MapHub<ServerChatHub>("/chatHub");

app.Run();
