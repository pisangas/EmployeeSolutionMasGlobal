using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.DTOs;

namespace ModelsTest
{   

    [TestClass]
    public class HourEmployeeDTOTest
    {
        [TestMethod]
        public void ReturnaAnnualSalary()
        {
            HourEmployeeDTO hourEmployeeDTO = new HourEmployeeDTO
            {
                EmployeeId = 1,
                Name = "Eduardo",
                ContractTypeName = "HourlySalaryEmployee",
                RoleId = 1,
                RoleDescription = "",
                RoleName = "",
                HourSalary = 2000,
                MonthSalary = 60000,
                AnnualSalary = 0
            };

            hourEmployeeDTO.ReturnSalary();
            Assert.AreEqual(2880000, hourEmployeeDTO.AnnualSalary);
        }
    }

}
