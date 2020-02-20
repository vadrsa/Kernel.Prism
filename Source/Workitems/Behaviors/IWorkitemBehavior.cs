using System.Threading.Tasks;

namespace Kernel.Workitems.Behaviors
{
    public interface IWorkitemBehavior
    {
        Task<bool> OnLaunching(IContextService service, WorkitemLaunchDescriptor launchDescriptor);
    }
}
