using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Spectrum.Classes {
    class SettingsHandler {

        public Dictionary<string, dynamic> defaultSettings = new Dictionary<string, dynamic>();
        public String settingsProfile;

        public SettingsHandler() {
            Console.WriteLine("WORKING");
            // creates default settings
            defaultSettings = createSettings("Default");
            
        }

        public void saveSettings() {
            
        }

        public Dictionary<string, dynamic> createSettings(string profileName) {
            Dictionary<string, dynamic> settingsDic = new Dictionary<string, dynamic>();


            XmlTextReader reader = new XmlTextReader(Environment.CurrentDirectory + "/Settings/settings.xml");
            Boolean startSettings = false;
            String ElementName = "", ContainerName = "";
            while (reader.Read()) {
                
                switch (reader.NodeType) {

                    // The node is an element.
                    case XmlNodeType.Element:
                        //Console.Write("<" + reader.Name + ">");
                        if (startSettings && char.IsUpper(reader.Name[0])) {
                            settingsDic[reader.Name] = new Dictionary<string, dynamic>();
                            ContainerName = reader.Name;
                        }
                        if (ElementName == "downloadLocation" && reader.Value == "" && ContainerName == "Updater") settingsDic[ContainerName][ElementName] = Environment.CurrentDirectory.ToString();
                        if (reader.Name == profileName) startSettings = true;
                        ElementName = reader.Name;
                        // Sets download location as current if no other value is entered
                        
                        break;

                    //Display the text in each element.
                    case XmlNodeType.Text: 
                        // Console.Write(reader.Value);
                        if (startSettings) {
                            
                            // Creates Settings With Correct Type
                            if (reader.Value == "true" || reader.Value == "false") settingsDic[ContainerName][ElementName] = Convert.ToBoolean(reader.Value);
                            else {
                                // Trys to create Int
                                try {
                                    settingsDic[ContainerName][ElementName] = Convert.ToInt32(reader.Value);
                                }
                                // assume string if int fails
                                catch {
                                    settingsDic[ContainerName][ElementName] = reader.Value;
                                }
                            }
                            
                        }
                        if (ElementName == "currentSettingsProfile") settingsProfile = reader.Value.ToLower();
                        break;

                    //Display the end of the element.
                    case XmlNodeType.EndElement: 
                        //Console.Write("</" + reader.Name + "> \n");
                        if (reader.Name == profileName) startSettings = false;
                        
                        break;
                }
            }

            if (profileName != "default") cleanSettings(settingsDic);

            return settingsDic;
        }


        private void cleanSettings(Dictionary<string, dynamic> settingsDic) {
            // Prints Items in Settings
            foreach (KeyValuePair<string, dynamic> kvp in defaultSettings) {
                if (!settingsDic.ContainsKey(kvp.Key)) settingsDic[kvp.Key] = kvp.Value;
            }
        }
    }
}
