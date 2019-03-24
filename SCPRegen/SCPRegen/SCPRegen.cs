using Smod2;
using Smod2.Attributes;
using Smod2.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCPRegen
{
    [PluginDetails(
    author = "Kade",
    name = "SCPRegen",
    description = "Allowing SCP's today to regen their health!",
    id = "kade.scpr",
    version = "1.1",
    SmodMajor = 3,
    SmodMinor = 3,
    SmodRevision = 1
    )]
    public class SCPRegen : Plugin
    {
        public override void OnDisable()
        {
            Info("Disabled SCPRegen!");
        }

        public override void OnEnable()
        {
            Info("\nSCPRegen " + Details.version + "\nEnabled!");
        }

        public override void Register()
        {
            AddConfig(new ConfigSetting("scpr_regenerate", true, SettingType.BOOL, true, "Enable or Disable the plugin"));
            AddConfig(new ConfigSetting("scpr_regenerate_timer", 5000, SettingType.NUMERIC, true, "The time in miliseconds it takes to regen health"));
            AddConfig(new ConfigSetting("scpr_regenerate_hp", 60, SettingType.NUMERIC, true, "The amount of health the scp's regen"));
            AddEventHandlers(new Events(this));
        }
    }
}
