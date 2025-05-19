using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UdesAPP.Dtos;
using UdesAPP.Students;
using Volo.Abp.Application.Services;

namespace UdesAPP.Payments
{
    public interface IPaymentAppService : IApplicationService
    {
        Task<List<PaymentsDto>> GetActivePaymentByStudentId(Guid studentId);
        Task<bool> StartPaymentProcess (StudentDto student);
        Task<PaymentDto> EnterHourBalanceByIdModal(Guid paymentId, decimal hourBalance);
        Task DeletePaymentById(Guid paymentId);
        Task EnrollForStudent(Guid studentId, Guid lessons);
    }
}
