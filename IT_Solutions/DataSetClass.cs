using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Solutions
{
    class DataSetClass
    {
            public static string DS = "DESKTOP-N1D77F1\\MYSERVERNAME", IC = "IT_SolutionDataBase"; /// Подключение к базе данных, указание названия базы
            public static string Users_ID = "null", Password = "null", App_Name = "Комания - IT-Решения"; 
            public static string ConnectionStrig = string.Format("Data Source = {0}; Initial Catalog = {1}; Integrated Security = true;", DS, IC, "; Persist Security Info = true; User ID = sa; Password = 1234"); /// <summary>
            ///  Строка для подключения
            public SqlConnection connection = new SqlConnection(ConnectionStrig);
            private SqlCommand command = new SqlCommand();
            public DataTable resultTable = new DataTable();
            public SqlDependency dependency = new SqlDependency();
            public enum act { select, manipulation };
            /// Метод для выполнения подключения к базе данных
            public void sqlExecute(string quety, act act) 
            {
                command.Connection = connection;
                command.CommandText = quety;
                command.Notification = null;
                switch (act)
                {
                    case act.select:
                        dependency.AddCommandDependency(command);
                        SqlDependency.Start(connection.ConnectionString);
                        connection.Open();
                        resultTable.Load(command.ExecuteReader());
                        connection.Close();
                        break;
                    case act.manipulation:
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                        break;
                }
            
        }
    }
}
