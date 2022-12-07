using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.SqlServer.Server;

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
                        var txt = TextBox1.Text;
                        TextBox1.Text = lbi.Content.ToString();
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
            if (_dragSource.GetType() == typeof(TextBox))
            {
                var lbMain = (ListBox)sender;
                var data = e.Data.GetData(typeof(string));
                if (data != null){
                    if (_isLeftMouse)
                    {
                        var lbi = new ListBoxItem();
                        lbi.Content = (string)data;
                        lbMain.Items.Insert(0,lbi);
                    }
                    else
                    {
                        var lbi = new ListBoxItem();
                        lbi.Content = (string)data;
                        lbMain.Items.Add(lbi);
                    }
                }
            }
        }

        private void TextBox_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            _isLeftMouse = true;
            _dragSource = (TextBox)sender;
            if (TextBox1.Text != "") DragDrop.DoDragDrop(_dragSource, TextBox1.Text, DragDropEffects.Move);
            if (Keyboard.IsKeyDown(Key.LeftCtrl))
            {
                Clipboard.SetText(TextBox1.Text);
            }
            
            e.Handled = false;
        }

        private void TextBox1_OnPreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (TextBox1 != null)
            {
                _isLeftMouse = false;
                _dragSource = TextBox1;
                DragDrop.DoDragDrop(e.Source as DependencyObject, TextBox1.Text, DragDropEffects.Move);
                if (Keyboard.IsKeyDown(Key.LeftCtrl))
                {
                    Clipboard.SetText(TextBox1.Text);
                }

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

        private void TextBox1_OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.RightCtrl))
            {
                Clipboard.SetText(TextBox1.Text);
            }

            e.Handled = false;
        }
    }
}