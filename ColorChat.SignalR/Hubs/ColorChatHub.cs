using ColorChat.Domain.Models;
using Microsoft.AspNetCore.SignalR;

namespace ColorChat.SignalR.Hubs
{
    // SignalR hub for the color chat
    public class ColorChatHub : Hub
    {
        // Method to raise the connection new client event
        public override Task OnConnectedAsync()
        {
            Console.WriteLine($"*** Client connected: {Context.ConnectionId} ***");
            return base.OnConnectedAsync();
        }

        // Method to raise the disconnection event
        public override Task OnDisconnectedAsync(Exception? exception)
        {
            Console.WriteLine($"*** Client disconected: {Context.ConnectionId} ***");
            return base.OnDisconnectedAsync(exception);
        }

        // Method to send a color message to all clients, as parameter we use the name of fuction
        // that will be called on the client side
        public async Task SendColorMessageAsync(ColorChatModel colorChatModel)
        {
            await Clients.All.SendAsync("ReceiveColorMessage", colorChatModel);
        }
    }
}
