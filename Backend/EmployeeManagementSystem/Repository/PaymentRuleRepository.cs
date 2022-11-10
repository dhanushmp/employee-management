using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Interfaces;
using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Repository
{
    public class PaymentRuleRepository:IPaymentRule
    {
        private readonly DataContext _context;

        public PaymentRuleRepository(DataContext context)
        {
            _context = context;
        }
        public ICollection<PaymentRule> GetPaymentRule()
        {
            return _context.PaymentRules.ToList();
        }


        public bool CreatePaymentRule(PaymentRule paymentRule)
        {
            _context.Add(paymentRule);
            return Save();
        }

        public bool DeletePaymentRule(PaymentRule paymentRule)
        {
            _context.Remove(paymentRule);
            return Save();
        }

        public PaymentRule GetPaymentRule(int serialno)
        {
            return _context.PaymentRules.Where(o => o.Serialno == serialno).FirstOrDefault();
        }






        public bool OwnerExists(int serialno)
        {
            return _context.PaymentRules.Any(o => o.Serialno == serialno);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdatePaymentRule(PaymentRule paymentRule)
        {
            _context.Update(paymentRule);
            return Save();
        }
    }
}
