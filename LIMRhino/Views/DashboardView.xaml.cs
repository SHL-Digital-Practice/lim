using System;
using System.Linq;
using System.Reflection;
using System.Windows.Controls;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using Newtonsoft.Json;
using Rhino;
using Rhino.DocObjects;
using Rhino.FileIO;
using Rhino.Geometry;

namespace LIMRhino.Views
{
    /// <summary>
    /// Interaction logic for DashboardView.xaml
    /// </summary>
    public partial class DashboardView : UserControl
    {
        int objectsToLoad = 0;

        public DashboardView()
        {
            InitializeComponent();
            InitializeBrowser();
        }


        public async void InitializeBrowser()
        {
            string userDataFolder = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\browser";

            var environment = await CoreWebView2Environment.CreateAsync(null, userDataFolder, null);

            await this.webView.EnsureCoreWebView2Async(environment);

            webView.Source = new Uri("http://localhost:3000/dashboard");
            webView.CoreWebView2.OpenDevToolsWindow();

            webView.CoreWebView2.PostWebMessageAsString("hello from rhino");
            new DashboardObjectsManager(webView);
        }
    }
}
