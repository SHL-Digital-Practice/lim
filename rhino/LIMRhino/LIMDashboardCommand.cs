using LIMRhino.Views;
using Rhino;
using Rhino.Commands;
using Rhino.UI;
using RhinoWindows.Controls;
using System.Runtime.InteropServices;

namespace LIMRhino
{
    [Guid("881DBCEA-4F8E-47E8-B74E-59B8A9651EB7")]
    public class LIMDashboardPanelHost : WpfElementHost
    {
        public LIMDashboardPanelHost() : base(new CatalogueView(), null) { }
    }

    public class LIMDashboardCommand : Command
    {
        public LIMDashboardCommand()
        {
            // Rhino only creates one instance of each command class defined in a
            // plug-in, so it is safe to store a refence in a static property.
            Instance = this;
            Panels.RegisterPanel(
                LIMRhinoPlugin.Instance,
                typeof(LIMDashboardPanelHost),
                "LIM Dashboard",
                System.Drawing.SystemIcons.WinLogo,
                PanelType.System
            );
        }

        ///<summary>The only instance of this command.</summary>
        public static LIMDashboardCommand Instance { get; private set; }

        ///<returns>The command name as it appears on the Rhino command line.</returns>
        public override string EnglishName => "LIMDashboard";

        protected override Result RunCommand(RhinoDoc doc, RunMode mode)
        {
            var panelId = typeof(LIMDashboardPanelHost).GUID;

            var isPanelVisible = Panels.IsPanelVisible(panelId);

            if (isPanelVisible)
            {
                return Result.Success;
            }

            Panels.OpenPanel(panelId);
            return Result.Success;
        }
    }
}
