using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FinanceInfoRetriever.Utils
{
    public class ServiceStatus : INotifyPropertyChanged
    {
        public ServiceStatus()
        {
            enabled = false;
        }

        private bool enabled;
        public bool Enabled
        {
            get
            {
                return enabled;
            }
            set
            {
                SetProperty(ref enabled, value);
            }
        }
        public bool Disabled
        {
            get
            {
                return !enabled;
            }
            set
            {
                SetProperty(ref enabled, !value);
            }
        }

        private void SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            if (!EqualityComparer<T>.Default.Equals(field, value))
            {
                field = value;
                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Enabled"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Disabled"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
