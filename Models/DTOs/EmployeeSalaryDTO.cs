using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    //Employee Data Trasfer Object with Annual Salary Property
    public class EmployeeSalaryDTO
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string ContractTypeName { get; set; }
        public int RoleId { get; set; }
        public string RoleDescription { get; set; }
        public string RoleName { get; set; }
        public double AnnualSalary { get; set; }
    }
}
