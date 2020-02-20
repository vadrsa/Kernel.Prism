using System;
using System.Windows.Media.Imaging;

namespace Kernel.Configuration
{
    /// <summary>
    /// Base class of the project configuration
    /// </summary>
    public abstract class Project : OptionConfiguration
    {
        private void ConfigureRegionsBase()
        {
            var option = new RegionOptions();
            option.BeginConfigure();
            ConfigureRegions(option);
            option.EndConfigure();
            this.Configure(option);
        }

        public Project()
        {
            ConfigureRegionsBase();
        }

        protected abstract void ConfigureRegions(RegionOptions option);

        /// <summary>
        /// Name of the project
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Application folder name in the AppData
        /// </summary>
        public virtual string AppDataFolderName
        {
            get
            {
                return Name;
            }
        }

        /// <summary>
        /// Lifecicle hook to register features
        /// </summary>
        /// <param name="featureRegister">The feature register</param>
        public virtual void RegisterFeatures(IFeatureRegister featureRegister)
        {
        }
    }
}
