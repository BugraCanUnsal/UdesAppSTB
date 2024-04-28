﻿using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using System.Threading.Tasks;
using UdesAPP.Classes;
using UdesAPP.Dtos;
using UdesAPP.Payments;
using UdesAPP.Students;

namespace UdesAPP.Blazor.Pages.Students
{
    public partial class Students(
        PaymentAppService paymentAppService,
        StudentAppService studentAppService,
        AllClassesAppService allClassesAppService)
    {
        [Parameter]
        public List<AllClassesDto>? AllClassesDtos { get; set; }
        public bool Loaded { get; set; } = false;
        public async Task StartPaymentProcess(StudentDto context)
        {
            PaymentDto isInserted = await paymentAppService.StartPaymentProcess(context);
            if (isInserted != null)
            {
                //DÖNEN DEĞER TRUE İSE KAYIT EDİLDİ
            }
            else {
                //FALSE İSE INFO MESAJI
            }             
        }
        protected override async Task OnParametersSetAsync()
        {
            AllClassesDtos = await allClassesAppService.GetAllClassesAsync();
            Loaded = true;
            await base.OnParametersSetAsync();
        }
    }
}