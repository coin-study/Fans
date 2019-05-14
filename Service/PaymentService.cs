using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fans.Data;
using fans.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace fans.Service
{
    public class PaymentService : IPayment
    {
        private readonly ApplicationDbContext _context;

        public PaymentService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Create(Payment payment)
        {
            _context.Add(payment);
            await _context.SaveChangesAsync();
        }

        public Task Delete(int paymentId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Payment> GetAll()
        {
            return _context.Payments
                .Include( payment => payment.Member)
                    .ThenInclude( member => member.Club);
        }

        public Payment GetById(int paymentId)
        {
            return _context.Payments.Where( payment => payment.Id == paymentId)
                .Include( payment => payment.Member)
                .FirstOrDefault();
        }
        public int GetPaymentIdByMemberId(int memberId)
        {
            var pm = _context.Payments.Where( payment => payment.MemberId == memberId)
                        .FirstOrDefault();
            
            if (pm == null) 
            {
                return 0;
            }
            else
            {
                return pm.Id;
            }
        }

        public async Task MarkAsNotPaid(int id)
        {
            var payment = GetById(id);

            payment.Paid = false;

            _context.Update(payment);
            await _context.SaveChangesAsync();
        }

        public async Task MarkAsPaid(int id)
        {
            var payment = GetById(id);

            payment.Paid = true;
            
            _context.Update(payment);
            await _context.SaveChangesAsync();
        }

        public async Task Update(int id, Payment payment)
        {
            var paymentToUpdate = GetById(id);

            paymentToUpdate.Limit = payment.Limit;
            paymentToUpdate.Amount = payment.Amount;
            paymentToUpdate.PaymentBank = payment.PaymentBank;
            paymentToUpdate.PaymentCustomer = payment.PaymentCustomer;
            paymentToUpdate.PaymentConfirm = payment.PaymentConfirm;
            paymentToUpdate.Paid = payment.Paid;

            _context.Update(paymentToUpdate);
            await _context.SaveChangesAsync();
        }
    }
}