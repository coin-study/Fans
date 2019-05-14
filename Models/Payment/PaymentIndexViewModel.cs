using System.Collections.Generic;

namespace fans.Models.Payment
{
    public class PaymentIndexViewModel
    {
        public IEnumerable<PaymentViewModel> Payments { get; set; }
        
    }
}