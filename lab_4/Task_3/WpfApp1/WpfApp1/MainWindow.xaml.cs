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
        private double _allScore = 0;
        private int _count = 0;
        private Random _r = new Random();
        public MainWindow()
        {
            InitializeComponent();
            _centerX = _r.Next(0, 0);
            _centerY = _r.Next(0, 0);
        }
        private int _centerX;
        private int _centerY;
        private void CheckScore(object sender, RoutedEventArgs e)
        {
            _count++;
            var point = Mouse.GetPosition(this);
            var lenght = Math.Sqrt(Math.Pow(_centerX - point.X, 2) + Math.Pow(_centerY - point.Y, 2));
            var mn = 0.0;
            if (lenght <= 300)
            {
                var score = (int)((1 - (lenght / 300)) * 10);
                _allScore += score;
                mn = (1 - (lenght / 300));
                if (score == 10)
                {
                    MessageBox.Show("Вы попали в центр");
                    _count = 0;
                    _allScore = 0;
                }
            }
            if (_count == 10)
            {
                MessageBox.Show($"Вы зкончили игру ваш счет: {_allScore}. Игра начнется занаво");
                _count = 0;
                _allScore = 0;
                mn = 1;
            }
            Application.Current.MainWindow.Opacity = mn;
            Application.Current.MainWindow.Title = $"MainWindow | {_count}/10 | {_allScore}";
        }
    }
}
