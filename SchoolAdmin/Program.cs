using SchoolAdmin.Facilities;
using SchoolAdmin.Learning;
using SchoolAdmin.LookUp;
using SchoolAdmin.Teaching;
using System;
using System.Collections.Generic;
using SchoolAdmin.MongoDbDemo;
using MongoDB.Bson;
using SchoolAdmin.AdoDotnetDemo;
using SchoolAdmin.AdoDotnetDemo.DTO;
using Microsoft.Data.SqlClient.Server;

namespace SchoolAdmin
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instantiate the sqlDataService class
            SqlDataService sqlDbservice = new SqlDataService();

            // Define aand insert Teacher objects
            TeacherDTO teacher1 = new TeacherDTO() { FirstName = "Adeleke", MiddleName = "", LastName = "Ayinde", Subject = "Physics" };
            TeacherDTO teacher2 = new TeacherDTO() { FirstName = "Temi", MiddleName = "Temitope", LastName = "Tegbe", Subject = "Philosophy" };
            sqlDbservice.Insert("teachers", teacher1);
            sqlDbservice.Insert("teachers", teacher2);

            // Define aand insert students objects
            StudentDTO student1 = new StudentDTO() { FirstName = "Newmann", MiddleName = "Philip", LastName = "Amadi", Level = "SSS 3" };
            StudentDTO student2 = new StudentDTO() { FirstName = "Habeeb", MiddleName = "", LastName = "Olakitan", Level = "SeniorMan" };
            sqlDbservice.Insert("students", student1);
            sqlDbservice.Insert("students", student2);

            ////// Instantiate the MongoDbService class
            //MongoDBService dbService = new MongoDBService();
            ////dbService.TestConnection();

            ////Create Teacher documents and nsert it in the collection
            //BsonDocument teacherDoc1 = new BsonDocument()
            //{
            //    {"staff_id", 1001 }, {"name", "Chief Adeleke Ayinde"}, {"subject", "Mathematics"}

            //};
            //BsonDocument teacherDoc2 = new BsonDocument()
            //{
            //    {"staff_id", 1002}, {"name", "High Chief Bayowa Odometa"}, {"subject", "Physics"}

            //};

            // Create a number of Student instances
            ILearner firstStudent = new Student(1001, "Betty Turner");
            firstStudent.Level = StudentLevel.JSS1;

            //Create an instance of the LibraryCatalog class
            LibraryCatalog catalog = new LibraryCatalog();

            //Subscribe the teacher and student to the BookAdded event
            catalog.BookAdded += firstTeacher.RecieveNewBookAlert;
            catalog.BookAdded += firstStudent.RecieveNewBookAlert;

            catalog.AddBook(new Book() { Title = "Things fall Apart", Author = "Chinua Achebe" });



            ////dbService.Insert("students", studentDoc);
            ////dbService.Insert("students", studentDoc2);

            ////dbService.Insert("teachers", teacherDoc1);
            ////dbService.Insert("teachers", teacherDoc2);

            //Console.WriteLine("The available teachers are:");
            //var teachers = dbService.FetchAll("teachers");
            //foreach (var teacher in teachers)
            //{
            //    Console.WriteLine(teacher);
            //}           

            //// Create a teacher instance
            //ITeacher firstTeacher = new Teacher(101, "Tunde Badmus");

            //// Create a subject instance based on the struct
            //SchoolSubject mySubject = new SchoolSubject
            //{
            //    Code = 101,
            //    Title = "Mathematics",
            //    Category = "General"
            //};

            //// Assign the subject to the teacher
            //firstTeacher.Subject = mySubject;


            //// Create a generic list of type ILearner
            //List<ILearner> studentList = new List<ILearner>();

            //// Create a number of Student instances
            //ILearner firstStudent = new Student(1001, "Betty Turner");
            //firstStudent.Level = StudentLevel.JSS1;

            ////Create an instance of the LibraryCatalog class
            //LibraryCatalog catalog = new LibraryCatalog();

            ////Subscribe the teacher and student to the BookAdded event
            //catalog.BookAdded += firstTeacher.RecieveNewBookAlert;
            //catalog.BookAdded += firstStudent.RecieveNewBookAlert;

            //catalog.AddBook(new Book() { Title = "Things fall Apart", Author = "Chinua Achebe" });



            //ILearner secondStudent = new Student(1002, "Alison Wood");
            //secondStudent.Level = StudentLevel.JSS2;

            //ILearner thirdStudent = new Student(1003, "Carl John");
            //thirdStudent.Level = StudentLevel.SSS1;

            //// Store the student instances in the list
            //studentList.Add(firstStudent);
            //studentList.Add(secondStudent);
            //studentList.Add(thirdStudent);

            // NOTE: The objects can also be added using AddRange as follows:
            // studentList.AddRange(new List<Student> { firstStudent, secondStudent, thirdStudent });

            // Now, assign the list of students to the teacher's Learners property
            //firstTeacher.Learners = studentList;

            //// Display the teacher's subject title and code
            //Console.WriteLine($"{firstTeacher.Name} teaches {firstTeacher.Subject.Title} with code {firstTeacher.Subject.Code}");

            //// Display the number of learners assigned to the teacher
            //Console.WriteLine($"The number of learners assigned to {firstTeacher.Name} is {firstTeacher.Learners.Count}");

            //foreach (Student student in firstTeacher.Learners)
            //{
            //    Console.WriteLine($"Name: {student.Name} \t\tLevel:{student.Level}");
            //}

            //// Check if teacher's learners include a newly created student named "Carl John"
            //Student searchStudent = new Student(1003, "Carl John");
            //searchStudent.Level = StudentLevel.SSS1;
            //bool isAssignedStudent = firstTeacher.Learners.Contains(searchStudent);
            //Console.WriteLine($"The search for Carl John returned: {isAssignedStudent}");

            //// Check if teacher's learners include the original student named "Carl John"
            //isAssignedStudent = firstTeacher.Learners.Contains(thirdStudent);
            //Console.WriteLine($"The search for Carl John returned: {isAssignedStudent}");

            //// Exploring KeyValuePair<TKey, TValue> type
            //KeyValuePair<int, ILearner> student1, student2, student3;
            //student1 = new KeyValuePair<int, ILearner>(5, firstStudent);
            //student2 = new KeyValuePair<int, ILearner>(7, secondStudent);
            //student3 = new KeyValuePair<int, ILearner>(10, thirdStudent);

            //// Exploring Dictionary<TKey, TValue> type
            //Dictionary<int, ILearner> studentDictionary;
            //studentDictionary = new Dictionary<int, ILearner>();
            //studentDictionary.Add(5, firstStudent);
            //studentDictionary.Add(7, secondStudent);
            //studentDictionary.Add(10, thirdStudent);

            //foreach(KeyValuePair<int, ILearner> kvp in studentDictionary)
            //{
            //    Console.WriteLine($"Key is {kvp.Key} \t Value is {kvp.Value.Name}");
            //}
        }
    }
}
