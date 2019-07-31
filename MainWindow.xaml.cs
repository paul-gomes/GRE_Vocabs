using System;
using System.Windows;
using CefSharp;
using CefSharp.Wpf;

namespace GRE_Vocabs
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ChromiumWebBrowser chromeBrowser;
        public MainWindow()
        {
            InitializeComponent();
            // Start the browser after initialize global component
            InitializeChromium();
        }
        public void InitializeChromium()
        {
            CefSettings settings = new CefSettings();
            // Initialize cef with the provided settings
            Cef.Initialize(settings);

            // Create a browser component
            chromeBrowser = new ChromiumWebBrowser("https://www.vocabulary.com/dictionary/affable#wordPage");

            // Add it to the form and fill it to the form window.
            vocabView.Children.Add(chromeBrowser);

        }

        private void vocabulary_click(object sender, RoutedEventArgs e)
        {
            
        }

    }

}
