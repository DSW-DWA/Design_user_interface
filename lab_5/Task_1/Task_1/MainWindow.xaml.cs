using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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
using System.Media;

namespace Task_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _changeColor = true;
        public MainWindow()
        {
            InitializeComponent();
            var window = Window.GetWindow(this);
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen; 
        }
        public void CtrShortcut1(Object sender, ExecutedRoutedEventArgs e)
        {
            _changeColor = !_changeColor;
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (_changeColor)
            {
                double x = Math.Abs((double)e.GetPosition(this).X / Application.Current.MainWindow.Width * 255);
                double y = Math.Abs((double)e.GetPosition(this).Y / Application.Current.MainWindow.Height * 255);
                Brush brush = new SolidColorBrush(Color.FromRgb((byte)x, (byte)(y + 5), (byte)(y + 5)));
                Application.Current.MainWindow.Background = brush;
            }
        }
        private void Window_Close(Object sender, ExecutedRoutedEventArgs e)
        {
            var result = MessageBox.Show("Закрыть?", "Закрытие", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes) this.Close();
        }
        private void Window_Unshrink(Object sender, ExecutedRoutedEventArgs e)
        {
            var window = Window.GetWindow(this);
            window.Left -= 5;
            window.Top -= 5;
            window.Height += 10;
            window.Width += 10;
        }
        private void Window_Shrink(Object sender, ExecutedRoutedEventArgs e)
        {
            var window = Window.GetWindow(this);
            window.Left += 5;
            window.Top += 5;
            window.Height -= 10;
            window.Width -= 10;
        }
        private void Window_Center(Object sender, ExecutedRoutedEventArgs e)
        {
            var window = Window.GetWindow(this);
            window.Left += (Mouse.GetPosition(this).X - window.Width/2);
            window.Top += (Mouse.GetPosition(this).Y - window.Height/2);
        }

        private void Window_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var result = MessageBox.Show("Закрыть?", "Закрытие", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes) this.Close();
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            var window = Window.GetWindow(this);
            if (e.Key == Key.Down)
            {
                window.Top += 20;
            }
            if (e.Key == Key.Up)
            {
                window.Top -= 20;
            }
            if (e.Key == Key.Left)
            {
                window.Left -= 20;
            }
            if (e.Key == Key.Right)
            {
                window.Left += 20;
            }
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var window = Window.GetWindow(this);
            SystemSounds.Beep.Play();
            window.Title = $"Лаб 6 Чупеев Андрей | {window.Width}x{window.Height}";
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var window = Window.GetWindow(this);
            if (Mouse.LeftButton == MouseButtonState.Pressed && Mouse.RightButton == MouseButtonState.Pressed)
            {
                window.Left += (Mouse.GetPosition(this).X - window.Width / 2);
                window.Top += (Mouse.GetPosition(this).Y - window.Height / 2);
                return;
            }
            if (Mouse.RightButton == MouseButtonState.Pressed)
            {
                window.Left += 5;
                window.Top += 5;
                window.Height -= 10;
                window.Width -= 10;
            }
        }
    }
}
