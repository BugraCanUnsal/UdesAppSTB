using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdesAPP.Dtos;
using UdesAPP.Repositories;
using UdesAPP.Students;
using Volo.Abp.Application.Services;

namespace UdesAPP.Payments
{
    [Authorize("UdesAPP.HostPermission")]
    public class PaymentAppService : ApplicationService, IPaymentAppService
    {
        private readonly PaymentsManager _paymentsManager;

        public PaymentAppService(PaymentsManager paymentsManager)
        {
            _paymentsManager = paymentsManager;
        }

        public async Task DeletePaymentById(Guid paymentId)
        {
            await _paymentsManager.DeletePaymentById(paymentId);
        }

        public Task EnrollForStudent(Guid studentId, Guid lessons)
        {
            throw new NotImplementedException();
        }

        public async Task<PaymentDto> EnterHourBalanceByIdModal(Guid paymentId, decimal hourBalance)
        {
            Payment payment = await _paymentsManager.EnterHourBalanceByIdModal(paymentId, hourBalance);
            return ObjectMapper.Map<Payment, PaymentDto>(payment);
        }

        public async Task<List<PaymentsDto>> GetActivePaymentByStudentId(Guid studentId)
        {
            return await _paymentsManager.GetActivePaymentByStudentId(studentId);
        }
        public async Task<bool> StartPaymentProcess(StudentDto studentDto)
        {
            List<PaymentsDto> hasActivePaymentProcess = await GetActivePaymentByStudentId(studentDto.Id);

            if (hasActivePaymentProcess.Count != 0)
            {
                return false;
            }
            
            Payment newPayment = await _paymentsManager.InsertActivePaymentProcess(studentDto.Id,
                studentDto.Name,
                studentDto.Surname
                );
            
            return true;
        }
    }
}
