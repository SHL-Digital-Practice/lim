using System.Runtime.InteropServices;
using LIM.Rhino.Views;
using Rhino;
using Rhino.Commands;
using RhinoWindows.Controls;

namespace LIM.Rhino
{
  public class CatalogueCommand : Command
  {
    public override string EnglishName => "LIMCatalogue";

    protected override Result RunCommand(RhinoDoc doc, RunMode mode)
    {
      RhinoApp.WriteLine("Hello from {0}!", EnglishName);
      return Result.Success;
    }
  }

  [Guid("d92fcdc6-4a64-4b58-ab70-b75f0a3fd6bd")]
  public class CataloguePanelHost : WpfElementHost
  {
    public CataloguePanelHost(uint docSn)
      : base(new CataloguePanel(docSn), null)
    {
    }
  }
}