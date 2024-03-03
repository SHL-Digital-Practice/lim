using Microsoft.Web.WebView2.Wpf;
using Newtonsoft.Json;
using Rhino;
using Rhino.FileIO;
using Rhino.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LIMRhino
{
    public class DashboardObjectsManager
    {
        private readonly WebView2 webView;

        private bool onTransaction = false;
        private int numOfTransactionObjects = 0;
        private List<Guid> transactionObjects;

        public DashboardObjectsManager(WebView2 webView)
        {
            this.webView = webView;
            RhinoDoc.BeforeTransformObjects += HandleBeforeTransform;
            RhinoDoc.ReplaceRhinoObject += HandleReplaceObject;
            RhinoDoc.DeleteRhinoObject += HandleDeleteObject;
            RhinoDoc.AddRhinoObject += HandleAddObject;
            RhinoDoc.BeginOpenDocument += HandleBeginOpenDocument;
            RhinoDoc.UndeleteRhinoObject += HandleUndeleteObject;
        }

        private void HandleUndeleteObject(object sender, Rhino.DocObjects.RhinoObjectEventArgs e)
        {
            if (onTransaction == true) { return; }
            onTransaction = true;
            transactionObjects = new List<Guid>() { e.ObjectId };
            numOfTransactionObjects = 1;
            return;
        }

        private void HandleBeginOpenDocument(object sender, DocumentOpenEventArgs e)
        {
            if (onTransaction == true) { return; }
            onTransaction = true;
            transactionObjects = e.Document.Objects.Select(o => o.Id).ToList();
            numOfTransactionObjects = transactionObjects.Count;
            return;

        }

        private void HandleAddObject(object sender, Rhino.DocObjects.RhinoObjectEventArgs e)
        {
            if (onTransaction == false) {
                onTransaction = true;
                transactionObjects = new List<Guid>() { e.ObjectId };
                numOfTransactionObjects = 1;
                endTransaction();
                return;
            }

            if (numOfTransactionObjects > 1)
            {
                numOfTransactionObjects--;
                return;
            } else
            {
                endTransaction();
                return;
            }
        }

        private void HandleDeleteObject(object sender, Rhino.DocObjects.RhinoObjectEventArgs e)
        {
            if (onTransaction == false) {
                onTransaction= true;
                transactionObjects = new List<Guid>() { e.ObjectId };
                numOfTransactionObjects = 1;
                endTransaction();
            }
        }

        private void HandleReplaceObject(object sender, Rhino.DocObjects.RhinoReplaceObjectEventArgs e)
        {
            if (onTransaction == true) { return ; }

            onTransaction = true;
            transactionObjects = new List<Guid>() { e.NewRhinoObject.Id };
            numOfTransactionObjects = 1;
            return;

        }

        private void HandleBeforeTransform(object sender, Rhino.DocObjects.RhinoTransformObjectsEventArgs e)
        {
            if (onTransaction == true) { return; }
            
            onTransaction = true;
            numOfTransactionObjects = e.ObjectCount;

            return; 
        }

        private void endTransaction()
        {
            if (RhinoDoc.ActiveDoc.Objects.Count > 0)
            {
                // Send state to dashboard;

                var writeOptions = new FileWriteOptions()
                {
                    SuppressDialogBoxes = true,
                    SuppressAllInput = true,
                };
                var objWriteOptions = new FileObjWriteOptions(writeOptions);
                objWriteOptions.MeshParameters = MeshingParameters.Minimal;
                var writeResult = FileObj.Write(@"C:\Temp\sample.obj", RhinoDoc.ActiveDoc, objWriteOptions);

                if (writeResult == Rhino.PlugIns.WriteFileResult.Success)
                {
                    var message = new
                    {
                        type = "loadObject",
                        path = @"C:\Temp\sample.obj",
                    };
                    webView.CoreWebView2.PostWebMessageAsJson(JsonConvert.SerializeObject(message));
                }
                else
                {
                    var message = new { type = "unloadAll" };
                    webView.CoreWebView2.PostWebMessageAsJson(JsonConvert.SerializeObject(message));
                }
            }

            // Clean up
            numOfTransactionObjects = 0;
            transactionObjects = null;
            onTransaction = false;
        }
    }
}
