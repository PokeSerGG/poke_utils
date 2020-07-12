using CitizenFX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poke_utils_sv
{
    public class poke_utils_sv_init : BaseScript
    {
        public poke_utils_sv_init()
        {
            initRegisterItems();
        }

        private async Task initRegisterItems()
        {
            await Delay(4000);
            for (int i = 0; i < LoadConfig.Config["ItemsToUse"].Count(); i++)
            {
                await Delay(200);
                int index = i;
                TriggerEvent("vorpCore:registerUsableItem", LoadConfig.Config["ItemsToUse"][i]["Name"].ToString(), new Action<dynamic>((data) =>
                {
                    Player source = getSource(data.source);
                    source.TriggerEvent("poke_utils:useItem", LoadConfig.Config["ItemsToUse"][index]["ProvisionType"].ToString(), LoadConfig.Config["ItemsToUse"][index]["InteractionType"].ToString());
                }));
            }
        }

        public static Player getSource(int handle)
        {
            PlayerList pl = new PlayerList();
            Player p = pl[handle];
            return p;
        }
    }
}
