using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace UdesAPP.Payments
{
    public interface IPaymentsCRUDAppService : IApplicationService,
        ICrudAppService<
            PaymentDto,
            int,
            PagedAndSortedResultRequestDto,
            PaymentDto>
    {
    }
}
