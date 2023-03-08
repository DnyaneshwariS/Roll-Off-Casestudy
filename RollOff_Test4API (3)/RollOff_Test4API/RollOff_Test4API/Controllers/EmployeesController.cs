using System;
using System.Collections.Generic;

using System.Threading.Tasks;
using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using RollOff_Test4API.Services;

namespace RollOff_Test4API.Controllers
{
    #region EmployeeController

  
    // [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeService _context;
        private readonly IMapper _mapper;

        public EmployeesController(EmployeeService context,IMapper mapper)//dependency injection
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Employees
        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetDetails()
        {
            var data= await _context.GetAllEmployeeDetails();
            return Ok(_mapper.Map<List<Models.DTO.GetEmployee>>(data));
        }
       [HttpGet]
        [Route("[controller]/{id:int}")]
   //Disolay employees by employeeid
        public async Task<IActionResult> GetEmployeeByID(int id)
        {
            var result=await _context.GetEmployeeByID(id);
            try
            {
                if (result == null)
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Not found");
            }
            return Ok(result);
        }
        //display setails by employeename,email and global id
       [HttpGet]
        [Route("[controller]/{data}")]
        public async Task<IActionResult> GetEmployee([FromRoute] string data)
        {
            //fetch employee
            var result = await _context.GetEmployee(data);
            try
            {
                if (result == null)
                {
                    return NotFound();
                }
            }
            catch
            {
           
                Console.WriteLine("Not found");
            
        }
            var resultDTO = _mapper.Map<List<Models.DTO.GetEmployeeByID>>(result);
            return Ok(resultDTO);
        }

      

    }
    #endregion
}
