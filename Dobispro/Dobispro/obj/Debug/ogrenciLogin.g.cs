﻿#pragma checksum "..\..\ogrenciLogin.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E8445037A9E1E593506D05D9A7254FBD"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DevExpress.Xpf.Editors;
using DevExpress.Xpf.Editors.DataPager;
using DevExpress.Xpf.Editors.DateNavigator;
using DevExpress.Xpf.Editors.ExpressionEditor;
using DevExpress.Xpf.Editors.Filtering;
using DevExpress.Xpf.Editors.Flyout;
using DevExpress.Xpf.Editors.Popups;
using DevExpress.Xpf.Editors.Popups.Calendar;
using DevExpress.Xpf.Editors.RangeControl;
using DevExpress.Xpf.Editors.Settings;
using DevExpress.Xpf.Editors.Settings.Extension;
using DevExpress.Xpf.Editors.Validation;
using DevExpress.Xpf.LayoutControl;
using Dobispro;
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


namespace Dobispro {
    
    
    /// <summary>
    /// ogrenciLogin
    /// </summary>
    public partial class ogrenciLogin : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\ogrenciLogin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid gridtst;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\ogrenciLogin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Editors.TextEdit txtTcNo;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\ogrenciLogin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Editors.PasswordBoxEdit txtSifre;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\ogrenciLogin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.LayoutControl.Tile girisYap;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\ogrenciLogin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.LayoutControl.Tile geri;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\ogrenciLogin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Dobispro.Bildirim bildirim1;
        
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
            System.Uri resourceLocater = new System.Uri("/Dobispro;component/ogrencilogin.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ogrenciLogin.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            this.gridtst = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.txtTcNo = ((DevExpress.Xpf.Editors.TextEdit)(target));
            
            #line 11 "..\..\ogrenciLogin.xaml"
            this.txtTcNo.PreviewTouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.txtTcNo_PreviewTouchDown);
            
            #line default
            #line hidden
            
            #line 11 "..\..\ogrenciLogin.xaml"
            this.txtTcNo.PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.txtTcNo_PreviewMouseDown);
            
            #line default
            #line hidden
            
            #line 11 "..\..\ogrenciLogin.xaml"
            this.txtTcNo.EditValueChanged += new DevExpress.Xpf.Editors.EditValueChangedEventHandler(this.txtTcNo_EditValueChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txtSifre = ((DevExpress.Xpf.Editors.PasswordBoxEdit)(target));
            
            #line 12 "..\..\ogrenciLogin.xaml"
            this.txtSifre.PreviewTouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.txtSifre_PreviewTouchDown);
            
            #line default
            #line hidden
            
            #line 12 "..\..\ogrenciLogin.xaml"
            this.txtSifre.PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.txtSifre_PreviewMouseDown);
            
            #line default
            #line hidden
            
            #line 12 "..\..\ogrenciLogin.xaml"
            this.txtSifre.EditValueChanged += new DevExpress.Xpf.Editors.EditValueChangedEventHandler(this.txtSifre_EditValueChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.girisYap = ((DevExpress.Xpf.LayoutControl.Tile)(target));
            
            #line 13 "..\..\ogrenciLogin.xaml"
            this.girisYap.PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.girisYap_PreviewMouseDown);
            
            #line default
            #line hidden
            
            #line 13 "..\..\ogrenciLogin.xaml"
            this.girisYap.PreviewTouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.girisYap_PreviewTouchDown);
            
            #line default
            #line hidden
            return;
            case 5:
            this.geri = ((DevExpress.Xpf.LayoutControl.Tile)(target));
            
            #line 19 "..\..\ogrenciLogin.xaml"
            this.geri.PreviewTouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.geri_PreviewTouchDown);
            
            #line default
            #line hidden
            
            #line 19 "..\..\ogrenciLogin.xaml"
            this.geri.PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.geri_PreviewMouseDown);
            
            #line default
            #line hidden
            return;
            case 6:
            this.bildirim1 = ((Dobispro.Bildirim)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

