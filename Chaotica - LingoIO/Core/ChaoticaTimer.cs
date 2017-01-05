using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml;

namespace Chaotica___LingoIO.Core
{
    public class ChaoticaTimer : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public int Tick ;

        private int _Tick
        {
            get
            {
                return _Tick;
            }

            set
            {
                _Tick = value;
                NotifyPropertyChanged("Tick");
            }
        }

        private long initTick = 0;
        
        
        public void Start()
        {
            //initTick = (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond) / 1000;
            ChaoticaThread();
        }

        public void Reset()
        {
            Start();
            return;
        }

        private void NotifyPropertyChanged(String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        internal void ChaoticaThread()
        {

            
        }

        public ChaoticaTimer()
        {

        }
    }
}
