using System;
using System.Diagnostics.SymbolStore;
using System.Windows;
using System.Windows.Controls;

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
            _comboBox = ComboBoxTitles;
            _groupBox = GroupBoxFont;
        }

        private UIElement _comboBox;
        private UIElement _groupBox;
        private void ComboBoxTitles_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = (ComboBox)sender;
            var selectedItem = (ComboBoxItem)comboBox.SelectedItem;
            Application.Current.MainWindow.Title = selectedItem.Content.ToString();
        }
        
        private void ToggleButton_OnChecked(object sender, RoutedEventArgs e)
        {
            var radioButton = (RadioButton)sender;
            Application.Current.MainWindow.FontSize = Convert.ToInt32(radioButton.Content.ToString());
        }

        private void ButtonBase_OnClick_Font(object sender, RoutedEventArgs e)
        {
            if (Grid.Children.Contains(_groupBox))
            {
                Grid.Children.Remove(_groupBox);
            }
            else
            {
                Grid.Children.Add(_groupBox);
            }
        }

        private void ButtonBase_OnClick_Title(object sender, RoutedEventArgs e)
        {
            if (Grid.Children.Contains(_comboBox))
            {
                Grid.Children.Remove(_comboBox);
            }
            else
            {
                Grid.Children.Add(_comboBox);
            }
        }
    }
}