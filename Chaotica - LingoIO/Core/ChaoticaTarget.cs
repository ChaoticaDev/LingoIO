using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chaotica___LingoIO.Core
{
    public class ChaoticaTarget : INotifyPropertyChanged
    {

        private String _Title, _ID;

        public String WID;

        public List<List<ChaoticaWord>> Combinations;

        public event PropertyChangedEventHandler PropertyChanged;


        public String Title
        {

            get
            {
                return this._Title;
            }

            set
            {
                _Title = value;
                NotifyPropertyChanged("Title");
            }
        }

        public String ID
        {

            get
            {
                return this._ID;
            }

            set
            {
                _ID = value;
                NotifyPropertyChanged("ID");
            }
        }

        public ChaoticaLanguage Language { get; private set; }

        private void NotifyPropertyChanged(String propertyName = "")

        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ChaoticaTarget(String __ID, ChaoticaLanguage __LANG)
        {
            this.ID = __ID;
            this.Language = __LANG;
            this.Combinations = new List<List<ChaoticaWord>>();
        }
    }
}
