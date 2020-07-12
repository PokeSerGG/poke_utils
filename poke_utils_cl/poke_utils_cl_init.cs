using CitizenFX.Core;
using CitizenFX.Core.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poke_utils_cl
{
    public class poke_utils_cl_init : BaseScript
    {
        public poke_utils_cl_init()
        {
            EventHandlers["poke_utils:useItem"] += new Action<string, string>(item_UseItem);
        }

        private void item_UseItem(string provisionType, string interactionType)
        {
            API.TaskItemInteraction(API.PlayerPedId(), API.GetHashKey(provisionType), API.GetHashKey(interactionType), 1, 0, -1082130432);
        }
    }
}
