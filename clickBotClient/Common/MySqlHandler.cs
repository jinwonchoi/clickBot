﻿using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.Common;
using MySql.Data.MySqlClient;
using MySql.Data;
using MySql.Data.Types;
using System.Data;
using System.Collections;

namespace WeDoCommon
{
    class MySqlHandler
    {
        private MySqlConnection myConnection = null;
        private MySqlCommand myCommand  = null;
        private MySqlDataAdapter adapter = new MySqlDataAdapter();
        private string myConnectionString = "";
        public MySqlHandler() {
        }

        public MySqlHandler(string conStr) {
            myConnection = new MySqlConnection(myConnectionString);
        }

        public MySqlHandler(string url, int port, string dbName, string user, string passwd)
        {
            //Server=myServerAddress;Port=1234;Database=myDataBase;Uid=myUsername;Pwd = myPassword;
            string conStr = string.Format("Server={0};Port={1};Database={2};Uid={3};Pwd={4};Connect Timeout=30", url, port, dbName, user, passwd);
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

        public void PrintParameters()
        {
            string queryStr = myCommand.CommandText;
            IEnumerator ie = myCommand.Parameters.GetEnumerator();
            while(ie.MoveNext()) {
                MySqlParameter param = (MySqlParameter)ie.Current;
                queryStr += string.Format("\n {0}[{1}]", param.ParameterName, param.Value);
            }

            Logger.debug(queryStr);
        }

        //private MySqlConnection GetConnection()
        //{
        //    MySqlConnection connection = null;
        //    try
        //    {
        //        string connectionStr = "server="+WDdbHost+";uid="+WDdbUser+";pwd="+WDdbPass+";database="+WDdbName;

        //        connection = new MySqlConnection(ConnectionString);
        //    }
        //    catch (Exception ex)
        //    {
        //        logWrite("GetMySqlConnection Exception");
        //        logWrite(ex.ToString());
        //    }
        //    return connection;
        //}

/*
        MySqlCommand myCommand = new MySqlCommand(myInsertQuery);
        myConnection = new MySqlConnection(myConnectionString);
        adapter = new MySqlDataAdapter();
        */
    }
}
