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

namespace lab_4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MessageBox.Show("Привет, мир! \nПривет, мир! \nПривет, мир!");
        }
        private void Button_Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Button_Resize(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Width = 800;
            Application.Current.MainWindow.Height = 450;
        }
        private void MouseMoveEvent(object sender, MouseEventArgs e)
        {
            Random r = new Random();
            var red = (byte)((Mouse.GetPosition(this).X * 255) / Application.Current.MainWindow.Width);
            var green = (byte)((Mouse.GetPosition(this).X * 255) / Application.Current.MainWindow.Width);
            var blue = (byte)((Mouse.GetPosition(this).Y * 255) / Application.Current.MainWindow.Height);
            Brush brush = new SolidColorBrush(Color.FromRgb(red,green,blue));
            Application.Current.MainWindow.Background = brush;
        }

    }
}
