﻿#pragma checksum "..\..\..\..\View\SalesOrder\RecurringSalesInvoice.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "FAD650554865EE87FBE22B1147550E24"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Accounts_Pos.Helpers;
using Accounts_Pos.Helpers.GridWithSolidGridLines;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interactivity;
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
using Xceed.Wpf.Toolkit;
using Xceed.Wpf.Toolkit.Chromes;
using Xceed.Wpf.Toolkit.Core.Converters;
using Xceed.Wpf.Toolkit.Core.Input;
using Xceed.Wpf.Toolkit.Core.Media;
using Xceed.Wpf.Toolkit.Core.Utilities;
using Xceed.Wpf.Toolkit.Panels;
using Xceed.Wpf.Toolkit.Primitives;
using Xceed.Wpf.Toolkit.PropertyGrid;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;
using Xceed.Wpf.Toolkit.PropertyGrid.Commands;
using Xceed.Wpf.Toolkit.PropertyGrid.Converters;
using Xceed.Wpf.Toolkit.PropertyGrid.Editors;
using Xceed.Wpf.Toolkit.Zoombox;


namespace Accounts_Pos.View.SalesOrder {
    
    
    /// <summary>
    /// RecurringSalesInvoice
    /// </summary>
    public partial class RecurringSalesInvoice : System.Windows.Window, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 14 "..\..\..\..\View\SalesOrder\RecurringSalesInvoice.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Frequency;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\View\SalesOrder\RecurringSalesInvoice.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Xceed.Wpf.Toolkit.MaskedTextBox ProcessNextOccuranceOn;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\..\View\SalesOrder\RecurringSalesInvoice.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Xceed.Wpf.Toolkit.MaskedTextBox LastPosted;
        
        #line default
        #line hidden
        
        
        #line 100 "..\..\..\..\View\SalesOrder\RecurringSalesInvoice.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CustomerCodeTxt;
        
        #line default
        #line hidden
        
        
        #line 105 "..\..\..\..\View\SalesOrder\RecurringSalesInvoice.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CustomerNameTxt;
        
        #line default
        #line hidden
        
        
        #line 113 "..\..\..\..\View\SalesOrder\RecurringSalesInvoice.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid ProductGrid;
        
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
            System.Uri resourceLocater = new System.Uri("/Accounts_Pos;component/view/salesorder/recurringsalesinvoice.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\SalesOrder\RecurringSalesInvoice.xaml"
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
            this.Frequency = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 2:
            this.ProcessNextOccuranceOn = ((Xceed.Wpf.Toolkit.MaskedTextBox)(target));
            return;
            case 3:
            this.LastPosted = ((Xceed.Wpf.Toolkit.MaskedTextBox)(target));
            return;
            case 4:
            
            #line 95 "..\..\..\..\View\SalesOrder\RecurringSalesInvoice.xaml"
            ((System.Windows.Documents.Hyperlink)(target)).Click += new System.Windows.RoutedEventHandler(this.Customerlink_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.CustomerCodeTxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.CustomerNameTxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.ProductGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            System.Windows.EventSetter eventSetter;
            switch (connectionId)
            {
            case 8:
            eventSetter = new System.Windows.EventSetter();
            eventSetter.Event = System.Windows.Controls.Control.PreviewMouseDoubleClickEvent;
            
            #line 165 "..\..\..\..\View\SalesOrder\RecurringSalesInvoice.xaml"
            eventSetter.Handler = new System.Windows.Input.MouseButtonEventHandler(this.ItemCode_PreviewMouseDown);
            
            #line default
            #line hidden
            ((System.Windows.Style)(target)).Setters.Add(eventSetter);
            eventSetter = new System.Windows.EventSetter();
            eventSetter.Event = System.Windows.UIElement.PreviewMouseDownEvent;
            
            #line 166 "..\..\..\..\View\SalesOrder\RecurringSalesInvoice.xaml"
            eventSetter.Handler = new System.Windows.Input.MouseButtonEventHandler(this.ItemCode_PreviewMouseDown);
            
            #line default
            #line hidden
            ((System.Windows.Style)(target)).Setters.Add(eventSetter);
            eventSetter = new System.Windows.EventSetter();
            eventSetter.Event = System.Windows.UIElement.LostFocusEvent;
            
            #line 167 "..\..\..\..\View\SalesOrder\RecurringSalesInvoice.xaml"
            eventSetter.Handler = new System.Windows.RoutedEventHandler(this.ItemCode_LostFocus);
            
            #line default
            #line hidden
            ((System.Windows.Style)(target)).Setters.Add(eventSetter);
            break;
            case 9:
            eventSetter = new System.Windows.EventSetter();
            eventSetter.Event = System.Windows.Controls.Control.PreviewMouseDoubleClickEvent;
            
            #line 175 "..\..\..\..\View\SalesOrder\RecurringSalesInvoice.xaml"
            eventSetter.Handler = new System.Windows.Input.MouseButtonEventHandler(this.ItemDescription_PreviewMouseDown);
            
            #line default
            #line hidden
            ((System.Windows.Style)(target)).Setters.Add(eventSetter);
            break;
            case 10:
            eventSetter = new System.Windows.EventSetter();
            eventSetter.Event = System.Windows.Controls.Control.PreviewMouseDoubleClickEvent;
            
            #line 182 "..\..\..\..\View\SalesOrder\RecurringSalesInvoice.xaml"
            eventSetter.Handler = new System.Windows.Input.MouseButtonEventHandler(this.ItemOrderQty_PreviewMouseDown);
            
            #line default
            #line hidden
            ((System.Windows.Style)(target)).Setters.Add(eventSetter);
            break;
            case 11:
            eventSetter = new System.Windows.EventSetter();
            eventSetter.Event = System.Windows.Controls.Control.PreviewMouseDoubleClickEvent;
            
            #line 189 "..\..\..\..\View\SalesOrder\RecurringSalesInvoice.xaml"
            eventSetter.Handler = new System.Windows.Input.MouseButtonEventHandler(this.ItemUnitPrice_PreviewMouseDown);
            
            #line default
            #line hidden
            ((System.Windows.Style)(target)).Setters.Add(eventSetter);
            break;
            case 12:
            eventSetter = new System.Windows.EventSetter();
            eventSetter.Event = System.Windows.Controls.Control.PreviewMouseDoubleClickEvent;
            
            #line 196 "..\..\..\..\View\SalesOrder\RecurringSalesInvoice.xaml"
            eventSetter.Handler = new System.Windows.Input.MouseButtonEventHandler(this.ItemDiscount_PreviewMouseDown);
            
            #line default
            #line hidden
            ((System.Windows.Style)(target)).Setters.Add(eventSetter);
            break;
            case 13:
            eventSetter = new System.Windows.EventSetter();
            eventSetter.Event = System.Windows.Controls.Control.PreviewMouseDoubleClickEvent;
            
            #line 203 "..\..\..\..\View\SalesOrder\RecurringSalesInvoice.xaml"
            eventSetter.Handler = new System.Windows.Input.MouseButtonEventHandler(this.ItemLineAmount_PreviewMouseDown);
            
            #line default
            #line hidden
            ((System.Windows.Style)(target)).Setters.Add(eventSetter);
            eventSetter = new System.Windows.EventSetter();
            eventSetter.Event = System.Windows.Data.Binding.TargetUpdatedEvent;
            
            #line 204 "..\..\..\..\View\SalesOrder\RecurringSalesInvoice.xaml"
            eventSetter.Handler = new System.EventHandler<System.Windows.Data.DataTransferEventArgs>(this.TextBox_TextChanged);
            
            #line default
            #line hidden
            ((System.Windows.Style)(target)).Setters.Add(eventSetter);
            break;
            }
        }
    }
}
