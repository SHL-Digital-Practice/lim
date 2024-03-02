﻿using System;
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
        public DashboardView()
        {
            InitializeComponent();
            InitializeBrowser();

            RhinoDoc.AddRhinoObject += RhinoDoc_AddRhinoObject;
        }

        private void RhinoDoc_AddRhinoObject(object sender, Rhino.DocObjects.RhinoObjectEventArgs e)
        {
            var objects = Rhino.RhinoDoc.ActiveDoc.Objects.GetObjectList(ObjectType.Brep);
            var geometries = objects.Select(x => x.Geometry.ToJSON(new SerializationOptions()));
            var json = JsonConvert.SerializeObject(geometries);
            webView.CoreWebView2.PostWebMessageAsJson(json);
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
