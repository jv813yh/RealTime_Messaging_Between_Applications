using ColorChat.Domain.Models;
using Real_Time_Messaging_Between_Applications.Services;
using Real_Time_Messaging_Between_Applications.ViewModels;
using System.Windows.Input;

namespace Real_Time_Messaging_Between_Applications.Commands
{
    // SendColorCharMessageCommand class that implements the ICommand interface
    // to send a color message
    public class SendColorCharMessageCommand : ICommand
    {
        private readonly ColorChatViewModel _colorChatViewModel;
        private readonly ISignalRChatService _signalRChatService;

        public event EventHandler? CanExecuteChanged;

        public SendColorCharMessageCommand(ColorChatViewModel colorChatColorViewModel, ISignalRChatService signalRChat)
        {
            _colorChatViewModel = colorChatColorViewModel;
            _signalRChatService = signalRChat;
        }

        public bool CanExecute(object? parameter)
            => true;

        // Send the color message to the SignalR hub when the command is executed
        public async void Execute(object? parameter)
        {
            try
            {
                // Create a new ColorChatModel object with the RGB values
                ColorChatModel colorChatModel = new ColorChatModel
                {
                    Red = _colorChatViewModel.Red,
                    Green = _colorChatViewModel.Green,
                    Blue = _colorChatViewModel.Blue
                };

                // Send the color message to the SignalR hub
                await _signalRChatService.SendColorMessageAsync(colorChatModel);

                // Clear the error message
                _colorChatViewModel.ErrorMessage = string.Empty;
            }
            catch (Exception)
            {
                _colorChatViewModel.ErrorMessage = "Unable to send color message";
            }
        }
    }
}
