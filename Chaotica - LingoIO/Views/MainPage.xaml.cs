using Windows.UI.Xaml.Controls;
using System.Collections.ObjectModel;
using Chaotica___LingoIO.Core;
using System.Collections.Generic;
using static Chaotica___LingoIO.Core.ChaoticaCore;
using System;
using Windows.UI.Xaml.Navigation;
using MySql.Data.MySqlClient;

namespace Chaotica___LingoIO.Views
{
    public sealed partial class MainPage : Page
    {
        static ChaoticaDBManager db = new ChaoticaDBManager();

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
            if (ChaoticaCore.Courses.Count > 0)
            {
                return;
            }

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

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            String auth = ChaoticaCore.Authenticate(DataCached.localSettings.Values["AuthKey"].ToString());

            if (auth != null)
            {
                LoginPanelSP.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                CoursesGV.Visibility = Windows.UI.Xaml.Visibility.Visible;
            }
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
            ViewModel.GotoCourses();
        }

        private void LoginBTN_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            LoginStatusTB.Text = "";
            
            String auth = ChaoticaCore.Authenticate(UsernameTB.Text, PasswordTB.Text);

            if (auth != null)
            {
                LoginPanelSP.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                CoursesGV.Visibility = Windows.UI.Xaml.Visibility.Visible;
            }
            else
            {
                CoursesGV.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                LoginPanelSP.Visibility = Windows.UI.Xaml.Visibility.Visible;
                LoginStatusTB.Text = "Error! Invalid user credentials!";
            }

            UsernameTB.Text = "";
            PasswordTB.Text = "";
        }

        private void RegBTN_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        { 
            if(UsernameTB.Text == "" || PasswordTB.Text == "")
            {
                return;
            }

            MySqlDataReader reader = ChaoticaDBManager.Query("SELECT * FROM accounts WHERE `Username` = '" + UsernameTB.Text + "'");

            bool found = false;

            while (reader.Read())
            {
                found = true;
            }

            reader.Close();

            if (!found)
            {
                ChaoticaDBManager.QueryExec("INSERT into `accounts` (Username, Password) VALUES ('" + UsernameTB.Text + "', '" + PasswordTB.Text + "')");
                LoginBTN_Click(sender, e);
            }else
            {
                LoginStatusTB.Text = "Account creation failed! Account already exists!";
            }
        }



        private void UsernameTB_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
        }

        private void PasswordTB_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
        }

        private void Page_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {

        }
    }
}
