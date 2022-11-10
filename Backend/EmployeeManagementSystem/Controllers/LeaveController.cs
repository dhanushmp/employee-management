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
    public class LeaveController : ControllerBase
    {
        private readonly ILeave _leaveRepository;
        private readonly IMapper _mapper;

        public LeaveController(ILeave leaveRepository,

            IMapper mapper)
        {
            _leaveRepository = leaveRepository;

            _mapper = mapper;
        }


        ////[HttpGet, Authorize(Roles = "Manager")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Leave>))]
        public IActionResult GetLeave()
        {
            try
            {
                var owners = _mapper.Map<List<LeaveDto>>(_leaveRepository.GetLeave());

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
        [ProducesResponseType(200, Type = typeof(Leave))]
        [ProducesResponseType(400)]

        public IActionResult GetLeave(int serialno)
        {
            try
            {
                if (!_leaveRepository.OwnerExists(serialno))
                    return NotFound();

                var employee = _mapper.Map<LeaveDto>(_leaveRepository.GetLeave(serialno));

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
        public IActionResult CreateLeave([FromBody] LeaveDto leaveCreate)
        {
            try
            {
                if (leaveCreate == null)
                    return BadRequest(ModelState);

                var employee = _leaveRepository.GetLeave()
                    .Where(c => c.EmployeeId == leaveCreate.EmployeeId)
                    .FirstOrDefault();

                if (employee != null)
                {
                    ModelState.AddModelError("", "Owner already exists");
                    return StatusCode(422, ModelState);
                }

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var ownerMap = _mapper.Map<Leave>(leaveCreate);



                if (!_leaveRepository.CreateLeave(ownerMap))
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
        public IActionResult UpdateLeave(int serialno, [FromBody] LeaveDto updatedLeave)
        {
            try
            {
                if (updatedLeave == null)
                    return BadRequest(ModelState);

                if (serialno != updatedLeave.Serialno)
                    return BadRequest(ModelState);

                if (!_leaveRepository.OwnerExists(serialno))
                    return NotFound();

                if (!ModelState.IsValid)
                    return BadRequest();

                var ownerMap = _mapper.Map<Leave>(updatedLeave);

                if (!_leaveRepository.UpdateLeave(ownerMap))
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
        public IActionResult DeleteLeave(int serialno)
        {
            try
            {
                if (!_leaveRepository.OwnerExists(serialno))
                {
                    return NotFound();
                }

                var leaveToDelete = _leaveRepository.GetLeave(serialno);

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (!_leaveRepository.DeleteLeave(leaveToDelete))
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
