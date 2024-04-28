using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace UdesAPP.Payments
{
    public class PaymentsCRUIDAppService :
        CrudAppService<
            Payment,
            PaymentDto,
            int,
            PagedAndSortedResultRequestDto,
            PaymentDto>,
        IPaymentsCRUIDAppService
    {
        public PaymentsCRUIDAppService(IRepository<Payment, int> repository) 
            : base(repository)
        {
        }
    }
}
