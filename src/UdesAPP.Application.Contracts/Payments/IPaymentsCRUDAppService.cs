using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace UdesAPP.Payments
{
    public interface IPaymentsCRUDAppService : IApplicationService,
        ICrudAppService<
            PaymentDto,
            Guid,
            PagedAndSortedResultRequestDto,
            PaymentDto>
    {
        Task<List<PaymentDto>> GetAllPaymentsAsync();
    }
}
