
using RollOff_Test4API.Models.Domain;
using RollOff_Test4API.Repository;

using System.Collections.Generic;

using System.Threading.Tasks;

namespace RollOff_Test4API.Services
{
    #region EmployeeService

  
    public class EmployeeService
    {
        private IEmployeeDetails _EmpDetailsRepositoty;

        public EmployeeService(IEmployeeDetails EmpDetails)
        {
            _EmpDetailsRepositoty = EmpDetails;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeeDetails()
        {
            return await _EmpDetailsRepositoty.GetAllEmployeeDetails();
        }
        public async Task<Employee> GetEmployeeByID(int ID)
        {
            return await _EmpDetailsRepositoty.GetEmployeeByID(ID);
        }
        public async Task<IEnumerable<Employee>> GetEmployee(string data)
        {
            
            return await _EmpDetailsRepositoty.GetEmployee(data);
        }
    }
    #endregion
}
