using System;
using System.Security.Policy;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Task_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private int _colorNumber = 0;
        private int _cursorNumber = 0;
        private void Step1_OnClick(object sender, RoutedEventArgs e)
        {
            if (Step2.Visibility == Visibility.Visible && Step3.Visibility == Visibility.Visible)
            {
                Step2.Visibility = Visibility.Hidden;
            }
            else
            {
                Step2.Visibility = Step2.Visibility == Visibility.Hidden ? Visibility.Visible : Visibility.Hidden;
                Step3.Visibility = Step3.Visibility == Visibility.Hidden ? Visibility.Visible : Visibility.Hidden;
            }
        }

        private void Step2_OnClick(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this);
            if (window.Width > 500 && window.Height > 300)
            {
                window.Left += 5;
                window.Top += 5;
                window.Height -= 10;
                window.Width -= 10;
            }
        }

        private void Step3_OnClick(object sender, RoutedEventArgs e)
        {
            var arrayOfColors = new Brush[] { Brushes.Red, Brushes.Blue, Brushes.Green, Brushes.Purple, Brushes.Aqua };
            if (Keyboard.IsKeyDown(Key.LeftShift) == false)
            {
                _colorNumber++;
                if (_colorNumber > 4) _colorNumber = 0;
                var window = Window.GetWindow(this);
                Application.Current.MainWindow.Background = arrayOfColors[_colorNumber];
            }
            else
            {
                _colorNumber--;
                if (_colorNumber < 0) _colorNumber = 4;
                Application.Current.MainWindow.Background = arrayOfColors[_colorNumber];
            }
            if (Keyboard.IsKeyDown(Key.LeftCtrl)) Application.Current.MainWindow.Background = Brushes.White;
        }

        private void Step4_OnClick(object sender, RoutedEventArgs e)
        {
            var arrayOfCursors= new Cursor[] { Cursors.Arrow, Cursors.Hand, Cursors.Cross, Cursors.Help, Cursors.Pen };
            _cursorNumber++;
            if (_cursorNumber > 4) _cursorNumber = 0;
            Application.Current.MainWindow.Cursor = arrayOfCursors[_cursorNumber];
        }


        private void MainWindow_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Step2.Visibility = Visibility.Visible; 
            Step3.Visibility = Visibility.Visible;
            if (e.ClickCount >= 2) this.Close();
        }
        private void Window_Close(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }
        private void Window_Start(object sender, ExecutedRoutedEventArgs e)
        {
            Step2.Visibility = Visibility.Visible; 
            Step3.Visibility = Visibility.Visible;
        }
    }
}