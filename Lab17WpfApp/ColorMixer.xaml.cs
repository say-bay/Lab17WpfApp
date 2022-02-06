using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab17WpfApp
{
    /// <summary>
    /// Логика взаимодействия для ColorMixer.xaml
    /// </summary>
    public partial class ColorMixer : UserControl
    {
        public static DependencyProperty ColorProperty;
        public static DependencyProperty RedProperty;
        public static DependencyProperty GreenProperty;
        public static DependencyProperty BlueProperty;
        public Color Color
        {
            get { return (Color)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }
        public byte Red
        {
            get { return (byte)GetValue(RedProperty); }
            set { SetValue(RedProperty, value); }
        }
        public byte Green
        {
            get { return (byte)GetValue(GreenProperty); }
            set { SetValue(GreenProperty, value); }
        }
        public byte Blue
        {
            get { return (byte)GetValue(BlueProperty); }
            set { SetValue(BlueProperty, value); }
        }

        public ColorMixer()
        {
            ColorProperty = DependencyProperty.Register("Color", typeof(Color), typeof(ColorMixer),
                new FrameworkPropertyMetadata(Colors.Black, new PropertyChangedCallback(OnColorChanged)));
            RedProperty = DependencyProperty.Register("Red", typeof(Color), typeof(ColorMixer),
    new FrameworkPropertyMetadata(Colors.Red, new PropertyChangedCallback(OnColorRGBChanged)));
            RedProperty = DependencyProperty.Register("Green", typeof(Color), typeof(ColorMixer),
new FrameworkPropertyMetadata(Colors.Green, new PropertyChangedCallback(OnColorRGBChanged)));
            RedProperty = DependencyProperty.Register("Blue", typeof(Color), typeof(ColorMixer),
    new FrameworkPropertyMetadata(Colors.Blue, new PropertyChangedCallback(OnColorRGBChanged)));
            InitializeComponent();
        }
        private static void OnColorRGBChanged(DependencyObject sender,
            DependencyPropertyChangedEventArgs e)
        {
            ColorMixer colorMixer = (ColorMixer)sender;
            Color color = colorMixer.Color;
            if (e.Property == RedProperty)
                color.R = (byte)e.NewValue;
            else if (e.Property == GreenProperty)
                color.G = (byte)e.NewValue;
            else if (e.Property == BlueProperty)
                color.B = (byte)e.NewValue;
            colorMixer.Color = color;
        }
        private static void OnColorChanged(DependencyObject sender,
            DependencyPropertyChangedEventArgs e)
        {
            Color newColor = (Color)e.NewValue;
            ColorMixer colormixer = (ColorMixer)sender;
            colormixer.Red = newColor.R;
            colormixer.Green = newColor.G;
            colormixer.Blue = newColor.B;
        }
    }
}
