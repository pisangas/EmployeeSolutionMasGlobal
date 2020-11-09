using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Contracts
{
    public interface IEmployeeLogic
    {
        Task<List<EmployeeSalaryDTO>> GetAllEmployee();
        Task<EmployeeSalaryDTO> GetAllEmployeeById(int Id);
    }
}
