using GalaSoft.MvvmLight;
using Kernel.Workitems;
using Prism.Commands;
using SampleModule.Workitems.ModalRuntimeExample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleModule.Workitems.ModalRuntimeExample.Views
{
    class ModalRuntimeViewModel : ViewModelBase, IWorkitemAware<ModalRuntimeExampleWorkitem>
    {

        public ModalRuntimeExampleWorkitem Workitem { get; set; }

        public void SetWorkitem(ModalRuntimeExampleWorkitem workItem)
        {
            Workitem = workItem;
        }

        private DelegateCommand _ChangeToModalCommand;

        public DelegateCommand ChangeToModalCommand
        {
            get
            {
                if (_ChangeToModalCommand == null)
                    _ChangeToModalCommand = new DelegateCommand(ChangeToModal);
                return _ChangeToModalCommand;
            }
        }

        private void ChangeToModal()
        {
            Workitem.ChangeToModalState();
        }
    }
}
