using GalaSoft.MvvmLight;
using Kernel.Managers;
using Kernel.Workitems;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleModule.Workitems.LocalStorageExample.Views
{
    class LocalStorageViewModel : ViewModelBase, IWorkitemAware<LocalStorageExampleWorkitem>
    {

        public LocalStorageExampleWorkitem Workitem { get; set; }

        public void SetWorkitem(LocalStorageExampleWorkitem workItem)
        {
            Workitem = workItem;
        }

        private string _key;

        public string Key
        {
            get { return _key; }
            set { Set(ref _key, value, nameof(Key)); }
        }

        private string _value;

        public string Value
        {
            get { return _value; }
            set { Set(ref _value, value, nameof(Value)); }
        }

        private string _getterKey;

        public string GetterKey
        {
            get { return _getterKey; }
            set { Set(ref _getterKey, value, nameof(GetterKey)); }
        }

        private string _getterValue;

        public string GetterValue
        {
            get { return _getterValue; }
            set { Set(ref _getterValue, value, nameof(GetterValue)); }
        }

        public DelegateCommand _saveCommand;
        public DelegateCommand SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                    _saveCommand = new DelegateCommand(Save);
                return _saveCommand;
            }
        }

        private void Save()
        {
            Workitem.LocalStorage.Write(Key, Value);
            CommonServiceLocator.ServiceLocator.Current.GetInstance<IUIManager>().ShowMessageBox($"The value with key '{Key}' was saved", "Saved");
        }

        public DelegateCommand _requeustCommand;
        public DelegateCommand RequestCommand
        {
            get
            {
                if (_requeustCommand == null)
                    _requeustCommand = new DelegateCommand(Request);
                return _requeustCommand;
            }
        }

        private void Request()
        {
            var result = Workitem.LocalStorage.Request(GetterKey);
            if (result.Exists)
            {
                GetterValue = result.Value.ToString();
            }
        }
    }
}
