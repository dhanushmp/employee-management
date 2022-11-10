using AutoMapper;
using EmployeeManagementSystem.Dto;
using EmployeeManagementSystem.Interfaces;
using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeDesignationDetailController : ControllerBase
    {
        private readonly IEmployeeDesignationDetail _employeeDesignationDetailRepository;
        private readonly IMapper _mapper;

        public EmployeeDesignationDetailController(IEmployeeDesignationDetail employeeDesignationDetailRepository,

            IMapper mapper)
        {
            _employeeDesignationDetailRepository = employeeDesignationDetailRepository;

            _mapper = mapper;
        }


        ////[HttpGet, Authorize(Roles = "Manager")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<EmployeeDesignationDetail>))]
        public IActionResult GetEmployeeDesignationDetail()
        {
            try
            {
                var owners = _mapper.Map<List<EmployeeDesignationDetailDto>>(_employeeDesignationDetailRepository.GetEmployeeDesignationDetail());

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                return Ok(owners);
            }
            catch 
            {
                return BadRequest("error in get method");
            }
        }

        [HttpGet("{serialno}")]
        [ProducesResponseType(200, Type = typeof(EmployeeDesignationDetail))]
        [ProducesResponseType(400)]

        public IActionResult GetEmployeeDesignationDetail(int serialno)
        {
            try
            {
                if (!_employeeDesignationDetailRepository.OwnerExists(serialno))
                    return NotFound();

                var employee = _mapper.Map<EmployeeDesignationDetailDto>(_employeeDesignationDetailRepository.GetEmployeeDesignationDetail(serialno));

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                return Ok(employee);
            }
            catch
            {
                return BadRequest("error");
            }
        }



        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateEmployeeDesignationDetail([FromBody] EmployeeDesignationDetailDto employeeCreate)
        {
            try
            {
                if (employeeCreate == null)
                    return BadRequest(ModelState);

                var employee = _employeeDesignationDetailRepository.GetEmployeeDesignationDetail()
                    .Where(c => c.EmployeeId == employeeCreate.EmployeeId)
                    .FirstOrDefault();

                if (employee != null)
                {
                    ModelState.AddModelError("", "employee already exists");
                    return StatusCode(422, ModelState);
                }

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var employeeMap = _mapper.Map<EmployeeDesignationDetail>(employeeCreate);



                if (!_employeeDesignationDetailRepository.CreateEmployeeDesignationDetail(employeeMap))
                {
                    ModelState.AddModelError("", "Something went wrong while saving");
                    return StatusCode(500, ModelState);
                }

                return Ok("Successfully created");
            }
            catch
            {
                return BadRequest("error");
            }
        }

        [HttpPut("{serialno}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateEmployeeDesignationDetail(int serialno, [FromBody] EmployeeDesignationDetailDto updatedemployeeDetail)
        {
            try
            {
                if (updatedemployeeDetail == null)
                    return BadRequest(ModelState);

                if (serialno != updatedemployeeDetail.Serialno)
                    return BadRequest(ModelState);

                if (!_employeeDesignationDetailRepository.OwnerExists(serialno))
                    return NotFound();

                if (!ModelState.IsValid)
                    return BadRequest();

                var DesignationMap = _mapper.Map<EmployeeDesignationDetail>(updatedemployeeDetail);

                if (!_employeeDesignationDetailRepository.UpdateEmployeeDesignationDetail(DesignationMap))
                {
                    ModelState.AddModelError("", "Something went wrong updating owner");
                    return StatusCode(500, ModelState);
                }

                return NoContent();
            }
            catch
            {
                return BadRequest("error");
            }
        }

        [HttpDelete("{serialno}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteEmployeeDesignationDetail(int serialno)
        {
            try
            {
                if (!_employeeDesignationDetailRepository.OwnerExists(serialno))
                {
                    return NotFound();
                }

                var DesignationToDelete = _employeeDesignationDetailRepository.GetEmployeeDesignationDetail(serialno);

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (!_employeeDesignationDetailRepository.DeleteEmployeeDesignationDetail(DesignationToDelete))
                {
                    ModelState.AddModelError("", "Something went wrong deleting Designation");
                }

                return NoContent();
            }
            catch
            {
                return BadRequest("error");
            }
        }
    }
}
