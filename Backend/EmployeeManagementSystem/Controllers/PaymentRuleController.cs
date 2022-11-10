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
    public class PaymentRuleController : ControllerBase
    {
        private readonly IPaymentRule _paymentRuleRepository;
        private readonly IMapper _mapper;

        public PaymentRuleController(IPaymentRule paymentRuleRepository,

            IMapper mapper)
        {
            _paymentRuleRepository = paymentRuleRepository;

            _mapper = mapper;
        }


        ////[HttpGet, Authorize(Roles = "admin")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<PaymentRule>))]
        public IActionResult GetPaymentRule()
        {
            try
            {
                var owners = _mapper.Map<List<PaymentRuleDto>>(_paymentRuleRepository.GetPaymentRule());

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
        [ProducesResponseType(200, Type = typeof(PaymentRule))]
        [ProducesResponseType(400)]

        public IActionResult GetPaymentRule(int serialno)
        {
            try
            {
                if (!_paymentRuleRepository.OwnerExists(serialno))
                    return NotFound();

                var employee = _mapper.Map<PaymentRuleDto>(_paymentRuleRepository.GetPaymentRule(serialno));

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
        public IActionResult CreatePaymentRule([FromBody] PaymentRuleDto ruleCreate)
        {
            try
            {
                if (ruleCreate == null)
                    return BadRequest(ModelState);

                var employee = _paymentRuleRepository.GetPaymentRule()
                    //.Where(c => c.EmployeeName.Trim().ToUpper() == employeeCreate.EmployeeName.TrimEnd().ToUpper())
                    .FirstOrDefault();

                //if ( != null)
                //{
                //    ModelState.AddModelError("", "Owner already exists");
                //    return StatusCode(422, ModelState);
                //}

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var ownerMap = _mapper.Map<PaymentRule>(ruleCreate);



                if (!_paymentRuleRepository.CreatePaymentRule(ownerMap))
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
        public IActionResult UpdatePaymentRule(int serialno, [FromBody] PaymentRuleDto updatedpaymentRule)
        {
            try
            {
                if (updatedpaymentRule == null)
                    return BadRequest(ModelState);

                if (serialno != updatedpaymentRule.Serialno)
                    return BadRequest(ModelState);

                if (!_paymentRuleRepository.OwnerExists(serialno))
                    return NotFound();

                if (!ModelState.IsValid)
                    return BadRequest();

                var ownerMap = _mapper.Map<PaymentRule>(updatedpaymentRule);

                if (!_paymentRuleRepository.UpdatePaymentRule(ownerMap))
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
        public IActionResult DeletePaymentRule(int serialno)
        {
            try
            {
                if (!_paymentRuleRepository.OwnerExists(serialno))
                {
                    return NotFound();
                }

                var ownerToDelete = _paymentRuleRepository.GetPaymentRule(serialno);

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (!_paymentRuleRepository.DeletePaymentRule(ownerToDelete))
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
