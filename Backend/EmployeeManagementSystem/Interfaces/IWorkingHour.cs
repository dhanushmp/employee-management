using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Interfaces
{
    public interface IWorkingHour
    {
        ICollection<WorkingHour> GetWorkingHour();
        WorkingHour GetWorkingHour(int serialno);
        bool OwnerExists(int serialno);
        bool CreateWorkingHour(WorkingHour workingHour);
        bool UpdateWorkingHour(WorkingHour workingHour);
        bool DeleteWorkingHour(WorkingHour workingHour);
        bool Save();
    }
}
