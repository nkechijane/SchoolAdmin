using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;

namespace SchoolAdmin.MongoDbDemo
{
    class MongoDBService
    {
        MongoClient mongo;
        IMongoDatabase database;
        IMongoCollection<BsonDocument> teachersCollection, studentsCollection;

        public MongoDBService()
        {
            mongo = new MongoClient("mongodb://localhost:27017/school_admin_db");
            database = mongo.GetDatabase("school_admin_db");
            teachersCollection = database.GetCollection<BsonDocument>("teachers");
            studentsCollection = database.GetCollection<BsonDocument>("students");
        }

        public void Insert(string collectionName, BsonDocument dataToInsert)
        {
            switch (collectionName)
            {
                case "teachers":
                    teachersCollection.InsertOne(dataToInsert);
                    break;
                case "students":
                    studentsCollection.InsertOne(dataToInsert);
                    break;
                default:
                    Console.WriteLine("Invalid collection! Only 'teachers' and 'students' are allowed.");
                    break;
            }
        }

        public List<BsonDocument> FetchAll(string collectionName)
        {
            List<BsonDocument> result;
            switch (collectionName)
            {
                case "teachers":
                    result = teachersCollection.Find(new BsonDocument()).ToList();
                    break;
                case "students":
                    result = studentsCollection.Find(new BsonDocument()).ToList();
                    break;
                default:
                    result = null;
                    Console.WriteLine("Invalid collection! Only 'teachers' and 'students' are allowed.");
                    break;
            }
            return result;
        }

        public int Update(string collectionName, KeyValuePair<string, string> dataToUpdate, int id)
        {
            var result = 0;
            switch (collectionName)
            {
                case "teachers":
                    var filter = Builders<BsonDocument>.Filter.Eq("staff_id", id);
                    var update = Builders<BsonDocument>.Update.Set(dataToUpdate.Key, dataToUpdate.Value);
                    teachersCollection.UpdateMany(filter, update);
                    result = 1;
                    break;
                case "students":
                    var filter1 = Builders<BsonDocument>.Filter.Eq("Reg_Number", id);
                    var update1 = Builders<BsonDocument>.Update.Set(dataToUpdate.Key, dataToUpdate.Value);
                    studentsCollection.UpdateMany(filter1, update1);
                    result = 1;
                    break;
                default:
                    result = 0;
                    Console.WriteLine("Invalid collection! Only 'teachers' and 'students' are allowed.");
                    break;
            }
            return result;
        }


        public int delete(string collectionName, int id)
        {
            var result = 0;
            switch (collectionName)
            {
                case "teachers":
                    var filter = Builders<BsonDocument>.Filter.Eq("staff_id", id);
                    teachersCollection.DeleteOne(filter);
                    result = 1;
                    break;
                case "students":
                    var filter1 = Builders<BsonDocument>.Filter.Eq("Reg_Number", id);
                    studentsCollection.DeleteOne(filter1);
                    result = 1;
                    break;
                default:
                    result = 0;
                    Console.WriteLine("Invalid collection! Only 'teachers' and 'students' are allowed.");
                    break;
            }
            return result;
        }
        //public void TestConnection()
        //{            
        //    // Display a list of databases on this server
        //    var dbList = mongo.ListDatabases().ToList();
        //    Console.WriteLine("The list of databases on this server is:");
        //    foreach (var db in dbList)
        //    {
        //        Console.WriteLine(db);
        //    }


        //}
    }
}
