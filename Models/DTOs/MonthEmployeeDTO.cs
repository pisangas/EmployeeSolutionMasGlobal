using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    //Employee Data Trasfer Object
    public class MonthEmployeeDTO : EmployeeDTO
    {
        public override void ReturnSalary()
        {
            try
            {
                if (ContractTypeName == "MonthlySalaryEmployee")
                {
                    AnnualSalary = MonthSalary * 12;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Monthly calculate Salary, Process failed: {ex.Message}");
            }
        }
    }
}
