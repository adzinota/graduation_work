#pragma checksum "..\..\..\..\Windows\StatisticsWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "A79480A9A7B1C6D610C62111A61FF6ACA6660D16"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using DomainComputersInfo.Windows;
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


namespace DomainComputersInfo.Windows {
    
    
    /// <summary>
    /// StatisticsWindow
    /// </summary>
    public partial class StatisticsWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\..\Windows\StatisticsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Processor;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\..\Windows\StatisticsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Socket;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\..\Windows\StatisticsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Virtualization;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\..\Windows\StatisticsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button MemorySize;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\Windows\StatisticsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button MemoryType;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\Windows\StatisticsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button MemoryVersion;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\Windows\StatisticsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button MemoryEdition;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.6.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/DomainComputersInfo;component/windows/statisticswindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Windows\StatisticsWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.6.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Processor = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\..\..\Windows\StatisticsWindow.xaml"
            this.Processor.Click += new System.Windows.RoutedEventHandler(this.Processor_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Socket = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\..\..\Windows\StatisticsWindow.xaml"
            this.Socket.Click += new System.Windows.RoutedEventHandler(this.Socket_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Virtualization = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\..\..\Windows\StatisticsWindow.xaml"
            this.Virtualization.Click += new System.Windows.RoutedEventHandler(this.Virtualization_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.MemorySize = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\..\..\Windows\StatisticsWindow.xaml"
            this.MemorySize.Click += new System.Windows.RoutedEventHandler(this.MemorySize_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.MemoryType = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\..\..\Windows\StatisticsWindow.xaml"
            this.MemoryType.Click += new System.Windows.RoutedEventHandler(this.MemoryType_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.MemoryVersion = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\..\Windows\StatisticsWindow.xaml"
            this.MemoryVersion.Click += new System.Windows.RoutedEventHandler(this.OSVersion_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.MemoryEdition = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\..\..\Windows\StatisticsWindow.xaml"
            this.MemoryEdition.Click += new System.Windows.RoutedEventHandler(this.OSEdition_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

