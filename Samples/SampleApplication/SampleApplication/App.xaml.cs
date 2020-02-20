using Infrastructure.Utility;
using Kernel;

namespace SampleApplication
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        public App() : base(new SampleApplicationProject())
        {
            
        }

        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();
            PrismHelper.SetCustomViewTypeToViewModelTypeResolver();
        }
    }
}
