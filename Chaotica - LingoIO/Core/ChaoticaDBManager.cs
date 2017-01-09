using System;
using MySql.Data.MySqlClient;
using System.Text;

namespace Chaotica___LingoIO.Core
{

    class ChaoticaDBManager
    {
        //Database details
        private static String dbuser = "", dbpass = "", dbdbname = "IOSpeech", dbhost = "chaoticadev.com";

        //Connect to database
        public static MySqlConnection connection = new MySql.Data.MySqlClient.MySqlConnection();

        public static bool connectionOpen { get; private set; }
        public static string lastErrorMessage { get; internal set; }

        //MysqlQuery function
        public static MySqlDataReader Query(String stmt)
        {
            //Create MySQL Statement
            MySqlCommand projs = new MySqlCommand(stmt, ChaoticaDBManager.connection);

            //Execute MySQL Reader
            MySqlDataReader reader = projs.ExecuteReader();

            //return Reader
            return reader;
        }

        //MysqlQuery function then close
        public static void QueryExec(String stmt)
        {
            //Execute write_function

            MySqlCommand projs = new MySqlCommand(stmt, ChaoticaDBManager.connection);
            MySqlDataReader reader = projs.ExecuteReader();

            //Closes reader
            reader.Close();
        }

        internal static bool Connect()
        {
            String err;

            System.Text.EncodingProvider ppp;
            ppp = System.Text.CodePagesEncodingProvider.Instance;
            Encoding.RegisterProvider(ppp);

            try
            {
                if (connection.State == ConnectionState.Open)
                {
                    return false;
                }
                //Connection String
                connection.ConnectionString = "Server=chaoticadev.com;Uid=" + dbuser + ";Pwd=" + dbpass + ";Database=" + dbdbname + ";SslMode=None;CharSet=utf8;";

                //Open Connection
                connection.Open();

                connectionOpen = true;
                return true;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                connectionOpen = false;
                lastErrorMessage = ex.Message;
                //Navigation<ErrorView>.Navigate(ex.Message);
                //Get MySQL Error
                err = (ex.Message);
                return false;
            }
        }

        public ChaoticaDBManager()
        {
            if (connectionOpen) { return; }

            String err;

            System.Text.EncodingProvider ppp;
            ppp = System.Text.CodePagesEncodingProvider.Instance;
            Encoding.RegisterProvider(ppp);

            try
            {
                if (connection.State == ConnectionState.Open)
                {
                    return;
                }
                //Connection String
                connection.ConnectionString = "Server=" + dbhost + ";Uid=" + dbuser + ";Pwd=" + dbpass + ";Database=" + dbdbname + ";SslMode=None;CharSet=utf8;";

                //Open Connection
                connection.Open();

                connectionOpen = true;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                connectionOpen = false;
                lastErrorMessage = ex.Message;
                //Navigation<ErrorView>.Navigate(ex.Message);
                //Get MySQL Error
                err = (ex.Message);
            }
        }
    }
}
