﻿#pragma checksum "..\..\Secretary.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "823B14EFE5B629DF4052596F1D47A229B252B7774528D1601E96DD066D7999A5"
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
using ftn_sims_hci_hospital;


namespace ftn_sims_hci_hospital {
    
    
    /// <summary>
    /// Secretary
    /// </summary>
    public partial class Secretary : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\Secretary.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btncreatepatient;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\Secretary.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnlistallpatients;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\Secretary.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView patientData;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\Secretary.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnviewpatient;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\Secretary.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btndeletepatient;
        
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
            System.Uri resourceLocater = new System.Uri("/ftn-sims-hci-hospital;component/secretary.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Secretary.xaml"
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
            this.btncreatepatient = ((System.Windows.Controls.Button)(target));
            
            #line 10 "..\..\Secretary.xaml"
            this.btncreatepatient.Click += new System.Windows.RoutedEventHandler(this.btncreatepatient_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnlistallpatients = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\Secretary.xaml"
            this.btnlistallpatients.Click += new System.Windows.RoutedEventHandler(this.btnlistallpatients_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.patientData = ((System.Windows.Controls.ListView)(target));
            return;
            case 4:
            this.btnviewpatient = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\Secretary.xaml"
            this.btnviewpatient.Click += new System.Windows.RoutedEventHandler(this.btnviewpatient_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btndeletepatient = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\Secretary.xaml"
            this.btndeletepatient.Click += new System.Windows.RoutedEventHandler(this.btndeletepatient_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

