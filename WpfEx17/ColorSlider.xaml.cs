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

namespace WpfEx17
{
    /// <summary>
    /// Логика взаимодействия для ColorSlider.xaml
    /// </summary>
    public partial class ColorSlider : UserControl
    {
        public static DependencyProperty ColorProperty =
            DependencyProperty.Register(
                "Color",
                typeof(Color),
                typeof(ColorSlider),
                new FrameworkPropertyMetadata(
                    Colors.Black,
                    new PropertyChangedCallback(OnColorChanged))
                );

        private static void OnColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Color newColor = (Color)e.NewValue;
            ColorSlider colorSlider = (ColorSlider)d;
            colorSlider.Red = newColor.R;
            colorSlider.Green = newColor.G;
            colorSlider.Blue = newColor.B;
        }

        public static DependencyProperty RedProperty =
            DependencyProperty.Register(
                "Red",
                typeof(byte),
                typeof(ColorSlider),
                new FrameworkPropertyMetadata(
                    new PropertyChangedCallback(OnColorRGBCanged))
                );

        public static DependencyProperty GreenProperty =
            DependencyProperty.Register(
                "Green",
                typeof(byte),
                typeof(ColorSlider),
                new FrameworkPropertyMetadata(
                    new PropertyChangedCallback(OnColorRGBCanged))
                );
        public static DependencyProperty BlueProperty =
            DependencyProperty.Register(
                "Blue",
                typeof(byte),
                typeof(ColorSlider),
                new FrameworkPropertyMetadata(
                    new PropertyChangedCallback(OnColorRGBCanged))
                );

        private static void OnColorRGBCanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ColorSlider colorSlider = (ColorSlider)d;
            Color color = colorSlider.Color;
            if (e.Property == RedProperty)
                color.R = (byte)e.NewValue;
            else if (e.Property == GreenProperty)
                color.G = (byte)e.NewValue;
            else if (e.Property == BlueProperty)
                color.B = (byte)e.NewValue;

            colorSlider.Color = color;
        }

        public Color Color
        {
            get => (Color)GetValue(ColorProperty);
            set => SetValue(ColorProperty, value);
        }
        public byte Red
        {
            get => (byte)GetValue(RedProperty);
            set => SetValue(RedProperty, value);
        }
        public byte Green
        {
            get => (byte)GetValue(GreenProperty);
            set => SetValue(GreenProperty, value);
        }
        public byte Blue
        {
            get => (byte)GetValue(BlueProperty);
            set => SetValue(BlueProperty, value);
        }

        public static readonly RoutedEvent ColorChangedEvent =
            EventManager.RegisterRoutedEvent(
                "ColorChanged", 
                RoutingStrategy.Bubble,
                typeof(RoutedPropertyChangedEventHandler<Color>), 
                typeof(ColorSlider));

        public event RoutedPropertyChangedEventHandler<Color> ColorChanged
        {
            add { AddHandler(ColorChangedEvent, value); }
            remove { RemoveHandler(ColorChangedEvent, value); }
        }

        public ColorSlider()
        {
            InitializeComponent();
        }
    }
}
