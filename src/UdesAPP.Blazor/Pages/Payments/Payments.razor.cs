using Blazorise;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using UdesAPP.Payments;

namespace UdesAPP.Blazor.Pages.Payments
{
    public partial class Payments(NavigationManager navigationManager,
        PaymentAppService paymentAppService,
        PaymentsCRUDAppService paymentsCRUDAppService)
    {
        [Parameter]
        public List<PaymentDto> PaymentDtos { get; set; }
        private Validations EditValidationsRef;
        private PaymentDto paymentDto = new PaymentDto();
        private Modal EnterHourBalanceByIdModal { get; set; }
        private Modal DeletePaymentByIdModal { get; set; }
        private NavigationManager uriHelper = navigationManager;
        private void OpenEnterHourBalanceByIdModal(PaymentDto payment)
        {
            EditValidationsRef.ClearAll();
            paymentDto = payment;
            EnterHourBalanceByIdModal.Show();
        }
        private void CloseEnterHourBalanceByIdModal()
        {
            EnterHourBalanceByIdModal.Hide();
        }
        private async Task EnterHourBalanceById()
        {
            PaymentDto response = await paymentAppService.EnterHourBalanceByIdModal(paymentDto.Id, paymentDto.HourBalance);
            uriHelper.NavigateTo(uriHelper.Uri, forceLoad: true);
            EnterHourBalanceByIdModal.Hide();
        }
        private void OpenDeletePaymentByIdModal(PaymentDto payment)
        {
            EditValidationsRef.ClearAll();
            paymentDto = payment;
            DeletePaymentByIdModal.Show();
        }
        private void CloseDeletePaymentByIdModal()
        {
            DeletePaymentByIdModal.Hide();
        }
        private async Task DeletePaymentById()
        {
            await paymentAppService.DeletePaymentById(paymentDto.Id);
            uriHelper.NavigateTo(uriHelper.Uri, forceLoad: true);
            DeletePaymentByIdModal.Hide();
        }
        protected override async Task OnParametersSetAsync()
        {
            PaymentDtos = await paymentsCRUDAppService.GetAllPaymentsAsync();
            await base.OnParametersSetAsync();
        }
    }
}
