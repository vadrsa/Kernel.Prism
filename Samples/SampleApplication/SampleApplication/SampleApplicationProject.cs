using Infrastructure.Constants;
using Kernel;
using Kernel.Configuration;
using Kernel.Prism;
using Kernel.Workitems;
using SampleModule.Features;
using System.Windows;

namespace SampleApplication
{
    class SampleApplicationProject : Project
    {
        public override string Name => "Sample Application";

        protected override void ConfigureRegions(RegionOptions option)
        {
            option.SetWindowCreator(CreateShell)
                .SupportsRegion(KnownRegions.Content)
                .SupportsModal(CreateModal);
        }

        private Window CreateShell()
        {
            var window = new MainWindow();
            return window;
        }

        private IModalWindow CreateModal()
        {
            return new ModalWindow(this);
        }

        public override void RegisterFeatures(IFeatureRegister featureRegister)
        {
            base.RegisterFeatures(featureRegister);
            featureRegister.Register(new LocalStorageExampleFeature());
            featureRegister.Register(new ModalExampleFeature());
        }
    }
}
