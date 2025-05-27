using Microsoft.AspNetCore.Authorization;
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
    [Authorize("UdesAPP.HostPermission")]
    public class PaymentsCRUDAppService :
        CrudAppService<
            Payment,
            PaymentDto,
            Guid,
            PagedAndSortedResultRequestDto,
            PaymentDto>,
        IPaymentsCRUDAppService
    {
        public PaymentsCRUDAppService(IRepository<Payment, Guid> repository) 
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
