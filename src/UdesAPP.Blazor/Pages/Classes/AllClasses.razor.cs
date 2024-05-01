using Blazorise;
using Blazorise.DataGrid;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UdesAPP.Books;
using UdesAPP.Classes;
using UdesAPP.Dtos;
using UdesAPP.Periods;
using UdesAPP.Teachers;
using Volo.Abp.Application.Dtos;
using static Microsoft.AspNetCore.Components.NavigationManager;

namespace UdesAPP.Blazor.Pages.Classes
{
    public partial class AllClasses(
        StudentsOfClassesAppService studentsOfClassesAppService,
        TeachersCRUDAppService teachersCRUDAppService,
        BooksCRUDAppService booksCRUDAppService,
        PeriodsAppService periodsAppService,
        NavigationManager navigationManager)
    {
        [Parameter]
        public List<PeriodDto>? PeriodDtos { get; set; }
        [Parameter]
        public List<TeacherDto> TeachersDtos { get; set; }
        [Parameter]
        public List<BooksDto>? BooksDtos { get; set; }        
        public bool Loaded { get; set; } = false;
        public int Lessons { get; set; }
        private List<StudentsOfClassDto> StudentsOfClass {  get; set; }
        private StudentsOfClassesAppService _studentsOfClassesAppService = studentsOfClassesAppService;
        private PeriodsAppService _periodsAppService = periodsAppService;
        private TeachersCRUDAppService _teachersCRUDAppService = teachersCRUDAppService;
        private BooksCRUDAppService _booksCRUDAppService = booksCRUDAppService;
        private Validations EditValidationsRef;
        private StudentsOfClassDto DeletingFromClassStudent = new StudentsOfClassDto();
        private AllClassesDto EnrollForTheClassDto = new AllClassesDto();
        private Modal DeleteStudentFromClassModal { get; set; }
        private Modal EnrollForTheClassModal { get; set; }
        private NavigationManager uriHelper = navigationManager;

        public async Task ClassIsClicked(DataGridRowMouseEventArgs<AllClassesDto> clickedClass)
        {
            StudentsOfClass = await _studentsOfClassesAppService.GetStudentsByClassId(clickedClass.Item.Id);
        }
        protected override async Task OnParametersSetAsync()
        {
            PeriodDtos = await _periodsAppService.GetAllPeriods();
            BooksDtos = await _booksCRUDAppService.GetAllBooksAsync();
            TeachersDtos = await _teachersCRUDAppService.GetAllTeachersAsync();
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
        private void OpenEnrollForTheClassModal(AllClassesDto enrollClass)
        {
            EditValidationsRef.ClearAll();
            EnrollForTheClassDto = enrollClass;
            EnrollForTheClassModal.Show();
        }
        private void CloseEnrollForTheClassModal()
        {
            EnrollForTheClassModal.Hide();
        }
        private async Task EnrollForTheClass(int classId, int lessons)
        {
            await _studentsOfClassesAppService.EnrollOfTheClass(classId, lessons);
            uriHelper.NavigateTo(uriHelper.Uri, forceLoad: true);
            EnrollForTheClassModal.Hide();
        }
    }
}
