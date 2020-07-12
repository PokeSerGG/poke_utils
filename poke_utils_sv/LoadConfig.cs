using CitizenFX.Core;
using CitizenFX.Core.Native;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace poke_utils_sv
{
    class LoadConfig : BaseScript
    {
        public static JObject Config = new JObject();
        public static string ConfigString;
        public static string resourcePath = $"{API.GetResourcePath(API.GetCurrentResourceName())}";

        public static bool isConfigLoaded = false;

        public LoadConfig()
        {
            EventHandlers[$"{API.GetCurrentResourceName()}:getConfig"] += new Action<Player>(getConfig);

            LoadConfigAndLang();
        }

        private void LoadConfigAndLang()
        {
            if (File.Exists($"{resourcePath}/Config.json"))
            {
                ConfigString = File.ReadAllText($"{resourcePath}/Config.json", Encoding.UTF8);
                Config = JObject.Parse(ConfigString);
            }
            else
            {
                Debug.WriteLine($"{API.GetCurrentResourceName()}: Config.json Not Found");
            }
            isConfigLoaded = true;
        }

        private async void getConfig([FromSource] Player source)
        {
            source.TriggerEvent($"{API.GetCurrentResourceName()}:SendConfig", ConfigString);
        }
    }
}
