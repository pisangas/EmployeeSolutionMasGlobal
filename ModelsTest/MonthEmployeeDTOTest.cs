using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.DTOs;

namespace ModelsTest
{
    [TestClass]
    public class MonthEmployeeDTOTest
    {
        [TestMethod]
        public void ReturnaAnnualSalary()
        {
            MonthEmployeeDTO monthEmployeeDTO = new MonthEmployeeDTO
            {
                EmployeeId = 1,
                Name = "Eduardo",
                ContractTypeName = "MonthlySalaryEmployee",
                RoleId = 1,
                RoleDescription = "",
                RoleName = "",
                HourSalary = 2000,
                MonthSalary = 1000,
                AnnualSalary = 0
            };
            monthEmployeeDTO.ReturnSalary();
            Assert.AreEqual(12000, monthEmployeeDTO.AnnualSalary);
        }
    }
}
