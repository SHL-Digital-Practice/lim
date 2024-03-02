using LIMRhino.Views;
using Rhino;
using Rhino.Commands;
using Rhino.UI;
using RhinoWindows.Controls;
using System.Runtime.InteropServices;

namespace LIMRhino
{
    [Guid("8DBF9960-A020-46A8-929E-39BD21F0840D")]
    public class LIMCataloguePanelHost : WpfElementHost
    {
        public LIMCataloguePanelHost() : base(new Catalogue(), null) { }
    }

    public class LIMCatalogueCommand : Command
    {
        public LIMCatalogueCommand()
        {
            // Rhino only creates one instance of each command class defined in a
            // plug-in, so it is safe to store a refence in a static property.
            Instance = this;
            Panels.RegisterPanel(
                LIMRhinoPlugin.Instance,
                typeof(LIMCataloguePanelHost),
                "LIM Catalogue",
                System.Drawing.SystemIcons.WinLogo,
                PanelType.System
            );
        }

        ///<summary>The only instance of this command.</summary>
        public static LIMCatalogueCommand Instance { get; private set; }

        ///<returns>The command name as it appears on the Rhino command line.</returns>
        public override string EnglishName => "LIMCatalogue";

        protected override Result RunCommand(RhinoDoc doc, RunMode mode)
        {
            var panelId = typeof(LIMCataloguePanelHost).GUID;

            var isPanelVisible = Panels.IsPanelVisible( panelId );

            if ( isPanelVisible )
            {
                return Result.Success;
            }

            Panels.OpenPanel( panelId );
            return Result.Success;
        }
    }
}
