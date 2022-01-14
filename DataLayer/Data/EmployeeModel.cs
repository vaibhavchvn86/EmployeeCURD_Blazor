using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Data
{
    public class EmployeeModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string EmployeeId { get; set; }
        public string Name { get; set; }
        public string ProfileImg { get; set; }
        public string Gender { get; set; }
        public string Department { get; set; }
        public int Salary { get; set; }
        public DateTime StartDate { get; set; }
        public string Note { get; set; }
    }
}
