using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.IO.Ports;

namespace OperationConsole
{
    class OperationConsole
    {
        static void Main(string[] args)
        {
            while (true)
            {
                remoteOperations();
            }
        }

        //Questa funzione viene eseguita dal frontEnd del pannello di controllo
        private static void remoteOperations()
        {
            try
            {
                string dirToLook = Funzioni.getStatus("SCRIPT_FOLDER");  //E' li file sul quale si trova il frontEnd del controllo cupola non quello dell'utente

                //Si prende i file che ci sono nella directory e solo quelli che iniziano con Script
                List<String> listFileInDir = Directory.GetFiles(dirToLook).ToList();
                listFileInDir = listFileInDir.FindAll(name => name.Split(new String[] { "\\" }, StringSplitOptions.None).Last().StartsWith("Script"));

                //Se non ci sono file non si fa niente
                if (listFileInDir.Count() < 1)
                {
                    return;
                }

                Funzioni.log("\n***********GESTIONE AUTOMATICA***********");

                //Ordina i file ed analizza solo il più recente
                listFileInDir = listFileInDir.OrderByDescending(name => name.Split(new String[] { "\\" }, StringSplitOptions.None).Last().Replace("Script", "").Split('.')[0]).ToList();

                string fileToConsider = listFileInDir[0];
                Funzioni.log("Considerato il file " + fileToConsider);

                List<String> linesOfFileToConsider = File.ReadAllLines(fileToConsider).ToList();
                string montComName = "COM4"; // Funzioni.getStatus("COM_MONTATURA");
                Funzioni.log("Seriale arduino: " + montComName);

                string arduComName = "COM9"; // Funzioni.getStatus("COM_ARDUINO");
                Funzioni.log("Seriale montatura: " + arduComName);

                SerialPort montCom = new SerialPort(montComName, 9600, Parity.None, 8, StopBits.One);
                Funzioni.log("Costruito oggetto montCom");

                SerialPort arduCom = new SerialPort(arduComName, 9600, Parity.None, 8, StopBits.One);
                Funzioni.log("Costruito oggetto arduCom");

                //montCom.Open();
                Funzioni.log("Aperta connessione a montCom");

                //arduCom.Open();
                Funzioni.log("Aperta connessione a arduCom");

                foreach (string operationToDo in linesOfFileToConsider)
                {
                    Funzioni.log("- - - Operazione da svolgere: " + operationToDo + " - - -");

                    #region Operazioni predefinite

                    switch (operationToDo)
                    {
                        case "":
                            {
                                Funzioni.log("Entrato in esecuzione su messaggio vuoto");
                            }
                            break;
                        case "Parcheggia montatura":
                            {
                                Funzioni.log("Entrato in esecuzione: \"Parcheggia montatura\"");
                                Funzioni.log("Invio messaggio di parcheggio");
                                //montCom.WriteLine(":KA#");
                                Funzioni.log("Messaggio di parcheggio montatura :KA# inviato");
                            }
                            break;
                        case "Parcheggia cupola":
                            {
                                Funzioni.log("Entrato in esecuzione: \"Parcheggia cupola\"");
                                Funzioni.log("Invio messaggio di parcheggio cupola");
                                //arduCom.WriteLine("Q");
                                Funzioni.log("Messaggio di parcheggio cupola Q inviato");
                            }
                            break;
                        case "Chiudi specola":
                            {
                                Funzioni.log("Entrato in esecuzione: \"Chiudi specola\"");
                                Funzioni.log("Invio messaggio di chiusura specola");
                                //arduCom.WriteLine("c");
                                Funzioni.log("Messaggio di chiusura specola inviato");

                            }
                            break;
                        case "Apri specola":
                            {
                                Funzioni.log("Entrato in esecuzione: \"Apri specola\"");
                                Funzioni.log("Invio messaggio di apertura specola");
                                //arduCom.WriteLine("C");
                                Funzioni.log("Messaggio di apertura specola inviato");
                            }
                            break;
                        case "Muovi montatura":
                            {
                                Funzioni.log("Entrato in esecuzione: \"Muovi montatura\"");
                                Funzioni.log("Invio messaggio di movimento montatura");

                                Funzioni.log("Messaggio di movimento montatura inviato");
                            }
                            break;
                        case "Spegni montatura":
                            {
                                Funzioni.log("Entrato in esecuzione: \"Parcheggia montatura\"");
                                Funzioni.log("Invio messaggio di spegnimento montatura");

                                Funzioni.log("Messaggio di spegnimento montatura inviato");
                            }
                            break;
                        case "Spegni pannello":
                            {
                                Funzioni.log("Entrato in esecuzione: \"Spegni montatura\"");
                                Funzioni.log("Invio messaggio di spegnimento pannello");

                                Funzioni.log("Messaggio di spegnimento pannello inviato");

                            }
                            break;
                        case "Accendi montatura":
                            {
                                Funzioni.log("Entrato in esecuzione: \"Accendi montatura\"");
                                Funzioni.log("Invio messaggio di accensione montatura");

                                Funzioni.log("Messaggio di accensione montatura inviato");

                            }
                            break;
                        case "Accedi pannello":
                            {
                                Funzioni.log("Entrato in esecuzione: \"Accendi pannello\"");
                                Funzioni.log("Invio messaggio di accensione pannello");

                                Funzioni.log("Messaggio di accensione pannello inviato");

                            }
                            break;
                        case "Blocca tutto":
                            {
                                Funzioni.log("Entrato in esecuzione: \"Blocca tutto\"");
                                Funzioni.log("Invio messaggio di bloccaggio totale");

                                Funzioni.log("Messaggio di bloccaggio totale inviato");

                            }
                            break;
                        case "Sblocca tutto":
                            {
                                Funzioni.log("Entrato in esecuzione: \"Sblocca tutto\"");
                                Funzioni.log("Invio messaggio di sbloccaggio totale");

                                Funzioni.log("Messaggio di sbloccaggio totale inviato");

                            }
                            break;

                        //TODO - A piacere si aggiungono altri comandi con altri nomi

                        default:
                            {
                                Funzioni.log("Messaggio non interpretato");
                            }
                            break;
                    }

                    #endregion Operazioni predefinite
                }

                Funzioni.log("Esecuzione operazioni terminata");

                //Il file eseguito viene rinominato con DONE all'inizio del nome del file
                string executedFileToConsider = fileToConsider.Replace(fileToConsider.Split(new String[] { "\\" }, StringSplitOptions.None).Last(),
                                                                       "DONE" + fileToConsider.Split(new String[] { "\\" }, StringSplitOptions.None).Last());
                File.Move(fileToConsider, executedFileToConsider);
                Funzioni.log("File rinominato il " + executedFileToConsider);
            }
            catch (Exception ex)
            {
                Funzioni.log("Errore: " + ex.Message);
            }
        }
    }
}