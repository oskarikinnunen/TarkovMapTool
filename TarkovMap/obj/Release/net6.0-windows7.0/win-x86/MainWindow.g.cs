﻿#pragma checksum "..\..\..\..\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "F15C1C45733AA1CAA3FDD242ED06359194E38C29"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Web.WebView2.Wpf;
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
using TarkovMap;


namespace TarkovMap {
    
    
    /// <summary>
    /// TarkovMapWindow
    /// </summary>
    public partial class TarkovMapWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grid;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid webgrid;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Microsoft.Web.WebView2.Wpf.WebView2 webView;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox URLBox;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LoadLabel;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border MapBorder;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Map;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label MapName;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ToggleBorder;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox WikiSearch;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button WikiSearchButton;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label DebugLabel;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.7.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/TarkovMap;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.7.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.grid = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.webgrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.webView = ((Microsoft.Web.WebView2.Wpf.WebView2)(target));
            
            #line 15 "..\..\..\..\MainWindow.xaml"
            this.webView.NavigationCompleted += new System.EventHandler<Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs>(this.webView_NavigationCompleted);
            
            #line default
            #line hidden
            
            #line 15 "..\..\..\..\MainWindow.xaml"
            this.webView.NavigationStarting += new System.EventHandler<Microsoft.Web.WebView2.Core.CoreWebView2NavigationStartingEventArgs>(this.webView_NavigationStarting);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 17 "..\..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Close_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.URLBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 28 "..\..\..\..\MainWindow.xaml"
            this.URLBox.KeyDown += new System.Windows.Input.KeyEventHandler(this.TextBox_KeyDown);
            
            #line default
            #line hidden
            return;
            case 6:
            this.LoadLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.MapBorder = ((System.Windows.Controls.Border)(target));
            return;
            case 8:
            this.Map = ((System.Windows.Controls.Image)(target));
            
            #line 35 "..\..\..\..\MainWindow.xaml"
            this.Map.MouseWheel += new System.Windows.Input.MouseWheelEventHandler(this.Map_MouseWheel);
            
            #line default
            #line hidden
            
            #line 35 "..\..\..\..\MainWindow.xaml"
            this.Map.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Map_MouseDown);
            
            #line default
            #line hidden
            
            #line 36 "..\..\..\..\MainWindow.xaml"
            this.Map.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.Map_MouseLeftButtonUp);
            
            #line default
            #line hidden
            
            #line 36 "..\..\..\..\MainWindow.xaml"
            this.Map.MouseMove += new System.Windows.Input.MouseEventHandler(this.Map_MouseMove);
            
            #line default
            #line hidden
            
            #line 37 "..\..\..\..\MainWindow.xaml"
            this.Map.MouseRightButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Map_MouseRightButtonDown);
            
            #line default
            #line hidden
            return;
            case 9:
            this.MapName = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            
            #line 52 "..\..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Expander)(target)).Collapsed += new System.Windows.RoutedEventHandler(this.Expander_Collapsed);
            
            #line default
            #line hidden
            
            #line 52 "..\..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Expander)(target)).Expanded += new System.Windows.RoutedEventHandler(this.Expander_Expanded);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 54 "..\..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Ballistics_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 55 "..\..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Market_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 56 "..\..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Close_Click);
            
            #line default
            #line hidden
            return;
            case 14:
            this.ToggleBorder = ((System.Windows.Controls.Button)(target));
            
            #line 57 "..\..\..\..\MainWindow.xaml"
            this.ToggleBorder.Click += new System.Windows.RoutedEventHandler(this.ToggleBorder_Click);
            
            #line default
            #line hidden
            return;
            case 15:
            this.WikiSearch = ((System.Windows.Controls.TextBox)(target));
            
            #line 58 "..\..\..\..\MainWindow.xaml"
            this.WikiSearch.GotFocus += new System.Windows.RoutedEventHandler(this.WikiSearch_GotFocus);
            
            #line default
            #line hidden
            
            #line 58 "..\..\..\..\MainWindow.xaml"
            this.WikiSearch.LostFocus += new System.Windows.RoutedEventHandler(this.WikiSearch_LostFocus);
            
            #line default
            #line hidden
            
            #line 58 "..\..\..\..\MainWindow.xaml"
            this.WikiSearch.KeyUp += new System.Windows.Input.KeyEventHandler(this.WikiSearch_KeyUp);
            
            #line default
            #line hidden
            return;
            case 16:
            this.WikiSearchButton = ((System.Windows.Controls.Button)(target));
            
            #line 59 "..\..\..\..\MainWindow.xaml"
            this.WikiSearchButton.Click += new System.Windows.RoutedEventHandler(this.WikiSearchButton_Click);
            
            #line default
            #line hidden
            return;
            case 17:
            this.DebugLabel = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

