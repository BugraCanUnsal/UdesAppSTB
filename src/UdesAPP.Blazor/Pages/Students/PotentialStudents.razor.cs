using Blazorise;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using UdesAPP.Students;
using UdesAPP.Params;

namespace UdesAPP.Blazor.Pages.Students
{
    public partial class PotentialStudents(
        PotentialStudentsCRUDAppService potentialStudentsCRUDAppService,
        ParametersAppService parametersAppService)
    {
        [Parameter]
        public List<PotentialStudentsDto> StudentDtos { get; set; }
        [Parameter]
        public List<ParametersDto>? ParamsDtos { get; set; }
        public bool Loaded { get; set; } = false;
        private PotentialStudentsCRUDAppService _potentialStudentsCRUDAppService = potentialStudentsCRUDAppService;
        private ParametersAppService _parametersAppService = parametersAppService;
        private PotentialStudentsDto _potentialStudentsDto = new PotentialStudentsDto();
        private Modal NoteModal {  get; set; }
        private void OpenNoteModal(PotentialStudentsDto potStudentsDto)
        {
            _potentialStudentsDto = potStudentsDto;
            NoteModal.Show();
        }
        private void CloseNoteModal()
        {
            NoteModal.Hide();
        }
        private async Task UpdateNoteOfPotentialStudent(PotentialStudentsDto potentialStudentsDto)
        {
            await _potentialStudentsCRUDAppService.UpdateNoteOfStudent(potentialStudentsDto);
            NoteModal.Hide();
            Message.Success($"{potentialStudentsDto.StudentName} {potentialStudentsDto.StudentSurname} " +
                $"isimli öğrencinin başvuru notu güncellendi.");
        }
        protected override async Task OnParametersSetAsync()
        {
            StudentDtos = await _potentialStudentsCRUDAppService.GetAllPotentialStudentsAsync();
            ParamsDtos = await _parametersAppService.GetParametersByParamType("BookSeries");
            Loaded = true;
            await base.OnParametersSetAsync();
        }
        private bool OnBookSerieFilter(object itemValue, object searchValue)
        {
            if (searchValue is string bookFilter)
            {
                var serie = ParamsDtos.Find(x => x.ParamCode.ToString() == itemValue?.ToString());
                if (serie != null)
                {
                    return serie.ParamDescription.ToUpper().Contains(bookFilter.ToUpper());
                }
                return bookFilter == "";
            }
            return true;
        }
    }
}
