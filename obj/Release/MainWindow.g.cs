﻿#pragma checksum "..\..\MainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "186B29A278953DA2A0342D657215BD6E2939AB4B6BC7C7FC590F46972704E6BB"
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
using XO;


namespace XO {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid XOs;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button U;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button UR;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button D;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button C;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button UL;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DL;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DR;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button R;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button L;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Controls;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Debox;
        
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
            System.Uri resourceLocater = new System.Uri("/XO;component/mainwindow.xaml", System.UriKind.Relative);
            
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
            this.XOs = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.U = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\MainWindow.xaml"
            this.U.MouseMove += new System.Windows.Input.MouseEventHandler(this.War);
            
            #line default
            #line hidden
            
            #line 18 "..\..\MainWindow.xaml"
            this.U.Click += new System.Windows.RoutedEventHandler(this.XO_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.UR = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\MainWindow.xaml"
            this.UR.Click += new System.Windows.RoutedEventHandler(this.XO_Click);
            
            #line default
            #line hidden
            
            #line 20 "..\..\MainWindow.xaml"
            this.UR.MouseMove += new System.Windows.Input.MouseEventHandler(this.War);
            
            #line default
            #line hidden
            return;
            case 4:
            this.D = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\MainWindow.xaml"
            this.D.Click += new System.Windows.RoutedEventHandler(this.XO_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.C = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\MainWindow.xaml"
            this.C.MouseMove += new System.Windows.Input.MouseEventHandler(this.War);
            
            #line default
            #line hidden
            
            #line 22 "..\..\MainWindow.xaml"
            this.C.Click += new System.Windows.RoutedEventHandler(this.XO_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.UL = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\MainWindow.xaml"
            this.UL.MouseMove += new System.Windows.Input.MouseEventHandler(this.War);
            
            #line default
            #line hidden
            
            #line 23 "..\..\MainWindow.xaml"
            this.UL.Click += new System.Windows.RoutedEventHandler(this.XO_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.DL = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\MainWindow.xaml"
            this.DL.MouseMove += new System.Windows.Input.MouseEventHandler(this.War);
            
            #line default
            #line hidden
            
            #line 24 "..\..\MainWindow.xaml"
            this.DL.Click += new System.Windows.RoutedEventHandler(this.XO_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.DR = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\MainWindow.xaml"
            this.DR.MouseMove += new System.Windows.Input.MouseEventHandler(this.War);
            
            #line default
            #line hidden
            
            #line 25 "..\..\MainWindow.xaml"
            this.DR.Click += new System.Windows.RoutedEventHandler(this.XO_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.R = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\MainWindow.xaml"
            this.R.MouseMove += new System.Windows.Input.MouseEventHandler(this.War);
            
            #line default
            #line hidden
            
            #line 26 "..\..\MainWindow.xaml"
            this.R.Click += new System.Windows.RoutedEventHandler(this.XO_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.L = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\MainWindow.xaml"
            this.L.MouseMove += new System.Windows.Input.MouseEventHandler(this.War);
            
            #line default
            #line hidden
            
            #line 27 "..\..\MainWindow.xaml"
            this.L.Click += new System.Windows.RoutedEventHandler(this.XO_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.Controls = ((System.Windows.Controls.Grid)(target));
            return;
            case 12:
            
            #line 30 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.Debox = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

