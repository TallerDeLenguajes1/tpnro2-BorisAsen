﻿#pragma checksum "..\..\modificarAlumno.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "9719C908EDA5105C582BB65891EBA1E7"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
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
using TP2_WPF;


namespace TP2_WPF {
    
    
    /// <summary>
    /// modificarAlumno
    /// </summary>
    public partial class modificarAlumno : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\modificarAlumno.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbDNIMod;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\modificarAlumno.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbApellidoMod;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\modificarAlumno.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbNombreMod;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\modificarAlumno.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dtpNacimientoMod;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\modificarAlumno.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnModificarAlumno;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\modificarAlumno.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox testLista;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\modificarAlumno.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cboCurso;
        
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
            System.Uri resourceLocater = new System.Uri("/TP2 WPF;component/modificaralumno.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\modificarAlumno.xaml"
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
            this.txbDNIMod = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.txbApellidoMod = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txbNombreMod = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.dtpNacimientoMod = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 5:
            this.btnModificarAlumno = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\modificarAlumno.xaml"
            this.btnModificarAlumno.Click += new System.Windows.RoutedEventHandler(this.btnModificarAlumno_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.testLista = ((System.Windows.Controls.ListBox)(target));
            return;
            case 7:
            this.cboCurso = ((System.Windows.Controls.ComboBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

