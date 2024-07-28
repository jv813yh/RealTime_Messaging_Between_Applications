using Microsoft.AspNetCore.SignalR.Client;
using Real_Time_Messaging_Between_Applications.Services;
using Real_Time_Messaging_Between_Applications.ViewModels;
using System.Windows;

namespace Real_Time_Messaging_Between_Applications
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Create a new SignalR connection to the ColorChat hub
            HubConnection connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5249/colorChat")
                .Build();

            // Create a new SignalRChatService instance
            ISignalRChatService chatService = new SignalRChatService(connection);

            // Create a new ColorChatViewModel instance with the SignalRChatService
            // also is calls ConnectAsync to connect to the SignalR hub in the CreateColorChatViewModel method
            ColorChatViewModel chatViewModel = ColorChatViewModel.CreateColorChatViewModel(chatService);

            MainWindow mainWindow = new MainWindow()
            {
                // Set the DataContext of the MainWindow to the MainViewModel
                DataContext = new MainViewModel(chatViewModel)
            };

            mainWindow.Show();
        }
    }

}
