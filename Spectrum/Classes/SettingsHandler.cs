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
            String ElementName = "";
            while (reader.Read()) {
                switch (reader.NodeType) {
                    // The node is an element.
                    case XmlNodeType.Element:
                        //Console.Write("<" + reader.Name + ">");
                        if (reader.Name.ToLower() == profileName) startSettings = true;
                        ElementName = reader.Name;
                        break;

                    //Display the text in each element.
                    case XmlNodeType.Text: 
                        // Console.Write(reader.Value);
                        if (startSettings) {
                           
                            // Creates Settings With Correct Type
                            if (reader.Value == "true" || reader.Value == "false") settingsDic[ElementName] = Convert.ToBoolean(reader.Value);
                            else {
                                // Trys to create Int
                                try {
                                    settingsDic[ElementName] = Convert.ToInt32(reader.Value);
                                }
                                // assume string if int fails
                                catch {
                                    settingsDic[ElementName] = reader.Value;
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
            return settingsDic;
        }
    }
}
