using AutoMapper;
using System.Collections.Generic;
using UdesAPP.Books;
using UdesAPP.Classes;
using UdesAPP.Dtos;
using UdesAPP.Params;
using UdesAPP.Payments;
using UdesAPP.Periods;
using UdesAPP.Students;
using UdesAPP.Teachers;

namespace UdesAPP;

public class UdesAPPApplicationAutoMapperProfile : Profile
{
    public UdesAPPApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Student, StudentDto>();
        CreateMap<StudentsOfClassDto, Student>();
        CreateMap<CreateUpdateStudentsDto, Student>();
        CreateMap<StudentDto, CreateUpdateStudentsDto>();
        CreateMap<Class, AllClassesDto>();
        CreateMap<CreateUpdateAllClassesDto, Class>();
        CreateMap<AllClassesDto, CreateUpdateAllClassesDto>();
        CreateMap<Student, StudentsOfClassDto>();
        CreateMap<Period, PeriodsDto>();
        CreateMap<Teacher, TeacherDto>();
        CreateMap<TeacherDto, Teacher>();
        CreateMap<Payment, PaymentDto>();
        CreateMap<PaymentDto, Payment>();
        CreateMap<Param, ParametersDto>();
        CreateMap<ParametersDto, Param>();      
        CreateMap<Book, BooksDto>();      
        CreateMap<BooksDto, Book>();      
    }
}
