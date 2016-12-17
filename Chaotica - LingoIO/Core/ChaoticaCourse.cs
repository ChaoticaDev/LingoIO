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
    public class ChaoticaCourse : INotifyPropertyChanged
    {

        private String _Title, _Description;

        private ObservableCollection<ChaoticaLesson> _Lessons;

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

        public ObservableCollection<ChaoticaLesson> Lessons
        {

            get
            {
                return this._Lessons;
            }

            set
            {
                _Lessons = value;
                NotifyPropertyChanged("Lessons");
            }
        }

        private void NotifyPropertyChanged(String propertyName = "")

        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ChaoticaCourse(String __Title, String __Description)
        {
            this.Title = __Title;
            this.Description = __Description;

            this.Lessons = new ObservableCollection<ChaoticaLesson>();
        }
    }
}
