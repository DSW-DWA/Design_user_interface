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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int _count = 1;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ChangeColor_MainWindow(object sender, RoutedEventArgs e)
        {
            if (_count % 2 == 1 ) 
            {
                Random r = new Random();
                Brush brush = new SolidColorBrush(Color.FromRgb((byte)r.Next(1, 255),
                                  (byte)r.Next(1, 255), (byte)r.Next(1, 233)));
                Application.Current.MainWindow.Background = brush;
            }
            else
            {
                Application.Current.MainWindow.Background = new SolidColorBrush(Color.FromRgb(255,
                                  255, 255));
            }
            _count++;
        }
        private void ChangeColor_Red(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Background = new SolidColorBrush(Color.FromRgb(255,
                                0, 0));
        }
        private void ChangeColor_Green(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Background = new SolidColorBrush(Color.FromRgb(0,
                                128, 0));
        }
        private void ChangeColor_Yellow(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Background = new SolidColorBrush(Color.FromRgb(255,
                                255, 0));
        }
    }
}
