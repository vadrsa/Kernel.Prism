using Prism.Regions;

namespace Kernel
{
    public interface IRegionManagerExtension
    {
        IRegionCollection Regions { get; }
        object AddToRegion(string regionName, object view);
    }
}
