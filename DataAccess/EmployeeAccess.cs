using Commons;
using DataAccess.Contracts;
using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class EmployeeAccess : IEmployeeAccess
    {
        // Get All Employees Via API
        public async Task<IEnumerable<Employee>> GetAllApiEmployee()
        {
            try
            {
                IEnumerable<Employee> DataResponseConvert;
                var client = new HttpClient();
                HttpResponseMessage DataResponse = await client.GetAsync(Constants.EmployeesApiSourse);
                DataResponse.EnsureSuccessStatusCode();
                string content = await DataResponse.Content.ReadAsStringAsync();
                DataResponseConvert = JsonConvert.DeserializeObject<IEnumerable<Employee>>(content);
                return DataResponseConvert;
            }
            catch (Exception ex)
            {
                throw  new Exception ($"Error Getting API Data: {ex.Message}");                
            }
            
        }
    }
}
