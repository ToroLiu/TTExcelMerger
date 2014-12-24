using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ExcelMerger.ViewModels
{
    internal abstract class VMBase : INotifyPropertyChanged
    {
        private Dictionary<string, object> _keyValueMap = new Dictionary<string, object>();

        protected void SetValue<T>(T value, [CallerMemberName] string key = "")
        {
            _keyValueMap[key] = value;
            OnPropertyChanged(key);
        }

        protected T GetValue<T>([CallerMemberName] string key = "")
        {
            if (_keyValueMap.ContainsKey(key) == false)
                return default(T);

            var ret = _keyValueMap[key];
            if (ret is T)
                return (T)ret;

            return default(T);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
