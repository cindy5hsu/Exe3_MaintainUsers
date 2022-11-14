using ISpan.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exe3_MaintainUsers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dbHelper = new sqlDbHelper("default");

            //SqlInsert(dbHelper);
            //SqlUpdate(dbHelper);
            //SqlDelete(dbHelper);
           SqlSelect(dbHelper);


        }

        private static void SqlSelect(sqlDbHelper dbHelper)
        {
           
            string sql = "SELECT Name, Account, Password, dateofBirthd, Height FROM Users WHERE Id> @Id  ORDER BY Id ASC";
           
                var parameters = new SqlParameterBuilder().AddNInt("Id", 0).Build();
                DataTable news = dbHelper.Select(sql, parameters);
                foreach (DataRow row in news.Rows)
                {
                    string name = row.Field<string>("Name");
                string Account = row.Field<string>("Account");
                string Password = row.Field<string>("Password");
                DateTime dateOfBirthd = row.Field<DateTime>("dateOfBirthd");
                int Height = row.Field<int>("Height");

                Console.WriteLine($@"Name={name} Account={Account} Password={Password} 
                                 Birthday={dateOfBirthd.ToString("yyyy-MM-dd")} Height={Height}");
                }
          
        }

        private static void SqlDelete(sqlDbHelper dbHelper)
        {
            string sql = @"DELETE FROM Users WHERE Id=@Id";

            //var parameters = new sqlDbHelper("default");
           
                var parameters = new SqlParameterBuilder()
                    .AddNInt("id", 2)
                    .Build();

            dbHelper.ExecteNonQuery(sql, parameters);

                Console.WriteLine("記錄已 delete");
           
               
            
        }

        private static void SqlUpdate(sqlDbHelper dbHelper)
        {
            string sql = $@"UPDATE Users 
							SET Name=@Name, Account=@Account,Password=@Password
							,dateofBirthd=@dateofBirthd,Height=@Height 
							WHERE Id=@Id";

            var parameters = new SqlParameterBuilder()
                                   .AddNInt("Id", 1)
                                   .AddNVarchar("Name", 50, "sandy ")
                                   .AddNVarchar("Account", 50, "sandy777")
                                   .AddNVarchar("Password", 50, "666sandy")
                                   .AddNDateTime("dateOfBirthd", Convert.ToDateTime("1999 - 12 - 11"))
                                   .AddNInt("Height", 162)
                                   .Build();

            dbHelper.ExecteNonQuery(sql, parameters);

            Console.WriteLine("記錄已修改");
        }

        public static void SqlInsert(sqlDbHelper dbHelper)
        {
            string sql = @"insert into Users(Name,Account,Password,DateofBirthd,Heights)
                       values(@Name,@Account,@Password,@DateofBirthd,@Heights)";
            var parameters = new SqlParameterBuilder()
                             .AddNVarchar("Name", 50, "Tony")
                             .AddNVarchar("Account", 50, "Tony10")
                             .AddNVarchar("Password", 30, "12345")
                             .AddNDateTime("DateofBirthd", DateTime.Now)
                             .AddNInt("Heights", 167)
                             .Build();

            dbHelper.ExecteNonQuery(sql, parameters);
            Console.WriteLine("記錄已新增");
            
        } 

    }
}
