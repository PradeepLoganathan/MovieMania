using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Serialization;

namespace MovieMania.Core
{
    public static class LoadConfig
    {
        public static Dictionary<string, string> ConfigValues = new Dictionary<string, string>();

        public static void Load()
        {
            try
            {
                var assembly = typeof(LoadConfig).GetTypeInfo().Assembly;
                Stream stream = assembly.GetManifestResourceStream("MovieMania.Core.MovieManiaConfig.cfg");

                string text = "";
                using (var reader = new StreamReader(stream))
                {
                    text = reader.ReadToEnd();
                    string[] ConfigSets = text.Split('^');
                    foreach (string config in ConfigSets)
                    {
                        string[] Configs = config.Split('~');
                        ConfigValues.Add(Configs[0], Configs[1]);
                    }
                }
            }
            catch (Exception e)
            {

            }


        }
    }
    
}