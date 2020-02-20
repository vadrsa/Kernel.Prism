using Infrastructure.Utility;
using Kernel;
using Kernel.Configuration;
using Kernel.Managers;
using Kernel.Prism;
using Kernel.Workitems;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SampleApplication
{
    /// <summary>
    /// Interaction logic for ModalWindow.xaml
    /// </summary>
    public partial class ModalWindow : Window, IModalWindow
    {
        ITaskManager TaskManager => CommonServiceLocator.ServiceLocator.Current.GetInstance<ITaskManager>();

        public ModalWindow(Project project)
        {
            var names = new DynamicRegionNames(project);
            DynamicRegionManager.SetDynamicRegionNames(this, names);
            Prism.Regions.RegionManager.SetRegionManager(this, CommonServiceLocator.ServiceLocator.Current.GetInstance<IRegionManager>());
            Prism.Regions.RegionManager.UpdateRegions();
            InitializeComponent();
        }

        public DependencyObject GetRegionHolder()
        {
            return this;
        }

        void IModalWindow.Focus()
        {

            TaskManager.RunUIThread(() =>
            {
                UIHelper.TryFocusWindow(this);
            });
        }

        void IModalWindow.Unfocus()
        {

            TaskManager.RunUIThread(() =>
            {
                this.WindowState = System.Windows.WindowState.Minimized;
            });
        }

    }
}
