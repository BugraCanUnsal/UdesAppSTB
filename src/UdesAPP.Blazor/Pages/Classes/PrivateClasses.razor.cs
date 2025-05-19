using System;
using Blazorise;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;
using UdesAPP.Classes;
using UdesAPP.Students;

namespace UdesAPP.Blazor.Pages.Classes
{
    public partial class PrivateClasses(
        StudentsOfClassesAppService studentsOfClassesAppService,
        NavigationManager navigationManager)
    {
        List<StudentDto> pageStudents { get; set; }
        StudentDto EnrollStudent = new StudentDto();
        public decimal Lessons { get; set; }
        private Modal EnrollForTheStudentModal { get; set; }
        private Validations EditValidationsRef;
        private StudentsOfClassesAppService _studentsOfClassesAppService = studentsOfClassesAppService;
        private NavigationManager uriHelper = navigationManager;

        protected override async Task OnInitializedAsync()
        {
            pageStudents = await _studentsOfClassesAppService.GetAllPrivateClassStudents();
            await base.OnInitializedAsync();
        }
        private void OpenEnrollForTheStudentModal(StudentDto studentDto)
        {
            //EditValidationsRef.ClearAll();
            EnrollStudent = studentDto;
            EnrollForTheStudentModal.Show();
        }
        private void CloseEnrollForTheStudentModal()
        {
            EnrollForTheStudentModal.Hide();
        }
        private async Task EnrollForTheStudent(Guid studentId, decimal lessons)
        {
            await _studentsOfClassesAppService.EnrollOfTheStudent(studentId, lessons);
            uriHelper.NavigateTo(uriHelper.Uri, forceLoad: true);
            EnrollForTheStudentModal.Hide();
        }
    }
}
