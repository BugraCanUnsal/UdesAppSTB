using Volo.Abp.Settings;

namespace UdesAPP.Settings;

public class UdesAPPSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(UdesAPPSettings.MySetting1));
    }
}
