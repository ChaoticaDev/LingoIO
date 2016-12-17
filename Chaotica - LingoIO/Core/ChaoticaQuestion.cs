using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chaotica___LingoIO.Core
{
    public enum ChaoticaLanguage
    {
        English,
        Spanish
    }

    public class ChaoticaQuestion : INotifyPropertyChanged
    {

        private String _Title;

        private ObservableCollection<ChaoticaTarget> _PossibleAnswers;

        public event PropertyChangedEventHandler PropertyChanged;

        public ChaoticaLanguage LanguageFrom = ChaoticaLanguage.English;
        public ChaoticaLanguage LanguageTo = ChaoticaLanguage.English;

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

        public ObservableCollection<ChaoticaTarget> PossibleAnswers
        {

            get
            {
                return this._PossibleAnswers;
            }

            set
            {
                _PossibleAnswers = value;
                NotifyPropertyChanged("Questions");
            }
        }

        private void NotifyPropertyChanged(String propertyName = "")

        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ChaoticaQuestion(String __Title, ChaoticaLanguage __LanguageFrom = ChaoticaLanguage.English, ChaoticaLanguage __LanguageTo = ChaoticaLanguage.Spanish)
        {
            this.Title = __Title;
            this.LanguageFrom = __LanguageFrom;
            this.LanguageTo = __LanguageTo;

            this.PossibleAnswers = new ObservableCollection<ChaoticaTarget>();
        }
    }
}
