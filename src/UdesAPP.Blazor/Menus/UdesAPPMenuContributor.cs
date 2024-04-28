using System.Threading.Tasks;
using UdesAPP.Localization;
using UdesAPP.MultiTenancy;
using Volo.Abp.Identity.Blazor;
using Volo.Abp.SettingManagement.Blazor.Menus;
using Volo.Abp.TenantManagement.Blazor.Navigation;
using Volo.Abp.UI.Navigation;

namespace UdesAPP.Blazor.Menus;

public class UdesAPPMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var administration = context.Menu.GetAdministration();
        var l = context.GetLocalizer<UdesAPPResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                UdesAPPMenus.Home,
                l["Menu:Home"],
                "/",
                icon: "fas fa-home",
                order: 0
            )
        );

        context.Menu.AddItem(
            new ApplicationMenuItem(
                "Students",
                l["Menu:Students"],
                icon: "fa fa-graduation-cap"
            ).AddItem(
                new ApplicationMenuItem(
                    "AllStudents",
                    l["Menu:AllStudents"],
                    url: "/students"
                    )
                ).AddItem(
                new ApplicationMenuItem(
                    "PotentialStudents",
                    l["Menu:PotentialStudents"],
                    url: "/potentialStudents"))
         );

        context.Menu.AddItem(
            new ApplicationMenuItem(
                "Classes",
                l["Menu:Classes"],
                icon: "fa-solid fa-school"
                ).AddItem(
                new ApplicationMenuItem(
                    "AllClasses",
                    l["Menu:AllClasses"],
                    url: "/allClasses"
                 )
         ));
        context.Menu.AddItem(
            new ApplicationMenuItem(
                "Teachers",
                l["Menu:Teachers"],
                icon: "fa-solid fa-person-chalkboard",
                 url: "/teachers"
                ));

        context.Menu.AddItem(
            new ApplicationMenuItem(
                "Periods",
                l["Menu:Periods"],
                icon: "fa-solid fa-arrows-spin",
                 url: "/periods"
                ));

        context.Menu.AddItem(
            new ApplicationMenuItem(
                "Payments",
                l["Menu:Payments"],
                icon: "fa-solid fa-money-check-dollar",
                 url: "/payments"
                ));



        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenus.GroupName, 3);

        return Task.CompletedTask;
    }
}
