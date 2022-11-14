﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Utility
{
    public class sqlDbHelper
    {
        private string connString;
        /// <summary>
        /// 連接字串
        /// </summary>
        /// <param name="keyofConnString"></param>
        public sqlDbHelper(string keyofConnString)
        {
            connString = System.Configuration.ConfigurationManager
                                      .ConnectionStrings[keyofConnString]
                                      .ConnectionString;
        }

        public void ExecteNonQuery(string sql, SqlParameter[] parameters)
        {
            using (var conn = new SqlConnection(connString))
            {
                SqlCommand command = new SqlCommand(sql, conn);
                conn.Open();

                command.Parameters.AddRange(parameters);
                command.ExecuteNonQuery();
            }
        }

        public DataTable Select(string sql, SqlParameter[] parameters)
        {
            using (var conn = new SqlConnection(connString))
            {
                var command = new SqlCommand(sql, conn);
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "hhh");

                return dataSet.Tables["hhh"];
            }
        }
    }


}
