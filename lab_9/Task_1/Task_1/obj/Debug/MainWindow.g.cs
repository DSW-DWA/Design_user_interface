﻿#pragma checksum "..\..\MainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "99820720C539A90FB60607E5711C94C1F69332FC71DABD44C3C6226535B26224"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using Task_1;


namespace Task_1 {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Grid;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboBoxTitles;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GroupBox GroupBoxFont;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton RadioButtonDefaultFont;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel StackPanelCheck;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox CheckBox_comboBox;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox CheckBox_groupBox;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Menu Menu;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ListBox1;
        
        #line default
        #line hidden
        
        
        #line 111 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ListBox2;
        
        #line default
        #line hidden
        
        
        #line 145 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ListBox3;
        
        #line default
        #line hidden
        
        
        #line 172 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.StatusBar StatusBar;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Task_1;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 10 "..\..\MainWindow.xaml"
            ((Task_1.MainWindow)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.MainWindow_OnMouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 23 "..\..\MainWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.Window_Close);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 24 "..\..\MainWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.Window_Start);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Grid = ((System.Windows.Controls.Grid)(target));
            return;
            case 5:
            this.ComboBoxTitles = ((System.Windows.Controls.ComboBox)(target));
            
            #line 33 "..\..\MainWindow.xaml"
            this.ComboBoxTitles.MouseMove += new System.Windows.Input.MouseEventHandler(this.UIElement_OnMouseMove);
            
            #line default
            #line hidden
            
            #line 34 "..\..\MainWindow.xaml"
            this.ComboBoxTitles.MouseLeave += new System.Windows.Input.MouseEventHandler(this.UIElement_OnMouseLeave);
            
            #line default
            #line hidden
            
            #line 35 "..\..\MainWindow.xaml"
            this.ComboBoxTitles.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboBoxTitles_OnSelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.GroupBoxFont = ((System.Windows.Controls.GroupBox)(target));
            
            #line 52 "..\..\MainWindow.xaml"
            this.GroupBoxFont.MouseMove += new System.Windows.Input.MouseEventHandler(this.UIElement_OnMouseMove);
            
            #line default
            #line hidden
            
            #line 53 "..\..\MainWindow.xaml"
            this.GroupBoxFont.MouseLeave += new System.Windows.Input.MouseEventHandler(this.UIElement_OnMouseLeave);
            
            #line default
            #line hidden
            return;
            case 7:
            this.RadioButtonDefaultFont = ((System.Windows.Controls.RadioButton)(target));
            
            #line 61 "..\..\MainWindow.xaml"
            this.RadioButtonDefaultFont.Checked += new System.Windows.RoutedEventHandler(this.ToggleButton_OnChecked);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 63 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.RadioButton)(target)).Checked += new System.Windows.RoutedEventHandler(this.ToggleButton_OnChecked);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 66 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.RadioButton)(target)).Checked += new System.Windows.RoutedEventHandler(this.ToggleButton_OnChecked);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 69 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.RadioButton)(target)).Checked += new System.Windows.RoutedEventHandler(this.ToggleButton_OnChecked);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 72 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.RadioButton)(target)).Checked += new System.Windows.RoutedEventHandler(this.ToggleButton_OnChecked);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 75 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.RadioButton)(target)).Checked += new System.Windows.RoutedEventHandler(this.ToggleButton_OnChecked);
            
            #line default
            #line hidden
            return;
            case 13:
            this.StackPanelCheck = ((System.Windows.Controls.StackPanel)(target));
            
            #line 83 "..\..\MainWindow.xaml"
            this.StackPanelCheck.MouseMove += new System.Windows.Input.MouseEventHandler(this.UIElement_OnMouseMove);
            
            #line default
            #line hidden
            
            #line 84 "..\..\MainWindow.xaml"
            this.StackPanelCheck.MouseLeave += new System.Windows.Input.MouseEventHandler(this.UIElement_OnMouseLeave);
            
            #line default
            #line hidden
            return;
            case 14:
            this.CheckBox_comboBox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 87 "..\..\MainWindow.xaml"
            this.CheckBox_comboBox.Click += new System.Windows.RoutedEventHandler(this.ButtonBase_OnClick_Title);
            
            #line default
            #line hidden
            return;
            case 15:
            this.CheckBox_groupBox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 88 "..\..\MainWindow.xaml"
            this.CheckBox_groupBox.Click += new System.Windows.RoutedEventHandler(this.ButtonBase_OnClick_Font);
            
            #line default
            #line hidden
            return;
            case 16:
            this.Menu = ((System.Windows.Controls.Menu)(target));
            
            #line 93 "..\..\MainWindow.xaml"
            this.Menu.MouseMove += new System.Windows.Input.MouseEventHandler(this.UIElement_OnMouseMove);
            
            #line default
            #line hidden
            
            #line 94 "..\..\MainWindow.xaml"
            this.Menu.MouseLeave += new System.Windows.Input.MouseEventHandler(this.UIElement_OnMouseLeave);
            
            #line default
            #line hidden
            return;
            case 17:
            this.ListBox1 = ((System.Windows.Controls.ListBox)(target));
            return;
            case 18:
            
            #line 105 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuItem_OnClick_Delete);
            
            #line default
            #line hidden
            return;
            case 19:
            this.ListBox2 = ((System.Windows.Controls.ListBox)(target));
            return;
            case 20:
            
            #line 120 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuItem_OnClick_Delete);
            
            #line default
            #line hidden
            return;
            case 21:
            
            #line 127 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.TextBox)(target)).PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.NumberValidationTextBoxC);
            
            #line default
            #line hidden
            
            #line 128 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.TextBox)(target)).KeyDown += new System.Windows.Input.KeyEventHandler(this.TextBox_OnKeyDown);
            
            #line default
            #line hidden
            return;
            case 22:
            
            #line 132 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuItem_OnClick_C);
            
            #line default
            #line hidden
            return;
            case 23:
            
            #line 135 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuItem_OnClick_E);
            
            #line default
            #line hidden
            return;
            case 24:
            
            #line 139 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuItem_OnClick_Delete);
            
            #line default
            #line hidden
            return;
            case 25:
            this.ListBox3 = ((System.Windows.Controls.ListBox)(target));
            return;
            case 26:
            
            #line 153 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuItem_OnClick_Delete);
            
            #line default
            #line hidden
            return;
            case 27:
            
            #line 162 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.TextBox)(target)).KeyDown += new System.Windows.Input.KeyEventHandler(this.TextBox_OnKeyDown_ContextMenu);
            
            #line default
            #line hidden
            return;
            case 28:
            
            #line 166 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuItem_OnClick_Delete);
            
            #line default
            #line hidden
            return;
            case 29:
            
            #line 167 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuItem_OnClick_A);
            
            #line default
            #line hidden
            return;
            case 30:
            
            #line 168 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuItem_OnClick_D);
            
            #line default
            #line hidden
            return;
            case 31:
            this.StatusBar = ((System.Windows.Controls.Primitives.StatusBar)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

