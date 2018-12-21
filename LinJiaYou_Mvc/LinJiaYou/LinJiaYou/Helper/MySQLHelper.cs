using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using WxPayAPI;

namespace LinJiaYou.Helper
{
    public static class MySQLHelper
    {
        private static string GetConnStr()
        {
            string connStr = ConfigurationManager.ConnectionStrings["EsdTekContext"].ToString();
            return connStr;
        }
        public static DataTable GetDataTable(string mysqlStr)
        {
            DataTable dataTable = new DataTable();
            DataSet dataSet = new DataSet();
            MySqlConnection mySqlConnection = new MySqlConnection();
            mySqlConnection.ConnectionString = GetConnStr();
            MySqlCommand mySqlCommand = new MySqlCommand();
            mySqlCommand.Connection = mySqlConnection;
            mySqlCommand.CommandType = CommandType.Text;
            mySqlCommand.CommandText = mysqlStr;
            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
            mySqlDataAdapter.Fill(dataSet);
            if (dataSet.Tables.Count>0)
            {
                dataTable = dataSet.Tables[0];
            }
            return dataTable;
        }
        public static int ExecuteSql(string mysqlStr)
        {
            int result = 0;
            Log.Info("", " mysqlStr: " + mysqlStr);
            try {
                MySqlConnection mySqlConnection = new MySqlConnection();
                mySqlConnection.ConnectionString = GetConnStr();
                MySqlCommand mySqlCommand = new MySqlCommand();
                mySqlCommand.Connection = mySqlConnection;
                mySqlCommand.CommandType = CommandType.Text;
                mySqlCommand.CommandText = mysqlStr;
                mySqlConnection.Open();
                result = mySqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Log.Info("", " ExecuteSql error message : " + ex.Message);
            }
            return result;
        }
    }
}