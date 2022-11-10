using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Models
{
    public class PaymentRule
    {
        [Key]
        public int Serialno { get; set; }   
        public string Rule { get; set; }    
    }
}
