﻿#pragma checksum "..\..\viewClientWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "0BBC9F14122797F281401D43DF852B4B"
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
    /// viewClientWindow
    /// </summary>
    public partial class viewClientWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\viewClientWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid clientDataGrid;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\viewClientWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addClientButton;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\viewClientWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button deleteClientButton;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\viewClientWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ascSortClientButton;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\viewClientWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button descSortClientButton;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\viewClientWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button saveButton;
        
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
            System.Uri resourceLocater = new System.Uri("/CourseWorkWpfApp;component/viewclientwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\viewClientWindow.xaml"
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
            
            #line 8 "..\..\viewClientWindow.xaml"
            ((CourseWorkWpfApp.viewClientWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.clientDataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 3:
            this.addClientButton = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\viewClientWindow.xaml"
            this.addClientButton.Click += new System.Windows.RoutedEventHandler(this.addClientButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.deleteClientButton = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\viewClientWindow.xaml"
            this.deleteClientButton.Click += new System.Windows.RoutedEventHandler(this.deleteClientButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ascSortClientButton = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\viewClientWindow.xaml"
            this.ascSortClientButton.Click += new System.Windows.RoutedEventHandler(this.ascSortClientButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.descSortClientButton = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\viewClientWindow.xaml"
            this.descSortClientButton.Click += new System.Windows.RoutedEventHandler(this.descSortClientButton_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.saveButton = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\viewClientWindow.xaml"
            this.saveButton.Click += new System.Windows.RoutedEventHandler(this.saveButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

