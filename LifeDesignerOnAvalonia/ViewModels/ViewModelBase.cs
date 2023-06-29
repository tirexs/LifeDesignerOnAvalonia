using ReactiveUI;
using System.ComponentModel;
using System;
using System.Runtime.CompilerServices;

namespace LifeDesignerOnAvalonia.ViewModels
{


    public class ViewModelBase : ReactiveObject, INotifyPropertyChanged, IDisposable
    {

        public event PropertyChangedEventHandler? PropertyChanged;


        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public virtual void Dispose()
        {

        }


    }
}