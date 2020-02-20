using Infrastructure.Constants;
using Kernel;
using Kernel.Configuration;
using SampleModule.Constants;
using SampleModule.Views;
using SampleModule.Workitems.LocalStorageExample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleModule.Features
{
    public class LocalStorageExampleFeature : Feature
    {
        public LocalStorageExampleFeature()
        {
        }

        public override void Attach()
        {
            base.Attach();
            RegionManager.AddToRegion(KnownRegions.MainMenu, new LocalStorageExampleButton());
            CommandManager.RegisterCommand(Commands.OpenLocalStorageExampleWorkitem, OpenLocalStorageExampleWorkitem);
        }

        private void OpenLocalStorageExampleModalWorkitem()
        {
            CurrentContextService.LaunchModalWorkItem<LocalStorageExampleWorkitem>();
        }

        private void OpenLocalStorageExampleWorkitem()
        {
            CurrentContextService.LaunchWorkItem<LocalStorageExampleWorkitem>();
        }
    }
}
