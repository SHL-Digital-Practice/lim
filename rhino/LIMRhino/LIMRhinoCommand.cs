using Rhino;
using Rhino.Commands;
using Rhino.Geometry;
using Rhino.Input;
using Rhino.Input.Custom;
using Rhino.UI;
using System;
using System.Collections.Generic;

namespace LIMRhino
{
    public class LIMRhinoCommand : Command
    {
        public LIMRhinoCommand()
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
        public static LIMRhinoCommand Instance { get; private set; }

        ///<returns>The command name as it appears on the Rhino command line.</returns>
        public override string EnglishName => "LIMRhinoCommand";

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
