using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationConsole
{
    class Funzioni
    {
        public static string CONFIG_FILE = "GlobalConfigFile.gttbntt";  //il file deve essere quello da cui attinge il pannello di controllo della cupola
        public static string LOG_PATH = DateTime.Now.Day.ToString().PadLeft(2, '0') + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Year.ToString() + ".gttbntt";  //File di log in caso di errore

        public static string getStatus(string keyName)
        {
            List<String> fileLines = File.ReadAllLines(CONFIG_FILE).ToList();

            foreach (string fileLine in fileLines)
            {
                if (fileLine.Split('=')[0] == keyName)
                {
                    return fileLine.Split('=')[1].Substring(1).Substring(0, fileLine.Split('=')[1].Substring(1).Length - 1);
                }
            }
            return "Chiave non trovata";
        }

        public static void setStatus(string keyName, string keyValue)
        {
            //TODO
        }

        public static string extractValue(string key)
        {
            key = key.Split('=')[1];
            key = key.Substring(1);
            return key.Substring(0, key.Length - 1);
        }

        public static void log(string message)
        {
            message = DateTime.Now + "\t" + message + Environment.NewLine;
            Console.Write(message);
            File.AppendAllText(LOG_PATH, message);
        }
    }
}