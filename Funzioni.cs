using System.Net.NetworkInformation;
using System.Reflection;
using System.Diagnostics;

namespace RemoDome
{
    public static class Funzioni
    {
        #region Variabili

        //public readonly static string PWS = "l'uomo delle lampadine";
        //public readonly static double X = -0.11, Y = -0.2, Z = 0.12;  //centro di massa della montatura...X=-0.11 Y=-0.02 Z=0.12
        //public readonly static double THETA = 10;  //latitudine in radianti
        public readonly static double NUMERO_PIEDINI = 489;
        public readonly static double OFFSET_ASTRO_PHYSICS = 0;  //offset per il 180
        public readonly static double OFFSET_RITCHEY_CHRETIEN = 50;  //offset per il 400
        public readonly static double RA = 5;  //raggio della cupola
        public readonly static int GENERAL_OFFSET = 3;  //offset in numero di piedini
        public readonly static double DOME_WIDTH = 1.16;  //apertura in metri
        public readonly static double DOME_WIDTH_FOOT = DOME_WIDTH * NUMERO_PIEDINI / (2 * Math.PI * RA);  //apertura della specola in numero di piedini
        public readonly static string CONFIG_FILE_NAME = "config.gttbntt";  //file di configurazione del sistema
        public static bool connection = false;
        public static bool SYSTEM_IS_CONNECTED = false;  //Indica lo stato connesso o meno del sistema
        public static Allineamenti currentAllignment = Allineamenti.AstroPhysics;
        public readonly static string cameraIP = "http://10.136.2.63:85/";
//        public readonly static string helpMessage =
//            "RemoDome " + Assembly.GetEntryAssembly().GetName().Version + " developed by " + " - " + ((AssemblyCompanyAttribute)Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(AssemblyCompanyAttribute), false)).Company + @"
//
//Software di controllo completo dello stato della specola e della montatura. Adattatato alla configurazione della
//cupola dell'Associazione Astrofili Mantovani. L'intero progetto di remotizzazione comprende una parte hardware
//relativa alla fisica connessione/comunicazione fra le parti ed una parte software per lo scambio dati fra di esse.
//Di seguito elencati i maggiori flussi di comunicazione in ordine di complessità e di impegno delle risorse:
//- computer di controllo -> montatura
//- computer di controllo -> pannello di alimentazione
//- montatura -> ricevitore GPS
//- computer di controllo -> sensore di pioggia.
//Il progetto dell'elettronica e dell'hardware è stato realizzato da Marco Benatti, mentre lo sviluppo software da
//Riccardo Gatti. Si ringraziano tutti i soci che nelle più diverse occasioni si sono resi disponibile per un aiuto.
//
//-----------------------------------------------------------------------------------------------------------------
//
//All'apertura del programma una schermata propone di comunicare lo stato iniziale della cupola rilevano se il
//pannello di alimentazione e la montatura all'avvio siano già accesi o meno.
//La schermata principale del programma si divide in tre sezioni:
//- in alto a sinistra i controlli di gestione della cupola
//- in basso a sinistra lo stato del computer di controllo
//- a destra lo streaming live della cupola per assicurare l'assenza di errori.
//
//Il programma ricerca in automatico le porte seriali connesso al computer e controllo se fra queste ve ne sono di
//già settate per la comunicazione direzione montatura e direzione cupola. Nel caso si utilizzi una nuova seriale
//sarà sufficiente, una volta selezionata, spuntare la casellina a fianco del menù. All'avvio successivo il
//programma preferirà la selezione di quella nuova porta seriale. Lo stesso vale per il tipo di allineamento.
//Dopo aver selezionato le porte corrette, alla pressione del tasto " + "\"Connetti\"" + @" il sistema stabilisce la
//connessione con il pannello di alimentazione e la montatura ed inizia la comunicazione.
//ATTENZIONE: In fase di accensione, la montatura è collegata al GPS così da poter ottenere posizione e orario,
//    è fondamentale che la comunicazione venga spostata sulla porta seriale così da poter interagire con il
//    programma. Tramite la pulsantiera si procede come segue:
//    Menù -> Impostazioni -> Porta GPS -> Seriale -> OK
//    Da questo momento in poi la montatura comunicherà correttamente con il programma
//Con la pressione del tasto " + "\"Muovi\"" + @" si mette in movimento la montatura togliendola dalla posizione di
//parcheggio e dalla pressio del tasto " + "\"Insegui\"" + @" in poi la cupola inizierà a ruotare inseguendo il
//targhet allineato all'asse ottico del telescopio scelto.
//Il pulsante che all'avvio è nominato come " + "\"Cupola\"" + @" permette l'apertura e la chiusura della specola a
//seconda dello stato attuale (in caso di specola aperta permette la chiusura e vice versa).
//I pulsanti " + "\"Sinistra\" e \"Destra\"" + @" permettono piccole correzione della posizione della cupola ruotandola
//rispettivamente a sinistra ed a destra.
//Il punlsante " + "\"Parcheggia\"" + @" effettua il parcheggio sia della montatura che della cupola, mentre il pulsante " +
//            "\"Stop\"" + @" ferma immediatamente solo il movimento della montatura
//La casetta aggiorna la schermata del live streaming e riporta il programma all'indirizzo IP di default al quale si
//trova la camera infrarossi che in questo caso vale: " + cameraIP + ".";

        #endregion Variabili

        public static string GetStatus(string keyName)
        {
            try
            {
                string[] fileLines = File.ReadAllLines(CONFIG_FILE_NAME);
                foreach (string fileLine in fileLines)
                {
                    if (fileLine.Split('=')[0] == keyName)
                    {
                        return fileLine.Split('=')[1];
                    }
                }
            }
            catch (Exception ex)
            {
                Messaggi.ShowException("Eccezione al GetStatus:", ex);
            }
            return "Chiave non trovata";
        }

        public static void SetStatus(string keyName, string value)
        {
            try
            {
                string[] fileLines = File.ReadAllLines(CONFIG_FILE_NAME);
                int i = 0;
                for (i = 0; i < fileLines.Count(); i++)
                {
                    if (fileLines[i].Split('=')[0] == keyName)
                        break;
                }
                fileLines[i] = keyName + "=" + value;

                File.WriteAllLines(CONFIG_FILE_NAME, fileLines);
            }
            catch (Exception ex)
            {
                Messaggi.ShowException("Errore al SetStatus", ex);
            }
        }

        public static void ComparsaScomparsaColorazione(FrontEnd frontEnd)
        {
            if (Funzioni.GetStatus("PANNELLO").Equals("ON"))
            {
                frontEnd.button_accendi_pannello.Text = "Spegni pannello";
                frontEnd.button_accendi_pannello.BackColor = Color.Green;
            }
            else if (Funzioni.GetStatus("PANNELLO").Equals("OFF"))
            {
                frontEnd.button_accendi_pannello.Text = "Accendi pannello";
                frontEnd.button_accendi_pannello.BackColor = Color.Red;

                frontEnd.button_accendi.Visible = false;
                frontEnd.button_muovi.Visible = false;
                frontEnd.button_accendi_pannello.Visible = false;
                frontEnd.button_cupola.Visible = false;
                frontEnd.button_piu.Visible = false;
                frontEnd.button_insegui.Visible = false;
                frontEnd.button_meno.Visible = false;
                frontEnd.button_parcheggia.Visible = false;
                frontEnd.button_accendi.Visible = false;
            }

            if (Funzioni.GetStatus("MONTATURA").Equals("ON"))
            {
                frontEnd.button_accendi.Text = "Spegni montatura";
                frontEnd.button_accendi.BackColor = Color.Green;
                frontEnd.button_accendi_pannello.Visible = false;
            }
            else if (Funzioni.GetStatus("MONTATURA").Equals("OFF"))
            {
                frontEnd.button_accendi.Text = "Accendi montatura";
                frontEnd.button_accendi.BackColor = Color.Red;

                frontEnd.button_accendi.Visible = false;
                frontEnd.button_muovi.Visible = false;
                frontEnd.button_accendi_pannello.Visible = true;
                frontEnd.button_cupola.Visible = false;
                frontEnd.button_piu.Visible = false;
                frontEnd.button_insegui.Visible = false;
                frontEnd.button_meno.Visible = false;
                frontEnd.button_parcheggia.Visible = false;
            }
        }

        public static double P_M(double azimut, ref string azimutString)
        {
            try
            {
                azimutString = Math.Round(azimut, 2).ToString();
                azimut = Math.PI * azimut / 180;  //da gradi a radianti
                double posizioneMontatura = (180 * azimut / Math.PI) * NUMERO_PIEDINI / 360 + DOME_WIDTH_FOOT / 2 * Math.Cos(azimut / 2);

                if (currentAllignment == Allineamenti.AstroPhysics)
                    posizioneMontatura += OFFSET_ASTRO_PHYSICS;
                if (currentAllignment == Allineamenti.RitcheyChrétien)
                    posizioneMontatura += OFFSET_RITCHEY_CHRETIEN;

                return posizioneMontatura;
            }
            catch (Exception ex)
            {
                Messaggi.ShowError("Errore in P_M: " + ex.Message);
                return 0;
            }
        }

        public static void CheckForAnotherIstance()
        {
            if (System.Diagnostics.Process.GetProcessesByName(Path.GetFileNameWithoutExtension(Assembly.GetEntryAssembly().Location)).Count() > 1)
            {
                Messaggi.ShowWarning("Un altra istanza del programma è già in esecuzione");
                Application.Exit();
            }
        }

        public static void CheckForInternetConnection()
        {
            try
            {
                Ping myPing = new Ping();
                String host = "google.com";
                byte[] buffer = new byte[32];
                int timeout = 2000;
                PingOptions pingOptions = new PingOptions();
                PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
                connection = reply.Status == IPStatus.Success;
            }
            catch
            {
                connection = false;
                Messaggi.ShowWarning("Connessione a internet assente");
            }
        }

        public static void Wait(int millis, ProgressBar progressBar)
        {
            int step = 100;
            progressBar.Visible = true;
            progressBar.Minimum = 0;
            progressBar.Maximum = millis;
            for (int i = 0; i < millis; i = i + step)
            {
                progressBar.Value = i;
                Thread.Sleep(step);
            }
            progressBar.Visible = false;
        }

        public static void ControlRemoteOperations()
        {
            //TODO
        }

        public static void PcStatus(RichTextBox rtb)
        {
            rtb.Text = "Parametri sistema" + Environment.NewLine + Environment.NewLine;

            //Utilizzo CPU
            PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            rtb.Text += "CPU: " + cpuCounter.NextValue() + "%" + Environment.NewLine;

            //Utilizzo RAM
            PerformanceCounter ramCounter = new PerformanceCounter("Memory", "Available MBytes");
            rtb.Text += "RAM: " + ramCounter.NextValue() + "MB" + Environment.NewLine;

            //Temperatura processore
            //ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\WMI", "SELECT * FROM MSAcpi_ThermalZoneTemperature");
            //ManagementObjectCollection collection = searcher.Get();
            //
            //foreach (ManagementBaseObject tempObject in collection)
            //{
            //    rtb.Text += "Temperatura processore: " + ((Convert.ToDouble(tempObject["CurrentTemperature"]) / 10) - 273.15).ToString() + Environment.NewLine;
            //}

            //Tempo di esecuzione
            rtb.Text += "Tempo di esecuzione: " + (DateTime.UtcNow - Process.GetCurrentProcess().StartTime.ToUniversalTime()).ToString();
        }

        public enum Allineamenti
        {
            AstroPhysics,
            RitcheyChrétien
        }
    }
}