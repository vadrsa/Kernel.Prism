using Infrastructure.Constants;
using Kernel;
using Kernel.Workitems;
using Prism.Ioc;
using SampleModule.Workitems.LocalStorageExample.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleModule.Workitems.LocalStorageExample
{
    [SingleInstanceWorkitem]
    class LocalStorageExampleWorkitem : WorkitemBase
    {
        public LocalStorageExampleWorkitem(IContainerExtension container) : base(container)
        {
        }

        public override string WorkItemName => "Local Storage";

        protected override void RegisterViews(IViewContainer container)
        {
            base.RegisterViews(container);
            container.Register(new LocalStorage(), KnownRegions.Content);
        }
    }
}
