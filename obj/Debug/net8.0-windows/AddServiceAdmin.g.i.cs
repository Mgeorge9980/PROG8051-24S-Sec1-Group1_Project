﻿#pragma checksum "..\..\..\AddServiceAdmin.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1515BA74ABB01D55C4E26F9996DEF483F2B8F3E0"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
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


namespace StudioManagement {
    
    
    /// <summary>
    /// AddServiceAdminWindow
    /// </summary>
    public partial class AddServiceAdminWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\AddServiceAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ServiceNameTextBox;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\AddServiceAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock ServiceNamePlaceholder;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\AddServiceAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox RateTextBox;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\AddServiceAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock RatePlaceholder;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\AddServiceAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SaveServiceButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.4.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/StudioManagement;V1.0.0.0;component/addserviceadmin.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\AddServiceAdmin.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.4.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.ServiceNameTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 17 "..\..\..\AddServiceAdmin.xaml"
            this.ServiceNameTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.ServiceNameTextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ServiceNamePlaceholder = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.RateTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 32 "..\..\..\AddServiceAdmin.xaml"
            this.RateTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.RateTextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.RatePlaceholder = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.SaveServiceButton = ((System.Windows.Controls.Button)(target));
            
            #line 43 "..\..\..\AddServiceAdmin.xaml"
            this.SaveServiceButton.Click += new System.Windows.RoutedEventHandler(this.SaveServiceButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

