using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace UdesAPP.Payments
{
    public interface IPaymentsCRUIDAppService : IApplicationService,
        ICrudAppService<
            PaymentDto,
            int,
            PagedAndSortedResultRequestDto,
            PaymentDto>
    {
    }
}
