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
        Task<List<PaymentsDto>> GetActivePaymentByStudentId(int studentId);
        Task<bool> StartPaymentProcess (StudentDto student);
        Task<PaymentDto> EnterHourBalanceByIdModal(int paymentId, int? hourBalance);
        Task DeletePaymentById(int paymentId);
        Task EnrollForStudent(int studentId, int lessons);
    }
}
