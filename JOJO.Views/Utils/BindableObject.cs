using Caliburn.Micro;
using JOJO.UC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Sugar.WPF.Utils
{
    
        public abstract class BindableObject : Conductor<IShell>.Collection.OneActive, INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            protected void OnPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }

            protected void SetProperty<T>(ref T item, T value, [CallerMemberName] string propertyName = null)
            {
                if (!EqualityComparer<T>.Default.Equals(item, value))
                {
                    item = value;
                    OnPropertyChanged(propertyName);
                }
            }
        }
    

}
