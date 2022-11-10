using AutoMapper;
using EmployeeManagementSystem.Dto;
using EmployeeManagementSystem.Interfaces;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeDetailController : ControllerBase
    { 
   private readonly IEmployeeDetail _employeeDetailRepository;
        private readonly IMapper _mapper;

    public EmployeeDetailController(IEmployeeDetail employeeDetailRepository,
      
        IMapper mapper)
    {
            _employeeDetailRepository = employeeDetailRepository;
      
        _mapper = mapper;
    }


        ////[HttpGet, Authorize(Roles = "Manager")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<EmployeeDetail>))]
        public IActionResult GetEmployeeDetail()
        {
            try
            {
                var owners = _mapper.Map<List<EmployeeDetailDto>>(_employeeDetailRepository.GetEmployeeDetail());

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                return Ok(owners);
            }
            catch
            {
                return BadRequest("error");
            }
        }

        [HttpGet("{serialno}")]
    [ProducesResponseType(200, Type = typeof(EmployeeDetail))]
    [ProducesResponseType(400)]

    public IActionResult GetEmployeeDetail(int serialno)
    {
            try
            {
                if (!_employeeDetailRepository.OwnerExists(serialno))
                    return NotFound();

                var employee = _mapper.Map<EmployeeDetailDto>(_employeeDetailRepository.GetEmployeeDetail(serialno));

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
    public IActionResult CreateCustomer( [FromBody] EmployeeDetailDto employeeCreate)
    {
            try
            {
                if (employeeCreate == null)
                    return BadRequest(ModelState);

                var employee = _employeeDetailRepository.GetEmployeeDetail()
                    .Where(c => c.EmployeeName.Trim().ToUpper() == employeeCreate.EmployeeName.TrimEnd().ToUpper())
                    .FirstOrDefault();

                //if ( != null)
                //{
                //    ModelState.AddModelError("", "Owner already exists");
                //    return StatusCode(422, ModelState);
                //}

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var ownerMap = _mapper.Map<EmployeeDetail>(employeeCreate);



                if (!_employeeDetailRepository.CreateEmployeeDetail(ownerMap))
                {
                    ModelState.AddModelError("", "Something went wrong while savin");
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
    public IActionResult UpdateEmployeeDetail(int serialno, [FromBody] EmployeeDetailDto updatedemployeeDetail)
    {
            try
            {
                if (updatedemployeeDetail == null)
                    return BadRequest(ModelState);

                if (serialno != updatedemployeeDetail.Serialno)
                    return BadRequest(ModelState);

                if (!_employeeDetailRepository.OwnerExists(serialno))
                    return NotFound();

                if (!ModelState.IsValid)
                    return BadRequest();

                var ownerMap = _mapper.Map<EmployeeDetail>(updatedemployeeDetail);

                if (!_employeeDetailRepository.UpdateEmployeeDetail(ownerMap))
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
    public IActionResult DeleteEmployeeDetail(int serialno)
    {
            try
            {
                if (!_employeeDetailRepository.OwnerExists(serialno))
                {
                    return NotFound();
                }

                var ownerToDelete = _employeeDetailRepository.GetEmployeeDetail(serialno);

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (!_employeeDetailRepository.DeleteEmployeeDetail(ownerToDelete))
                {
                    ModelState.AddModelError("", "Something went wrong deleting owner");
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
