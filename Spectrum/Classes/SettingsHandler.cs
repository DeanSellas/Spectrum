using System;
using System.Collections.Generic;
using System.Xml;
using System.IO;

namespace Spectrum.Classes {
    public class SettingsHandler {
        public Dictionary<string, dynamic> settings = new Dictionary<string, dynamic>();
        public string currentProfile;

        public List<string> profileList = new List<string>();

        string launchTime = DateTime.Now.ToString();

        string settingsFile = Environment.CurrentDirectory + "\\Settings\\settings.xml";

        // only changes a few settings
        public List<string> changedSettings = new List<string>();

        XmlDocument doc = new XmlDocument();
        public SettingsHandler() {
            settingsExist();

            // creates default settings
            settings = createSettings();
            if (currentProfile == "") currentProfile = "Default";
            else if (!settings.ContainsKey(currentProfile)) newProfile(currentProfile);
            printSettings();

            //changedSettings.Add("setting to change");

            //newProfile("test");
            saveSettings();
        }


        // gets setting value
        internal dynamic getSetting(string master, string setting, string profile = "Default") {
            try {
                return settings[profile][master][setting];
            }
            catch {
                return settings["Default"][master][setting];
            }
        }

        // Prints Items in Settings
        internal void printSettings() {
            Console.WriteLine("Current Profile: " + currentProfile + "\n--------------------------------");

            foreach (string one in settings.Keys)
                foreach (string two in settings[one].Keys)
                    foreach (string three in settings[one][two].Keys)
                        Console.WriteLine("Profile: {0} -- Master: {1} -- Settings: {2} -- Value: {3}", one, two, three, settings[one][two][three]);
            Console.WriteLine("-------------------------------- \n---Profiles Avaliable---");
            foreach (string profile in profileList) Console.WriteLine("Profile: {0}", profile);
            Console.WriteLine("--------------------------------");
        }

        // Checks to see if settings exist, if not creates settings
        private void settingsExist() {
            // creates directory if it does not exist
            if (!Directory.Exists("Settings"))
                Directory.CreateDirectory("Settings");
            // creates settings if file does not exist
            if (!File.Exists(settingsFile))
                File.WriteAllText(settingsFile, Properties.Resources.settingsDefault);

        }

        // Gets Settings Profiles
        public List<String> getSettingProfiles() {
            List<string> profiles = new List<string>();
            doc.Load(settingsFile);
            XmlNode root = doc.DocumentElement;

            // assigns settings profile and if it doesnt exist create it
            currentProfile = root.SelectSingleNode("descendant::currentSettingsProfile").InnerText;

            XmlNode parent = root.SelectSingleNode("descendant::Profiles");

            // Adds each profile to list
            foreach (XmlNode child in parent.ChildNodes) 
                profiles.Add(child.Name);

            return profiles;
        }

        // Creates Settings Dictionary From XML File
        public Dictionary<string, dynamic> createSettings() {
            profileList = getSettingProfiles();

            Dictionary<string, dynamic> tmpSettings = new Dictionary<string, dynamic>();

            doc.Load(settingsFile);
            XmlNode root = doc.DocumentElement;

            // loops through profiles
            foreach (string profile in profileList) {
                // creates new dictionary for profile
                tmpSettings[profile] = new Dictionary<string, dynamic>();

                XmlNode parent = root.SelectSingleNode("descendant::" + profile);
                // loops through categories
                foreach (XmlNode master in parent.ChildNodes) {
                    tmpSettings[profile][master.Name] = new Dictionary<string, dynamic>();
                    // loops through settings
                    foreach(XmlNode setting in master.ChildNodes) {
                        // converts to int if possible
                        try {
                            tmpSettings[profile][master.Name][setting.Name] = Convert.ToInt32(setting.InnerText);
                        }
                        // converts to boolean or saves as string
                        catch {
                            if(setting.InnerText.ToLower() == "false" || setting.InnerText.ToLower() == "true") tmpSettings[profile][master.Name][setting.Name] = Convert.ToBoolean(setting.InnerText);
                            else tmpSettings[profile][master.Name][setting.Name] = setting.InnerText;
                        }
                        // check for download location and sets to default if none is set
                        if(profile == "Default" && (setting.Name == "downloadPath" || setting.Name == "logPath"))
                            tmpSettings[profile][master.Name][setting.Name] = Environment.CurrentDirectory;
                        if (profile == "Default" && setting.Name == "lastCheck")
                            tmpSettings[profile][master.Name][setting.Name] = launchTime;
                    }
                }
            }
            return tmpSettings;
        }
        
        // Saves Settings To XML File
        public void saveSettings(bool saveAll = true) {
            doc.Load(settingsFile);
            XmlNode root = doc.DocumentElement;

            // loops through profiles
            foreach (string profile in settings.Keys) {
                // sets parent profile node
                XmlNode parentNode = root.SelectSingleNode("descendant::" + profile);

                // creates new setting if doesnt exist in file
                if (parentNode == null) newProfile(profile);

                // changes all settings
                if (saveAll) {
                    // loops through categories
                    foreach (string master in settings[profile].Keys) {
                        // sets master node
                        XmlNode masterNode = parentNode.SelectSingleNode("descendant::" + master);
                        // list of items to be removed
                        List<XmlNode> removeNodeList = new List<XmlNode>();
                        // loops through settings
                        foreach (string child in settings[profile][master].Keys) {
                            // assigns child node
                            XmlNode childNode = masterNode.SelectSingleNode("descendant::" + child);
                            //Console.WriteLine(childNode.ParentNode.Name);
                            // if node doesnt exist create it
                            if (childNode == null) childNode = masterNode.AppendChild(createNode(root, child));
                            // saves the node settings
                            if (profile != "Default") {
                                if (settings[profile][master][child] != settings["Default"][master][child])
                                    childNode.InnerText = Convert.ToString(settings[profile][master][child]);
                                // if settings is different set node for deletion
                                else removeNodeList.Add(childNode);

                            }

                            // saves default download location
                            if (profile == "Default" && (child == "downloadPath" || child == "logPath"))childNode.InnerText = Convert.ToString(settings[profile][master][child]);
                            // saves last update check
                            if (profile == "Default" && child == "lastCheck") childNode.InnerText = Convert.ToString(settings[profile][master][child]);
                        }

                        // Removes nodes that are the same as the default. Not sure why This needs to be included outside of main loop
                        for (int i = 0; i < removeNodeList.Count; i++) {
                            masterNode.RemoveChild(removeNodeList[i]);
                            settings[profile][master].Remove(removeNodeList[i].Name);
                        }
                    }
                }
            }

            // saves settings then updates them for Spectrum
            doc.Save(settingsFile);
        }
        
        // Creates A New Profile
        public void newProfile(string profileName) {
            settings[profileName] = new Dictionary<string, dynamic>();

            // adds profile to the document
            doc.Load(settingsFile);
            XmlNode root = doc.DocumentElement;
            root.SelectSingleNode("descendant::Profiles").AppendChild(createNode(root, profileName));
            doc.Save(settingsFile);

            profileList.Add(profileName);
        }

        // Creates A New Node
        private XmlNode createNode(XmlNode root, String nodeName) { return root.OwnerDocument.CreateElement(nodeName); }

    }

}