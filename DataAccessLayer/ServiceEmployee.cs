using DataLayer.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using ServiceLayer;
using ServiceLayer.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public class ServiceEmployee : IServiceEmployee
    {
        private readonly IMongoCollection<EmployeeModel> Employee;

        public ServiceEmployee(IDBservice setting)
        {
            var client = new MongoClient(setting.ConnectionString);
            var database = client.GetDatabase(setting.DatabaseName);
            Employee = database.GetCollection<EmployeeModel>("Employee");
        }

        //// Other method to get databse details.
        //public ServiceEmployee(IOptions<DBservice> setting)
        //{
        //    var client = new MongoClient(setting.Value.ConnectionString);
        //    var database = client.GetDatabase(setting.Value.DatabaseName);
        //    Employee = database.GetCollection<EmployeeModel>("Employee");
        //}

        public EmployeeModel AddEmp(EmployeeModel Emp)
        {
            try
            {
                Employee.InsertOne(Emp);
                return Emp;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public string DeleteEmp(string Id)
        {
            try
            {
                Employee.FindOneAndDelete(x => x.EmployeeId == Id);
                return "Employee Data Deleted";

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public EmployeeModel EditEmp(EmployeeModel edit)
        {
            try
            {
                var checkEmp = Employee.Find(x => x.EmployeeId == edit.EmployeeId).FirstOrDefault();
                if(checkEmp == null)
                {
                    Employee.InsertOne(edit);
                }
                else
                {
                    Employee.ReplaceOne(x => x.EmployeeId == edit.EmployeeId, edit);
                }
                return edit;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<EmployeeModel> GetAllEmp()
        {
            try
            {
                return Employee.Find(FilterDefinition<EmployeeModel>.Empty).ToList();
                // return Employee.Find( a => true).ToList();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public EmployeeModel GetEmpById(string Id)
        {
            try
            {
                return Employee.Find(x => x.EmployeeId == Id).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
