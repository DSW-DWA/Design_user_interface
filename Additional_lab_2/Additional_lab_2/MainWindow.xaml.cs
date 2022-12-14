using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Additional_lab_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            _window = Application.Current.MainWindow;
            _tmp.Add(new DataGridItem(1.0));
            _tmp.Add(new DataGridItem(2.0));
            _tmp.Add(new DataGridItem(3.0));
            _tmp.Add(new DataGridItem(4.0));
            _tmp.Add(new DataGridItem(5.0));
            _tmp.Add(new DataGridItem(6.0));
            _tmp.Add(new DataGridItem(7.0));
            _tmp.Add(new DataGridItem(8.0));
            _tmp.Add(new DataGridItem(9.0));
            _tmp.Add(new DataGridItem(10.0));
            _tmp.Add(new DataGridItem(1.0));
            _tmp.Add(new DataGridItem(2.0));
            _tmp.Add(new DataGridItem(3.0));
            _tmp.Add(new DataGridItem(4.0));
            _tmp.Add(new DataGridItem(5.0));
            _tmp.Add(new DataGridItem(6.0));
            _tmp.Add(new DataGridItem(7.0));
            _tmp.Add(new DataGridItem(8.0));
            _tmp.Add(new DataGridItem(9.0));
            _tmp.Add(new DataGridItem(10.0));
            DG1.ItemsSource = _tmp;
        }

        public ObservableCollection<DataGridItem> _tmp = new ObservableCollection<DataGridItem>();
        readonly Window _window = Application.Current.MainWindow;
        private void ComboBoxItem_OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var cbi = (ComboBoxItem)sender;
            _window.Title = cbi.Content.ToString();
        }

        private void RadioButton_OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var rb = (RadioButton)sender;
            _window.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(rb.Content.ToString()));
        }

        private void CheckBox_OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            StackPanel.IsEnabled = !StackPanel.IsEnabled;
        }

        private void MenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            var mi = (MenuItem)sender;
            if (mi.Header.ToString() == "Удалить")
            {
                var del = new List<DataGridItem>();
                foreach (var dataGridCellInfo in DG1.SelectedCells)
                {
                    del.Add((DataGridItem)dataGridCellInfo.Item);
                }

                var tmp = (ObservableCollection<DataGridItem>)DG1.ItemsSource;
                foreach (var dataGridItem in del)
                {
                    tmp.Remove(dataGridItem);
                }
            }

            if (mi.Header.ToString() == "C")
            {
                var del = new List<DataGridItem>();
                foreach (var dataGridCellInfo in DG1.Items)
                {
                    del.Add((DataGridItem)dataGridCellInfo);
                }

                var ans = "";
                foreach (var dataGridItem in del)
                {
                    if (Math.Truncate(dataGridItem.Number) % 2 == 0 && dataGridItem.Number > 0)
                    {
                        ans += dataGridItem.Number + Environment.NewLine;
                    }
                }

                if (ans == "")
                {
                    ans += "Чисел нет";
                }

                MessageBox.Show(ans);
            }
            if (mi.Header.ToString() == "G")
            {
                var del = new List<DataGridItem>();
                for (var i = 0; i < 6 && i < DG1.Items.Count; i++)
                {
                    del.Add((DataGridItem)DG1.Items[i]);
                }

                var ans = "";
                foreach (var dataGridItem in del)
                {
                    var dr = Convert.ToDecimal(Math.Abs(dataGridItem.Number));
                    var cl = Convert.ToDecimal(Math.Abs(Math.Truncate(dataGridItem.Number)));
                    var raz = (int)Math.Truncate((dr - cl)*100);
                    if (raz % 2 == 0 )
                    {
                        foreach (var gridItem in del)
                        {
                            ans += gridItem.Number + Environment.NewLine;
                        }
                        break;
                    }
                }

                if (ans == "")
                {
                    ans += "Чисел нет";
                }

                MessageBox.Show(ans);
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
            foreach (var listBox1SelectedItem in ListBox3.SelectedItems)
            {
                lbis.Add((ListBoxItem)listBox1SelectedItem);
            }
            lbis.ForEach(x => ListBox3.Items.Remove(x));
        }
    }
}