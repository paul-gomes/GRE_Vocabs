﻿#pragma checksum "..\..\..\WordStats.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "1DB7ADE0D8023FF1801999A257BACE750A80287EE13B977275975871D2C27CF3"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using GRE_Vocabs;
using GRE_Vocabs.Models;
using Microsoft.Toolkit.Wpf.UI.Controls;
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


namespace GRE_Vocabs {
    
    
    /// <summary>
    /// WordStats
    /// </summary>
    public partial class WordStats : System.Windows.Window, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 90 "..\..\..\WordStats.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button showLearning;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\..\WordStats.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button showReview;
        
        #line default
        #line hidden
        
        
        #line 103 "..\..\..\WordStats.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button showFlagged;
        
        #line default
        #line hidden
        
        
        #line 108 "..\..\..\WordStats.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button showMastered;
        
        #line default
        #line hidden
        
        
        #line 118 "..\..\..\WordStats.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox vocabListComboBox;
        
        #line default
        #line hidden
        
        
        #line 123 "..\..\..\WordStats.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView wordStatsView;
        
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
            System.Uri resourceLocater = new System.Uri("/GRE_Vocabs;component/wordstats.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\WordStats.xaml"
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
            this.showLearning = ((System.Windows.Controls.Button)(target));
            
            #line 90 "..\..\..\WordStats.xaml"
            this.showLearning.Click += new System.Windows.RoutedEventHandler(this.ShowLearning_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.showReview = ((System.Windows.Controls.Button)(target));
            
            #line 98 "..\..\..\WordStats.xaml"
            this.showReview.Click += new System.Windows.RoutedEventHandler(this.ShowReview_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.showFlagged = ((System.Windows.Controls.Button)(target));
            
            #line 103 "..\..\..\WordStats.xaml"
            this.showFlagged.Click += new System.Windows.RoutedEventHandler(this.ShowFlagged_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.showMastered = ((System.Windows.Controls.Button)(target));
            
            #line 108 "..\..\..\WordStats.xaml"
            this.showMastered.Click += new System.Windows.RoutedEventHandler(this.ShowMastered_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.vocabListComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 118 "..\..\..\WordStats.xaml"
            this.vocabListComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.VocabListComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.wordStatsView = ((System.Windows.Controls.ListView)(target));
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
            switch (connectionId)
            {
            case 7:
            
            #line 146 "..\..\..\WordStats.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ClassifyReview_Click);
            
            #line default
            #line hidden
            break;
            case 8:
            
            #line 149 "..\..\..\WordStats.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ClassifyFlagged_Click);
            
            #line default
            #line hidden
            break;
            case 9:
            
            #line 152 "..\..\..\WordStats.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ClassifyMastered_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

