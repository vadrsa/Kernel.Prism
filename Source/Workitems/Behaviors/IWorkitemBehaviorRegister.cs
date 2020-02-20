using Kernel.Workitems.Behaviors;

namespace Kernel
{
    public interface IWorkitemBehaviorRegister
    {
        void Register(IWorkitemBehavior behavior);
    }
}
