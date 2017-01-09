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
    public sealed partial class CoursesPage : Page
    {

        public ObservableCollection<ChaoticaCourse> Courses { get; set; }

        protected override void OnNavigatedTo (NavigationEventArgs e)
        {
            this.Courses = ChaoticaCore.Courses;
        }

        public CoursesPage()
        {
            this.InitializeComponent();
        }

        private void gView_ItemClick(object sender, ItemClickEventArgs e)
        {
            ChaoticaCore.SelectedCourse = ((ChaoticaCourse)e.ClickedItem);
            ViewModel.GotoExamine(sender);
        }
    }
}
