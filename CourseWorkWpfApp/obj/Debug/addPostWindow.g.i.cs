﻿#pragma checksum "..\..\addPostWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "FC0CD221BE2E6611EF790ED3122360FA"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using CourseWorkWpfApp;
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


namespace CourseWorkWpfApp {
    
    
    /// <summary>
    /// addPostWindow
    /// </summary>
    public partial class addPostWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\addPostWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\addPostWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox postTitleTextBox;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\addPostWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid postDataGrid;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\addPostWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addPostButton;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\addPostWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button savePostButton;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\addPostWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button editPostButton;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\addPostWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button deletePostButton;
        
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
            System.Uri resourceLocater = new System.Uri("/CourseWorkWpfApp;component/addpostwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\addPostWindow.xaml"
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
            
            #line 8 "..\..\addPostWindow.xaml"
            ((CourseWorkWpfApp.addPostWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.label = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.postTitleTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.postDataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 5:
            this.addPostButton = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\addPostWindow.xaml"
            this.addPostButton.Click += new System.Windows.RoutedEventHandler(this.addPostButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.savePostButton = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\addPostWindow.xaml"
            this.savePostButton.Click += new System.Windows.RoutedEventHandler(this.savePostButton_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.editPostButton = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\addPostWindow.xaml"
            this.editPostButton.Click += new System.Windows.RoutedEventHandler(this.editPostButton_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.deletePostButton = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\addPostWindow.xaml"
            this.deletePostButton.Click += new System.Windows.RoutedEventHandler(this.deletePostButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
