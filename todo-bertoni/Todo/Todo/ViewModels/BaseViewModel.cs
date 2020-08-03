using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Todo.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected Boolean SetProperty<T>(
            ref T storage,
            T value,
            [CallerMemberName] String propertyName = null)
        {
            if (Equals(storage, value))
            {
                return false;
            }
            else
            {
                storage = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

                return true;
            }
        }
    }
}
