using System;
using MySql.Data.MySqlClient;
using System.Text;

namespace Chaotica___LingoIO.Core
{

    public class ChaoticaDatabase : IDisposable
    {
        //Database details
        private String dbuser = "", dbpass = "", dbdbname = "IOSpeech", dbhost = "chaoticadev.com";

        //Connect to database
        public MySqlConnection connection = new MySql.Data.MySqlClient.MySqlConnection();

        public bool connectionOpen { get; private set; }
        public string lastErrorMessage { get; internal set; }
        
        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        internal bool Connect()
        {
            System.Text.EncodingProvider ppp;
            ppp = System.Text.CodePagesEncodingProvider.Instance;
            Encoding.RegisterProvider(ppp);

            try
            {
                if (this.connection.State == ConnectionState.Open)
                {
                    return false;
                }

                //Connection String
                this.connection.ConnectionString = "Server=chaoticadev.com;Uid=" + dbuser + ";Pwd=" + dbpass + ";Database=" + dbdbname + ";SslMode=None;CharSet=utf8;";

                //Open Connection
                this.connection.Open();

                this.connectionOpen = true;
                return true;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                this.connectionOpen = false;
                this.lastErrorMessage = ex.Message;
                //Navigation<ErrorView>.Navigate(ex.Message);
                //Get MySQL Error
                return false;
            }
        }
        internal void CloseConnection()
        {
            if (this.connection.State == ConnectionState.Open)
            {
                this.connection.Close();
            }
        }

        //MysqlQuery function
        public MySqlDataReader Query(String stmt)
        {
            try
            {
                //Create MySQL Statement
                MySqlCommand projs = new MySqlCommand(stmt, this.connection);

                //Execute MySQL Reader
                MySqlDataReader reader = projs.ExecuteReader();

                //return Reader
                return reader;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                this.lastErrorMessage = ex.Message;

                return null;
            }
        }

        //MysqlQuery function then close
        public void QueryExec(String stmt)
        {

            try
            {
                //Execute write_function
                MySqlCommand projs = new MySqlCommand(stmt, this.connection);
                MySqlDataReader reader = projs.ExecuteReader();

                //Closes reader
                reader.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                this.lastErrorMessage = ex.Message;
            }
        }
        
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    
                    if(this.connection.State == ConnectionState.Open)
                    {
                        this.connection.Close();
                    }
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~ChaoticaDatabase() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion

    }
}
