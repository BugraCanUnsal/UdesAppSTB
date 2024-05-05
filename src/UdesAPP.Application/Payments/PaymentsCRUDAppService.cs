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
    public class PaymentsCRUDAppService :
        CrudAppService<
            Payment,
            PaymentDto,
            int,
            PagedAndSortedResultRequestDto,
            PaymentDto>,
        IPaymentsCRUDAppService
    {
        public PaymentsCRUDAppService(IRepository<Payment, int> repository) 
            : base(repository)
        {
        }
        public async Task<List<PaymentDto>> GetAllPaymentsAsync()
        {
            List<Payment> payments = await Repository.GetListAsync();
            return ObjectMapper.Map<List<Payment>, List<PaymentDto>>(payments);
        }
    }
}
