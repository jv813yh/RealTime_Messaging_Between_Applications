using ColorChat.Domain.Models;
using System.Windows.Media;

namespace Real_Time_Messaging_Between_Applications.ViewModels
{
    public class ColorChatColorViewModel : ViewModelBase
    {
        public ColorChatModel ColorChat { get; set; }

        // This property will return a SolidColorBrush with the color of the ColorChat
        // for the fill of the Rectangle in the ColorChatView
        public Brush ColorBrush
        {
            get 
            {
                try
                {   
                    return new SolidColorBrush(Color.FromRgb(
                            ColorChat.Red,
                            ColorChat.Green,
                            ColorChat.Blue));
                }
                catch (Exception)
                {

                    return new SolidColorBrush(Colors.Black);
                }
            }

        }

        public ColorChatColorViewModel(ColorChatModel colorChat)
        {
            ColorChat = colorChat;
        }
    }
}
