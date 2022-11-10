using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Interfaces;
using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Repository
{
    public class EmployeeDetailRepository: IEmployeeDetail
    {
        private readonly DataContext _context;

        public EmployeeDetailRepository(DataContext context)
        {
            _context = context;
        }
        public ICollection<EmployeeDetail> GetEmployeeDetail()
        {
            return _context.EmployeeDetails.ToList();
        }


        public bool CreateEmployeeDetail(EmployeeDetail employeeDetail)
        {
            _context.Add(employeeDetail);
            return Save();
        }

        public bool DeleteEmployeeDetail(EmployeeDetail employeeDetail)
        {
            _context.Remove(employeeDetail);
            return Save();
        }

        public EmployeeDetail GetEmployeeDetail(int serialno)
        {
            return _context.EmployeeDetails.Where(o => o.Serialno == serialno).FirstOrDefault();
        }

       

      
       

        public bool OwnerExists(int serialno)
        {
            return _context.EmployeeDetails.Any(o => o.Serialno ==serialno );
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateEmployeeDetail(EmployeeDetail employeeDetail)
        {
            _context.Update(employeeDetail);
            return Save();
        }
    }
}
