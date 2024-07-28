using ColorChat.Domain.Models;
using Real_Time_Messaging_Between_Applications.Commands;
using Real_Time_Messaging_Between_Applications.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Real_Time_Messaging_Between_Applications.ViewModels
{
    public class ColorChatViewModel : ViewModelBase
    {
        private byte _red;
        public byte Red
        {
            get => _red;
            set
            {
                _red = value;
                OnPropertyChanged(nameof(Red));
            }
        }

        private byte _green;
        public byte Green
        {
            get => _green;
            set
            {
                _green = value;
                OnPropertyChanged(nameof(Green));
            }
        }

        private byte _blue;
        public byte Blue
        {
            get => _blue;
            set
            {
                _blue = value;
                OnPropertyChanged(nameof(Blue));
            }
        }

        private string _errorMessage = string.Empty;
        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
                OnPropertyChanged(nameof(HasErrorMessage));
            }
        }

        public bool HasErrorMessage 
            => !string.IsNullOrEmpty(ErrorMessage);

        public ICommand SendColorChatMessageCommand { get; }

        // ObservableCollection to store the color messages received from the SignalR hub
        // and display them in the ColorChatView like rectagnles with the color
        public ObservableCollection<ColorChatColorViewModel> Messages { get; }

        public ColorChatViewModel(ISignalRChatService chatService)
        {
            Messages = new ObservableCollection<ColorChatColorViewModel>();
            SendColorChatMessageCommand = new SendColorCharMessageCommand(this, chatService);

            // Subscribe to the ColorMessageReceived event to add the color messages
            chatService.ColorMessageReceived += ChatService_ColorMessageReceived;
        }

        /// <summary>
        /// Create a new instance of the ColorChatViewModel and connect to the SignalR hub
        /// </summary>
        /// <param name="chatService"></param>
        /// <returns> Instance of ColorChatViewModel with the connection to the hub </returns>
        public static ColorChatViewModel CreateColorChatViewModel(ISignalRChatService chatService)
        {
            ColorChatViewModel colorChatViewModel = new ColorChatViewModel(chatService);

            // Connect to the SignalR hub when the view model is created
            chatService.ConnectAsync().ContinueWith(task =>
            {

                if(task.Exception != null)
                {
                    colorChatViewModel.ErrorMessage = $"{task.Exception.Message}";
                }

            });

            return colorChatViewModel;
        }

        // Method to invoke when a color message is received
        private void ChatService_ColorMessageReceived(ColorChatModel model)
        {
            //Messages.Add(new ColorChatColorViewModel(model));

            // Invoke the dispatcher to update the UI to add the new color message to the ObservableCollection
            App.Current.Dispatcher.Invoke(() =>
            {
                Messages.Add(new ColorChatColorViewModel(model));
            });
        }
    }
}
