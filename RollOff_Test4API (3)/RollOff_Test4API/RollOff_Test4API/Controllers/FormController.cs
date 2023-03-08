using AutoMapper;

using Microsoft.AspNetCore.Mvc;
using RollOff_Test4API.Models.Domain;
using RollOff_Test4API.Models.DTO;
using RollOff_Test4API.Repository;

using System.Collections.Generic;

using System.Threading.Tasks;

namespace RollOff_Test4API.Controllers
{
    #region FededbackformContoller

   
    [Route("api/[controller]")]
    [ApiController]
    public class FormController : ControllerBase
    {
        private readonly Ifeedbackform formRepository;
        private readonly IMapper mapper;

        public FormController(Ifeedbackform formRepository, IMapper mapper)//dependency injection
        {
            this.formRepository = formRepository;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployeeForm(feedbackformdto formTable)//adding feedback of employee
        {
            //DTO to Model
            var employeeForm = mapper.Map<feedbackform>(formTable);

            //Pass Detail to Repository
            var response = await formRepository.AddFormAsync(employeeForm);

            //Convert back to DTO
            var formTableDTO = mapper.Map<feedbackformdto>(response);

            return Ok(formTableDTO);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployeesForms()//get the details of the employee
        {
            var formDetails = await formRepository.GetAllFormsAsync();

            //return DTO

            var formDetailsDTO = mapper.Map<List<feedbackformdto>>(formDetails);

            return Ok(formDetailsDTO);
        }

        [HttpDelete]
        [Route("{ggid}")]
        public async Task<IActionResult> DeleteEmployeeForm(double ggid)//delete details of the employee
        {
            var employee = await formRepository.DeleteFormAsync(ggid);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPut]
        [Route("{ggid}")]
        public async Task<IActionResult> UpdateEmployeeForm(double ggid, feedbackformdto updateFormDTO)//update details of employee
        {
            var employee = mapper.Map<feedbackform>(updateFormDTO);
            var emp = await formRepository.UdateFormAsync(ggid, employee);
            if (emp == null)
            {
                return NotFound();
            }
            var empDTO = mapper.Map<feedbackformdto>(emp);
            return Ok(empDTO);

        }
    }
    #endregion
}
