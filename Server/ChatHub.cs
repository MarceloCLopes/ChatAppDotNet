using Microsoft.AspNetCore.SignalR;

namespace Server;

public class ChatHub : Hub
{
    public override Task OnConnectedAsync()
    {
        Console.WriteLine("Temos uma nova conexão!!!");
        return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        Console.WriteLine("O usuário saiu!!!");
        return base.OnDisconnectedAsync(exception);
    }

    public async Task JoinRoom(string name, string room)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, room);
        await Clients.Group(room).SendAsync("ReceiveMessage", $"{name} entrou na sala {room}");
    }
}
