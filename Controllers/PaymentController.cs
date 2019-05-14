using System.Linq;
using fans.Models.Payment;
using fans.Service;
using Microsoft.AspNetCore.Mvc;

namespace fans.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IMember _memberService;
        private readonly IPayment _paymentService;

        public PaymentController(IMember memberService, IPayment paymentService)
        {
            _memberService = memberService;
            _paymentService = paymentService;
        }

        public IActionResult Index()
        {
            var payments = _paymentService.GetAll()
                .Select( p => new PaymentViewModel 
                {
                    Id = p.Id,
                    Limit = p.Limit,
                    Amount = p.Amount,
                    PaymentBank = p.PaymentBank,
                    PaymentCustomer = p.PaymentCustomer,
                    PaymentConfirm = p.PaymentConfirm,
                    MemberId = p.MemberId,
                    ClubName = p.Member.Club.Name
                });
            
            var model = new PaymentIndexViewModel
            {
                Payments = payments
            };

            return View(model);
        }
    }
}