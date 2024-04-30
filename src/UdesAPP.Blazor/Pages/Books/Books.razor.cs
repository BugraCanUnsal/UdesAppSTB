using Blazorise;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UdesAPP.Params;

namespace UdesAPP.Blazor.Pages.Books
{
    public partial class Books(NavigationManager navigationManager,
        ParametersAppService parametersAppService)
    {
        private Validations EditValidationsRef;
        [Parameter]
        public List<ParametersDto> BookSeriesDto { get; set; }
        [Parameter]
        public List<ParametersDto> EduProgramDto { get; set; }
        public bool Loaded { get; set; } = false;
        private Modal EnterHourBalanceByIdModal { get; set; }
        private Modal DeletePaymentByIdModal { get; set; }
        private NavigationManager uriHelper = navigationManager;
        protected override async Task OnParametersSetAsync()
        {
            var paramDtos = await parametersAppService.GetParametersByParamType(String.Empty);
            EduProgramDto = paramDtos.FindAll(x => x.Paramtype == "EduPrograms");
            BookSeriesDto = paramDtos.FindAll(x => x.Paramtype == "BookSeries");
            Loaded = true;
            await base.OnParametersSetAsync();
        }

    }
}
