using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contracts
{
    public interface IEmployeeAccess
    {
        //Interface Get all Employees whatever Source
        Task<IEnumerable<Employee>> GetAllApiEmployee();
    }
}
