using System;
using System.IO;
using System.Security.Policy;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Task1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            _anim1 = (BeginStoryboard)this.Resources["MyStoryboardAfter"];
            _anim = (BeginStoryboard)this.Resources["MyStoryboard"];
            _ren = MyAnimation;
        }
        private BeginStoryboard _anim;
        private BeginStoryboard _anim1;
        private RotateTransform _ren;
        private bool _rectanglesAuto = false;
        private void ButtonBase_OnClick_Up(object sender, RoutedEventArgs e)
        {
            var btn = (Button)sender;
            var grid = (Grid)btn.Parent;
            var tb =(TextBox)grid.Children[0];
            tb.Text = (Convert.ToInt32(tb.Text) + 1).ToString();
            RectangleCount_OnPreviewTextInput(tb);
            if (_rectanglesAuto)
            {
                ButtonBase_OnClick_Rectangles();
            }
            var ti = (TabItem)Draw.SelectedItem;
            if (ti == DrawAnimation)
            {
                ButtonBase_OnClick_Rectangles();
            }
        }

        private void ButtonBase_OnClick_Down(object sender, RoutedEventArgs e)
        {
            var btn = (Button)sender;
            var grid = (Grid)btn.Parent;
            var tb =(TextBox)grid.Children[0];
            var num = Convert.ToInt32(tb.Text);
            if (num > 0)
            {
                tb.Text = (Convert.ToInt32(tb.Text) - 1).ToString();
                RectangleCount_OnPreviewTextInput(tb);
                if (_rectanglesAuto)
                {
                    ButtonBase_OnClick_Rectangles();
                }
                var ti = (TabItem)Draw.SelectedItem;
                if (ti == DrawAnimation)
                {
                    ButtonBase_OnClick_Rectangles();
                }
            }
            
        }
        private void ButtonBase_OnClick_Rectangles(object sender, RoutedEventArgs e)
        {
            var ti = (TabItem)Draw.SelectedItem;
            if (ti == DrawRectangle)
            {
                Rectangles.Children.Clear();
                var height = Convert.ToInt32(RectangleSideA.Text) + 20;
                var width = Convert.ToInt32(RectangleSideB.Text) + 20;
                var k = Convert.ToInt32(RectangleCount.Text);
                var thick = Convert.ToInt32(RectangStrokeThick.Text);
                var thickType = "2400";
                if (ComboBoxRectangleStrokeType.Text == "Штрихованные")
                {
                    thickType = "3";
                }
                if (ComboBoxRectangleStrokeType.Text == "Точки")
                {
                    thickType = "1";
                }
                for (int i = 0; i < k; i++)
                {
                    if (width > 20 && height > 20)
                    {
                        var rec = new Rectangle();
                        rec.Stroke = Brushes.Black;
                        rec.Height = height - 20;
                        rec.Width = width - 20;
                        rec.StrokeThickness = thick;
                        rec.StrokeDashArray = DoubleCollection.Parse(thickType);
                        height -= 20;
                        width -= 20;
                        Rectangles.Children.Add(rec);
                    }
                }
            }
            if (ti == DrawSquare)
            {
                var side = Convert.ToInt32(SquareSide.Text);
                var k = Convert.ToInt32(SquareCount.Text);
                var cos = Convert.ToDouble(SquareCos.Value);
                var angleRad = Math.Acos(cos);
                var angle = Math.Acos(cos) * (180/Math.PI);
                Squares.Children.Clear();
                var r = new Random();
                var brushFill = new SolidColorBrush(Color.FromRgb((byte)r.Next(1, 255),
                    (byte)r.Next(1, 255), (byte)r.Next(1, 233)));
                var rec = new Rectangle();
                rec.Height = side;
                rec.Width = side;
                if (k != 0)Squares.Children.Add(rec);
                if (cos != 0)
                {
                    for (var i = 0; i < k - 1; i++)
                    {
                        var rec1 = new Rectangle();
                        var rotate = new RotateTransform();
                        rotate.Angle = (i + 1) * angle;
                        side = Convert.ToInt32(side / ((Math.Tan(angleRad) + 1) * cos));
                        rec1.Fill = brushFill;
                        rec1.Height = side;
                        rec1.Width = side;
                        rec1.LayoutTransform = rotate;
                        brushFill = new SolidColorBrush(Color.FromRgb((byte)r.Next(1, 255),
                            (byte)r.Next(1, 255), (byte)r.Next(1, 233)));
                        Squares.Children.Add(rec1);
                    }
                }
                return;
            }
            if (ti == DrawAnimation)
            {
                Animations.Children.Clear();
                _anim.Storyboard.Stop(this);
                _anim1.Storyboard.Stop(this);
                var rec = new Rectangle();
                rec.Width = Convert.ToInt32(AnimationSide.Text);
                rec.Height = Convert.ToInt32(AnimationSide.Text);
                rec.Name = "RectangleAnimation";
                rec.Margin = new Thickness(0, 0, 2 * rec.Width, 0);
                rec.Stroke = Brushes.Black;
                rec.RenderTransformOrigin = new Point(1,1);
                rec.RenderTransform = _ren;
                Animations.Children.Add(rec);
                return;
            }
        }
        private void ButtonBase_OnClick_Rectangles()
        {
            var ti = (TabItem)Draw.SelectedItem;
            if (ti == DrawRectangle){
                Rectangles.Children.Clear();
                var height = Convert.ToInt32(RectangleSideA.Text) + 20;
                var width = Convert.ToInt32(RectangleSideB.Text) + 20;
                var k = Convert.ToInt32(RectangleCount.Text);
                var thick = Convert.ToInt32(RectangStrokeThick.Text);
                var thickType = "2400";
                if (ComboBoxRectangleStrokeType.Text == "Штрихованные")
                {
                    thickType = "3";
                }
                if (ComboBoxRectangleStrokeType.Text == "Точки")
                {
                    thickType = "1";
                }

                var r = new Random();
                var brush = new SolidColorBrush(Color.FromRgb((byte)r.Next(1, 255),
                    (byte)r.Next(1, 255), (byte)r.Next(1, 233)));
                var cbi = ComboBoxRectangleStrokeColor;
                if (cbi.Text == "Red")
                {
                    brush = Brushes.Red;
                }
                if (cbi.Text == "Green")
                {
                    brush = Brushes.DarkGreen;
                }
                if (cbi.Text == "Black")
                {
                    brush = Brushes.Black;
                }
                if (cbi.Text == "Yellow")
                {
                    brush = Brushes.Yellow;
                }
                if (cbi.Text == "Orange")
                {
                    brush = Brushes.Orange;
                }
                if (cbi.Text == "White")
                {
                    brush = Brushes.White;
                }
                if (cbi.Text == "Blue")
                {
                    brush = Brushes.Blue;
                }
                for (int i = 0; i < k; i++)
                {
                    if (width > 20 && height > 20)
                    {
                        var rec = new Rectangle();
                        rec.Stroke = brush;
                        rec.Height = height - 20;
                        rec.Width = width - 20;
                        rec.StrokeThickness = thick;
                        rec.StrokeDashArray = DoubleCollection.Parse(thickType);
                        height -= 20;
                        width -= 20;
                        Rectangles.Children.Add(rec);
                        if (cbi.Text == "Random")
                        {
                            brush = new SolidColorBrush(Color.FromRgb((byte)r.Next(1, 255),
                                (byte)r.Next(1, 255), (byte)r.Next(1, 233)));
                        }
                    }
                }
                return;
            }
            if (ti == DrawSquare)
            {
                var side = Convert.ToInt32(SquareSide.Text);
                var k = Convert.ToInt32(SquareCount.Text);
                var cos = Convert.ToDouble(SquareCos.Value);
                var angleRad = Math.Acos(cos);
                var angle = Math.Acos(cos) * (180/Math.PI);
                Squares.Children.Clear();
                var r = new Random();
                var brushFill = new SolidColorBrush(Color.FromRgb((byte)r.Next(1, 255),
                    (byte)r.Next(1, 255), (byte)r.Next(1, 233)));
                var rec = new Rectangle();
                rec.Height = side;
                rec.Width = side;
                rec.Fill = brushFill;
                brushFill = new SolidColorBrush(Color.FromRgb((byte)r.Next(1, 255),
                    (byte)r.Next(1, 255), (byte)r.Next(1, 233)));
                if (k != 0)Squares.Children.Add(rec);
                if (cos != 0)
                {
                    for (var i = 0; i < k - 1; i++)
                    {
                        var rec1 = new Rectangle();
                        var rotate = new RotateTransform();
                        rotate.Angle = (i + 1) * angle;
                        side = Convert.ToInt32(side / ((Math.Tan(angleRad) + 1) * cos));
                        rec1.Height = side;
                        rec1.Width = side;
                        rec1.LayoutTransform = rotate;
                        rec1.Fill = brushFill;
                        brushFill = new SolidColorBrush(Color.FromRgb((byte)r.Next(1, 255),
                            (byte)r.Next(1, 255), (byte)r.Next(1, 233)));
                        Squares.Children.Add(rec1);
                    }
                }
                return;
            }

            if (ti == DrawAnimation)
            {
                Animations.Children.Clear();
                _anim.Storyboard.Stop(this);
                _anim1.Storyboard.Stop(this);
                var rec = new Rectangle();
                rec.Width = Convert.ToInt32(AnimationSide.Text);
                rec.Height = Convert.ToInt32(AnimationSide.Text);
                rec.Name = "RectangleAnimation";
                rec.Margin = new Thickness(0, 0, 2 * rec.Width, 0);
                rec.Stroke = Brushes.Black;
                rec.RenderTransformOrigin = new Point(1,1);
                rec.RenderTransform = _ren;
                Animations.Children.Add(rec);
                return;
            }
        }
        private void CheckBoxRectangles_OnClick(object sender, RoutedEventArgs e)
        {
            var cb = (CheckBox)sender;
            var ti = (TabItem)Draw.SelectedItem;
            if (cb.IsChecked == true)
            {
                _rectanglesAuto = true;
                if (ti == DrawRectangle) RectanglesRewrite.IsEnabled = false;
                if (ti == DrawSquare) SquareRewrite.IsEnabled = false;
            }
            else
            {
                _rectanglesAuto = false;
                if (ti == DrawRectangle) RectanglesRewrite.IsEnabled = true;
                if (ti == DrawSquare) SquareRewrite.IsEnabled = true;
            }

            ButtonBase_OnClick_Rectangles();
        }
        private void Rectangle_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (_rectanglesAuto)
            {
                ButtonBase_OnClick_Rectangles();
            }
        }
        private void ComboBoxRectangleStrokeType_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_rectanglesAuto)
            {
                var cb = (ComboBox)sender;
                var cbi = (ComboBoxItem)cb.SelectedItem;
                var thickType = "2400";
                if (cbi.Content.ToString() == "Штрихованные")
                {
                    thickType = "3";
                }

                if (cbi.Content.ToString() == "Точки")
                {
                    thickType = "1";
                }
                var si = (TabItem)Draw.SelectedItem;
                var gr = (Grid)si.Content;
                var gr1 = (Grid)gr.Children[1];
                if (gr1!= null)
                {
                    foreach (UIElement rectanglesChild in gr1.Children)
                    {
                        var rec = (Rectangle)rectanglesChild;
                        rec.StrokeDashArray = DoubleCollection.Parse(thickType);
                    }
                }
            }
        }
        private void ComboBoxRectangleStrokeColor_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_rectanglesAuto)
            {
                Random r = new Random();
                Brush brush = new SolidColorBrush(Color.FromRgb((byte)r.Next(1, 255), 
                    (byte)r.Next(1, 255), (byte)r.Next(1, 233)));
                var cb = (ComboBox)sender;
                var cbi = (ComboBoxItem)cb.SelectedItem;
                if (cbi.Content.ToString() == "Red")
                {
                    brush = Brushes.Red;
                }
                if (cbi.Content.ToString() == "Green")
                {
                    brush = Brushes.DarkGreen;
                }
                if (cbi.Content.ToString() == "Black")
                {
                    brush = Brushes.Black;
                }
                if (cbi.Content.ToString() == "Yellow")
                {
                    brush = Brushes.Yellow;
                }
                if (cbi.Content.ToString() == "Orange")
                {
                    brush = Brushes.Orange;
                }
                if (cbi.Content.ToString() == "White")
                {
                    brush = Brushes.White;
                }
                if (cbi.Content.ToString() == "Blue")
                {
                    brush = Brushes.Blue;
                }

                var si = (TabItem)Draw.SelectedItem;
                var gr = (Grid)si.Content;
                var gr1 = (Grid)gr.Children[1];
                if (gr1!= null)
                {
                    foreach (UIElement rectanglesChild in gr1.Children)
                    {
                        var rec = (Rectangle)rectanglesChild;
                        rec.Stroke = brush;
                        if (cbi.Content.ToString() == "Random")
                        {
                            brush = new SolidColorBrush(Color.FromRgb((byte)r.Next(1, 255),
                                (byte)r.Next(1, 255), (byte)r.Next(1, 233)));
                        }
                    }
                }
            }
        }
        private void RectangleCount_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Regex.IsMatch(e.Text, @"\d"))
            {
                e.Handled = true;
                return;
            }
            var ti = (TabItem)Draw.SelectedItem;
            if (ti == DrawRectangle)
            {

                var tb = (TextBox)sender;
                var heightText = RectangleSideA.Text + (tb.Name == "RectangleSideA" ? e.Text : "");
                var widthText = RectangleSideB.Text + (tb.Name == "RectangleSideB" ? e.Text : "");
                var kText = RectangleCount.Text + (tb.Name == "RectangleCount" ? e.Text : "");
                var height = Convert.ToInt32(heightText);
                var width = Convert.ToInt32(widthText);
                var k = Convert.ToInt32(kText);
                if (height > 600)
                {
                    e.Handled = true;
                    RectangleSideA.Text = "600";

                }

                if (width > 600)
                {
                    e.Handled = true;
                    RectangleSideB.Text = "600";
                }

                if (height / 20 < k || width / 20 < k)
                {
                    var tmp = Math.Min(height / 20, width / 20);
                    e.Handled = true;
                    RectangleCount.Text = tmp.ToString();
                }
            }

            if (ti == DrawSquare)
            {
                var tb = (TextBox)sender;
                var heightText = SquareSide.Text + (tb.Name == "SquareSide" ? e.Text : "");
                var sd = Convert.ToInt32(heightText);
                if (sd > 600)
                {
                    e.Handled = true;
                    SquareSide.Text = "600";
                }
            }
            if (ti == DrawAnimation)
            {
                var sd = Convert.ToInt32(AnimationSide.Text + e.Text);
                if (sd > 130)
                {
                    e.Handled = true;
                    AnimationSide.Text = "130";
                }
            }
        }
        private void RectangleCount_OnPreviewTextInput(object sender)
        {
            var ti = (TabItem)Draw.SelectedItem;
            if (ti == DrawRectangle)
            {
                var heightText = RectangleSideA.Text;
                var widthText = RectangleSideB.Text;
                var kText = RectangleCount.Text;
                var height = Convert.ToInt32(heightText);
                var width = Convert.ToInt32(widthText);
                var k = Convert.ToInt32(kText);
                if (height > 600)
                {
                    RectangleSideA.Text = "600";

                }

                if (width > 600)
                {
                    RectangleSideB.Text = "600";
                }

                if (height / 20 < k || width / 20 < k)
                {
                    var tmp = Math.Min(height / 20, width / 20);
                    RectangleCount.Text = tmp.ToString();
                }
            }
        }
        private void DrawRectangle_OnInitialized(object sender, EventArgs e)
        {
            _rectanglesAuto = false;
        }

        private void RangeBase_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (_rectanglesAuto)
            {
                ButtonBase_OnClick_Rectangles();
            }
        }

        private void Timeline_OnCompleted(object sender, EventArgs e)
        {
            var r = RectangleAnimation.Margin.Right;
            var side = RectangleAnimation.Width;
            RectangleAnimation.Margin = new Thickness(0, 0, r - 2 * side, 0);
            _anim1.Storyboard.Begin(this, true);
        }

        private void ButtonStart_OnClick(object sender, RoutedEventArgs e)
        {
            var side = RectangleAnimation.Width;
            RectangleAnimation.Margin = new Thickness(0, 0, 2 * side, 0);
            _anim.Storyboard.Begin(this, true);
        }

        private void StopButtonAnimation_OnClick(object sender, RoutedEventArgs e)
        {
            _anim.Storyboard.Pause(this);
            _anim1.Storyboard.Pause(this);
        }

        private void AnimationSpeed_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var dur = AnimationSpeed.Value;
            if (_anim != null) _anim.Storyboard.Children[0].SpeedRatio = dur;
            if (_anim1 != null) _anim1.Storyboard.Children[0].SpeedRatio = dur;
        }

        private void DrawRectangle_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            _rectanglesAuto = false;
            if (CheckBoxRectangles != null) CheckBoxRectangles.IsChecked = false;
            if (CheckBoxSquare != null) CheckBoxSquare.IsChecked = false;
            if (RectanglesRewrite != null) RectanglesRewrite.IsEnabled = true;
            if (SquareRewrite != null) SquareRewrite.IsEnabled = true;
        }
        
        private void SaveButton_OnClick(object sender, RoutedEventArgs e)
        {
            var ti = (TabItem)Draw.SelectedItem;
            if (ti == DrawRectangle)
            {
                var rect = new Rect(CanvasRectangles.RenderSize);
                var visual = new DrawingVisual();
                var height = Convert.ToInt32(RectangleSideA.Text);
                var width = Convert.ToInt32(RectangleSideB.Text);
                using (var dc = visual.RenderOpen())
                {
                    dc.DrawRectangle(new VisualBrush(CanvasRectangles), null, rect);
                }

                var bitmap = new RenderTargetBitmap(
                    (int)rect.Width, (int)rect.Height, 96, 96, PixelFormats.Default);
                bitmap.Render(visual);
                var encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bitmap));
                using (var file = File.OpenWrite("Прямоуголники.bmp"))
                {
                    encoder.Save(file);
                }
            }

            if (ti == DrawSquare)
            {
                var rect = new Rect(CanvasSquare.RenderSize);
                var visual = new DrawingVisual();
                using (var dc = visual.RenderOpen())
                {
                    dc.DrawRectangle(new VisualBrush(CanvasSquare), null, rect);
                }

                var bitmap = new RenderTargetBitmap(
                    (int)rect.Width, (int)rect.Height, 96, 96, PixelFormats.Default);
                bitmap.Render(visual);
                var encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bitmap));
                using (var file = File.OpenWrite("Квадраты.bmp"))
                {
                    encoder.Save(file);
                } 
            }
        }
    }
}