using AutoMapper;
using BusinessLogic.Contracts;
using Commons;
using DataAccess;
using DataAccess.Contracts;
using Models;
using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace BusinessLogic
{
    public class EmployeeLogic : IEmployeeLogic
    {
        #region [Inversion de dependencia - Interfaz Business Layer -]
        private IEmployeeAccess _EmployeeAccess;
        public EmployeeLogic(IEmployeeAccess employeeAccess)
        {
            _EmployeeAccess = employeeAccess;
        }        
        public EmployeeLogic()
        {
        }
        #endregion

        #region [Annual Salary All Employees]        
        public async Task<List<EmployeeSalaryDTO>> GetAllEmployee()
        {
            IUnityContainer unityContainer = new UnityContainer();
            unityContainer.RegisterType<IEmployeeAccess, EmployeeAccess>();
            IEmployeeAccess _EmployeeAccess = unityContainer.Resolve<IEmployeeAccess>();

            try
            {
                List<EmployeeSalaryDTO> EmployeeSalaryAnnual = new List<EmployeeSalaryDTO>();
                List<MonthEmployeeDTO> employeeMonthList = new List<MonthEmployeeDTO>();
                List<HourEmployeeDTO> employeeHourList = new List<HourEmployeeDTO>();

                var employees = await _EmployeeAccess.GetAllApiEmployee();
                
                List<Employee> HourList = employees.Where(e => e.ContractTypeName == Constants.ContractHour).ToList();
                List<Employee> MonthList = employees.Where(e => e.ContractTypeName == Constants.ContractMonth).ToList();
                                
                foreach (Employee employee in HourList)
                { 
                    HourEmployeeDTO employeeHour = new HourEmployeeDTO
                    {
                        EmployeeId = employee.Id,
                        Name = employee.Name,
                        ContractTypeName = employee.ContractTypeName,
                        RoleId = employee.RoleId,
                        RoleDescription = employee.RoleDescription,
                        RoleName = employee.RoleName,
                        HourSalary = employee.HourlySalary,
                        MonthSalary = employee.MonthlySalary,
                        AnnualSalary = 0
                    };
                    employeeHourList.Add(employeeHour);                    
                };

                foreach (Employee employee in MonthList)
                {
                    MonthEmployeeDTO employeeMonth = new MonthEmployeeDTO
                    {
                        EmployeeId = employee.Id,
                        Name = employee.Name,
                        ContractTypeName = employee.ContractTypeName,
                        RoleId = employee.RoleId,
                        RoleDescription = employee.RoleDescription,
                        RoleName = employee.RoleName,
                        HourSalary = employee.HourlySalary,
                        MonthSalary = employee.MonthlySalary,
                        AnnualSalary = 0
                    };
                    employeeMonthList.Add(employeeMonth);
                }
                
                employeeHourList.ForEach(e => e.ReturnSalary());
                employeeMonthList.ForEach(e => e.ReturnSalary());

                foreach (var item in employeeHourList)
                {
                    EmployeeSalaryDTO employeeSalaries = new EmployeeSalaryDTO
                    {
                        EmployeeId = item.EmployeeId,
                        Name = item.Name,
                        ContractTypeName = item.ContractTypeName,
                        RoleId = item.RoleId,
                        RoleDescription = item.RoleDescription,
                        RoleName = item.RoleName,
                        AnnualSalary = item.AnnualSalary
                    };
                    EmployeeSalaryAnnual.Add(employeeSalaries);
                }
                
                foreach (var item in employeeMonthList)
                {
                    EmployeeSalaryDTO employeeSalaries = new EmployeeSalaryDTO
                    {
                        EmployeeId = item.EmployeeId,
                        Name = item.Name,
                        ContractTypeName = item.ContractTypeName,
                        RoleId = item.RoleId,
                        RoleDescription = item.RoleDescription,
                        RoleName = item.RoleName,
                        AnnualSalary = item.AnnualSalary
                    };
                    EmployeeSalaryAnnual.Add(employeeSalaries);
                }
                return EmployeeSalaryAnnual;
            }
            catch (Exception ex)
            {
                throw new Exception ($"{ex.Message}");
            }         
        }
        #endregion

        #region [Annual Salary Unique Employees]        
        public async Task<EmployeeSalaryDTO> GetAllEmployeeById(int Id)
        {
            IUnityContainer unityContainer = new UnityContainer();
            unityContainer.RegisterType<IEmployeeAccess, EmployeeAccess>();
            IEmployeeAccess _EmployeeAccess = unityContainer.Resolve<IEmployeeAccess>();
            EmployeeSalaryDTO employeeSalary;
            try
            {
                IEnumerable<Employee> employees = await _EmployeeAccess.GetAllApiEmployee();
                Employee UniqueEmployee = employees.Where(e => e.Id == Id).FirstOrDefault();

                if (UniqueEmployee.ContractTypeName == Constants.ContractHour)
                {
                    HourEmployeeDTO employeeHour = new HourEmployeeDTO
                    {
                        EmployeeId = UniqueEmployee.Id,
                        Name = UniqueEmployee.Name,
                        ContractTypeName = UniqueEmployee.ContractTypeName,
                        RoleId = UniqueEmployee.RoleId,
                        RoleDescription = UniqueEmployee.RoleDescription,
                        RoleName = UniqueEmployee.RoleName,
                        HourSalary = UniqueEmployee.HourlySalary,
                        MonthSalary = UniqueEmployee.MonthlySalary,
                        AnnualSalary = 0
                    };
                    employeeHour.ReturnSalary();
                    
                    employeeSalary = new EmployeeSalaryDTO
                    {
                        EmployeeId = employeeHour.EmployeeId,
                        Name = employeeHour.Name,
                        ContractTypeName = employeeHour.ContractTypeName,
                        RoleId = employeeHour.RoleId,
                        RoleDescription = employeeHour.RoleDescription,
                        RoleName = employeeHour.RoleName,
                        AnnualSalary = employeeHour.AnnualSalary
                    };                    
                }
                else
                {
                    MonthEmployeeDTO employeeMonth = new MonthEmployeeDTO
                    {
                        EmployeeId = UniqueEmployee.Id,
                        Name = UniqueEmployee.Name,
                        ContractTypeName = UniqueEmployee.ContractTypeName,
                        RoleId = UniqueEmployee.RoleId,
                        RoleDescription = UniqueEmployee.RoleDescription,
                        RoleName = UniqueEmployee.RoleName,
                        HourSalary = UniqueEmployee.HourlySalary,
                        MonthSalary = UniqueEmployee.MonthlySalary,
                        AnnualSalary = 0
                    };
                    employeeMonth.ReturnSalary();

                    employeeSalary = new EmployeeSalaryDTO
                    {
                        EmployeeId = employeeMonth.EmployeeId,
                        Name = employeeMonth.Name,
                        ContractTypeName = employeeMonth.ContractTypeName,
                        RoleId = employeeMonth.RoleId,
                        RoleDescription = employeeMonth.RoleDescription,
                        RoleName = employeeMonth.RoleName,
                        AnnualSalary = employeeMonth.AnnualSalary
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }

            return employeeSalary;
        }
        #endregion
    }
}
