using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.Common;
using MySql.Data.MySqlClient;
using MySql.Data;
using MySql.Data.Types;
using System.Data;
using System.Collections;
using System.Reflection;
using System.IO;
using WeDoCommon;

namespace WeDoCommon
{
    class MySqlHandler
    {
        private MySqlConnection myConnection = null;
        private MySqlCommand myCommand = null;
        private MySqlDataAdapter adapter = new MySqlDataAdapter();
        private string myConnectionString = "";

        public event EventHandler<StringEventArgs> LogWriteHandler;

        public MySqlHandler()
        {
        }

        public MySqlHandler(string conStr)
        {
            myConnection = new MySqlConnection(myConnectionString);
        }

        public MySqlHandler(string url, int port, string dbName, string user, string passwd)
        {
            //Server=myServerAddress;Port=1234;Database=myDataBase;Uid=myUsername;Pwd = myPassword;
            string conStr = string.Format("Server={0};Port={1};Database={2};Uid={3};Pwd={4};Connect Timeout=30", url, port, dbName, user, passwd);
            myConnection = new MySqlConnection(conStr);
        }

        public MySqlHandler(string url, int port, string dbName, string user)
        {
            //Server=myServerAddress;Port=1234;Database=myDataBase;Uid=myUsername;Pwd = myPassword;
            string conStr = string.Format("Server={0};Port={1};Database={2};Uid={3};Pwd=;Connect Timeout=30;PersistSecurityInfo=no", url, port, dbName, user);
            myConnection = new MySqlConnection(conStr);
        }

        public void Open()
        {
            if (myConnection != null)
                myConnection.Open();

            myCommand = myConnection.CreateCommand();
            myCommand.Connection = myConnection;
        }

        public bool Ping()
        {
            return myConnection.Ping();
        }

        public void Close()
        {
            try { myCommand.Connection.Close(); }
            catch (Exception ex) { }
            try { myConnection.Close(); }
            catch (Exception ex) { }
        }

        public void Parameters(string name, string value)
        {
            myCommand.Parameters.AddWithValue(name, value);
        }

        public void ClearParamaters()
        {
            myCommand.Parameters.Clear();
        }

        public void SetQuery(string query)
        {
            myCommand.CommandText = query;
            myCommand.CommandType = CommandType.Text;
        }

        public DataTable DoQuery()
        {
            if (myCommand.Parameters.Count > 0)
            {
                myCommand.Prepare();
            }

            PrintParameters();

            adapter = new MySqlDataAdapter();
            adapter.SelectCommand = myCommand;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        public MySqlDataReader DoQueryByReader()
        {
            if (myCommand.Parameters.Count > 0)
            {
                myCommand.Prepare();
            }

            PrintParameters();

            return myCommand.ExecuteReader();
        }


        public int DoExecute()
        {
            if (myCommand.Parameters.Count > 0)
            {
                myCommand.Prepare();
            }

            PrintParameters();

            return myCommand.ExecuteNonQuery();
        }

        public int ExecuteScript(string sql)
        {
            MySqlScript script = new MySqlScript(myConnection, sql);

            int count = script.Execute();

            Logger.info("Executed " + count + " statement(s).");

            return count;
        }

        public int ExecuteScriptByFileName(string fileName)
        {
            return ExecuteScript(GetTextFileContents(fileName));
        }

        private String GetTextFileContents(String fileName)
        {
            Assembly _assembly;
            StreamReader _textStreamReader;
            string sqlText = "";

            try
            {
                _assembly = Assembly.GetExecutingAssembly();

                _textStreamReader = new StreamReader(_assembly.GetManifestResourceStream(fileName));
                string line;
                while ((line = _textStreamReader.ReadLine()) != null)
                {
                    sqlText += line;
                }
            }
            catch (Exception ex)
            {
                Logger.error(string.Format("파일[{0}]여는중 오류발생", fileName) + ex.ToString());
            }
            return sqlText;
        }

        public void PrintParameters()
        {
            string queryStr = "쿼리실행:"+myCommand.CommandText+"\nParameter:";
            IEnumerator ie = myCommand.Parameters.GetEnumerator();
            while (ie.MoveNext())
            {
                MySqlParameter param = (MySqlParameter)ie.Current;
                queryStr += string.Format("{0}[{1}]", param.ParameterName, param.Value);
            }

            OnWriteLog(queryStr);
        }

        public virtual void OnWriteLog(string msg)
        {
            EventHandler<StringEventArgs> handler = this.LogWriteHandler;
            if (this.LogWriteHandler != null)
            {
                handler(this, new StringEventArgs(msg));
            }
        }
    }
}
