using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Interfaces;
using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Repository
{
    public class EmployeeDesignationDetailRepository : IEmployeeDesignationDetail
    {
        private readonly DataContext _context;

        public EmployeeDesignationDetailRepository(DataContext context)
        {
            _context = context;
        }
        public ICollection<EmployeeDesignationDetail> GetEmployeeDesignationDetail()
        {
            
            return _context.EmployeeDesignationDetails.ToList();
        }


        public bool CreateEmployeeDesignationDetail(EmployeeDesignationDetail employeeDetail)
        {
            _context.Add(employeeDetail);
            return Save();
        }

        public bool DeleteEmployeeDesignationDetail(EmployeeDesignationDetail employeeDesignationDetail)
        {
            _context.Remove(employeeDesignationDetail);
            return Save();
        }

        public EmployeeDesignationDetail GetEmployeeDesignationDetail(int serialno)
        {
            return _context.EmployeeDesignationDetails.Where(o => o.Serialno == serialno).FirstOrDefault();
        }

        public bool OwnerExists(int serialno)
        {
            return _context.EmployeeDesignationDetails.Any(o => o.Serialno == serialno);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateEmployeeDesignationDetail(EmployeeDesignationDetail employeeDesignationDetail)
        {
            _context.Update(employeeDesignationDetail);
            return Save();
        }
    }
}
