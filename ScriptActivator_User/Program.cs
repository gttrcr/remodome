using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ScriptActivator
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string dirToLook = Funzioni.getStatus("SCRIPT_FOLDER");

                //Lista di tutti i file contenuti in dirToLook
                List<String> listFileInDir = Directory.GetFiles(dirToLook).ToList();
                listFileInDir = listFileInDir.FindAll(name => name.Split(new String[] { "\\" }, StringSplitOptions.None).Last().StartsWith("TODOScript"));

                //Se non ci sono file non si fa niente
                if (listFileInDir.Count() < 1)
                {
                    throw new Exception("FNF");
                }

                //Ordina i file ed analizza solo il più recente
                listFileInDir = listFileInDir.OrderByDescending(name => name.Split(new String[] { "\\" }, StringSplitOptions.None).Last().Replace("TODOScript", "").Split('.')[0]).ToList();

                string fileToActivate = listFileInDir[0];

                //Il file eseguito viene rinominato con DONE all'inizio del nome del file
                string activatedFile = fileToActivate.Replace(fileToActivate.Split(new String[] { "\\" }, StringSplitOptions.None).Last(),
                                                              fileToActivate.Split(new String[] { "\\" }, StringSplitOptions.None).Last().Replace("TODO", ""));
                File.Move(fileToActivate, activatedFile);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Errore: " + ex.Message);
                if (ex.Message == "FNF")
                {
                    Console.WriteLine("Non è stato trovato nessun file attivabile:\n" +
                        "- E' stato creato il file?\n" +
                        "- Si trova nella cartella predefinita?\n" +
                        "- C'è connessione internet?\n" +
                        "- Il file è raggiungibile?\n" +
                        "- Il file è in uso da un qualche altro processo?");
                }
                Console.ReadLine();
            }
        }
    }
}