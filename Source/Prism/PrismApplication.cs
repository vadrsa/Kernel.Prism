using System.Windows;
using Kernel.Configuration;
using Kernel.Managers;
using Kernel.Prism;
using Kernel.Workitems;
using Kernel.Workitems.Behaviors;
using Prism.Ioc;

namespace Kernel
{
    /// <summary>
    /// Prism Applciation base class based on Unity Container implementation
    /// </summary>
    public abstract class PrismApplication : global::Prism.Unity.PrismApplication
    {

        public readonly bool IsDebug;
        protected readonly Project project;

        public PrismApplication(Project project)
        {
#if DEBUG
            IsDebug = true;
#endif
            this.project = project;
        }

        protected override Window CreateShell()
        {
            return project.GetOption<RegionOptions>().CreateWindow();
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            project.RegisterFeatures(Container.Resolve<IFeatureRegister>());
        }

        /// <summary>
        /// Register main types with the container
        /// </summary>
        /// <param name="containerRegistry"></param>
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry
                .RegisterInstance<Project>(project)
                .RegisterSingleton<IFeatureRegister, FeatureRegister>()
                .RegisterSingleton<IUIManager, UIManager>()
                .RegisterSingleton<ITaskManager, BaseTaskManager>()
                .RegisterSingleton<IContextService, ContextService>()
                .RegisterSingleton<IRegionManagerExtension, RegionManager>();

            RegionTransformationCollection regionTarnsformationCollection = new RegionTransformationCollection();
            ConfigureRegionTransformations(regionTarnsformationCollection);
            containerRegistry.RegisterInstance<IRegionTransformationCollection>(regionTarnsformationCollection);


            WorkitemBehaviors workitemBehaviors = new WorkitemBehaviors();
            ConfigureWorkitemBehaviors(workitemBehaviors);
            containerRegistry.RegisterInstance<IWorkitemBehaviorCollection>(workitemBehaviors);
        }

        protected virtual void ConfigureRegionTransformations(RegionTransformationCollection collection) { }

        protected virtual void ConfigureWorkitemBehaviors(IWorkitemBehaviorRegister register) { }

    }
}
