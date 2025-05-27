using Blazorise;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UdesAPP.Books;
using UdesAPP.Params;
using Volo.Abp.Application.Dtos;
using Volo.Abp.BlazoriseUI;
using static Microsoft.AspNetCore.Components.Forms.FieldIdentifier;

namespace UdesAPP.Blazor.Pages.Books
{
    public partial class Books
    {
        private List<ParametersDto> BookSeriesDto { get; set; } = new();
        private List<ParametersDto> EduProgramDto { get; set; } = new();
        private Validations validationsRef;
        public bool Loaded { get; set; } = false;
        protected override async Task OnParametersSetAsync()
        {
            var paramDtos = await ParametersAppService.GetParametersByParamType(String.Empty);
            EduProgramDto = paramDtos.FindAll(x => x.Paramtype == "EduPrograms");
            BookSeriesDto = paramDtos.FindAll(x => x.Paramtype == "BookSeries");
            Loaded = true;
            StateHasChanged();
            await base.OnParametersSetAsync();
        }
        private void OnSerieChanged(int? value, BooksDto booksDto)
        {
            if (value == 0)
                booksDto.Serie = null;
            else
                booksDto.Serie = Convert.ToInt32(value);
        }
        private void OnProgramChanged(int? value, BooksDto booksDto)
        {
            if (value == 0)
                booksDto.Program = null;
            else
                booksDto.Program = Convert.ToInt32(value);
        }
    }
}
