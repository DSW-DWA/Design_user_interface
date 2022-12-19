using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Windows.Input;
using System.Windows.Media;
using Binding = System.Windows.Data.Binding;
using TextBox = System.Windows.Controls.TextBox;
using Button = System.Windows.Controls.Button;
using Color = System.Windows.Media.Color;
using KeyEventArgs = System.Windows.Input.KeyEventArgs;
using Label = System.Windows.Controls.Label;
using MessageBox = System.Windows.MessageBox;
using RadioButton = System.Windows.Controls.RadioButton;

namespace Additional_lab_1
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

        private List<ChildFormInfo> _children = new List<ChildFormInfo>();
        private void AboutButton_OnClick(object sender, RoutedEventArgs e)
        {
            var about = new AboutForm(Main);
            about.Visibility = Visibility.Visible;
            Main.IsEnabled = false;
        }
        private void NotEnable()
        {
            IsVisibleCheckBox.IsEnabled = false;
            ChildWindowStateStackPanel.IsEnabled = false;
            NameChildTextBox.IsEnabled = false;
            XPositionChildLabel.Content = "";
            YPositionChildLabel.Content = "";
            HeightGrid.IsEnabled = false;
            WidthGrid.IsEnabled = false;
        }
        private void BindingPosition(ref ChildFormInfo cfi)
        {
            var bin = new Binding();
            bin.Source = cfi.Child;
            bin.Path = new PropertyPath(Window.LeftProperty);
            bin.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            BindingOperations.SetBinding(XPositionChildLabel, Label.ContentProperty, bin);
            var bin1 = new Binding();
            bin1.Source = cfi.Child;
            bin1.Path = new PropertyPath(Window.TopProperty);
            bin1.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            BindingOperations.SetBinding(YPositionChildLabel, Label.ContentProperty, bin1);
        }
        private void ChildButton_OnClick(object sender, RoutedEventArgs e)
        {
            var num = 1;
            if (_children.Count != 0)
            {
                num = _children.Max(x => x.Number) + 1;
            }
            else
            {
                _children.Add(new ChildFormInfo(_children.Select(x => x.Child).ToList()));
            }
            var child = new ChildForm(this ,num, Main.ActualHeight, Main.ActualWidth, 200, 300);
            var ci = new ChildFormInfo(num, child);
            _children.Add(ci);
            var all = _children.FirstOrDefault(x => x.Number == -1);
            if (all != null)
            {
                all.Children.Add(ci.Child);
            }
            SelectChildComboBox.ItemsSource = _children.Select(x => x.Name);
            SelectChildComboBox.IsEnabled = true;
            NotEnable();

            child.Visibility = Visibility.Visible;
        }
        private void MainWindow_OnClosing(object sender, CancelEventArgs e)
        {
            var result = MessageBox.Show("Закрыть форму?", "Закрытие", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }
        public void ChangeChildState(int num)
        {
            if (SelectChildComboBox.Text != "Все детки" && SelectChildComboBox.Text != "")
            {
                var tmp = _children.FirstOrDefault(x => x.Number == num);
                
                if (tmp != null && SelectChildComboBox.Text == num.ToString())
                {
                    if (tmp.Child.WindowState == WindowState.Maximized)
                    {
                        MaximizedRadioButton.IsChecked = true;
                    }

                    if (tmp.Child.WindowState == WindowState.Minimized)
                    {
                        MinimizedRadioButton.IsChecked = true;
                    }

                    if (tmp.Child.WindowState == WindowState.Normal)
                    {
                        NormalRadioButton.IsChecked = true;
                    }
                }
            }
        }
        public void CloseChild(int num)
        {
            var tmp = _children.FirstOrDefault(x => x.Number == num);
            if (tmp != null)
            {
                _children.Remove(tmp);
                if (_children.Count == 1 && _children.Count(x => x.Number == -1) > 0)
                {
                    _children.Clear();
                }
                SelectChildComboBox.ItemsSource = _children.Select(x => x.Name);
                if (_children.Any())
                {
                    SelectChildComboBox.IsEnabled = false;
                    ColorChangeButton.IsEnabled = false;
                }
                NotEnable();
            }
        }
        private void SelectChildComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                if (e.AddedItems[0].ToString() != "Все детки")
                {
                    var numCfi = e.AddedItems[0].ToString();
                    var cfi = _children.FirstOrDefault(x => x.Name == numCfi);
                    if (cfi != null)
                    {
                        IsVisibleCheckBox.IsEnabled = true;
                        ChildWindowStateStackPanel.IsEnabled = true;
                        NameChildTextBox.IsEnabled = true;
                        if (cfi.Child.IsVisible)
                        {
                            IsVisibleCheckBox.IsChecked = true;
                        }
                        else
                        {
                            IsVisibleCheckBox.IsChecked = false;
                        }
                        if (cfi.Child.WindowState == WindowState.Maximized)
                        {
                            MaximizedRadioButton.IsChecked = true;
                        }
                        if (cfi.Child.WindowState == WindowState.Minimized)
                        {
                            MinimizedRadioButton.IsChecked = true;
                        }
                        if (cfi.Child.WindowState == WindowState.Normal)
                        {
                            NormalRadioButton.IsChecked = true;
                        }
                        NameChildTextBox.Text = cfi.Name;
                        HeightGrid.IsEnabled = true;
                        WidthGrid.IsEnabled = true;
                        ColorChangeButton.IsEnabled = true;
                        BindingPosition(ref cfi);
                    }
                }
                else
                {
                    IsVisibleCheckBox.IsEnabled = true;
                    ChildWindowStateStackPanel.IsEnabled = true;
                    if (_children.Count(x => x.Number != -1 && x.Child.IsVisible) > 0)
                    {
                        IsVisibleCheckBox.IsChecked = true;
                    }
                    else
                    {
                        IsVisibleCheckBox.IsChecked = false;
                    }
                    if (_children.Count(x => x.Number != -1 && x.Child.WindowState == WindowState.Maximized) > 0)
                    {
                        MaximizedRadioButton.IsChecked = true;
                    }
                    if (_children.Count(x => x.Number != -1 && x.Child.WindowState == WindowState.Minimized) > 0)
                    {
                        MinimizedRadioButton.IsChecked = true;
                    }
                    if (_children.Count(x => x.Number != -1 && x.Child.WindowState == WindowState.Normal) > 0)
                    {
                        NormalRadioButton.IsChecked = true;
                    }

                    NameChildTextBox.Text = "";
                    NameChildTextBox.IsEnabled = false;
                    HeightGrid.IsEnabled = true;
                    WidthGrid.IsEnabled = true;
                    ColorChangeButton.IsEnabled = true;
                    BindingOperations.ClearBinding(XPositionChildLabel, Label.ContentProperty);
                    XPositionChildLabel.Content = "";
                    BindingOperations.ClearBinding(YPositionChildLabel, Label.ContentProperty);
                    YPositionChildLabel.Content = "";
                }
            }
        }
        private void IsVisibleCheckBox_OnClick(object sender, RoutedEventArgs e)
        {
            if (SelectChildComboBox.SelectionBoxItem.ToString() != "Все детки")
            {
                var numCfi = SelectChildComboBox.SelectionBoxItem.ToString();
                var cfi = _children.FirstOrDefault(x => x.Name == numCfi);
                if (cfi != null)
                {
                    if (IsVisibleCheckBox.IsChecked == true)
                    {
                        cfi.Child.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        cfi.Child.Visibility = Visibility.Hidden;
                    }
                }
            }
            else
            {
                if (IsVisibleCheckBox.IsChecked == true)
                {
                    _children.Where(x => x.Number != -1).ToList().ForEach(x => x.Child.Visibility = Visibility.Visible);
                }
                else
                {
                    _children.Where(x => x.Number != -1).ToList().ForEach(x => x.Child.Visibility = Visibility.Hidden);
                }
            }
        }
        private void RadioButton_OnClick(object sender, RoutedEventArgs e)
        {
            var rb = (RadioButton)sender;
            if (SelectChildComboBox.SelectionBoxItem.ToString() != "Все детки")
            {
                var numCfi = SelectChildComboBox.SelectionBoxItem.ToString();
                var cfi = _children.FirstOrDefault(x => x.Name == numCfi);
                if (cfi != null)
                {
                    if (rb == MaximizedRadioButton)
                    {
                        cfi.Child.WindowState = WindowState.Maximized;
                    }
                    if (rb == MinimizedRadioButton)
                    {
                        cfi.Child.WindowState = WindowState.Minimized;
                    }
                    if (rb == NormalRadioButton)
                    {
                        cfi.Child.WindowState = WindowState.Normal;
                    }
                }
            }
            else
            {
                if (rb == MaximizedRadioButton)
                {
                    _children.Where(x => x.Number != -1).ToList().ForEach(x => x.Child.WindowState = WindowState.Maximized);
                }
                if (rb == MinimizedRadioButton)
                {
                    _children.Where(x => x.Number != -1).ToList().ForEach(x => x.Child.WindowState = WindowState.Minimized);
                }
                if (rb == NormalRadioButton)
                {
                    _children.Where(x => x.Number != -1).ToList().ForEach(x => x.Child.WindowState = WindowState.Normal);
                }
            }
        }
        private void NameChildTextBox_OnLostFocus(object sender, RoutedEventArgs e)
        {
            var numCfi = SelectChildComboBox.SelectionBoxItem.ToString();
            var cfi = _children.FirstOrDefault(x => x.Name == numCfi);
            if (cfi != null && _children.All(x => x.Name != NameChildTextBox.Text))
            {
                cfi.Name = NameChildTextBox.Text;
                cfi.Child.Title = NameChildTextBox.Text;
                SelectChildComboBox.ItemsSource = _children.Select(x => x.Name);
                NotEnable();
            }
        }
        private void NameChildTextBox_OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                var numCfi = SelectChildComboBox.SelectionBoxItem.ToString();
                var cfi = _children.FirstOrDefault(x => x.Name == numCfi);
                if (cfi != null && _children.All(x => x.Name != NameChildTextBox.Text))
                {
                    cfi.Name = NameChildTextBox.Text;
                    cfi.Child.Title = NameChildTextBox.Text;
                    SelectChildComboBox.ItemsSource = _children.Select(x => x.Name).ToList();
                    NotEnable();
                }
            }
        }
        private void CloseChildButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (SelectChildComboBox.SelectionBoxItem.ToString() != "Все детки")
            {
                var numCfi = SelectChildComboBox.SelectionBoxItem.ToString();
                var cfi = _children.FirstOrDefault(x => x.Name == numCfi);
                if (cfi != null)
                {
                    _children.Where(x => x.Number != -1 && x.Name == cfi.Name).ToList().ForEach(x => x.Child.Close());
                    _children = _children.Where(x => x.Name != cfi.Name).ToList();
                    SelectChildComboBox.ItemsSource = _children.Select(x => x.Name);
                    SelectChildComboBox.IsEnabled = true;
                }
            }
            else
            {
                _children.Where(x => x.Number != -1).ToList().ForEach(x => x.Child.Close());
                _children.Clear();
                SelectChildComboBox.ItemsSource = _children.Select(x => x.Name);
                ColorChangeButton.IsEnabled = false;
            }
        }

        private void ColorChangeButton_OnClick(object sender, RoutedEventArgs e)
        {
            var clrDlg = new ColorDialog();
            if (clrDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var color = clrDlg.Color;
                if (SelectChildComboBox.SelectionBoxItem.ToString() != "Все детки")
                {
                    var numCfi = SelectChildComboBox.SelectionBoxItem.ToString();
                    var cfi = _children.FirstOrDefault(x => x.Name == numCfi);
                    if (cfi != null)
                    {
                        cfi.Child.Background = new SolidColorBrush(Color.FromArgb(color.A, color.R,color.G,color.B));
                    }
                }
                else
                {
                    _children
                        .Where(x => x.Number != -1)
                        .ToList()
                        .ForEach(x => x.Child.Background = new SolidColorBrush(Color.FromArgb(color.A, color.R,color.G,color.B)));
                }
            }
        }

        private void Up_OnClick(object sender, RoutedEventArgs e)
        {
            var btn = (Button)sender;
            var sp = (Grid)btn.Parent;
            if (SelectChildComboBox.SelectionBoxItem.ToString() != "Все детки")
            {
                var numCfi = SelectChildComboBox.SelectionBoxItem.ToString();
                var cfi = _children.FirstOrDefault(x => x.Name == numCfi);
                if (cfi != null)
                {
                    if (sp == HeightGrid)
                    {
                        cfi.Child.Height += 1;
                    }
                    if (sp == WidthGrid)
                    {
                        cfi.Child.Width += 1;
                    }
                }
            }
            else
            {
                if (sp == HeightGrid)
                {
                    _children.Where(x => x.Number != -1).ToList().ForEach(x => x.Child.Height +=1);
                }
                if (sp == WidthGrid)
                {
                    _children.Where(x => x.Number != -1).ToList().ForEach(x => x.Child.Height +=1);
                }
            }
        }
        private void Down_OnClick(object sender, RoutedEventArgs e)
        {
            var btn = (Button)sender;
            var sp = (Grid)btn.Parent;
            if (SelectChildComboBox.SelectionBoxItem.ToString() != "Все детки")
            {
                var numCfi = SelectChildComboBox.SelectionBoxItem.ToString();
                var cfi = _children.FirstOrDefault(x => x.Name == numCfi);
                if (cfi != null)
                {
                    if (sp == HeightGrid && cfi.Child.ActualHeight > 1)
                    {
                        cfi.Child.Height -= 1;
                    }
                    if (sp == WidthGrid && cfi.Child.ActualWidth > 1)
                    {
                        cfi.Child.Width -= 1;
                    }
                }
            }
            else
            {
                if (sp == HeightGrid)
                {
                    _children.Where(x => x.Number != -1).ToList().ForEach(x =>
                    {
                        var cfi = x.Child;
                        if (cfi.ActualHeight > 1)
                        {
                            cfi.Height -= 1;
                        }
                    });
                }
                if (sp == WidthGrid)
                {
                    _children.Where(x => x.Number != -1).ToList().ForEach(x =>
                    {
                        var cfi = x.Child;
                        if (cfi.ActualWidth > 1)
                        {
                            cfi.Width -= 1;
                        }
                    });
                }
            }
        }
    }
}