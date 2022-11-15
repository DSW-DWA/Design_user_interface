using System.Windows;

namespace Task_2
{
    public partial class ChooseFileWindow : Window
    {
        public string ChosenFiel;
        public ChooseFileWindow()
        {
            InitializeComponent();
            ChosenFiel = "nothing";
        }
        private void SmallButton_OnClick(object sender, RoutedEventArgs e)
        {
            ChosenFiel = "small.txt";
            DialogResult = true;
        }

        private void BigButton_OnClick(object sender, RoutedEventArgs e)
        {
            ChosenFiel = "big.txt";
            DialogResult = true;
        }
    }
}