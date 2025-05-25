using System;
using System.Threading.Tasks;
using UdesAPP.Books;
using UdesAPP.GeneralEnums;
using UdesAPP.Params;
using UdesAPP.Students;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore;

public class UdesAppDataSeederContributor
    : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<Student, Guid> _studentRepository;
    private readonly IRepository<Param, Guid> _paramRepository;

    public UdesAppDataSeederContributor(IRepository<Student, Guid> studentRepository, IRepository<Param, Guid> paramRepository)
    {
        _paramRepository = paramRepository;
        _studentRepository = studentRepository;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        if (await _paramRepository.GetCountAsync() == 0)
        {
            await _paramRepository.InsertAsync(new Param
            {
                Paramtype = "BookSeries",
                ParamCode = 1,
                ParamDescription = "Temel İngiliz Dili Serisi"
            }, autoSave: true);
            await _paramRepository.InsertAsync(new Param
            {
                Paramtype = "BookSeries",
                ParamCode = 2,
                ParamDescription = "Simultane Çeviri Serisi"
            }, autoSave: true);
            await _paramRepository.InsertAsync(new Param
            {
                Paramtype = "BookSeries",
                ParamCode = 3,
                ParamDescription = "Express Serisi"
            }, autoSave: true);
            await _paramRepository.InsertAsync(new Param
            {
                Paramtype = "BookSeries",
                ParamCode = 4,
                ParamDescription = "Genel İngilizce"
            }, autoSave: true);
            await _paramRepository.InsertAsync(new Param
            {
                Paramtype = "BookSeries",
                ParamCode = 5,
                ParamDescription = "İngilizce Sohbet Dili"
            }, autoSave: true);
            await _paramRepository.InsertAsync(new Param
            {
                Paramtype = "BookSeries",
                ParamCode = 6,
                ParamDescription = "Tiyatral Serisi"
            }, autoSave: true);
            await _paramRepository.InsertAsync(new Param
            {
                Paramtype = "BookSeries",
                ParamCode = 7,
                ParamDescription = "Karşılaştırmalı İngilizce Serisi"
            }, autoSave: true);
            await _paramRepository.InsertAsync(new Param
            {
                Paramtype = "BookSeries",
                ParamCode = 8,
                ParamDescription = "Anadili Metoduyla İngilizce Konuşma Serisi"
            }, autoSave: true);
            await _paramRepository.InsertAsync(new Param
            {
                Paramtype = "EduPrograms",
                ParamCode = 1,
                ParamDescription = "Günlük İngilizce Eğitimi"
            }, autoSave: true);
            await _paramRepository.InsertAsync(new Param
            {
                Paramtype = "EduPrograms",
                ParamCode = 2,
                ParamDescription = "Profesyonel İş Hayatı İçin İngilizce Eğitimi"
            }, autoSave: true);
            await _paramRepository.InsertAsync(new Param
            {
                Paramtype = "EduPrograms",
                ParamCode = 3,
                ParamDescription = "İngilizce Öğretmenleri ve Çevirmenler İçin İngilizce Eğitimi"
            }, autoSave: true);
        }
    }
}
