﻿#pragma checksum "..\..\HolidayRequestCreation.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "D250CC7A36574EC60159ACF4F4C192653DD924300B91A7CE59A2035076CF751E"
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
    /// HolidayRequestCreation
    /// </summary>
    public partial class HolidayRequestCreation : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\HolidayRequestCreation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox holidayDescription;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\HolidayRequestCreation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker holidayStartDate;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\HolidayRequestCreation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker holidayEndDate;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\HolidayRequestCreation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnHolidaySubmit;
        
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
            System.Uri resourceLocater = new System.Uri("/ftn-sims-hci-hospital;component/holidayrequestcreation.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\HolidayRequestCreation.xaml"
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
            this.holidayDescription = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.holidayStartDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 3:
            this.holidayEndDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 4:
            this.btnHolidaySubmit = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\HolidayRequestCreation.xaml"
            this.btnHolidaySubmit.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

