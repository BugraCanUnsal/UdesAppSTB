using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdesAPP.Dtos;
using UdesAPP.Payments;
using UdesAPP.Periods;
using UdesAPP.Students;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace UdesAPP.Repositories
{
    public class PaymentsManager : IDomainService
    {
        private readonly IRepository<Payment> _paymentRepository;
        private readonly IRepository<Student> _studentRepository;

        public PaymentsManager(IRepository<Payment> paymentRepository,
            IRepository<Student> studentRepository)
        {
            _paymentRepository = paymentRepository;
            _studentRepository = studentRepository;
        }

        public async Task<List<PaymentsDto>> GetActivePaymentByStudentId(int studentId)
        {
            var _payments = await _paymentRepository.GetListAsync();

            var paymentsDto = _payments.FindAll(x => x.StudentId == studentId && x.IsActive)
                .Select(r => new PaymentsDto()
            {
                Id = r.Id,
                StudentId = r.StudentId,
                StudentName = r.StudentName,
                StudentSurname = r.StudentSurname,
                HourBalance = r.HourBalance,
                FeeBalance = r.FeeBalance,
                IsActive = r.IsActive
            }).ToList();

            return await Task.FromResult(paymentsDto);
        }
      
        public async Task<Payment> InsertActivePaymentProcess(
            int studentId,
            string studentName,
            string studentSurname)
        {
            Payment paymentEntity = new Payment()
            {
                StudentId = studentId,
                StudentName = studentName,
                StudentSurname = studentSurname,
                HourBalance = 0,
                FeeBalance = 0,
                IsActive = true
            };

            var insertedPayment = await _paymentRepository.InsertAsync(paymentEntity);

            return insertedPayment;
        }

        public async Task<Payment> EnterHourBalanceByIdModal(
            int paymentId,
            int? hourBalance)
        {
            List<Payment> payments = await _paymentRepository.GetListAsync();
            List<Student> students = await _studentRepository.GetListAsync();

            Payment payment = payments.Find(x=> x.Id == paymentId);

            if (payment != null && students != null)
            {
                Student student = students.Find(x => x.Id == payment.StudentId);
                payment.HourBalance += hourBalance;
                if (student != null)
                {
                    switch ((int)student.Type)
                    {
                        case 1:
                           payment.FeeBalance += hourBalance * student.GroupLessonFee;
                           break;
                        case 2:
                           payment.FeeBalance += hourBalance * student.IndividualLessonFee;
                           break;
                    }                    
                }                               
            }
            Payment updatedPayment = await _paymentRepository.UpdateAsync(payment);
            return await Task.FromResult(updatedPayment);
        }
        public async Task DeletePaymentById(int paymentId)
        {
            List<Payment> payments = await _paymentRepository.GetListAsync();
            if (payments != null)
            {
                Payment payment = payments.Find(x => x.Id == paymentId);
                await _paymentRepository.DeleteAsync(payment);
            }            
        }
    }
}
