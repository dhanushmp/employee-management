using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Interfaces;
using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Repository
{
    public class WorkingHourRepository:IWorkingHour
    {
        private readonly DataContext _context;

        public WorkingHourRepository(DataContext context)
        {
            _context = context;
        }
        public ICollection<WorkingHour> GetWorkingHour()
        {
            return _context.WorkingHours.ToList();
        }


        public bool CreateWorkingHour(WorkingHour workingHour)
        {
            _context.Add(workingHour);
            return Save();
        }

        public bool DeleteWorkingHour(WorkingHour workingHour)
        {
            _context.Remove(workingHour);
            return Save();
        }

        public WorkingHour GetWorkingHour(int serialno)
        {
            return _context.WorkingHours.Where(o => o.Serialno == serialno).FirstOrDefault();
        }

        public bool OwnerExists(int serialno)
        {
            return _context.WorkingHours.Any(o => o.Serialno == serialno);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateWorkingHour(WorkingHour workingHour)
        {
            _context.Update(workingHour);
            return Save();
        }
    }
}
