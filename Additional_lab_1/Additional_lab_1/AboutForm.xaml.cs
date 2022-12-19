using System;
using System.Windows;

namespace Additional_lab_1
{
    public partial class AboutForm : Window
    {
        public AboutForm(Window main)
        {
            InitializeComponent(); 
            InfoTextBlock.Text = $"Чупеев Андрей Дмитриевич{Environment.NewLine}Версия 1.0";
            _main = main;
        }

        private Window _main;
        private void AcceptButton_OnClick(object sender, RoutedEventArgs e)
        {
            _main.IsEnabled = true;
            this.Close();
        }
    }
}