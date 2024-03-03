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
        
        public static bool IsLoadingObj = false;
        public static SpeciesRecord Species = null;
        
        public BridgeCsharp()
        {
            RhinoDoc.AddRhinoObject += (sender, args) =>
            {
                if (!IsLoadingObj) return;
                    
                args.TheObject.Attributes.SetUserString("id", Species.Id.ToString());
                IsLoadingObj = false;
                
            };
        }

        public Boolean GetAsset(string url, string jsonSpecies)
        {
            var species = JsonConvert.DeserializeObject<SpeciesRecord>(jsonSpecies);
            DownloadAsset(url, species);

            return true;
        }
        
        static async Task DownloadAsset(string url, SpeciesRecord species)
        {
            Species = species;
            
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls13;
            string filePath = @"C:\Temp\downloaded_file.obj";
   
            using (WebClient webClient = new WebClient())
            {

                try
                {
                    webClient.DownloadFile(url, filePath);
                    
                    var options = new FileObjReadOptions(new FileReadOptions());
                    options.MapYtoZ = true;
                    
                    
                    IsLoadingObj = true;
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
