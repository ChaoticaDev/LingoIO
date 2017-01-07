using Windows.UI.Xaml.Controls;
using System.Collections.ObjectModel;
using Chaotica___LingoIO.Core;
using System.Collections.Generic;
using static Chaotica___LingoIO.Core.ChaoticaCore;
using System;

namespace Chaotica___LingoIO.Views
{
    public sealed partial class MainPage : Page
    {
        ChaoticaDBManager db = new ChaoticaDBManager();
        private ObservableCollection<ChaoticaCourse> _Questions;

        public ObservableCollection<ChaoticaCourse> Courses
        {

            get
            {
                return this._Questions;
            }

            set
            {
                _Questions = value;
            }
        }

        public async void LoadInitData()
        {
            await ChaoticaCoreWindow.xAsync(() => 
            {
                //Load vocabulary
                ChaoticaCore.DataCached.VocabularyCache = CourseUtils.BindVocabulary();

                //Bind course data
                ChaoticaCore.Courses = ChaoticaCore.DatabaseUtils.GetCourses();
                CourseUtils.BindLessons();
                CourseUtils.BindQuestions();
                CourseUtils.BindTargets();
                CourseUtils.BindWords();

                //Update course collection
                this.Courses = ChaoticaCore.Courses;
                return true;
            });
        }

        public MainPage()
        {
            InitializeComponent();

            ChaoticaCore.DataCached.CacheInit();

            NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;

            LoadInitData();
        }

        private void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            ChaoticaCore.SelectedCourse = (ChaoticaCourse)e.ClickedItem;
            ViewModel.GotoLessons(sender);
        }
    }
}
