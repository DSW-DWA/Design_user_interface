#pragma checksum "..\..\..\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "85A3D77201BBB3F4D959C48E5AF3D98D596B844B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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
using Task_2;


namespace Task_2 {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Answer1;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Answer2;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox A;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox B;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox C;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.10.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Task_2;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.10.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Answer1 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.Answer2 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.A = ((System.Windows.Controls.TextBox)(target));
            
            #line 24 "..\..\..\MainWindow.xaml"
            this.A.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.A_TextChanged);
            
            #line default
            #line hidden
            
            #line 24 "..\..\..\MainWindow.xaml"
            this.A.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.NumberValidationTextBoxA);
            
            #line default
            #line hidden
            
            #line 24 "..\..\..\MainWindow.xaml"
            this.A.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.A_PreviewKeyDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.B = ((System.Windows.Controls.TextBox)(target));
            
            #line 29 "..\..\..\MainWindow.xaml"
            this.B.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.A_TextChanged);
            
            #line default
            #line hidden
            
            #line 29 "..\..\..\MainWindow.xaml"
            this.B.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.A_PreviewKeyDown);
            
            #line default
            #line hidden
            
            #line 29 "..\..\..\MainWindow.xaml"
            this.B.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.NumberValidationTextBoxB);
            
            #line default
            #line hidden
            return;
            case 5:
            this.C = ((System.Windows.Controls.TextBox)(target));
            
            #line 34 "..\..\..\MainWindow.xaml"
            this.C.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.A_TextChanged);
            
            #line default
            #line hidden
            
            #line 34 "..\..\..\MainWindow.xaml"
            this.C.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.A_PreviewKeyDown);
            
            #line default
            #line hidden
            
            #line 34 "..\..\..\MainWindow.xaml"
            this.C.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.NumberValidationTextBoxC);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

