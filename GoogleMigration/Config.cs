using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using IniParser;
using IniParser.Model;
using IniParser.Parser;

namespace GoogleMigration
{
    class Config
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string GroupAddress { get; set; }
        public string PstPath { get; set; }
        private readonly static string Home = Environment.GetEnvironmentVariable("USERPROFILE");
        private readonly string _configPath = Home + @"\Groups.Migrate.ini";
        private IniData _data;
        public Config()
        {
            Load();
        }

        public void Load()
        {
            
            if (!File.Exists(_configPath))
            {
                var parser = new IniDataParser();
                IniData createData = parser.Parse("");
                createData.Sections.AddSection("API");
                createData["API"].AddKey("ClientId");
                createData["API"].AddKey("ClientSecret");
                createData.Sections.AddSection("Settings");
                createData["Settings"].AddKey("GroupAddress");
                createData["Settings"].AddKey("PstPath");
                string dataStr = createData.ToString();
                File.WriteAllText(_configPath, dataStr);
            }

            var fileParser = new FileIniDataParser();
            _data = fileParser.ReadFile(_configPath);
            ClientId = _data["API"]["ClientId"];
            ClientSecret = _data["API"]["ClientSecret"];
            GroupAddress = _data["Settings"]["GroupAddress"];
            PstPath = _data["Settings"]["PstPath"];
        }

        public void Save()
        {
            var fileParser = new FileIniDataParser();
            _data["API"]["ClientId"] = ClientId;
            _data["API"]["ClientSecret"] = ClientSecret;
            _data["Settings"]["GroupAddress"] = GroupAddress;
            _data["Settings"]["PstPath"] = PstPath;
            fileParser.WriteFile(_configPath, _data);
        }
    }
}
