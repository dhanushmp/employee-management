using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Models
{
    public class WorkingHour
    {
        [Key]
        public int Serialno { get; set; }   
        public String EmployeeId { get; set; }  
        public Int32 ComworkingHour { get; set; }   
        public Int32 EmpworkingHour { get; set; }   

    }
}
