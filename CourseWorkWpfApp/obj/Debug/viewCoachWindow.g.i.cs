﻿#pragma checksum "..\..\viewCoachWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "55AB0E1911B96011947AF29A6E5A98A1"
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
    /// viewCoachWindow
    /// </summary>
    public partial class viewCoachWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\viewCoachWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid coachDataGrid;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\viewCoachWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addCoachButton;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\viewCoachWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button deleteCoachtButton;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\viewCoachWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ascSortCoachButton;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\viewCoachWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button descSortCoachButton;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\viewCoachWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button saveCoachButton;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\viewCoachWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button editCoachButton;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\viewCoachWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox searchCoachTextBox;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\viewCoachWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button searchCoachButton;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\viewCoachWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label searchToolsLabel;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\viewCoachWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox searchSurnameCheckBox;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\viewCoachWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox searchPostCheckBox;
        
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
            System.Uri resourceLocater = new System.Uri("/CourseWorkWpfApp;component/viewcoachwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\viewCoachWindow.xaml"
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
            
            #line 8 "..\..\viewCoachWindow.xaml"
            ((CourseWorkWpfApp.viewCoachWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.coachDataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 3:
            this.addCoachButton = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\viewCoachWindow.xaml"
            this.addCoachButton.Click += new System.Windows.RoutedEventHandler(this.addCoachButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.deleteCoachtButton = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\viewCoachWindow.xaml"
            this.deleteCoachtButton.Click += new System.Windows.RoutedEventHandler(this.deleteCoachtButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ascSortCoachButton = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\viewCoachWindow.xaml"
            this.ascSortCoachButton.Click += new System.Windows.RoutedEventHandler(this.ascSortCoachButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.descSortCoachButton = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\viewCoachWindow.xaml"
            this.descSortCoachButton.Click += new System.Windows.RoutedEventHandler(this.descSortCoachButton_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.saveCoachButton = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\viewCoachWindow.xaml"
            this.saveCoachButton.Click += new System.Windows.RoutedEventHandler(this.saveButton_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.editCoachButton = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\viewCoachWindow.xaml"
            this.editCoachButton.Click += new System.Windows.RoutedEventHandler(this.editCoachButton_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.searchCoachTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 37 "..\..\viewCoachWindow.xaml"
            this.searchCoachTextBox.GotFocus += new System.Windows.RoutedEventHandler(this.searchCoachTextBox_GotFocus);
            
            #line default
            #line hidden
            return;
            case 10:
            this.searchCoachButton = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\viewCoachWindow.xaml"
            this.searchCoachButton.Click += new System.Windows.RoutedEventHandler(this.searchCoachButton_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.searchToolsLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 12:
            this.searchSurnameCheckBox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 40 "..\..\viewCoachWindow.xaml"
            this.searchSurnameCheckBox.Checked += new System.Windows.RoutedEventHandler(this.searchSurnameCheckBox_Checked);
            
            #line default
            #line hidden
            
            #line 40 "..\..\viewCoachWindow.xaml"
            this.searchSurnameCheckBox.Unchecked += new System.Windows.RoutedEventHandler(this.searchSurnameCheckBox_Unchecked);
            
            #line default
            #line hidden
            return;
            case 13:
            this.searchPostCheckBox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 41 "..\..\viewCoachWindow.xaml"
            this.searchPostCheckBox.Checked += new System.Windows.RoutedEventHandler(this.searchPostCheckBox_Checked);
            
            #line default
            #line hidden
            
            #line 41 "..\..\viewCoachWindow.xaml"
            this.searchPostCheckBox.Unchecked += new System.Windows.RoutedEventHandler(this.searchPostCheckBox_Unchecked);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

