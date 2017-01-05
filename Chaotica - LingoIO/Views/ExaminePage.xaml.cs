using Windows.UI.Xaml.Controls;
using System.Collections.ObjectModel;
using Chaotica___LingoIO.Core;
using Windows.UI.Xaml.Navigation;
using System;
using System.ComponentModel;

namespace Chaotica___LingoIO.Views
{
    public sealed partial class ExaminePage : Page
    {
        enum ChaoticaExamineState
        {
            MODE_DEFAULT, // State, Awaiting answer
            MODE_CORRECTION, // State, Show correct or false
            MODE_FINISHED // State, Finished
        }

        internal ObservableCollection<ChaoticaQuestion> Questions;

        // Keep track of question count
        private int question_count = 0;

        // Keep track of current question index 
        private int question_index = 0;

        //Keep track of number answers correct
        private int num_right;

        //Keep track of number answers incorrect
        private int num_wrong;


        // Keep track of current question
        private ChaoticaQuestion currentQuestion { get; set; }

        //Keep track of examine state. Default = MODE_DEFAULT
        private ChaoticaExamineState State = ChaoticaExamineState.MODE_DEFAULT;
        
        long startTime = (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond) / 1000;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //Deserialize questions
            this.Questions = ChaoticaCore.SelectedLesson.Questions;

            //Set question count
            this.question_count = this.Questions.Count;

            //Set initial question = first question
            this.currentQuestion = this.Questions[question_index];

            //Set question title = first question title
            this.QuestionTitleTB.Text = this.currentQuestion.Title;
        }

        //Examine finished
        private void Finish()
        {
            this.State = ChaoticaExamineState.MODE_FINISHED;

            //Calculate results
            this.QuestionTitleTB.Text = "Finished with " + num_right.ToString() + " out of " + (num_right+num_wrong).ToString() + " correct!";

            //Disable input
            this.AnswerTB.IsEnabled = false;
            this.SubmitAnswerBTN.IsEnabled = false;
        }

        //Set next question title
        private void NextQuestion()
        {
            //If all questions not answered.
            if (question_index >= question_count - 1)
            {
                this.Finish();
                return;
            }

            this.AnswerTB.Focus(Windows.UI.Xaml.FocusState.Programmatic);

            //Set current question
            this.currentQuestion = this.Questions[question_index];

            //Set question title
            this.QuestionTitleTB.Text = this.currentQuestion.Title;
        }

        //Answer question
        private bool AnswerQuestion(String answer)
        {
            int diffTime = Convert.ToInt32(((DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond) / 1000) - startTime);

            //Keep track of answer found
            bool found = false;

            //Loop through possible answers
            foreach(ChaoticaTarget target in currentQuestion.PossibleAnswers)
            {
                //If possible answer matches input
                //Convert to lower to prevent capitalization issues
                foreach (var possible_answer in currentQuestion.PossibleAnswers)
                {
                    String combos = "";

                    int i = 0;
                    foreach(var combo in possible_answer.Combinations)
                    {
                        foreach(ChaoticaWord wrd in combo)
                        {
                            if (i == 0)
                            {
                                combos += wrd.Text;
                            }
                            else
                            {
                                combos += " " + wrd.Text;
                            }
                            i++;
                        }

                        String ans = answer.ToLower().Trim(new char[] { '?', '!', '.', '/', '\\', '"', '`', '~', ',' });
                        String cmb = combos.ToLower().Trim(new char[] { '?', '!', '.', '/', '\\', '"', '`', '~', ',' });

                        //Set to true if found
                        //This ensures found is not set to false if already found. (found == true)
                        found = found == true ? true : cmb == ans;

                        if (found)
                        {
                            break;
                        }
                    }
                }
                
            }
            

            //If all questions not answered.
            if ( question_index < question_count-1)
            {

                //Next question
                question_index++;
            }

            //Return correct | incorrect
            return found;
        }

        //Clear input text
        private void ClearInput()
        {
            //Clear input
            this.AnswerTB.Text = "";
        }


        public ExaminePage()
        {
            InitializeComponent();
        }

        //Submit Answer Button Clicked
        private void SubmitAnswerBTN_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            //Keep track of answer
            String answer = this.AnswerTB.Text;

            //Clear Input
            this.ClearInput();

            //If awaiting answer
            if ( this.State == ChaoticaExamineState.MODE_DEFAULT)
            {
                //Answer the question
                bool correct = this.AnswerQuestion(answer);

                if (correct)
                {
                    this.QuestionTitleTB.Text = "Correct!";
                    this.num_right++;
                }else
                {
                    this.QuestionTitleTB.Text = "Wrong!";
                    this.num_wrong++;
                }

                //Disable input
                this.AnswerTB.IsEnabled = false;
                this.SubmitAnswerBTN.Content = "Next";

                //Switch state = MODE_CORRECTION
                this.State = ChaoticaExamineState.MODE_CORRECTION;
            }else
            {
                //Go to next question
                this.NextQuestion();

                //Enabled input
                this.AnswerTB.IsEnabled = true;
                this.SubmitAnswerBTN.Content = "Answer";

                //Switch state = MODE_DEFAULT
                this.State = ChaoticaExamineState.MODE_DEFAULT;
            }
        }
    }
}
