using UdesAPP.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace UdesAPP.Permissions;

public class UdesAPPPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(UdesAPPPermissions.GroupName);
        //Define your own permissions here. Example:
        myGroup.AddPermission(UdesAPPPermissions.HostPermission, L("Permission:HostPermission"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<UdesAPPResource>(name);
    }
}
