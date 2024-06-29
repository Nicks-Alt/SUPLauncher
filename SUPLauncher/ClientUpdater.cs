using Microsoft.VisualBasic;

using System.Diagnostics;
using System.Net;
using System.Security.Principal;

namespace SUPLauncher
{
    class ClientUpdater
    {

    public static void Update()
    {
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12; // Secure security protocol for querying the github API
        HttpWebRequest request = WebRequest.CreateHttp("http://api.github.com/repos/Nicks-Alt/SUPLauncher/releases/latest");
        request.UserAgent = "Nick";
        WebResponse response = null;
        response = request.GetResponse(); // Get Response from webrequest
        StreamReader sr = new StreamReader(response.GetResponseStream()); // Create stream to access web data
        string currentRecord = sr.ReadToEnd(); // Read data from response stream
        var webData = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(currentRecord); // Deserialize JSON
        string newestVersion = webData.tag_name;
        string currentVersion = Program.Version; // Get current version of assembly
            if (newestVersion.Contains(currentVersion) == false) // If current program is not newest version -
            {
                if (Interaction.MsgBox("You do not have the lastest version(" + newestVersion + "). Would you like to go download the latest version?", MsgBoxStyle.YesNo, "Download latest version") == MsgBoxResult.Yes) // If they choose to update
                {
                    Program.OpenURL("https://github.com/Nicks-Alt/SUPLauncher/releases/latest");
                }
            }
    }

        public static bool checkForUpdates()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12; // Secure security protocol for querying the github API
            HttpWebRequest request = WebRequest.CreateHttp("http://api.github.com/repos/nickiscool1022/SUPLauncher/releases/latest");
            request.UserAgent = "Nick";
            WebResponse response = null;
            response = request.GetResponse(); // Get Response from webrequest
            StreamReader sr = new StreamReader(response.GetResponseStream()); // Create stream to access web data
            string currentRecord = sr.ReadToEnd(); // Read data from response stream
            var webData = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(currentRecord); // Deserialize JSON
            string newestVersion = webData.tag_name; // Get newest version
            string currentVersion = Program.Version; // Get current version of assembly
            if (newestVersion.Contains(currentVersion) == false) // If current program is not newest version -
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}
