﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chaotica___LingoIO.Core
{
    public class ChaoticaWord : INotifyPropertyChanged
    {

        private String _Text;
        private String _Counterpart;

        public event PropertyChangedEventHandler PropertyChanged;



        public String Text
        {

            get
            {
                return this._Text;
            }

            set
            {
                _Text = value;
                NotifyPropertyChanged("Title");
            }
        }

        public String Counterpart
        {

            get
            {
                return this._Counterpart;
            }

            set
            {
                _Counterpart = value;
                NotifyPropertyChanged("Counterpart");
            }
        }

        private void NotifyPropertyChanged(String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ChaoticaWord(String __Title, String __Counterpart)
        {
            this.Text = __Title;
            this.Counterpart = __Counterpart;
        }
    }
}
