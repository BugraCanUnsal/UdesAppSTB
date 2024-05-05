using Microsoft.AspNetCore.Components;
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
        [Parameter]
        public List<StudentDto> StudentDtos { get; set; }

        public bool Loaded { get; set; } = false;
        public async Task StartPaymentProcess(StudentDto context)
        {
            bool isInserted = await paymentAppService.StartPaymentProcess(context);
            //popup hazırla
        }
        protected override async Task OnParametersSetAsync()
        {
            AllClassesDtos = await allClassesAppService.GetAllClassesAsync();
            StudentDtos = await studentAppService.GetAllStudentsAsync();
            Loaded = true;
            await base.OnParametersSetAsync();
        }
        private bool OnClassesFilter(object itemValue, object searchValue)
        {
            if (searchValue is string classFilter)
            {
                var searchedClass = AllClassesDtos.Find(x => x.Id.ToString() == itemValue?.ToString());
                if (searchedClass != null)
                {
                    return searchedClass.ClassName.ToUpper().Contains(classFilter.ToUpper());
                }
                return classFilter == "";
            }

            return true;
        }
    }
}
