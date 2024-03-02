using System;
using System.Reflection;
using System.Windows.Controls;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using Rhino;

namespace LIMRhino.Views
{
    /// <summary>
    /// Interaction logic for DashboardView.xaml
    /// </summary>
    public partial class DashboardView : UserControl
    {
        public DashboardView()
        {
            InitializeComponent();
            InitializeBrowser();

            RhinoDoc.AddRhinoObject += RhinoDoc_AddRhinoObject;
        }

        private void RhinoDoc_AddRhinoObject(object sender, Rhino.DocObjects.RhinoObjectEventArgs e)
        {
            webView.CoreWebView2.PostWebMessageAsString("hello from rhino");
        }

        public async void InitializeBrowser()
        {
            string userDataFolder = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\browser";

            var environment = await CoreWebView2Environment.CreateAsync(null, userDataFolder, null);

            await this.webView.EnsureCoreWebView2Async(environment);

            webView.Source = new Uri("http://localhost:3000/dashboard");
            webView.CoreWebView2.OpenDevToolsWindow();

            webView.CoreWebView2.PostWebMessageAsString("hello from rhino");
        }
    }
}
