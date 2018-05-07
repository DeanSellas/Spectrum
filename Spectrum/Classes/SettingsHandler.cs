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
        public string settingsProfile;

        public List<string> settingsProfilesList = new List<string>();

        String launchTime = DateTime.Now.ToString();

        String settingsFile = Environment.CurrentDirectory + "/Settings/settings.xml";

        XmlDocument doc = new XmlDocument();
        public SettingsHandler() {

            // creates default settings
            defaultSettings = createSettings();

            // creates/assigns proper settings
            if (settingsProfile != "Default") currentSettings = createSettings(settingsProfile);
            else currentSettings = defaultSettings;

            settingsProfilesList = getSettingProfiles();
        }

        // Gets Settings Profiles
        public List<String> getSettingProfiles() {
            List<string> profiles = new List<string>();
            doc.Load(settingsFile);
            XmlNode root = doc.DocumentElement;
            XmlNode parent = root.SelectSingleNode("descendant::Profiles");

            // Adds each profile to list
            foreach (XmlNode child in parent.ChildNodes) profiles.Add(child.Name);

            return profiles;
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

                        // Sets Download Location. (not sure why last statement needs to be there, I just know it does...)
                        if (ElementName == "downloadLocation" && reader.Value == "" && ContainerName == "Updater") settingsDic[ContainerName][ElementName] = Environment.CurrentDirectory;

                        // Starts reading settings
                        if (reader.Name == profileName) startSettings = true;
                        ElementName = reader.Name;
                        
                        break;

                    //Display the text in each element.
                    case XmlNodeType.Text:
                        // Console.Write(reader.Value);

                        // sets setting profile
                        if (ElementName == "currentSettingsProfile") settingsProfile = reader.Value;
                        if (settingsProfile == null) settingsProfile = "Default";

                        // starts reading settings
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
                        
                        break;

                    //Display the end of the element.
                    case XmlNodeType.EndElement: 
                        //Console.Write("</" + reader.Name + "> \n");

                        // Ends reading settings when end node is hit
                        if (reader.Name == profileName) startSettings = false;
                        
                        break;
                }
            }
            reader.Close();

            // adds missing content to settings
            if (profileName != "default") fillSettings(settingsDic);
            
            return settingsDic;
        }


        private void fillSettings(Dictionary<string, dynamic> settingsDic) {
            // Adds missing items from currentSettings
            foreach (String master in defaultSettings.Keys) {
                if (!settingsDic.ContainsKey(master)) settingsDic[master] = defaultSettings[master];
                else
                    foreach (String key in defaultSettings[master].Keys)
                        if (!settingsDic[master].ContainsKey(key)) settingsDic[master][key] = defaultSettings[master][key];
            }
        }

        // Saves Settings
        public void saveSettings() {
            doc.Load(settingsFile);
            XmlNode root = doc.DocumentElement;

            // sets default updater data
            XmlNode defaultCheck = root.SelectSingleNode("descendant::Default/Updater");
            foreach (XmlNode item in defaultCheck.ChildNodes) {
                if (item.Name == "downloadLocation") item.InnerText = defaultSettings["Updater"]["downloadLocation"];
                // assigns last check to launch for default settings
                if (item.Name == "lastCheck") item.InnerText = launchTime;
            }

            if (settingsProfile == "Default") { doc.Save(settingsFile); createSettings(settingsProfile); return; }

            XmlNode myNode = root.SelectSingleNode("descendant::" + settingsProfile);

            // if new settings profile
            if (myNode == null) {
                XmlNode newProfile = createNode(root, settingsProfile);
                myNode = root.SelectSingleNode("descendant::Profiles").AppendChild(newProfile);
            }

            // writes settings to file
            // loops through masters
            foreach (String master in currentSettings.Keys) {
                // List of nodes to remove
                List<XmlNode> removeNodeList = new List<XmlNode>();
                // assigns master node
                XmlNode masterNode = root.SelectSingleNode("descendant::" + settingsProfile + "/" + master);
                // Creates master node if doesnt exist
                if (masterNode == null) masterNode = myNode.AppendChild(createNode(root, master));

                // loops through children in master
                foreach (String child in currentSettings[master].Keys) {
                    // assigns child node
                    XmlNode currentNode = masterNode.SelectSingleNode("descendant::" + child);
                    // if node doesnt exist create it
                    if (currentNode == null) currentNode = masterNode.AppendChild(createNode(root, child));
                    // if settings is different set node for deletion \\ else assign value to the node
                    if (currentSettings[master][child] == defaultSettings[master][child]) removeNodeList.Add(currentNode);
                    else currentNode.InnerText = Convert.ToString(currentSettings[master][child]);
                }
                // Removes nodes that are the same as the default. Not sure why This needs to be included outside of main loop
                for (int i = 0; i < removeNodeList.Count; i++) masterNode.RemoveChild(removeNodeList[i]);
            }


            // saves settings then updates them for Spectrum
            doc.Save(settingsFile);
            createSettings(settingsProfile);
        }

        // Creates A New Node
        private XmlNode createNode(XmlNode root, String nodeName) { return root.OwnerDocument.CreateElement(nodeName); }



    }
}