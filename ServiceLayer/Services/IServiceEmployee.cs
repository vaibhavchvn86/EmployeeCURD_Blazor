using DataLayer.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Services
{
    public interface IServiceEmployee
    {
        EmployeeModel AddEmp(EmployeeModel Emp);
        EmployeeModel EditEmp(EmployeeModel edit);
        string DeleteEmp(string Id);
        EmployeeModel GetEmpById(string Id);
        List<EmployeeModel> GetAllEmp();
    }
}
