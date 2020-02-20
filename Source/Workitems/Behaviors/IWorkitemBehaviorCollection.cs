using Kernel.Workitems.Behaviors;
using System.Collections.Generic;

namespace Kernel
{
    public interface IWorkitemBehaviorCollection
    {
        IWorkitemBehavior Behavior { get; }
    }
}
