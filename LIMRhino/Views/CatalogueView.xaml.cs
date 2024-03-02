using Microsoft.Web.WebView2.Core;
using System.Reflection;
using System;

namespace LIMRhino.Views
{
    /// <summary>
    /// Interaction logic for Catalogue.xaml
    /// </summary>
    public partial class CatalogueView
    {
        public CatalogueView()
        {
            InitializeComponent();
            InitializeBrowser();
        }

        public async void InitializeBrowser()
        { 
            string userDataFolder = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\browser";
            
            var environment = await CoreWebView2Environment.CreateAsync(null, userDataFolder, null);
        
            await this.webView.EnsureCoreWebView2Async(environment);

            webView.Source = new Uri("http://www.google.com");
        }
    }
}
