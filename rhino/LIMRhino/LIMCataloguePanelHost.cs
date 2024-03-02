using LIMRhino.Views;
using RhinoWindows.Controls;
using System.Runtime.InteropServices;

namespace LIMRhino
{
    [Guid("8DBF9960-A020-46A8-929E-39BD21F0840D")]
    public class LIMCataloguePanelHost: WpfElementHost
    {
        public LIMCataloguePanelHost(): base (new Catalogue(), null) 
        {
            
        }
    }
}
