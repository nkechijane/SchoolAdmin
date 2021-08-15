using Microsoft.Data.SqlClient;
using SchoolAdmin.AdoDotnetDemo.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin.AdoDotnetDemo.SqlDataService
{
    public class TeacherService
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter adp;
        SqlDataReader rdr;

        public TeacherService()
        {
            conn = new SqlConnection("Data Source =.; Initial Catalog = SchoolAdminDB; Integrated Security = True; Pooling = False");

        }
         
        public void Insert(TeacherDTO dataToInsert)
        {
            string commandstr = $"INSERT INTO Teachers(FirstName, MiddleName, LastName, Subject)" +
                        $"VALUES('{dataToInsert.FirstName}', '{dataToInsert.MiddleName}', '{dataToInsert.LastName}', '{dataToInsert.Subject}')";
            cmd = new SqlCommand(commandstr, conn);
            conn.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            conn.Close();
            Console.WriteLine($"Successfully inserted {rowsAffected} records into the 'Teachers' table.");
        }
       

        public List<TeacherDTO> FetchAll()
        {
            List<TeacherDTO> result = new List<TeacherDTO>();
            string commandStr = "SELECT * FROM Teachers";
            cmd = new SqlCommand(commandStr, conn);
            conn.Open();
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                result.Add(new TeacherDTO
                {
                    StaffId = (int)rdr["StaffId"],
                    FirstName = (string)rdr["FirstName"],
                    MiddleName = rdr["MiddleName"] == DBNull.Value ? string.Empty : (string)rdr["MiddleName"],
                    LastName = (string)rdr["LastName"],
                    Subject = (string)rdr["Subject"]
                }); 

            }
            conn.Close();
            return result;
        }

        public List<TeacherDTO> FetchWithFilter(KeyValuePair<string, object> filterPair, string comparer)
        {
            List<TeacherDTO> result = new List<TeacherDTO>();
            string commandStr = "SELECT * FROM Teachers WHERE " + $"{filterPair.Key} {comparer} '{filterPair.Value}'";

            cmd = new SqlCommand(commandStr, conn);

            conn.Open();
            rdr = cmd.ExecuteReader();
            {
                result.Add(new TeacherDTO
                {
                    StaffId = (int)rdr["StaffId"],
                    FirstName = (string)rdr["FirstName"],
                    MiddleName = rdr["MiddleName"] == DBNull.Value ? string.Empty : (string)rdr["MiddleName"],
                    LastName = (string)rdr["LastName"],
                    Subject = (string)rdr["Subject"]

                }); ;
            }
            conn.Close();
            return result;
        }

        public void Update(KeyValuePair<string, object> filterPair, string comparer, TeacherDTO newData)
        {
            string filterStr = " WHERE " + $"{filterPair.Key} {comparer} '{filterPair.Value}'";

            string updateStr = newData.FirstName == null ? "" : $"  FirstName = '{newData.FirstName}',";
            updateStr += newData.MiddleName == null ? "" : $" MiddleName = '{newData.MiddleName}',";
            updateStr += newData.LastName == null ? "" : $" LastName = '{newData.LastName}',";

            string commandStr = $"UPDATE Teachers SET" + updateStr.TrimEnd(',') + filterStr;
            cmd = new SqlCommand(commandStr, conn);
            conn.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            conn.Close();
            Console.WriteLine($"Successfully updated {rowsAffected} records in the 'Teachers' table.");
        }

        public void Delete (KeyValuePair<string, object> filterPair, string comparer)
        {
            string commandStr = $"DELETE FROM Teachers WHERE {filterPair.Key} {comparer} {filterPair.Value}";
            cmd = new SqlCommand(commandStr, conn);
            conn.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            conn.Close();
            Console.WriteLine($"Succesfully deleted {rowsAffected} records from 'Teachers' table.");
        }
        
    }
    
}