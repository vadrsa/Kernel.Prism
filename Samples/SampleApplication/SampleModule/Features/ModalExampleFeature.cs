using Infrastructure.Constants;
using Kernel;
using Kernel.Configuration;
using SampleModule.Constants;
using SampleModule.Views;
using SampleModule.Workitems.LocalStorageExample;
using SampleModule.Workitems.ModalExample;
using SampleModule.Workitems.ModalRuntimeExample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleModule.Features
{
    public class ModalExampleFeature : Feature
    {
        public ModalExampleFeature()
        {
        }

        public override void Attach()
        {
            base.Attach();
            RegionManager.AddToRegion(KnownRegions.MainMenu, new ModalExampleButton());
            CommandManager.RegisterCommand(Commands.OpenModalExampleModalWorkitem, OpenModalExampleModalWorkitem);
            RegionManager.AddToRegion(KnownRegions.MainMenu, new ModalRuntimeExampleButton());
            CommandManager.RegisterCommand(Commands.OpenModalRuntimeExampleWorkitem, OpenModalRuntimeExampleWorkitem);
        }

        private void OpenModalRuntimeExampleWorkitem()
        {
            CurrentContextService.LaunchWorkItem<ModalRuntimeExampleWorkitem>();
        }

        private void OpenModalExampleModalWorkitem()
        {
            CurrentContextService.LaunchModalWorkItem<ModalExampleWorkitem>();
        }

    }
}
