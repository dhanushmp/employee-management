using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Interfaces
{
    public interface IPaymentRule
    {
        ICollection<PaymentRule> GetPaymentRule();
        PaymentRule GetPaymentRule(int serialno);
        bool OwnerExists(int serialno);
        bool CreatePaymentRule(PaymentRule paymentRule);
        bool UpdatePaymentRule(PaymentRule paymentRule);
        bool DeletePaymentRule(PaymentRule paymentRule);
        bool Save();
    }
}
