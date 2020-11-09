using BusinessLogic;
using BusinessLogic.Contracts;
using Microsoft.AspNetCore.Cors;
using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace EmployeeWebApi.Controllers
{    
    public class EmployeeController : ApiController
    {
        #region [Initialize]        
        private IEmployeeLogic _IEmployeeLogic;
        public EmployeeController(IEmployeeLogic employeeLogic)
        {
            _IEmployeeLogic = employeeLogic;
        }
        
        readonly IEmployeeLogic employeeLogic = new EmployeeLogic();
        public EmployeeController()
        {
            _IEmployeeLogic = employeeLogic;
        }
        #endregion

        #region [GET - api/Employee/]
        public async Task<IHttpActionResult> GetAllEmployees()
        {
            try
            {
                return Ok(await _IEmployeeLogic.GetAllEmployee());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        #region [GET - api/Employee/{Id}]
        public async Task<IHttpActionResult> GetAllEmployeeById(int Id)
        {
            try
            {
                return Ok(await _IEmployeeLogic.GetAllEmployeeById(Id));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion
    }
}