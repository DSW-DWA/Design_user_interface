using System;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Windows;

namespace Task_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private string _nl = Environment.NewLine;
        private Random _rand = new Random();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Step1_OnClick(object sender, RoutedEventArgs e)
        {
            var a = new string[100];
            var sum = 0;
            for (var i = 0; i < 100; i++)
            {
                var num = _rand.Next(100000, 999999);
                a[i] = num.ToString();
                sum += num;
            }
            TextBoxConsole.Text = $"Данные (100 целых чисел) сгенерированы {_nl}Общая сумма: {sum}{_nl}";

            
            File.WriteAllLines("data.txt",a.Reverse());
            using (var fs = new FileStream("data.dat", FileMode.Open))
            {
                var bw = new BinaryWriter(fs);
                foreach (var num in a)
                {
                    bw.Write(Convert.ToInt32(num));
                }
                fs.Close();
            }
            
            TextBoxConsole.Text += $"Данные записаны в data.dat{_nl}Данные записаны в data.txt{_nl}";
            
            Step2.Visibility = Visibility.Visible;
        }

        private void Step2_OnClick(object sender, RoutedEventArgs e)
        {
            TextBoxConsole.Text += $"Файл data.dat считан{_nl}";
            using (var fs = new FileStream("data.dat", FileMode.Open))
            {
                var br = new BinaryReader(fs);
                for (var i = 0; i < 100; i++)
                {
                    var a = br.ReadInt32();
                    if (i == 0) TextBoxConsole.Text += $"a[0]={a} ";
                    if (i == 99) TextBoxConsole.Text += $"a[99]={a}{_nl}";
                }
                fs.Close();
            }
            Step3.Visibility = Visibility.Visible;
        }

        private void Step3_OnClick(object sender, RoutedEventArgs e)
        {
            var lines = File.ReadAllLines("data.txt");
            TextBoxConsole.Text += $"Файл data.txt считан{_nl}";
            TextBoxConsole.Text += $"a[0]={lines[0]} a[99]={lines[99]}{_nl}";
        }
    }
}