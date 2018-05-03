using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;

namespace Spectrum.Classes {
    class SettingsHandler {
        public Dictionary<string, dynamic> defaultSettings = new Dictionary<string, dynamic>();
        public Dictionary<string, dynamic> currentSettings = new Dictionary<string, dynamic>();
        public String settingsProfile;

        DateTime test;

        String launchTime = DateTime.Now.ToString();

        String settingsFile = Environment.CurrentDirectory + "/Settings/settings.xml";


        public SettingsHandler() {
            // creates default settings
            defaultSettings = createSettings();

            // creates/assigns proper settings
            if (settingsProfile != "Default") currentSettings = createSettings(settingsProfile);
            else currentSettings = defaultSettings;
            test = DateTime.Parse(launchTime);
        }

        public void saveSettings() {
            XmlDocument doc = new XmlDocument();
            doc.Load(settingsFile);
            XmlNode root = doc.DocumentElement;
            XmlNode myNode = root.SelectSingleNode("descendant::" + settingsProfile);

            // Loops through masters
            foreach (XmlNode master in myNode.ChildNodes) {
                var masterName = master.Name.ToString();

                // Creates list to store node names that will be removed
                List<XmlNode> removeNodeList = new List<XmlNode>();
                
                // Loops through settings
                foreach (XmlNode child in master.ChildNodes) {
                    var childName = child.Name.ToString();

                    // if setting exists in currentSettings
                    if (currentSettings[masterName].ContainsKey(childName)) {
                        // if item is different from default d
                        if (!defaultSettings[masterName].ContainsKey(childName) || currentSettings[masterName][childName] != defaultSettings[masterName][childName]) {
                            child.InnerText = Convert.ToString(currentSettings[masterName][childName]);
                            //Console.WriteLine(childName);
                        }
                        // else delete the node
                        else removeNodeList.Add(child);
                    }
                }
                // Removes nodes that are the same as the default. Not sure why This needs to be included outside of main loop
                for (int i = 0; i < removeNodeList.Count; i++) master.RemoveChild(removeNodeList[i]);
            }
            XmlNode defaultCheck = root.SelectSingleNode("descendant::Default/Updater");
            foreach (XmlNode item in defaultCheck.ChildNodes) {
                if (item.Name == "downloadLocation") item.InnerText = defaultSettings["Updater"]["downloadLocation"];
                // assigns last check to launch for default settings
                if (item.Name == "lastCheck") item.InnerText = launchTime;
            }


            doc.Save(settingsFile);
        }

        public Dictionary<string, dynamic> createSettings(string profileName = "Default") {
            Dictionary<string, dynamic> settingsDic = new Dictionary<string, dynamic>();
            
            XmlTextReader reader = new XmlTextReader(settingsFile);
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
                        if (ElementName == "downloadLocation" && reader.Value == "" && ContainerName == "Updater") settingsDic[ContainerName][ElementName] = Environment.CurrentDirectory;
                        if (reader.Name == profileName) startSettings = true;
                        ElementName = reader.Name;
                        // Sets download location as current if no other value is entered
                        
                        break;

                    //Display the text in each element.
                    case XmlNodeType.Text: 
                        // Console.Write(reader.Value);
                        if (startSettings) {
                            
                            // Creates Settings With Correct Type
                            if (reader.Value.ToLower() == "true" || reader.Value.ToLower() == "false") settingsDic[ContainerName][ElementName] = Convert.ToBoolean(reader.Value);
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
                        if (ElementName == "currentSettingsProfile") settingsProfile = reader.Value;
                        break;

                    //Display the end of the element.
                    case XmlNodeType.EndElement: 
                        //Console.Write("</" + reader.Name + "> \n");
                        if (reader.Name == profileName) startSettings = false;
                        
                        break;
                }
            }
            reader.Close();

            if (profileName != "default") cleanSettings(settingsDic);
            
            return settingsDic;
        }


        private void cleanSettings(Dictionary<string, dynamic> settingsDic) {
            // Prints Items in Settings
            foreach (String master in defaultSettings.Keys) {
                if (!settingsDic.ContainsKey(master)) settingsDic[master] = defaultSettings[master];
                else
                    foreach (String key in defaultSettings[master].Keys)
                        if (!settingsDic[master].ContainsKey(key)) settingsDic[master][key] = defaultSettings[master][key];
            }
        }
    }
}
