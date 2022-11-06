using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Task_2.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Task_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Quado _quado;
        private Biquad _biquad;
        private bool _flag = false;
        public MainWindow()
        {
            InitializeComponent();
        }
        private bool Validator(string str)
        {
            return Regex.Match(str, @"\d+").Success;
        }

        private void NumberValidationTextBoxA(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
            if (e.Text == " ") e.Handled = true;
            if (e.Text == "-" && A.Text == "") e.Handled = false;
            if (e.Text == "." && A.Text.Count(x => x == '.') == 0) e.Handled = false;
        }
        private void NumberValidationTextBoxB(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
            if (e.Text == " ") e.Handled = true;
            if (e.Text == "-" && B.Text == "") e.Handled = false;
            if (e.Text == "." && B.Text.Count(x => x == '.') == 0) e.Handled = false;
        }
        private void NumberValidationTextBoxC(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
            if (e.Text == " ") e.Handled = true;
            if (e.Text == "-" && C.Text == "") e.Handled = false;
            if (e.Text == "." && C.Text.Count(x => x == '.') == 0) e.Handled = false;
        }

        private void A_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (Validator(A.Text) && Validator(B.Text) && Validator(C.Text))
            {
                var a = Convert.ToDouble(A.Text, CultureInfo.InvariantCulture);
                var b = Convert.ToDouble(B.Text, CultureInfo.InvariantCulture);
                var c = Convert.ToDouble(C.Text, CultureInfo.InvariantCulture);
                _quado = new Quado(a, b, c);
                _biquad = new Biquad(a, b, c);
                Answer1.Text = _quado.ToString();
                Answer2.Text = _biquad.ToString();
            }
        }

        private void A_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space) e.Handled = true;
        }
    }
}
