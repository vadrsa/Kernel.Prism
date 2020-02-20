using Infrastructure.Constants;
using Kernel;
using Kernel.Workitems;
using Prism.Ioc;
using SampleModule.Workitems.ModalExample.Views;
using SampleModule.Workitems.ModalRuntimeExample.Views;

namespace SampleModule.Workitems.ModalRuntimeExample
{
    class ModalRuntimeExampleWorkitem : WorkitemBase
    {
        public ModalRuntimeExampleWorkitem(IContainerExtension container) : base(container)
        {
        }

        public override string WorkItemName => "Modal Runtime Example";

        protected override void RegisterViews(IViewContainer container)
        {
            base.RegisterViews(container);
            container.Register(new ModalRuntimeView(), KnownRegions.Content);
        }
    }
}
