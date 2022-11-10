using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Models
{
    public class EmployeeDetail
    {
        [Key]
        public int Serialno { get; set; }
        public string EmployeeId { get; set; } 
        public string EmployeeName { get; set; }
        public Int64 Phoneno { get; set; }
        public string? MailId { get; set; }
        public string Address { get; set; } 
    }
}
