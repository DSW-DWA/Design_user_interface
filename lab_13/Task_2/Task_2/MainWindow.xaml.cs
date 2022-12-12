using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Task_2
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

        private Brush _listBox1Brush = Brushes.Black;
        private Brush _listBox2Brush = Brushes.Black;
        private UIElement _dragSource;
        private bool _isLeftMouse = true;

        private void ListBox_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var lb = (ListBox)sender;
            _dragSource = lb;
            DragDrop.DoDragDrop(lb, lb, DragDropEffects.Move);
        }

        private void TextBox_OnDrop(object sender, DragEventArgs e)
        {
            if (_dragSource.GetType() == typeof(ListBox))
            {
                var data = e.Data.GetData(typeof(ListBox));
                if (data != null)
                {
                    var lb = (ListBox)data;
                    if (lb.SelectedItems.Count > 0)
                    {
                        if (lb == ListBox1)
                        {
                            foreach (var lbSelectedItem in lb.SelectedItems)
                            {
                                var lbInsert = (ListBoxItem)lbSelectedItem;
                                var item = new ListBoxItem();
                                item.Foreground = _listBox1Brush;
                                item.Content = lbInsert.Content;
                                ListBox1.Items.Add(item);
                            }

                            TextBlockInfo.Text = $"{lb.SelectedItems.Count} позиций доабавлено в ListBox1";
                        }

                        if (lb == ListBox2)
                        {
                            var del = new List<ListBoxItem>();
                            foreach (var lbSelectedItem in lb.SelectedItems)
                            {
                                var lbInsert = (ListBoxItem)lbSelectedItem;
                                del.Add(lbInsert);
                            }

                            foreach (var lbSelectedItem in del)
                            {
                                ListBox2.Items.Remove(lbSelectedItem);
                            }
                            TextBlockInfo.Text = $"{del.Count} позиций удалено из ListBox2";
                        }
                    }
                    else
                    {
                        var lbi = (ListBoxItem)lb.Items[0];
                        var txt = TextBox1.Text;
                        TextBox1.Text = lbi.Content.ToString();
                        lbi.Content = txt;
                        TextBlockInfo.Text = $"Изименина первая строка {lb.Name}";
                    }
                }
            }
        }

        private void TextBox_OnPreviewDragOver(object sender, DragEventArgs e)
        {
            e.Handled = true;
        }

        private void ListBox_OnDrop(object sender, DragEventArgs e)
        {
            if (_dragSource.GetType() == typeof(ListBox))
            {
                var lbMain = (ListBox)sender;
                var data = e.Data.GetData(typeof(ListBox));
                if (data != null)
                {
                    var lb = (ListBox)data;
                    if (lb != lbMain)
                    {
                        var del = new List<ListBoxItem>();
                        foreach (var lbSelectedItem in lb.SelectedItems)
                        {
                            var lbInsert = (ListBoxItem)lbSelectedItem;
                            var item = new ListBoxItem();
                            if (lbMain == ListBox1)
                            {
                                item.Foreground = _listBox1Brush;
                            }
                            if (lbMain == ListBox2)
                            {
                                item.Foreground = _listBox2Brush;
                            }
                            item.Content = lbInsert.Content;
                            lbMain.Items.Add(item);
                            del.Add(lbInsert);
                        }

                        foreach (var lbSelectedItem in del)
                        {
                            lb.Items.Remove(lbSelectedItem);
                        }
                        TextBlockInfo.Text = $"{del.Count} позиций персено из {lb.Name} в {lbMain.Name}";
                    }
                }
            }
            if (_dragSource.GetType() == typeof(TextBox))
            {
                var lbMain = (ListBox)sender;
                var data = e.Data.GetData(typeof(string));
                if (data != null){
                    if (_isLeftMouse)
                    {
                        var lbi = new ListBoxItem();
                        lbi.Content = (string)data;
                        if (lbMain == ListBox1)
                        {
                            lbi.Foreground = _listBox1Brush;
                        }
                        if (lbMain == ListBox2)
                        {
                            lbi.Foreground = _listBox2Brush;
                        }
                        lbMain.Items.Insert(0,lbi);
                        TextBlockInfo.Text = $"Позиция перенесена в начало {lbMain.Name}";
                    }
                    else
                    {
                        var lbi = new ListBoxItem();
                        lbi.Content = (string)data;
                        if (lbMain == ListBox1)
                        {
                            lbi.Foreground = _listBox1Brush;
                        }
                        if (lbMain == ListBox2)
                        {
                            lbi.Foreground = _listBox2Brush;
                        }
                        lbMain.Items.Add(lbi);
                        TextBlockInfo.Text = $"Позиция перенесена в конец {lbMain.Name}";
                    }
                }
            }
            if (_dragSource.GetType() == typeof(Rectangle))
            {
                var lbMain = (ListBox)sender;
                var data = e.Data.GetData(typeof(Point));
                if (data != null)
                {
                    var point = (Point)data;
                    var r = (byte)(255*(1 - (point.X / 200)));
                    var b = (byte)(255*(point.X / 200));
                    var brush = new SolidColorBrush(Color.FromRgb(r,0,b));
                    lbMain.Background = brush;
                    ColorRectangle.Fill = brush;
                }
                TextBlockInfo.Text = $"Фон {lbMain.Name} изменил цвет";
            }
        }

        private void TextBox_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            _isLeftMouse = true;
            _dragSource = (TextBox)sender;
            if (TextBox1.Text != "") DragDrop.DoDragDrop(_dragSource, TextBox1.Text, DragDropEffects.Move);
            
            e.Handled = false;
        }

        private void TextBox1_OnPreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (TextBox1 != null)
            {
                _isLeftMouse = false;
                _dragSource = TextBox1;
                DragDrop.DoDragDrop(e.Source as DependencyObject, TextBox1.Text, DragDropEffects.Move);

                e.Handled = true;
            }
        }
        private void QueryContinueDragHandler(object source, QueryContinueDragEventArgs e)
        {
            TextBox textBox = source as TextBox;

            e.Handled = true;

            if (e.EscapePressed)
            {
                e.Action = DragAction.Cancel;
                return;
            }            

            if ((e.KeyStates & DragDropKeyStates.LeftMouseButton) != DragDropKeyStates.None)
            {
                e.Action = DragAction.Continue;
                return;
            }

            if ((e.KeyStates & DragDropKeyStates.RightMouseButton) != DragDropKeyStates.None)
            {
                e.Action = DragAction.Continue;
                return;
            }

            e.Action = DragAction.Drop;

            if (textBox != null)
            {
                textBox.Text = String.Empty;
            }
        }


        private void TextBox1_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.LeftCtrl))
            {
                Clipboard.SetText(TextBox1.Text);
            }
        }
        private void ReadFromFileButton_OnDrop(object sender, DragEventArgs e)
        {
            if (_dragSource.GetType() == typeof(ListBox))
            {
                var data = e.Data.GetData(typeof(ListBox));
                if (data != null)
                {
                    var lb = (ListBox)data;
                    var lines = File.ReadAllLines("Lab13.txt");
                    foreach (var line in lines)
                    {
                        var lbi = new ListBoxItem();
                        lbi.Content = line;
                        lb.Items.Add(lbi);
                    }
                    TextBlockInfo.Text = $"Данные считанны из Lab13.txt в {lb.Name}";
                }
            }
        }

        private void SaveFileButton_OnDrop(object sender, DragEventArgs e)
        {
            if (_dragSource.GetType() == typeof(ListBox))
            {
                var data = e.Data.GetData(typeof(ListBox));
                if (data != null)
                {
                    var lb = (ListBox)data;
                    var lines = new List<string>();
                    foreach (var lbSelectedItem in lb.Items)
                    {
                        var lbi = (ListBoxItem)lbSelectedItem;
                        lines.Add(lbi.Content.ToString());
                    }
                    File.WriteAllLines("Lab13.txt", lines.ToArray());
                    TextBlockInfo.Text = $"Данные из {lb.Name} записанны в Lab13.txt";
                }
            }
        }

        private void ColorRectangle_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            var point = e.GetPosition(this);
            _dragSource = ColorRectangle;
            var pt = Grid.TranslatePoint(point, ColorRectangle);
            DragDrop.DoDragDrop(_dragSource, pt, DragDropEffects.Copy);
        }

        private void ColorRectangle_OnDrop(object sender, DragEventArgs e)
        {
            if (_dragSource.GetType() == typeof(ListBox))
            {
                var data = e.Data.GetData(typeof(ListBox));
                if (data != null)
                {
                    var lb = (ListBox)data;
                    var point = e.GetPosition(this);
                    var pt = Grid.TranslatePoint(point, ColorRectangle);
                    var r = (byte)(255*(1 - (pt.X / 200)));
                    var b = (byte)(255*(pt.X / 200));
                    var brush = new SolidColorBrush(Color.FromRgb(r,0,b));
                    foreach (var lbItem in lb.Items)
                    {
                        var lbi = (ListBoxItem)lbItem;
                        lbi.Foreground = brush;
                    }
                    if (lb == ListBox1)
                    {
                        _listBox1Brush = brush;
                    }
                    if (lb == ListBox2)
                    {
                        _listBox2Brush = brush;
                    }
                    ColorRectangle.Fill = brush;
                    TextBlockInfo.Text = $"Шрифт {lb.Name} изменил цвет";
                }
            }
        }
    }
}