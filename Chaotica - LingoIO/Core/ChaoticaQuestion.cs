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
        German,
        Spanish
    }

    public class ChaoticaQuestion : INotifyPropertyChanged
    {

        private String _Title, _ID;

        private ObservableCollection<ChaoticaWord> _Words;

        private ObservableCollection<ChaoticaTarget> _PossibleAnswers;

        public event PropertyChangedEventHandler PropertyChanged;

        public ChaoticaLanguage LanguageFrom = ChaoticaLanguage.English;
        public ChaoticaLanguage LanguageTo = ChaoticaLanguage.English;


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

        public ObservableCollection<ChaoticaWord> Words
        {
            get
            {
                return this._Words;
            }

            set
            {
                _Words = value;
                NotifyPropertyChanged("Words");
            }
        }

        private void NotifyPropertyChanged(String propertyName = "")

        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ChaoticaQuestion(String __ID, String __Title, ChaoticaLanguage __LanguageFrom = ChaoticaLanguage.English, ChaoticaLanguage __LanguageTo = ChaoticaLanguage.Spanish)
        {
            this.ID = __ID;
            this.Title = __Title;
            this.LanguageFrom = __LanguageFrom;
            this.LanguageTo = __LanguageTo;

            this.PossibleAnswers = new ObservableCollection<ChaoticaTarget>();
            this._Words = new ObservableCollection<ChaoticaWord>();
        }
    }
}
