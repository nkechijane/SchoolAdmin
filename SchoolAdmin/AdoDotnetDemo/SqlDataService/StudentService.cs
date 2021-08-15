using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolAdmin.AdoDotnetDemo.DTO;
using Microsoft.Data.SqlClient;



namespace SchoolAdmin.AdoDotnetDemo.SqlDataService
{
    public class StudentService
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter adp;
        SqlDataReader rdr;

        public StudentService()
        {
            conn = new SqlConnection("Data Source = .; Initial Catalog = SchoolAdminDB; Integrated Security = True; Pooling = False");
        }

        public void Insert(StudentDTO dataToInsert)
        {
            string commandStr = $"INSERT INTO Students(FirstName, MiddleName, LastName, Level)" + $"VALUES('{dataToInsert.FirstName}', '{dataToInsert.MiddleName}', '{dataToInsert.LastName}', '{dataToInsert.Level});')";
            cmd = new SqlCommand(commandStr, conn);
            conn.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            conn.Close();
            Console.WriteLine($"Successfully inserted {rowsAffected} records into the Student's table.");
        }

    }
}
