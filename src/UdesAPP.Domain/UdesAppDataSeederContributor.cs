using System;
using System.Threading.Tasks;
using UdesAPP.Books;
using UdesAPP.GeneralEnums;
using UdesAPP.Students;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore;

public class UdesAppDataSeederContributor
    : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<Student, int> _studentRepository;

    public UdesAppDataSeederContributor(IRepository<Student, int> studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        if (await _studentRepository.GetCountAsync() <= 0)
        {
            await _studentRepository.InsertAsync(
                new Student
                {
                    Name = "Hakan",
                    Surname = "Çam",
                    Birthdate = new DateTime(1994,03,03),
                    GSM = "5333333333",
                    Email = "hakancam@gmail.com",
                    Address = "Merter/İSTANBUL",
                    ClassId = 101,
                    Gender = Gender.Erkek,
                    IsActive = StudentState.Pasif,
                    Type = StudentType.Belirsiz,
                    GroupLessonFee = 270,
                    IndividualLessonFee = 1600,
                    Photograph = string.Empty
                },
                autoSave: true
            );

            await _studentRepository.InsertAsync(
                new Student
                {
                    Name = "Dünya",
                    Surname = "Güzeli",
                    Birthdate = new DateTime(1975, 02, 02),
                    GSM = "5222222222",
                    Email = "dunyaguzeli@gmail.com",
                    Address = "Bostancı/İSTANBUL",
                    ClassId = 102,
                    Gender = Gender.Kadın,
                    IsActive = StudentState.Aktif,
                    Type = StudentType.Özel,
                    GroupLessonFee = 220,
                    IndividualLessonFee = 1750,
                    Photograph = string.Empty
                },
                autoSave: true
            );
        }
    }
}
