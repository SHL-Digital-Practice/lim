using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Shapes;
using Newtonsoft.Json;
using Rhino;
using Rhino.FileIO;
using Path = System.IO.Path;

namespace LIMRhino.Bridge
{
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ComVisible(true)]
    public class BridgeCsharp
    {
        public Boolean GetAsset(string url)
        {
            
            
            // var asset = JsonConvert.DeserializeObject<SpeciesRecord>(url);
            
            DownloadAsset(url);

            return true;
        }
        
        static async Task DownloadAsset(string url)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls13;
            string filePath = @"C:\Temp\downloaded_file.obj";
   
            using (WebClient webClient = new WebClient())
            {

                try
                {
                    webClient.DownloadFile(url, filePath);
                    
                    var options = new FileObjReadOptions(new FileReadOptions());
                    options.MapYtoZ = true;
                    
                    
                    var obj = FileObj.Read(filePath, RhinoDoc.ActiveDoc, options);
                   
                    RhinoDoc.ActiveDoc.Views.Redraw();
                    
                    if (!File.Exists(filePath))
                    {
                        RhinoApp.WriteLine("File does not exist.");
                    }


                    RhinoApp.WriteLine("OBJ file imported successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error occurred: " + ex.Message);
                }
            }
        }
    }
}
