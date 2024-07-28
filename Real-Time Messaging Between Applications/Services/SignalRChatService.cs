using ColorChat.Domain.Models;
using Microsoft.AspNetCore.SignalR.Client;

namespace Real_Time_Messaging_Between_Applications.Services
{
    public class SignalRChatService : ISignalRChatService
    {
        // SignalR connection to the hub
        private readonly HubConnection _hubConnection;

        // Event to be raised when a color message is received
        public event Action<ColorChatModel> ColorMessageReceived;
        public SignalRChatService(HubConnection hubConnection)
        {
            _hubConnection = hubConnection;

            // Register the ReceiveColorMessage event handler
            _hubConnection.On<ColorChatModel>("ReceiveColorMessage",
                (color) => ColorMessageReceived?.Invoke(color));
        }

        /// <summary>
        /// Async method to connect to the SignalR hub
        /// </summary>
        /// <returns></returns>
        public async Task ConnectAsync()
        {
            await _hubConnection.StartAsync();
        }

        /// <summary>
        /// Async method to send a color message, as parameter we use the name 
        /// of fuction that will be called on the server side
        /// </summary>
        /// <param name="colorChatModel"></param>
        /// <returns></returns>
        public async Task SendColorMessageAsync(ColorChatModel colorChatModel)
        {
            await _hubConnection.SendAsync("SendColorMessageAsync", colorChatModel);
        }
    }
}
