using System.Windows;
using System.Windows.Controls;
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
        }

        private bool _afterPutIntTextBox;
        private UIElement _dragSource;
        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Label lbl = (Label)sender;
            _dragSource = lbl;
            DragDrop.DoDragDrop(lbl, lbl, DragDropEffects.Copy);
        }

        private void Grid_OnDrop(object sender, DragEventArgs e)
        {
            var lbl = (Label)e.Data.GetData(typeof(Label));
            if (!_afterPutIntTextBox)
            {
                if (Grid.Children.Contains(lbl))
                {
                    lbl.Margin = new Thickness(e.GetPosition(this).X - lbl.ActualWidth / 2,
                        e.GetPosition(this).Y - lbl.ActualHeight / 2, 0, 0);
                }
                else
                {
                    lbl.Margin = new Thickness(e.GetPosition(this).X - lbl.Width / 2,
                        e.GetPosition(this).Y - lbl.Height / 2, 0, 0);
                    Grid.Children.Add(lbl);
                    if (_dragSource.GetType() == typeof(TextBlock))
                    {
                        var tb1 = (TextBlock)_dragSource;
                        tb1.Text = "";
                        tb1.AllowDrop = true;
                    }
                }
            }
            else
            {
                _afterPutIntTextBox = false;
            }
        }

        private void UIElement_OnDrop(object sender, DragEventArgs e)
        {
            var tb = (TextBlock)sender;
            var lbl = (Label)e.Data.GetData(typeof(Label));
            tb.Text = lbl.Content.ToString();
            Grid.Children.Remove(lbl);
            _afterPutIntTextBox = true;
            tb.AllowDrop = false;
            if (_dragSource.GetType() == typeof(TextBlock))
            {
                var tb1 = (TextBlock)_dragSource;
                tb1.Text = "";
                tb1.AllowDrop = true;
            }
        }

        private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            var tb = (TextBlock)sender;
            var lbl = new Label();
            lbl.Content = tb.Text;
            lbl.Height = 30;
            lbl.Width = 60;
            lbl.VerticalAlignment = VerticalAlignment.Top;
            lbl.HorizontalAlignment = HorizontalAlignment.Left;
            lbl.AllowDrop = false;
            lbl.MouseDown += (o, args) =>
            {
                Label_MouseDown(lbl, e);
            };
            _dragSource = tb;
            DragDrop.DoDragDrop(tb, lbl, DragDropEffects.Copy);
        }
    }
}