﻿using Microsoft.EntityFrameworkCore;
using UdesAPP.Books;
using UdesAPP.Classes;
using UdesAPP.Students;
using UdesAPP.Teachers;
using UdesAPP.Periods;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using Acme.UdesAPP;
using UdesAPP.Payments;

namespace UdesAPP.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class UdesAPPDbContext :
    AbpDbContext<UdesAPPDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */

    #region Entities from the modules

    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }
    //Domainde oluşturulan entityler
    public DbSet<Student> Students { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Class> Classes { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Period> Periods { get; set; }
    public DbSet<Payment> Payments {  get; set; }  

    #endregion

    public UdesAPPDbContext(DbContextOptions<UdesAPPDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

        /* Configure your own tables/entities inside here */

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(UdesAPPConsts.DbTablePrefix + "YourEntities", UdesAPPConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});
        builder.Entity<Student>(b =>
        {
            b.ToTable(UdesAPPConsts.DbTablePrefix + "Students",
                UdesAPPConsts.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(x => x.Name).HasMaxLength(128);
            b.Property(x => x.Surname).HasMaxLength(128);
            b.Property(x => x.Birthdate).IsRequired(false);
            b.Property(x => x.Gender).IsRequired(false);
            b.Property(x => x.GSM).IsRequired(false).HasMaxLength(10);
            b.Property(x => x.Email).IsRequired(false).HasMaxLength(70);
            b.Property(x => x.Address).IsRequired(false).HasMaxLength(300);
            b.Property(x => x.ClassId).IsRequired(true);
            b.Property(x => x.Type).IsRequired(false);
            b.Property(x => x.GroupLessonFee).IsRequired(false);
            b.Property(x => x.IndividualLessonFee).IsRequired(false);
            b.Property(x => x.Photograph).IsRequired(false);
        });
        
        builder.Entity<Book>(b =>
        {
            b.ToTable(UdesAPPConsts.DbTablePrefix + "Books",
                UdesAPPConsts.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(x => x.Title).HasMaxLength(150);
            b.Property(x => x.Serie).IsRequired(false);
            b.Property(x => x.Program).IsRequired(false);
            b.Property(x => x.NumberOfPages).IsRequired(false);
            b.Property(x => x.NumberOfTopics).IsRequired(false);
            b.Property(x => x.NumberOfSentences).IsRequired(false);
            b.Property(x => x.NumberOfWords).IsRequired(false);
        });
        
        builder.Entity<Class>(b =>
        {
            b.ToTable(UdesAPPConsts.DbTablePrefix + "Classes",
                UdesAPPConsts.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(x => x.ClassName).HasMaxLength(150);
            b.Property(x => x.TeacherId).IsRequired(false);
            b.Property(x => x.BookId).IsRequired(false);
            b.Property(x => x.DaysAndTimesOfWeekId).IsRequired(false);
        });

        builder.Entity<Teacher>(b =>
        {
            b.ToTable(UdesAPPConsts.DbTablePrefix + "Teachers",
                UdesAPPConsts.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(x => x.Name).HasMaxLength(128);
            b.Property(x => x.Surname).HasMaxLength(128);
            b.Property(x => x.Birthdate).IsRequired(false);
            b.Property(x => x.Gender).IsRequired(false);
            b.Property(x => x.GSM).IsRequired(false).HasMaxLength(10);
            b.Property(x => x.Email).IsRequired(false).HasMaxLength(70);
            b.Property(x => x.Address).IsRequired(false).HasMaxLength(300);
            b.Property(x => x.GraduatedFrom).IsRequired(false).HasMaxLength(150);
        });

        builder.Entity<Period>(b =>
        {
            b.ToTable(UdesAPPConsts.DbTablePrefix + "Periods",
                UdesAPPConsts.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(x => x.Description).HasMaxLength(250);
        });

        builder.Entity<Payment>(b =>
        {
            b.ToTable(UdesAPPConsts.DbTablePrefix + "Payments",
                UdesAPPConsts.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(x => x.StudentName).HasMaxLength(128);
            b.Property(x => x.StudentSurname).HasMaxLength(128);
            b.Property(x => x.HourBalance).IsRequired(false);
            b.Property(x => x.FeeBalance).IsRequired(false);
        });
    }
}