﻿using Rhino;
using Rhino.Commands;
using Rhino.Geometry;
using Rhino.Input;
using Rhino.Input.Custom;
using System;
using System.Collections.Generic;

namespace LIM
{
    public class LIMCommand : Command
    {
        public LIMCommand()
        {
            // Rhino only creates one instance of each command class defined in a
            // plug-in, so it is safe to store a refence in a static property.
            Instance = this;
        }

        ///<summary>The only instance of this command.</summary>
        public static LIMCommand Instance { get; private set; }

        ///<returns>The command name as it appears on the Rhino command line.</returns>
        public override string EnglishName => "LIMCommand";

        protected override Result RunCommand(RhinoDoc doc, RunMode mode)
        {
    
            // Select a curve
            
            
            return Result.Success;
        }
    }
}
