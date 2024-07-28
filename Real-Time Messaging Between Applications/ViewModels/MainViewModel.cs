namespace Real_Time_Messaging_Between_Applications.ViewModels
{
    public class MainViewModel 
    {
        // This property will hold the ColorChatViewModel on the MainWindow
        public ColorChatViewModel ChatColorViewModel { get; }

        public MainViewModel(ColorChatViewModel chatViewModel)
        {
            ChatColorViewModel = chatViewModel;
        }
    }
}
