using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Security.Policy;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using NumericUpDownLib;

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
                var height = Convert.ToInt32(RectangleSideA.Text);
                var width = Convert.ToInt32(RectangleSideB.Text);
                var k = Convert.ToInt32(RectangleCount.Text);
                var step = Math.Min(height, width) / k;
                height += step;
                width += step;
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
                if (ComboBoxRectangleStrokeColor.IsEnabled)
                {
                    var cbi = ComboBoxRectangleStrokeColor.SelectedValue.ToString();
                    brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString(cbi));
                }
                for (int i = 0; i < k; i++)
                {
                    if (width > step && height > step)
                    {
                        var rec = new Rectangle();
                        rec.Stroke = brush;
                        rec.Height = height - step;
                        rec.Width = width - step;
                        rec.StrokeDashArray = DoubleCollection.Parse(thickType);
                        height -= step;
                        width -= step;
                        Rectangles.Children.Add(rec);
                        if (!ComboBoxRectangleStrokeColor.IsEnabled)
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
                rec.HorizontalAlignment = HorizontalAlignment.Right;
                rec.Margin =  new Thickness(0, 0, Animations.ActualWidth - Convert.ToInt32(AnimationSide.Text) - 10, 0);
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
                var height = Convert.ToInt32(RectangleSideA.Text);
                var width = Convert.ToInt32(RectangleSideB.Text);
                var k = Convert.ToInt32(RectangleCount.Text);
                var step = Math.Min(height, width) / k;
                height += step;
                width += step;
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
                if (ComboBoxRectangleStrokeColor.IsEnabled)
                {
                    var cbi = ComboBoxRectangleStrokeColor.SelectedValue.ToString();
                    brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString(cbi));
                }
                for (int i = 0; i < k; i++)
                {
                    if (width > step && height > step)
                    {
                        var rec = new Rectangle();
                        rec.Stroke = brush;
                        rec.Height = height - step;
                        rec.Width = width - step;
                        rec.StrokeDashArray = DoubleCollection.Parse(thickType);
                        height -= step;
                        width -= step;
                        Rectangles.Children.Add(rec);
                        if (!ComboBoxRectangleStrokeColor.IsEnabled)
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
                rec.HorizontalAlignment = HorizontalAlignment.Right;
                rec.Margin =  new Thickness(0, 0, Animations.ActualWidth - Convert.ToInt32(AnimationSide.Text) , 0);
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
                AutoRewrite.IsChecked = true;
                Rewrite.IsEnabled = false;
            }
            else
            {
                _rectanglesAuto = false;
                if (ti == DrawRectangle) RectanglesRewrite.IsEnabled = true;
                if (ti == DrawSquare) SquareRewrite.IsEnabled = true;
                AutoRewrite.IsChecked = false;
                Rewrite.IsEnabled = true;
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
                var cn = (Canvas)gr.Children[1];
                var gr1 = (Grid)cn.Children[0];
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
            if (CheckBoxRectangleRandom != null) CheckBoxRectangleRandom.IsChecked = false;
            if (_rectanglesAuto)
            {
                Random r = new Random();
                var cb = (ComboBox)sender;
                var cbi = cb.SelectedValue.ToString();
                var brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString(cbi));
                var si = (TabItem)Draw.SelectedItem;
                var gr = (Grid)si.Content;
                var cn = (Canvas)gr.Children[1];
                var gr1 = (Grid)cn.Children[0];
                if (gr1!= null)
                {
                    foreach (UIElement rectanglesChild in gr1.Children)
                    {
                        var rec = (Rectangle)rectanglesChild;
                        rec.Stroke = brush;
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
                if (width <= 0)
                {
                    e.Handled = true;
                    RectangleSideA.Text = "1";
                }

                if (width > 600)
                {
                    e.Handled = true;
                    RectangleSideB.Text = "600";
                }

                if (width <= 0)
                {
                    e.Handled = true;
                    RectangleSideB.Text = "1";
                }
                
                if (k > 9)
                {
                    e.Handled = true;
                    RectangleCount.Text = "9";
                }

                if (k <= 0)
                {
                    e.Handled = true;
                    RectangleCount.Text = "1";
                }
            }

            if (ti == DrawSquare)
            {
                var tb = (TextBox)sender;
                var heightText = SquareSide.Text + (tb.Name == "SquareSide" ? e.Text : "");
                var countText = SquareCount.Text + (tb == SquareCount ? e.Text : "");
                var sd = Convert.ToInt32(heightText);
                var count = Convert.ToInt32(countText);
                if (sd > 600)
                {
                    e.Handled = true;
                    SquareSide.Text = "600";
                }

                if (sd <= 0)
                {
                    e.Handled = true;
                    SquareSide.Text = "1";
                }

                if (count > 9)
                {
                    e.Handled = true;
                    SquareCount.Text = "9";
                }
                if (count <= 0)
                {
                    e.Handled = true;
                    SquareCount.Text = "1";
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
                if (height > 500)
                {
                    RectangleSideA.Text = "500";

                }

                if (width > 500)
                {
                    RectangleSideB.Text = "500";
                }

                if (k > 10)
                {
                    RectangleCount.Text = "10";
                }
            }
            if (ti == DrawSquare)
            {
                var tb = (TextBox)sender;
                var heightText = SquareSide.Text;
                var sd = Convert.ToInt32(heightText);
                if (sd > 500)
                {
                    SquareSide.Text = "500";
                }
            }
            if (ti == DrawAnimation)
            {
                var sd = Convert.ToInt32(AnimationSide.Text);
                if (sd > 130)
                {
                    AnimationSide.Text = "130";
                }
            }
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
            var rec = (Rectangle)(Animations.Children[0]);
            var r = rec.Margin.Right;
            var side = Convert.ToInt32(AnimationSide.Text);
            var right = r - side;
            if (right - side > 0)
            {
                rec.Margin = new Thickness(0, 0, right, 0);
                _anim.Storyboard.Begin(this, true);
            }
        }

        private void ButtonStart_OnClick(object sender, RoutedEventArgs e)
        {
            _anim.Storyboard.Stop(this);
            var rec = (Rectangle)(Animations.Children[0]);
            rec.Margin =  new Thickness(0, 0, Animations.ActualWidth - Convert.ToInt32(AnimationSide.Text) , 0);
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
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                _rectanglesAuto = false;
                if (CheckBoxRectangles != null) CheckBoxRectangles.IsChecked = false;
                if (CheckBoxSquare != null) CheckBoxSquare.IsChecked = false;
                if (RectanglesRewrite != null) RectanglesRewrite.IsEnabled = true;
                if (SquareRewrite != null) SquareRewrite.IsEnabled = true;
                AutoRewrite.IsChecked = false;
                Rewrite.IsEnabled = true;
            }
        }
        
        private void SaveButton_OnClick(object sender, RoutedEventArgs e)
        {
            var ti = (TabItem)Draw.SelectedItem;
            if (ti == DrawRectangle)
            {
                var rect = new Rect(CanvasRectangles.RenderSize);
                var sz = new Size(Convert.ToInt32(RectangleSideB.Text), Convert.ToInt32(RectangleSideA.Text));
                var rect1 = new Rect(sz);
                var visual = new DrawingVisual();
                using (var dc = visual.RenderOpen())
                {
                    var pt = new Point(0, Convert.ToInt32(CanvasRectangles.ActualHeight)-50);
                    var txt = new FormattedText(
                        $"Колл-во: {RectangleCount.Text}, Ширина: {RectangleSideB.Text}, Высота: {RectangleSideA.Text}",
                        CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface(SystemFonts.MessageFontFamily.Source), 20,
                        Brushes.Crimson);
                    rect1.Location = new Point(rect.Width / 2 - rect1.Width / 2, rect.Height / 2 - rect1.Height / 2);
                    dc.DrawText(txt,pt);
                    dc.DrawRectangle(new VisualBrush(Rectangles), null, rect1);
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
                var sz = new Size(Convert.ToInt32(SquareSide.Text),Convert.ToInt32(SquareSide.Text));
                var rect1 = new Rect(sz);
                var visual = new DrawingVisual();
                using (var dc = visual.RenderOpen())
                {
                    var pt = new Point(0, Convert.ToInt32(CanvasSquare.ActualHeight)-50);
                    var txt = new FormattedText(
                        $"Колл-во: {SquareCount.Text}, Сторона: {SquareSide.Text}, Косинус угла: {SquareCos.Value}",
                        CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface(SystemFonts.MessageFontFamily.Source), 20,
                        Brushes.Crimson);
                    rect1.Location = new Point(rect.Width / 2 - rect1.Width / 2, rect.Height / 2 - rect1.Height / 2);
                    dc.DrawText(txt,pt);
                    dc.DrawRectangle(new VisualBrush(Squares), null, rect1);
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

        private void MenuItem_OnClick2(object sender, RoutedEventArgs e)
        {
            var ti = (TabItem)Draw.SelectedItem;
            if (_rectanglesAuto)
            {
                _rectanglesAuto = false;
                if (ti == DrawRectangle) RectanglesRewrite.IsEnabled = true;
                if (ti == DrawSquare) SquareRewrite.IsEnabled = true;
                if (ti == DrawRectangle) CheckBoxRectangles.IsChecked = false;
                if (ti == DrawSquare) CheckBoxSquare.IsChecked = false;
            }
            ButtonBase_OnClick_Rectangles();
        }

        private void MenuItem_OnClick1(object sender, RoutedEventArgs e)
        {
            var ti = (TabItem)Draw.SelectedItem;
            var cmi = (MenuItem)sender;
            var cm = (ContextMenu)cmi.Parent;
            var rewrite = (MenuItem)cm.Items[2];
            if (!_rectanglesAuto)
            {
                _rectanglesAuto = true;
                if (ti == DrawRectangle) RectanglesRewrite.IsEnabled = false;
                if (ti == DrawSquare) SquareRewrite.IsEnabled = false;
                if (ti == DrawRectangle) CheckBoxRectangles.IsChecked = true;
                if (ti == DrawSquare) CheckBoxSquare.IsChecked = true;
                cmi.IsChecked = true;
                rewrite.IsEnabled = false;
            }
            else
            {
                _rectanglesAuto = false;
                if (ti == DrawRectangle) RectanglesRewrite.IsEnabled = true;
                if (ti == DrawSquare) SquareRewrite.IsEnabled = true;
                if (ti == DrawRectangle) CheckBoxRectangles.IsChecked = false;
                if (ti == DrawSquare) CheckBoxSquare.IsChecked = false;
                cmi.IsChecked = false;
                rewrite.IsEnabled = true;
            }

            ButtonBase_OnClick_Rectangles();
        }

        private void MainWindow_OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            var win = Application.Current.MainWindow;
            if (Rectangles != null) Rectangles.Width = win.ActualWidth - 210;
            if (Rectangles != null) Rectangles.Height = win.ActualHeight - 30;
            if (Squares != null) Squares.Width = win.ActualWidth - 210;
            if (Squares != null) Squares.Height = win.ActualHeight - 30;
            if (Animations != null) Animations.Width = win.ActualWidth - 210;
            if (Animations != null) Animations.Height = win.ActualHeight - 30;
        }

        private void RectangleSideA_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (_rectanglesAuto )
            {
                ButtonBase_OnClick_Rectangles();
            }
        }
        
        private void RectangleSideA_OnLostFocus(object sender, RoutedEventArgs e)
        {
            var ti = (TabItem)Draw.SelectedItem;
            if (RectangleSideA.Text == "") RectangleSideA.Text = "0";
            if (RectangleCount.Text == "") RectangleCount.Text = "0";
            if (RectangleSideB.Text == "") RectangleSideB.Text = "0";
            if (_rectanglesAuto || ti == DrawAnimation)
            {
                ButtonBase_OnClick_Rectangles();
            }
        }

        private void RectangleSideB_OnKeyDown(object sender, KeyEventArgs e)
        {
            var ti = (TabItem)Draw.SelectedItem;
            if (e.Key == Key.Enter)
            {
                if (RectangleSideA.Text == "") RectangleSideA.Text = "0";
                if (RectangleCount.Text == "") RectangleCount.Text = "0";
                if (RectangleSideB.Text == "") RectangleSideB.Text = "0";
                if (SquareSide.Text == "") SquareSide.Text = "0";
                if (SquareCount.Text == "") SquareCount.Text = "0";
                if (_rectanglesAuto || ti == DrawAnimation)
                {
                    ButtonBase_OnClick_Rectangles();
                } 
            }
        }

        private void CheckBoxRectangleRandom_OnClick(object sender, RoutedEventArgs e)
        {
            if (CheckBoxRectangleRandom.IsChecked == true)
            {
                ComboBoxRectangleStrokeColor.IsEnabled = false;
                if (_rectanglesAuto) ButtonBase_OnClick_Rectangles();
            }
            else
            {
                ComboBoxRectangleStrokeColor.IsEnabled = true;
                if (_rectanglesAuto) ButtonBase_OnClick_Rectangles();
            }
        }
    }
}