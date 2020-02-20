using Infrastructure.Constants;
using Kernel;
using Kernel.Workitems;
using Prism.Ioc;
using SampleModule.Workitems.ModalExample.Views;

namespace SampleModule.Workitems.ModalExample
{
    class ModalExampleWorkitem : WorkitemBase
    {
        public ModalExampleWorkitem(IContainerExtension container) : base(container)
        {
        }

        public override string WorkItemName => "Modal Example";

        protected override void RegisterViews(IViewContainer container)
        {
            base.RegisterViews(container);
            container.Register(new ModalView(), KnownRegions.Content);
        }
    }
}
