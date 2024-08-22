
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUPLauncher
{
    class PlayerTracking
    {
        public static void Update()
        {
            using (MySqlConnection con = new MySqlConnection($"Server=3.134.111.68;Port=3306;Database=suplauncher;Uid=suplauncher;Pwd=********;"))
            {   
                con.Open();
                MySqlCommand command = new MySqlCommand($"REPLACE INTO suplauncher (steamID, steamName, lastUsed) VALUES ('{frmLauncher.steam.GetSteamId()}', '{frmLauncher.Username.ToString()}', '{DateTime.Now.ToLongDateString()} - {DateTime.Now.ToLongTimeString()}');", con);
                command.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
