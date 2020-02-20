namespace Kernel.Configuration
{
    /// <summary>
    /// Register of features
    /// </summary>
    public interface IFeatureRegister
    {
        void Register<T>(T feature) where T : class, IFeature;
        T Get<T>() where T : class, IFeature;
        bool Contains<T>() where T : class, IFeature;
    }
}
