using System;
using System.IO;
using System.IO.IsolatedStorage;
using System.Text;

namespace gtt
{
    public class AppMemory
    {


        public string PlayerName
        {
            get { return this.GetValueOrDefault<string>("playerName", "Player"); }
            set { this.SaveValue("playerName", value); }
        }

        public uint HighScore
        {
            get { return this.GetValueOrDefault<uint>("highScore", 0); }
            set { this.SaveValue("highScore", value); }
        }

        public T GetValueOrDefault<T>(string key, T defaultValue)
        {
            if (IsolatedStorageSettings.ApplicationSettings.Contains(key))
                return (T) IsolatedStorageSettings.ApplicationSettings[key];

            return defaultValue;
        }

        public void SaveValue(string key, object value)
        {
            IsolatedStorageSettings.ApplicationSettings[key] = value;
            IsolatedStorageSettings.ApplicationSettings.Save();
        }
    }
}
