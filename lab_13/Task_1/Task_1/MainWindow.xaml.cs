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
        private bool _putInTextBox = false;
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
                if (!_putInTextBox)
                {
                    lbl.Margin = new Thickness(e.GetPosition(this).X - lbl.ActualWidth / 2,
                        e.GetPosition(this).Y - lbl.ActualHeight / 2, 0, 0);
                    
                    _putInTextBox = false;
                }
                else
                {
                    lbl.IsEnabled = true;
                    lbl.AllowDrop = false;
                    lbl.Margin = new Thickness(e.GetPosition(this).X - lbl.ActualWidth / 2,
                        e.GetPosition(this).Y - lbl.ActualHeight / 2, 0, 0);
                    if (_dragSource.GetType() == typeof(TextBlock))
                    {
                        var tb1 = (TextBlock)_dragSource;
                        tb1.Text = "";
                        tb1.AllowDrop = true;
                    }
                    
                    _putInTextBox = false;
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
            lbl.IsEnabled = false;
            lbl.AllowDrop = false;
            _afterPutIntTextBox = true;
            _putInTextBox = true;
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
            foreach (UIElement gridChild in Grid.Children)
            {
                var lbl1 = (Label)gridChild;
                if (lbl1.Content == tb.Text)
                {
                    lbl = lbl1;
                    break;
                }
            }
            _dragSource = tb;
            DragDrop.DoDragDrop(tb, lbl, DragDropEffects.Copy);
        }
    }
}