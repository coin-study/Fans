using System.Collections.Generic;
using System.Threading.Tasks;
using fans.EntityModels;

namespace fans.Service
{
    public interface IPayment
    {
        Payment GetById(int paymentId);
        int GetPaymentIdByMemberId(int memberId);
        IEnumerable<Payment> GetAll();

        Task Create(Payment payment);
        Task Update(int id, Payment payment);
        Task Delete(int paymentId);
        Task MarkAsPaid(int id);
        Task MarkAsNotPaid(int id);

    }
}