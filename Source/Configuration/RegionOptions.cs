using Kernel.Workitems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Kernel.Configuration
{
    /// <summary>
    /// Application wide options for the region
    /// </summary>
    public class RegionOptions
    {
        #region Private

        private bool isInConfig;

        private Func<Window> windowGetter;

        private Func<IModalWindow> modalWindowGetter;

        private List<string> _regionNames;

        #endregion

        public List<string> RegionNames => _regionNames;

        public Window CreateWindow()
        {
            return windowGetter();
        }

        public IModalWindow CreateModalWindow()
        {
            return modalWindowGetter();
        }

        public bool IsSupported(string region)
        {
            return _regionNames.Contains(region);
        }

        public RegionOptions BeginConfigure()
        {
            isInConfig = true;
            return this;
        }

        public RegionOptions SupportsRegions(IEnumerable<string> regions)
        {
            if (!isInConfig) throw new InvalidOperationException("Call BeginConfigure before configuring the option");
            if (_regionNames == null)
                _regionNames = new List<string>();
            _regionNames.AddRange(regions);
            _regionNames = _regionNames.Distinct().ToList();
            return this;
        }

        public RegionOptions SupportsRegion(string region)
        {
            return SupportsRegions(new List<string> { region });
        }

        public RegionOptions SupportsModal(Func<IModalWindow> modalWindowGetter)
        {
            if (!isInConfig) throw new InvalidOperationException("Call BeginConfigure before configuring the option");
            this.modalWindowGetter = modalWindowGetter;
            return this;
        }

        public RegionOptions SetWindowCreator(Func<Window> windowGetter)
        {
            if (!isInConfig) throw new InvalidOperationException("Call BeginConfigure before configuring the option");
            this.windowGetter = windowGetter;
            return this;
        }

        public RegionOptions EndConfigure()
        {
            isInConfig = false;
            return this;
        }

    }
}
