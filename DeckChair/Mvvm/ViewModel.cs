using System.Collections.Generic;
using System.ComponentModel;

namespace DeckChair.Mvvm
{
    public abstract class ViewModel : INotifyPropertyChanged
    {
        private Dictionary<string, object> _values;
        public event PropertyChangedEventHandler PropertyChanged;

        protected ViewModel()
        {
            _values = new Dictionary<string, object>();
        }

        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void SetValue(string name, object value)
        {
            if (_values.ContainsKey(name))
                _values.Remove(name);
            _values.Add(name, value);
            RaisePropertyChanged(name);
        }

        protected T GetValue<T>(string name)
        {
            if (_values.ContainsKey(name) == false)
                return default(T);
            return (T)_values[name];
        }
    }
}
