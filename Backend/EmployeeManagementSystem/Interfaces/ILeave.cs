using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Interfaces
{
    public interface ILeave
    {
        ICollection<Leave> GetLeave();
        Leave GetLeave(int serialno);
        bool OwnerExists(int serialno);
        bool CreateLeave(Leave leave);
        bool UpdateLeave(Leave leave);
        bool DeleteLeave(Leave leave);
        bool Save();
    }
}
