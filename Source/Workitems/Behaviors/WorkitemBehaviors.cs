namespace Kernel.Workitems.Behaviors
{
    public class WorkitemBehaviors : IWorkitemBehaviorRegister, IWorkitemBehaviorCollection
    {
        private WorkitemBehaviorCollection workitemBehaviors = new WorkitemBehaviorCollection();

        public IWorkitemBehavior Behavior => workitemBehaviors;

        public void Register(IWorkitemBehavior behavior)
        {
            workitemBehaviors.Register(behavior);
        }
    }
}
