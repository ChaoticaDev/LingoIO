using Chaotica___LingoIO.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Chaotica___LingoIO.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LessonsPage : Page
    {

        public ObservableCollection<ChaoticaLesson> Lessons { get; set; }

        protected override void OnNavigatedTo (NavigationEventArgs e)
        {
            this.Lessons = Template10.Services.SerializationService.SerializationService.Json.Deserialize<ObservableCollection<ChaoticaLesson>>(e.Parameter?.ToString());

            foreach(ChaoticaLesson lesson in this.Lessons)
            {
                lesson.ImageSource = lesson.TmpImageSource;
            }
        }

        public LessonsPage()
        {
            this.InitializeComponent();
        }

        private void gView_ItemClick(object sender, ItemClickEventArgs e)
        {
            ObservableCollection<ChaoticaQuestion> questions = ((ChaoticaLesson)e.ClickedItem).Questions;
            ViewModel.GotoExamine(sender, questions);
        }
    }
}
