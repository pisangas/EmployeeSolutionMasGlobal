using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    //Employee Data Trasfer Object 
    public abstract class EmployeeDTO
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string ContractTypeName { get; set; }
        public int RoleId { get; set; }
        public string RoleDescription { get; set; }
        public string RoleName { get; set; }
        public double HourSalary { get; set; }
        public double MonthSalary { get; set; }
        public double AnnualSalary { get; set; }

        public abstract void ReturnSalary();
    }
}

