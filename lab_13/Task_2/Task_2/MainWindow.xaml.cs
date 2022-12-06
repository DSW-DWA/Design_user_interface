using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

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

        private UIElement _dragSource;

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
                                item.Content = lbInsert.Content;
                                ListBox1.Items.Add(item);
                            }
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
                        }
                    }
                    else
                    {
                        var lbi = (ListBoxItem)lb.Items[0];
                        var txt = TextBox.Text;
                        TextBox.Text = lbi.Content.ToString();
                        lbi.Content = txt;
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
                        foreach (var lbSelectedItem in lb.SelectedItems)
                        {
                            var lbInsert = (ListBoxItem)lbSelectedItem;
                            var item = new ListBoxItem();
                            item.Content = lbInsert.Content;
                            ListBox1.Items.Add(item);
                        }
                    }
                }
            }
        }
    }
}