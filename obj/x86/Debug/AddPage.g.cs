﻿#pragma checksum "C:\Users\Deadalus\Documents\Visual Studio 2015\Projects\todo list\AddPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "AB4A276B3339E7925F4CCF93147E46B1"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace todo_list
{
    partial class AddPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.BackButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 12 "..\..\..\AddPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.BackButton).Click += this.BackButton_Click;
                    #line default
                }
                break;
            case 2:
                {
                    this.SaveButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 28 "..\..\..\AddPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.SaveButton).Click += this.SaveButton_Click;
                    #line default
                }
                break;
            case 3:
                {
                    this.Desc = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 4:
                {
                    this.Title = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 5:
                {
                    this.DateTextBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 6:
                {
                    this.DatePicker = (global::Windows.UI.Xaml.Controls.CalendarDatePicker)(target);
                    #line 16 "..\..\..\AddPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.CalendarDatePicker)this.DatePicker).DateChanged += this.DatePicker_DateChanged;
                    #line default
                }
                break;
            case 7:
                {
                    this.TimePiacer = (global::Windows.UI.Xaml.Controls.TimePicker)(target);
                    #line 17 "..\..\..\AddPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.TimePicker)this.TimePiacer).TimeChanged += this.TimePiacer_TimeChanged;
                    #line default
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

