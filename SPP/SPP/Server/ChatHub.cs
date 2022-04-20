using Microsoft.AspNetCore.SignalR;

namespace Server;

public class ChatHub : Hub
{
    public async Task Send(string user, string message)
    {
        await Clients.All.SendAsync("Send", user, message);
    }
    
    public async Task SendToPerson(string connectionId,string user ,string message)
    {
        await Clients.Client(connectionId).SendAsync("SendToPerson", user, message);
    }
}