using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Interfaces
{
    public interface IEmployeeDetail
    {
        ICollection<EmployeeDetail> GetEmployeeDetail();
        EmployeeDetail GetEmployeeDetail(int serialno);
        bool OwnerExists(int serialno);
        bool CreateEmployeeDetail(EmployeeDetail employeeDetail);
        bool UpdateEmployeeDetail(EmployeeDetail employeeDetail);
        bool DeleteEmployeeDetail(EmployeeDetail employeeDetail);
        bool Save();
    }
}
