using Windows.UI.Xaml.Controls;
using System.Collections.ObjectModel;
using Chaotica___LingoIO.Core;

namespace Chaotica___LingoIO.Views
{
    public sealed partial class MainPage : Page
    {

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

        internal ChaoticaCourse selectedCourse;

        public MainPage()
        {
            InitializeComponent();
            this.Courses = new ObservableCollection<ChaoticaCourse>();

            NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;

            ChaoticaCourse course = new ChaoticaCourse("The Basics", "The Basics");
            course.ImageSource = "Family Man Woman-96";

            ChaoticaLesson lesson = new ChaoticaLesson("Lesson 01", "Basics");
            lesson.TmpImageSource = "Pregnant-96";


            ChaoticaQuestion question = new ChaoticaQuestion("Él", ChaoticaLanguage.Spanish, ChaoticaLanguage.English);
            ChaoticaQuestion question2 = new ChaoticaQuestion("Ella", ChaoticaLanguage.Spanish, ChaoticaLanguage.English);
            ChaoticaQuestion question3 = new ChaoticaQuestion("Tú", ChaoticaLanguage.Spanish, ChaoticaLanguage.English);
            ChaoticaQuestion question4 = new ChaoticaQuestion("Yo", ChaoticaLanguage.Spanish, ChaoticaLanguage.English);
            ChaoticaQuestion question5 = new ChaoticaQuestion("Ellos", ChaoticaLanguage.Spanish, ChaoticaLanguage.English);
            ChaoticaQuestion question6 = new ChaoticaQuestion("Ellas", ChaoticaLanguage.Spanish, ChaoticaLanguage.English);
            ChaoticaQuestion question7 = new ChaoticaQuestion("Nosotros", ChaoticaLanguage.Spanish, ChaoticaLanguage.English);
            ChaoticaQuestion question8 = new ChaoticaQuestion("Nosotras", ChaoticaLanguage.Spanish, ChaoticaLanguage.English);
            ChaoticaQuestion question9 = new ChaoticaQuestion("Usted", ChaoticaLanguage.Spanish, ChaoticaLanguage.English);
            ChaoticaQuestion question10 = new ChaoticaQuestion("Ustedes", ChaoticaLanguage.Spanish, ChaoticaLanguage.English);


            ChaoticaQuestion question1 = new ChaoticaQuestion("He", ChaoticaLanguage.English, ChaoticaLanguage.Spanish);
            ChaoticaQuestion question2_1 = new ChaoticaQuestion("She", ChaoticaLanguage.English, ChaoticaLanguage.Spanish);
            ChaoticaQuestion question3_1 = new ChaoticaQuestion("You", ChaoticaLanguage.English, ChaoticaLanguage.Spanish);
            ChaoticaQuestion question4_1 = new ChaoticaQuestion("I", ChaoticaLanguage.English, ChaoticaLanguage.Spanish);
            ChaoticaQuestion question5_1 = new ChaoticaQuestion("They", ChaoticaLanguage.English, ChaoticaLanguage.Spanish);
            ChaoticaQuestion question6_1 = new ChaoticaQuestion("We", ChaoticaLanguage.English, ChaoticaLanguage.Spanish);


            ChaoticaTarget target1 = new ChaoticaTarget("Él");
            ChaoticaTarget target11_1 = new ChaoticaTarget("El");
            ChaoticaTarget target2_1 = new ChaoticaTarget("Ella");
            ChaoticaTarget target3_1 = new ChaoticaTarget("Tú");
            ChaoticaTarget target31_1 = new ChaoticaTarget("Tu");
            ChaoticaTarget target3_11 = new ChaoticaTarget("Usted");
            ChaoticaTarget target3_111 = new ChaoticaTarget("Ustedes");
            ChaoticaTarget target4_1 = new ChaoticaTarget("Yo");
            ChaoticaTarget target5_1 = new ChaoticaTarget("Ellos");
            ChaoticaTarget target5_11 = new ChaoticaTarget("Ellas");
            ChaoticaTarget target6_1 = new ChaoticaTarget("Nosotros");
            ChaoticaTarget target6_11 = new ChaoticaTarget("Nosotras");

            question1.PossibleAnswers.Add(target1);
            question1.PossibleAnswers.Add(target11_1);
            question2_1.PossibleAnswers.Add(target2_1);
            question3_1.PossibleAnswers.Add(target3_1);
            question3_1.PossibleAnswers.Add(target31_1);
            question3_1.PossibleAnswers.Add(target3_11);
            question3_1.PossibleAnswers.Add(target3_111);
            question4_1.PossibleAnswers.Add(target4_1);
            question5_1.PossibleAnswers.Add(target5_1);
            question5_1.PossibleAnswers.Add(target5_11);
            question6_1.PossibleAnswers.Add(target6_1);
            question6_1.PossibleAnswers.Add(target6_11);

            ChaoticaTarget target = new ChaoticaTarget("He");
            ChaoticaTarget target2 = new ChaoticaTarget("She");
            ChaoticaTarget target3 = new ChaoticaTarget("You");
            ChaoticaTarget target4 = new ChaoticaTarget("I");
            ChaoticaTarget target5 = new ChaoticaTarget("They");
            ChaoticaTarget target6 = new ChaoticaTarget("They");
            ChaoticaTarget target7 = new ChaoticaTarget("We");
            ChaoticaTarget target8 = new ChaoticaTarget("We");
            ChaoticaTarget target9 = new ChaoticaTarget("You");
            ChaoticaTarget target10 = new ChaoticaTarget("You");
            ChaoticaTarget target11 = new ChaoticaTarget("Y'all");
            ChaoticaTarget target12 = new ChaoticaTarget("You all");

            question.PossibleAnswers.Add(target);
            question2.PossibleAnswers.Add(target2);
            question3.PossibleAnswers.Add(target3);
            question4.PossibleAnswers.Add(target4);
            question5.PossibleAnswers.Add(target5);
            question6.PossibleAnswers.Add(target6);
            question7.PossibleAnswers.Add(target7);
            question8.PossibleAnswers.Add(target8);
            question9.PossibleAnswers.Add(target9);
            question10.PossibleAnswers.Add(target10);
            question10.PossibleAnswers.Add(target11);
            question10.PossibleAnswers.Add(target12);

            lesson.Questions.Add(question);
            lesson.Questions.Add(question2);
            lesson.Questions.Add(question3);
            lesson.Questions.Add(question4);
            lesson.Questions.Add(question5);
            lesson.Questions.Add(question6);
            lesson.Questions.Add(question7);
            lesson.Questions.Add(question8);
            lesson.Questions.Add(question9);
            lesson.Questions.Add(question10);


            lesson.Questions.Add(question1);
            lesson.Questions.Add(question2_1);
            lesson.Questions.Add(question3_1);
            lesson.Questions.Add(question4_1);
            lesson.Questions.Add(question5_1);
            lesson.Questions.Add(question6_1);

            course.Lessons.Add(lesson);

            this.Courses.Add(course);
            
        }

        private void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            selectedCourse = (ChaoticaCourse)e.ClickedItem;
            ViewModel.GotoLessons(sender, selectedCourse.Lessons);
        }
    }
}
