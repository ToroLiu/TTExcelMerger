using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelMerger.ViewModels;
using Newtonsoft.Json;

namespace ExcelMerger.Helpers
{
    internal static class ConfigHelper
    {
        private static Config _config = null;
        public static Config Config { 
            get {
                if (_config == null) {
                    Load();
                }
                return _config;
            }
            set {
                _config = value;
            }
        }

        private static void Load() 
        {
            string json = Properties.Settings.Default.AppSetting;
            if (string.IsNullOrEmpty(json))
            {
                Config = new Config();
            }
            else 
            {
                Config = JsonConvert.DeserializeObject<Config>(json);
            }
        }

        public static void Save() 
        {
            string json = JsonConvert.SerializeObject(Config);
            Properties.Settings.Default.AppSetting = json;
            Properties.Settings.Default.Save();
        }
    }

    internal class Config 
    {
        private VMMain _main = null;
        public VMMain Main {
            get {
                if (_main == null)
                    _main = new VMMain();
                return _main;
            }
            set {
                _main = value;
            }
        }

        public Config()
        {
            this.Main = new VMMain();
        }
    }
}
