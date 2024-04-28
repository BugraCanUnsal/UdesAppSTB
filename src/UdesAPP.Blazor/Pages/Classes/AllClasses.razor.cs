using Blazorise;
using Blazorise.DataGrid;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UdesAPP.Classes;
using UdesAPP.Dtos;
using UdesAPP.Periods;
using static Microsoft.AspNetCore.Components.NavigationManager;

namespace UdesAPP.Blazor.Pages.Classes
{
    public partial class AllClasses(
        StudentsOfClassesAppService studentsOfClassesAppService,
        PeriodsAppService periodsAppService,
        NavigationManager navigationManager)
    {
        [Parameter]
        public List<PeriodDto>? PeriodDtos { get; set; }
        public bool Loaded { get; set; } = false;
        private List<StudentsOfClassDto> StudentsOfClass {  get; set; }
        private StudentsOfClassesAppService _studentsOfClassesAppService = studentsOfClassesAppService;
        private PeriodsAppService _periodsAppService = periodsAppService;
        private Validations EditValidationsRef;
        private StudentsOfClassDto DeletingFromClassStudent = new StudentsOfClassDto();
        private Modal DeleteStudentFromClassModal { get; set; }
        private NavigationManager uriHelper = navigationManager;

        public async Task ClassIsClicked(DataGridRowMouseEventArgs<AllClassesDto> clickedClass)
        {
            StudentsOfClass = await _studentsOfClassesAppService.GetStudentsByClassId(clickedClass.Item.Id);
        }
        protected override async Task OnParametersSetAsync()
        {
            PeriodDtos = await _periodsAppService.GetAllPeriods();
            Loaded = true;
            await base.OnParametersSetAsync();
        }
        private void OpenDeleteFromClassModal(StudentsOfClassDto student)
        {
            EditValidationsRef.ClearAll();
            DeletingFromClassStudent = student;
            DeleteStudentFromClassModal.Show();
        }
        private void CloseDeleteStudentFromClassModal()
        {
            DeleteStudentFromClassModal.Hide();
        }
        private async Task DeleteStudentFromClassAsync()
        {
            bool response = await _studentsOfClassesAppService.DeleteStudentFromClass(DeletingFromClassStudent);
            uriHelper.NavigateTo(uriHelper.Uri, forceLoad: true);
            DeleteStudentFromClassModal.Hide();
        }



    }
}
