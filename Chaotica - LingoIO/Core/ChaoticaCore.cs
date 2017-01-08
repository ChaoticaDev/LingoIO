using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;

namespace Chaotica___LingoIO.Core
{
    public static class ChaoticaCore
    {
        public static ObservableCollection<ChaoticaCourse> Courses = new ObservableCollection<ChaoticaCourse>();

        public static ChaoticaCourse SelectedCourse { get; set; }
        public static ChaoticaLesson SelectedLesson { get; set; }

        public static async System.Threading.Tasks.Task xAsync(Func<int> p)
        {
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                p();
            });
        }

        public static class Utils
        {
            public static string RemoveSpecialCharacters(string str)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < str.Length; i++)
                {
                    if ((str[i] >= '0' && str[i] <= '9')
                        || (str[i] >= 'A' && str[i] <= 'z'
                            || (str[i] == '.' || str[i] == '_' || str[i] == ' ')))
                    {
                        sb.Append(str[i]);
                    }
                }

                return sb.ToString();
            }
        }

        public static class CourseUtils
        {
            public static Dictionary<String, Dictionary<String, List<String>>> BindVocabulary()
            {
                Dictionary<String, Dictionary<String, List<String>>> dict = new Dictionary<String, Dictionary<String, List<String>>>();

                dict.Add("English", new Dictionary<String, List<String>>());
                dict.Add("Spanish", new Dictionary<String, List<String>>());

                MySqlDataReader reader = ChaoticaDBManager.Query("SELECT * FROM english_words");

                while (reader.Read())
                {
                    String TitleText = reader.GetString("Title");

                    if (dict["English"].ContainsKey(TitleText) == false)
                    {
                        dict["English"].Add(TitleText, new List<String>());
                    }
                    dict["English"][TitleText].Insert(0, reader.GetString("Spanish"));
                }

                reader.Close();

                reader = ChaoticaDBManager.Query("SELECT * FROM spanish_words");

                while (reader.Read())
                {
                    String TitleText = reader.GetString("Title");
                    if (dict["Spanish"].ContainsKey(TitleText) == false)
                    {
                        dict["Spanish"].Add(TitleText, new List<String>());
                    }
                    dict["Spanish"][TitleText].Insert(0, reader.GetString("English"));
                }

                reader.Close();

                return dict;
            }
            public static void BindLessons()
            {
                foreach (ChaoticaCourse crs in Courses)
                {
                    crs.Lessons = DatabaseUtils.GetLessons(crs.ID);
                }
            }

            public static void BindQuestions()
            {
                foreach (ChaoticaCourse crs in Courses)
                {
                    foreach(ChaoticaLesson lsn in crs.Lessons)
                    {
                        lsn.Questions = ChaoticaCore.DatabaseUtils.GetQuestions(lsn.ID);
                    }
                }
            }

            public static void BindTargets()
            {
                foreach (ChaoticaCourse crs in Courses)
                {
                    foreach (ChaoticaLesson lsn in crs.Lessons)
                    {
                        foreach (ChaoticaQuestion qsn in lsn.Questions)
                        {
                            qsn.PossibleAnswers = DatabaseUtils.GetTargets(qsn.ID);
                        }
                    }
                }
            }

            public static void BindWords()
            {
                foreach (ChaoticaCourse crs in Courses)
                {
                    foreach (ChaoticaLesson lsn in crs.Lessons)
                    {
                        foreach (ChaoticaQuestion qsn in lsn.Questions)
                        {
                            foreach(ChaoticaTarget trg in qsn.PossibleAnswers)
                            {
                                String[] ids = trg.WID.Split(',');

                                List<ChaoticaWord> words = new List<ChaoticaWord>();
                                foreach(String id in ids)
                                {
                                    ChaoticaWord tmpWord = DatabaseUtils.GetWord(trg.Language, id);
                                    words.Add(tmpWord);
                                }

                                trg.Combinations.Add(words);
                                
                            }
                        }
                    }
                }
            }
        }

        public static class DataCached
        {
            public static Dictionary<String, Dictionary<String, List<String>>> VocabularyCache;

            public static void CacheInit()
            {
                VocabularyCache = new Dictionary<String, Dictionary<String, List<String>>>();
            }
        }

        public static class DatabaseUtils
        {
            public static ObservableCollection<ChaoticaCourse> GetCourses()
            {
                ObservableCollection<ChaoticaCourse> crs = new ObservableCollection<ChaoticaCourse>();
                MySqlDataReader reader = ChaoticaDBManager.Query("SELECT * FROM courses");

                ChaoticaCourse course;
                while (reader.Read())
                {
                    course = new ChaoticaCourse(reader.GetString("ID"), reader.GetString("Title"), reader.GetString("Description"));
                    course.ImageSource = reader.GetString("Icon");
                    crs.Add(course);
                }
                reader.Close();

                return crs;
            }

            public static ObservableCollection<ChaoticaLesson> GetLessons(String cid)
            {
                ObservableCollection<ChaoticaLesson> lsn = new ObservableCollection<ChaoticaLesson>();
                MySqlDataReader reader = ChaoticaDBManager.Query("SELECT * FROM lessons WHERE CID = '" + cid + "'");


                while (reader.Read())
                {
                    ChaoticaLesson lesson = new ChaoticaLesson(reader.GetString("ID"), reader.GetString("Title"), reader.GetString("Description"));
                    lesson.ImageSource = reader.GetString("Icon");
                    lsn.Add(lesson);
                }
                reader.Close();

                return lsn;
            }

            public static ObservableCollection<ChaoticaQuestion> GetQuestions(String lid)
            {
                ObservableCollection<ChaoticaQuestion> qsn = new ObservableCollection<ChaoticaQuestion>();
                MySqlDataReader reader = ChaoticaDBManager.Query("SELECT * FROM questions WHERE LID = '" + lid + "'");


                while (reader.Read())
                {
                    ChaoticaQuestion question = new ChaoticaQuestion(reader.GetString("ID"), reader.GetString("Title"));

                    question.LanguageFrom = reader.GetInt32("LFROM") == 1 ? ChaoticaLanguage.English : ChaoticaLanguage.Spanish;
                    question.LanguageTo = reader.GetInt32("LTO") == 1 ? ChaoticaLanguage.English : ChaoticaLanguage.Spanish;

                    question.PossibleAnswers = new ObservableCollection<ChaoticaTarget>();


                    qsn.Add(question);
                }
                reader.Close();

                return qsn;
            }


            public static ObservableCollection<ChaoticaTarget> GetTargets(String qid)
            {
                ObservableCollection<ChaoticaTarget> tgt = new ObservableCollection<ChaoticaTarget>();
                MySqlDataReader reader = ChaoticaDBManager.Query("SELECT * FROM question_words WHERE QID = '" + qid + "'");


                while (reader.Read())
                {
                    ChaoticaTarget target = new ChaoticaTarget(reader.GetString("ID"), reader.GetInt32("Language") == 1 ? ChaoticaLanguage.English : ChaoticaLanguage.Spanish);
                    target.WID = reader.GetString("WID");
                    tgt.Add(target);
                }
                reader.Close();

                return tgt;
            }

            public static ChaoticaWord GetWord(ChaoticaLanguage lang, String id)
            {
                String lang_words = lang == ChaoticaLanguage.English ? "english_words" : "spanish_words";
                MySqlDataReader reader = ChaoticaDBManager.Query("SELECT * FROM " + lang_words + " WHERE ID = '" + id + "' LIMIT 1");

                ChaoticaWord word = null;
                while (reader.Read())
                {
                    String counterpart = reader.GetString(lang == ChaoticaLanguage.English ? "Spanish" : "English");
                    word = new ChaoticaWord(reader.GetString("Title"), counterpart);
                }
                reader.Close();

                return word;
            }
        }
    }
}
