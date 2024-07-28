using ColorChat.Domain.Models;

namespace Real_Time_Messaging_Between_Applications.Services
{
    public interface ISignalRChatService
    {
        // This event will be raised when a new color message is received
        public event Action<ColorChatModel> ColorMessageReceived;

        // Connect to the SignalR hub
        Task ConnectAsync();

        // Send a color message to the SignalR hub
        Task SendColorMessageAsync(ColorChatModel colorChatModel);
    }
}
