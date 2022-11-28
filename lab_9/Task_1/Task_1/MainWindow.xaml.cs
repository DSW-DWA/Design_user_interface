using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

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
            _groupBoxSetMode = true;
        }

        private UIElement _comboBox;
        private bool _groupBoxSetMode;
        private void ComboBoxTitles_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = (ComboBoxItem)ComboBoxTitles.SelectedItem;
            if (ComboBoxItemTitle.IsSelected)
            {
                //ComboBoxTitles.SelectedItem = ComboBoxTitles.Items[ComboBoxTitles.Items.Count-2];
                ComboBoxTitles.SelectedItem = null;
            }
            else
            {
                if (selectedItem != null)
                {
                    Application.Current.MainWindow.Title = selectedItem.Content.ToString();   
                }
                else
                {
                    Application.Current.MainWindow.Title = "Изначальное название";
                }
            }
        }
        
        private void ToggleButton_OnChecked(object sender, RoutedEventArgs e)
        {
            var radioButton = (RadioButton)sender;
            Application.Current.MainWindow.FontSize = Convert.ToInt32(radioButton.Content.ToString());
            if (Menu != null) Menu.FontSize = Convert.ToInt32(radioButton.Content.ToString());
        }

        private void ButtonBase_OnClick_Font(object sender, RoutedEventArgs e)
        {
            _groupBoxSetMode = !_groupBoxSetMode;
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
        private void NumberValidationTextBoxC(object sender, TextCompositionEventArgs e)
        {
            var C = (TextBox)sender;
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
            if (e.Text == " ") e.Handled = true;
            if (e.Text == "-" && C.Text == "") e.Handled = false;
            if (e.Text == "." && C.Text.Count(x => x == '.') == 0) e.Handled = false;
        }

        private void TextBox_OnKeyDown(object sender, KeyEventArgs e)
        {
            var C = (TextBox)sender;
            if (e.Key == Key.Enter && C.Text != "")
            {
                var lbi = new ListBoxItem();
                lbi.Content = C.Text;
                ListBox1.Items.Add(lbi);
                C.Text = "";
            }
            else if (e.Key == Key.Enter)
            {
                MessageBox.Show("Вы ввели пустую строку");
            }
        }
        
        private void TextBox_OnKeyDown_ContextMenu(object sender, KeyEventArgs e)
        {
            var C = (TextBox)sender;
            if (e.Key == Key.Enter && C.Text != "")
            {
                var lbi = new ListBoxItem();
                lbi.Content = C.Text;
                ListBox3.Items.Add(lbi);
                C.Text = "";
            }
            else if (e.Key == Key.Enter)
            {
                MessageBox.Show("Вы ввели пустую строку");
            }
        }
        
        private void MenuItem_OnClick_Delete(object sender, RoutedEventArgs e)
        {
            var lbis = new List<ListBoxItem>();
            foreach (var listBox1SelectedItem in ListBox1.SelectedItems)
            {
                lbis.Add((ListBoxItem)listBox1SelectedItem);
            }
            lbis.ForEach(x => ListBox1.Items.Remove(x));
            lbis.Clear();
            foreach (var listBox1SelectedItem in ListBox2.SelectedItems)
            {
                lbis.Add((ListBoxItem)listBox1SelectedItem);
            }
            lbis.ForEach(x => ListBox2.Items.Remove(x));
            lbis.Clear();
            foreach (var listBox1SelectedItem in ListBox3.SelectedItems)
            {
                lbis.Add((ListBoxItem)listBox1SelectedItem);
            }
            lbis.ForEach(x => ListBox3.Items.Remove(x));
        }

        private void MenuItem_OnClick_C(object sender, RoutedEventArgs e)
        {
            foreach (var listBox1Item in ListBox1.Items)
            {
                var lbi = (ListBoxItem)listBox1Item;
                var num = Convert.ToDouble(lbi.Content,new System.Globalization.CultureInfo("en-US"));
                if (Math.Truncate(num) % 2 == 0 && num > 0)
                {
                    var lbiForLb2 = new ListBoxItem();
                    lbiForLb2.Content = lbi.Content;
                    ListBox2.Items.Add(lbiForLb2);
                }
            }
        }

        private void MenuItem_OnClick_E(object sender, RoutedEventArgs e)
        {
            var f = false;
            foreach (var listBox1Item in ListBox1.Items)
            {
                var lbi = (ListBoxItem)listBox1Item;
                var num = Convert.ToDouble(lbi.Content,new System.Globalization.CultureInfo("en-US"));
                if (num == 0) f = true;
            }
            foreach (var listBox1Item in ListBox1.Items)
            {
                var lbi = (ListBoxItem)listBox1Item;
                var num = Convert.ToDouble(lbi.Content,new System.Globalization.CultureInfo("en-US"));
                if (f)
                {
                    var lbiForLb2 = new ListBoxItem();
                    var dr = num - Math.Truncate(num);
                    lbiForLb2.Content = dr.ToString();
                    ListBox2.Items.Add(lbiForLb2);
                }
            }
        }

        private void MenuItem_OnClick_A(object sender, RoutedEventArgs e)
        {
            var k = 0;
            foreach (var listBox3Item in ListBox3.Items)
            {
                var lbi = (ListBoxItem)listBox3Item;
                if (!Regex.IsMatch(lbi.Content.ToString(),@"\d"))
                {
                    k++;
                }
            }
            MessageBox.Show($"Колл-во строк без чисел: {k}");
        }
        private void MenuItem_OnClick_D(object sender, RoutedEventArgs e)
        {
            var ans = "";
            var nl = Environment.NewLine;
            var i = 0;
            foreach (var listBox3Item in ListBox3.Items)
            {
                var lbi = (ListBoxItem)listBox3Item;
                if (i % 2 == 0)
                {
                    ans += Regex.Replace(lbi.Content.ToString(), @" ", @"") + nl;
                }
                else
                {
                    ans += Regex.Replace(lbi.Content.ToString(), @" ", @"  ") + nl;
                }
                i++;
            }
            MessageBox.Show(ans);
        }
        private void MainWindow_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.MainWindow.FontSize = 12;
            Menu.FontSize = 12;
            Application.Current.MainWindow.Title = "Изначальное название";
            RadioButtonDefaultFont.IsChecked = true;
            CheckBox_comboBox.IsChecked = false;
            CheckBox_groupBox.IsChecked = false;
            if (!Grid.Children.Contains(_comboBox))
            {
                Grid.Children.Add(_comboBox);
            }
            if (e.ClickCount >= 2) this.Close();
        }
        private void Window_Close(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }
        private void Window_Start(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.MainWindow.FontSize = 12;
            Menu.FontSize = 12;
            Application.Current.MainWindow.Title = "Изначальное название";
            RadioButtonDefaultFont.IsChecked = true;
            CheckBox_comboBox.IsChecked = false;
            CheckBox_groupBox.IsChecked = false;
            
            if (!Grid.Children.Contains(_comboBox))
            {
                Grid.Children.Add(_comboBox);
            }
        }

        private void UIElement_OnMouseMove(object sender, MouseEventArgs e)
        {
            
            StatusBar.Items.Clear();
            if (sender.Equals(ComboBoxTitles))
            {
                StatusBar.Items.Add("ComboBox");
            }
            if (sender.Equals(GroupBoxFont))
            {
                StatusBar.Items.Add("GroupBox");
            }

            if (sender.Equals(StackPanelCheck))
            {
                StatusBar.Items.Add("StackPanel");
            }

            if (sender.Equals(Menu))
            {
                StatusBar.Items.Add("Menu");
            }
            StatusBar.Visibility = Visibility.Visible;
        }

        private void UIElement_OnMouseLeave(object sender, MouseEventArgs e)
        {
            StatusBar.Visibility = Visibility.Hidden;
        }

        private void TextBoxAddTitle_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                var cbi = new ComboBoxItem();
                cbi.Content = TextBoxAddTitle.Text;
                ComboBoxTitles.Items.Insert(ComboBoxTitles.Items.Count - 1, cbi);
                ComboBoxTitles.SelectedItem = cbi;
            }
        }

        private void RadioButtonDefaultFont_OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (_groupBoxSetMode)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}