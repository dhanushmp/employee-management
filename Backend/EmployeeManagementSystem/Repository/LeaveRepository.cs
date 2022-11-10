using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Interfaces;
using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Repository
{
    public class LeaveRepository:ILeave
    {
        private readonly DataContext _context;

        public LeaveRepository(DataContext context)
        {
            _context = context;
        }
        public ICollection<Leave> GetLeave()
        {
            return _context.Leaves.ToList();
        }


        public bool CreateLeave(Leave leave)
        {
            _context.Add(leave);
            return Save();
        }

        public bool DeleteLeave(Leave leave)
        {
            _context.Remove(leave);
            return Save();
        }

        public Leave GetLeave(int serialno)
        {
            return _context.Leaves.Where(o => o.Serialno == serialno).FirstOrDefault();
        }






        public bool OwnerExists(int serialno)
        {
            return _context.Leaves.Any(o => o.Serialno == serialno);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateLeave(Leave leave)
        {
            _context.Update(leave);
            return Save();
        }
    }
}
