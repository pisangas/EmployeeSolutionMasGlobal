using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    //Employee Data Trasfer Object
    public class HourEmployeeDTO : EmployeeDTO
    {
        public override void ReturnSalary()
        {
            try
            {
                if (ContractTypeName == "HourlySalaryEmployee")
                {
                    AnnualSalary = 120 * HourSalary * 12;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Hourly calculate Salary, Process failed: {ex.Message}");
            }
        }
    }
}

