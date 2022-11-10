using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Interfaces
{
    public interface IEmployeeDesignationDetail
    {
        ICollection<EmployeeDesignationDetail> GetEmployeeDesignationDetail();
        EmployeeDesignationDetail GetEmployeeDesignationDetail(int serialno);
        bool OwnerExists(int serialno);
        bool CreateEmployeeDesignationDetail(EmployeeDesignationDetail employeeDesignationDetail);
        bool UpdateEmployeeDesignationDetail(EmployeeDesignationDetail employeeDesignationDetail);
        bool DeleteEmployeeDesignationDetail(EmployeeDesignationDetail employeeDesignationDetail);
        bool Save();
    }
}
