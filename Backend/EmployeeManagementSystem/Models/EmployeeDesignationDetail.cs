using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Models
{
    public class EmployeeDesignationDetail
    {
        [Key]
        public int Serialno { get; set; }   
        public string  EmployeeId { get; set; } 
        public string DesignationName { get; set; } 
        public string RoleName { get; set; }    
        public string Departmentname { get; set; }  

    }
}
