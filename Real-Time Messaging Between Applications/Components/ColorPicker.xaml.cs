using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Real_Time_Messaging_Between_Applications.Components
{
    /// <summary>
    /// Interaction logic for ColorPicker.xaml
    /// </summary>
    public partial class ColorPicker : UserControl
    {
        public static readonly DependencyProperty RedProperty =
            DependencyProperty.Register(nameof(Red), typeof(byte), typeof(ColorPicker), 
                new FrameworkPropertyMetadata((byte)0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnColorPropertyChanged));
        public byte Red
        {
            get { return (byte)GetValue(RedProperty); }
            set { SetValue(RedProperty, value); }
        }

        public static readonly DependencyProperty GreenProperty =
            DependencyProperty.Register(nameof(Green), typeof(byte), typeof(ColorPicker), 
                new FrameworkPropertyMetadata((byte)0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnColorPropertyChanged));
        public byte Green
        {
            get { return (byte)GetValue(GreenProperty); }
            set { SetValue(GreenProperty, value); }
        }

        public static readonly DependencyProperty BlueProperty =
            DependencyProperty.Register(nameof(Blue), typeof(byte), typeof(ColorPicker),
                new FrameworkPropertyMetadata((byte)0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnColorPropertyChanged));

        public byte Blue
        {
            get { return (byte)GetValue(BlueProperty); }
            set { SetValue(BlueProperty, value); }
        }

        public static readonly DependencyProperty ColorBrushProperty =
            DependencyProperty.Register(nameof(ColorBrush), typeof(Brush), typeof(ColorPicker), 
                new FrameworkPropertyMetadata(new SolidColorBrush(Colors.Black)));
        public Brush ColorBrush
        {
            get { return (Brush)GetValue(ColorBrushProperty); }
            set { SetValue(ColorBrushProperty, value); }
        }

        public ColorPicker()
        {
            InitializeComponent();
        }
        private static void OnColorPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if(d is ColorPicker colorPicker)
            {
                colorPicker.ColorBrush = new SolidColorBrush(Color.FromRgb(colorPicker.Red, colorPicker.Green, colorPicker.Blue));
            }
        }
    }
}
