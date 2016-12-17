using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace Chaotica___LingoIO.Core
{
    public class ChaoticaLesson : INotifyPropertyChanged
    {

        private String _Title, _Description;


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
        public String Description
        {

            get
            {
                return this._Description;
            }

            set
            {
                _Description = value;
                NotifyPropertyChanged("Description");
            }
        }

        public String TmpImageSource;

        public ImageSource Image;
        public String ImageSource
        {
            private get
            {
                return "";
            }

            set
            {
                ImageSource image = new BitmapImage(new Uri("ms-appx:///Assets/" + (String)value + ".png", UriKind.Absolute));
                Image = image;
                NotifyPropertyChanged("Image");
            }
        }

        private ObservableCollection<ChaoticaQuestion> _Questions;
        public ObservableCollection<ChaoticaQuestion> Questions
        {

            get
            {
                return this._Questions;
            }

            set
            {
                _Questions = value;
                NotifyPropertyChanged("Questions");
            }
        }
        
        private void NotifyPropertyChanged(String propertyName = "")

        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ChaoticaLesson(String __Title, String __Description)
        {
            this.Title = __Title;
            this.Description = __Description;

            this.Questions = new ObservableCollection<ChaoticaQuestion>();
        }
    }
}
