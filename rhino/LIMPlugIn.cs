using Rhino.PlugIns;

namespace LIM.Rhino
{
  public class LIMPlugIn : PlugIn
  {

    public LIMPlugIn()
    {
      Instance = this;
    }

    public static LIMPlugIn Instance
    {
      get; private set;
    }

    protected override LoadReturnCode OnLoad(ref string errorMessage)
    {
      return LoadReturnCode.Success;
    }

  }

}

