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
    public class WorkingHourController : ControllerBase
    {
        private readonly IWorkingHour _workingHourRepository;
        private readonly IMapper _mapper;

        public WorkingHourController(IWorkingHour workingHourRepository,

            IMapper mapper)
        {
            _workingHourRepository = workingHourRepository;

            _mapper = mapper;
        }


        ////[HttpGet, Authorize(Roles = "Manager")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<WorkingHour>))]
        public IActionResult GetWorkingHour()
        {
            try
            {
                var owners = _mapper.Map<List<WorkingHourDto>>(_workingHourRepository.GetWorkingHour());

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
        [ProducesResponseType(200, Type = typeof(WorkingHour))]
        [ProducesResponseType(400)]

        public IActionResult GetWorkingHour(int serialno)
        {
            try
            {
                if (!_workingHourRepository.OwnerExists(serialno))
                    return NotFound();

                var employee = _mapper.Map<WorkingHourDto>(_workingHourRepository.GetWorkingHour(serialno));

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
        public IActionResult CreateWorkingHour([FromBody] WorkingHourDto hourCreate)
        {
            try
            {
                if (hourCreate == null)
                    return BadRequest(ModelState);

                var workhour = _workingHourRepository.GetWorkingHour()
                    // .Where(c => c.EmployeeName.Trim().ToUpper() == employeeCreate.EmployeeName.TrimEnd().ToUpper())
                    .FirstOrDefault();

                //if ( != null)
                //{
                //    ModelState.AddModelError("", "Owner already exists");
                //    return StatusCode(422, ModelState);
                //}

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var workingHourMap = _mapper.Map<WorkingHour>(hourCreate);



                if (!_workingHourRepository.CreateWorkingHour(workingHourMap))
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
        public IActionResult UpdateWorkingHour(int serialno, [FromBody] WorkingHourDto updatedworkingHour)
        {
            try
            {
                if (updatedworkingHour == null)
                    return BadRequest(ModelState);

                if (serialno != updatedworkingHour.Serialno)
                    return BadRequest(ModelState);

                if (!_workingHourRepository.OwnerExists(serialno))
                    return NotFound();

                if (!ModelState.IsValid)
                    return BadRequest();

                var workingHourMap = _mapper.Map<WorkingHour>(updatedworkingHour);

                if (!_workingHourRepository.UpdateWorkingHour(workingHourMap))
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
        public IActionResult DeleteWorkingHour(int serialno)
        {
            try
            {
                if (!_workingHourRepository.OwnerExists(serialno))
                {
                    return NotFound();
                }

                var workingHourToDelete = _workingHourRepository.GetWorkingHour(serialno);

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (!_workingHourRepository.DeleteWorkingHour(workingHourToDelete))
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
