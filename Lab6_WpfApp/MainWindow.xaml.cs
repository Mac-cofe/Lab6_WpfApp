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


// Разработать в WPF приложении класс WeatherControl, моделирующий погодную сводку – температуру(целое число в диапазоне от -50 до +50), 
// направление ветра(строка), скорость ветра(целое число), 
// наличие осадков(возможные значения: 0 – солнечно, 1 – облачно, 2 – дождь, 3 – снег.
//Можно использовать целочисленное значение, либо создать перечисление enum). Свойство «температура» преобразовать в свойство зависимости.

namespace Lab6_WpfApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    class WeatherControl : DependencyObject
    {
        public static readonly DependencyProperty TemptProperty;
        public Veter Wind;
        public Osadki Ocadki;


        public enum Veter
        {
            C = 0,
            Y = 1,
            Z = 3,
            V = 4,
            CZ = 5,
            YZ = 6,
            CV = 7,
            YV = 8,
        }


        public enum Osadki
        {

            Sun = 0,
            Cloudy = 1,
            Rain = 3,
            Snow = 4
        }


        public int Tempt
        {
            get => (int)GetValue(TemptProperty);
            set => SetValue(TemptProperty, value);
        }

        public WeatherControl(int tempt, Veter wind, Osadki ocadki)
        {
            this.Tempt = tempt;
            this.Wind = wind;
           this. Ocadki = ocadki;
        }

        static WeatherControl()
        {
            TemptProperty = DependencyProperty.Register(
                nameof(Tempt),
                typeof(int),
                typeof(WeatherControl),
                new FrameworkPropertyMetadata(
                    0,
                   FrameworkPropertyMetadataOptions.AffectsMeasure |
                   FrameworkPropertyMetadataOptions.AffectsRender,
                   null,
                   new CoerceValueCallback(CoerceTempt)),
                new ValidateValueCallback(ValidateTempt));
        }


        private static bool ValidateTempt(object value)
        {
            int t = (int)value;
            if (t >= -50 && t <= 50)
                return true;
            else
                return false;
        }

        private static object CoerceTempt(DependencyObject d, object baseValue)
        {
            int t = (int)baseValue;
            if (t >= -50 && t <= 50)
                return t;
            else return 0;
        }

    }





    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

        }

        private void start_Click(object sender, RoutedEventArgs e)
        {
            WeatherControl Weather1 = new WeatherControl(-2, (WeatherControl.Veter)2, (WeatherControl.Osadki)3);

            text1.Text = "Температура: " + Weather1.Tempt + " Ветер: ";   // проверка. Но как из enum получить именно значение, а не индекс???


        }
    }
}
