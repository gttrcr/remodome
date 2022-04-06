using System.IO.Ports;
using System.Reflection;

namespace RemoDome
{
    public partial class FrontEnd : Form
    {
        bool evento_muovi = false;
        bool evento_insegui = false;
        bool evento_parcheggia = false;

        public FrontEnd()
        {
            try
            {
                InitializeComponent();
                Text += " " + Assembly.GetEntryAssembly().GetName().Version;

                webBrowser.Navigate(new Uri(Funzioni.cameraIP));

                foreach (string DISP in SerialPort.GetPortNames())
                {
                    ComboBox_porta_montatura.Items.Add(DISP);
                    ComboBox_porta_arduino.Items.Add(DISP);
                }

                ComboBox_porta_montatura.SelectedItem = Funzioni.GetStatus("COM_MONTATURA");
                ComboBox_porta_arduino.SelectedItem = Funzioni.GetStatus("COM_ARDUINO");
                ComboBox_all_nto.SelectedItem = Funzioni.GetStatus("ALL_NTO");

                FormClosing += new FormClosingEventHandler(Ti_sconnetto_alla_chiusura);

                Funzioni.ComparsaScomparsaColorazione(this);
            }
            catch (Exception ex)
            {
                Messaggi.ShowException("Errore al caricamento FrontEnd", ex);
            }
        }

        private void Ti_sconnetto_alla_chiusura(object sender, EventArgs e)
        {
            try
            {
                if (Funzioni.GetStatus("MONTATURA").Equals("ON"))
                    if (Messaggi.YesNo("E' stata richiesta la chiusura del programma. Non è sicuro procedere se la montatura non è stata spenta correttamente. Spegnere?") == DialogResult.Yes)
                    {
                        AccendiMontatura();
                        Funzioni.SetStatus("MONTATURA", "OFF");
                    }

                if (Funzioni.GetStatus("PANNELLO").Equals("ON"))
                    if (Messaggi.YesNo("E' stata richiesta la chiusura del programma. Non è sicuro procedere se la montatura non è stata spenta correttamente. Spegnere?") == DialogResult.Yes)
                    {
                        SpegniPannello();
                        Funzioni.SetStatus("PANNELLO", "OFF");
                    }

                if (ARDU.IsOpen)
                {
                    ARDU.WriteLine("g");
                    richTextBoxCommunication.Text += Environment.NewLine + "Send g to Arduino. N.:1";
                    ARDU.Close();
                }

                if (MONT.IsOpen)
                    MONT.Close();

                Application.Exit();
            }
            catch (Exception ex)
            {
                Messaggi.ShowException("Errore Ti_sconnetto_alla_chiusura", ex);
            }
        }

        private void ComboBox_porta_montatura_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ComboBox_porta_montatura.SelectedItem.Equals(ComboBox_porta_arduino.SelectedItem))
                    Messaggi.ShowWarning("Montatura e cupola settati sulla medesima porta");

                if (checkBox_default_montatura.Checked)
                    Funzioni.SetStatus("COM_MONTATURA", ComboBox_porta_montatura.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
                Messaggi.ShowException("Errore in ComboBox_porta_montatura_SelectedIndexChanged", ex);
            }
        }

        private void ComboBox_porta_arduino_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ComboBox_porta_arduino.SelectedItem.Equals(ComboBox_porta_montatura.SelectedItem))
                    Messaggi.ShowError("Cupola e montatura settati sulla medesima porta");

                if (checkBox_default_arduino.Checked)
                    Funzioni.SetStatus("COM_ARDUINO", ComboBox_porta_arduino.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
                Messaggi.ShowException("Errore in ComboBox_porta_arduino_SelectedIndexChanged", ex);
            }
        }

        private void ComboBox_all_nto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBox_default_all_nto.Checked)
                    Funzioni.SetStatus("ALL_NTO", ComboBox_all_nto.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
                Messaggi.ShowException("Errore al ComboBox_all_nto_SelectedIndexChanged", ex);
            }
        }

        private void Button_connetti_Click(object sender, EventArgs e)
        {
            try
            {
                if (button_connetti.Text.Equals("Connetti"))
                {
                    if (!Object.Equals(ComboBox_porta_montatura.SelectedItem, null) && !Object.Equals(ComboBox_porta_arduino.SelectedItem, null) && !Object.Equals(ComboBox_all_nto.SelectedItem, null))
                    {
                        MONT.Close();
                        MONT.PortName = ComboBox_porta_montatura.SelectedItem.ToString();
                        MONT.BaudRate = 9600;
                        MONT.DataBits = 8;
                        MONT.Parity = Parity.None;
                        MONT.StopBits = StopBits.One;
                        MONT.Handshake = Handshake.None;
                        MONT.Encoding = System.Text.Encoding.Default; //molto importante!!!
                        MONT.ReadTimeout = 10000;
                        MONT.Open();

                        ARDU.Close();
                        ARDU.PortName = ComboBox_porta_arduino.SelectedItem.ToString();
                        ARDU.BaudRate = 9600;
                        ARDU.DataBits = 8;
                        ARDU.Parity = Parity.None;
                        ARDU.StopBits = StopBits.One;
                        ARDU.Handshake = Handshake.None;
                        ARDU.Encoding = System.Text.Encoding.Default; //molto importante!!!
                        ARDU.ReadTimeout = 10000;
                        ARDU.Open();

                        timer_refresh.Enabled = true;
                        timer_refresh.Start();

                        button_connetti.Text = "Disconnetti";
                        if (Funzioni.GetStatus("MONTATURA").Equals("OFF"))
                            button_accendi_pannello.Visible = true;
                        if (Funzioni.GetStatus("MONTATURA").Equals("ON"))
                            ARDU.WriteLine("G");
                        if (Funzioni.GetStatus("PANNELLO").Equals("OFF"))
                            button_accendi_pannello.Visible = true;
                        if (Funzioni.GetStatus("PANNELLO").Equals("ON"))
                            button_accendi_pannello.Visible = true;

                        if (ComboBox_all_nto.SelectedIndex == (int)Funzioni.Allineamenti.AstroPhysics)
                            Funzioni.currentAllignment = Funzioni.Allineamenti.AstroPhysics;
                        else if (ComboBox_all_nto.SelectedIndex == (int)Funzioni.Allineamenti.RitcheyChrétien)
                            Funzioni.currentAllignment = Funzioni.Allineamenti.RitcheyChrétien;

                        Funzioni.SYSTEM_IS_CONNECTED = !Funzioni.SYSTEM_IS_CONNECTED;
                    }
                    else
                    {
                        MessageBox.Show("Selezionare una porta o un allineamento adeguato", "Cupola Remota");
                    }
                }
                else if (button_connetti.Text.Equals("Disconnetti"))
                {
                    ARDU.WriteLine("g");
                    richTextBoxCommunication.Text += Environment.NewLine + "Send g to Arduino. N.:2";
                    MONT.Close();
                    ARDU.Close();
                    timer_refresh.Stop();
                    button_connetti.Text = "Connetti";
                }
            }
            catch (Exception ex)
            {
                Messaggi.ShowException("Errore in button_connetti_Click", ex);
            }
        }

        private void Button_cupola_Click(object sender, EventArgs e)
        {
            try
            {
                if (button_cupola.Text.Equals("Apri portellone"))
                {
                    ARDU.WriteLine("C");
                    richTextBoxCommunication.Text += Environment.NewLine + "Send C to Arduino. N.:3";
                    button_cupola.Text = "Chiudi portellone";
                }
                else if (button_cupola.Text.Equals("Chiudi portellone"))
                {
                    ARDU.WriteLine("c");
                    richTextBoxCommunication.Text += Environment.NewLine + "Send c to Arduino. N.:4";
                    button_cupola.Text = "Apri portellone";
                }
            }
            catch (Exception ex)
            {
                Messaggi.ShowException("Errore in button_cupola_Click", ex);
            }
        }

        private void Button_muovi_Click(object sender, EventArgs e)
        {
            evento_muovi = true;
            evento_insegui = false;
            evento_parcheggia = false;
        }

        private void Button_insegui_Click(object sender, EventArgs e)
        {
            evento_muovi = false;
            evento_insegui = true;
            evento_parcheggia = false;
        }

        private void Button_parcheggia_Click(object sender, EventArgs e)
        {
            evento_muovi = false;
            evento_insegui = false;
            evento_parcheggia = true;

            ARDU.WriteLine("Q");
            richTextBoxCommunication.Text += Environment.NewLine + "Send Q to Arduino. N.:5";
            Funzioni.Wait(30000, progressBar);
            Messaggi.Show("Parcheggio cupola avvenuto con successo");
        }

        private void Button_stop_Click(object sender, EventArgs e)
        {
            try
            {
                RiceviDatiMONT(":STOP#:STOP#");
            }
            catch (Exception ex)
            {
                Messaggi.ShowException("Errore al Button_stop_click", ex);
            }
        }

        private void Timer_refresh_Tick(object sender, EventArgs e)
        {
            try
            {
                Funzioni.ControlRemoteOperations();
                Funzioni.PcStatus(richTextBox_computerStatus);

                if (evento_muovi)
                {
                    Muovi();
                    button_cupola.Text = StatoPortellone();
                }
                else if (evento_insegui)
                {
                    Insegui();
                    //label_stato_montatura.Text = StatoMontatura();
                }
                else if (evento_parcheggia)
                    Parcheggia();
            }
            catch (Exception ex)
            {
                Messaggi.ShowException("Errore in timer_refresh_Tick", ex);
                timer_refresh.Stop();
            }
        }

        private string StatoPortellone()
        {
            try
            {
                switch (RiceviDatiARDU("B"))
                {
                    case "M":
                        return String.Empty;
                    case "C":
                        return "Apri portellone";
                    case "A":
                        return "Chiudi portellone";
                    case "O":
                        return String.Empty;
                    default:
                        return String.Empty;
                }
            }
            catch (Exception ex)
            {
                timer_refresh.Stop();
                Messaggi.ShowException("Errore in StatoPortellone", ex);
                return "---";
            }
        }

        private void ControlloPioggia()
        {
            try
            {
                string piove = RiceviDatiARDU("E");
                if (piove.Equals("P"))
                {
                    MessageBox.Show("ATTENZIONE!! Piove", "Cupola Remota");
                    label_pioggia.Text = "Piove";
                    ARDU.WriteLine("Q");
                    richTextBoxCommunication.Text += Environment.NewLine + "Send Q to Arduino. N.:6";
                    MONT.WriteLine(":KA#:KA#");
                    timer_refresh.Stop();
                }
                else if (piove.Equals("NP"))
                {
                    label_pioggia.Text = "Non piove";
                }
            }
            catch (Exception ex)
            {
                Messaggi.ShowException("Errore al ControlloPioggia", ex);
            }
        }

        private string RiceviDatiMONT(string invio_dati)
        {
            string dati_ricevuti = String.Empty;
            MONT.WriteLine(invio_dati);
            label_invio_a_montatura.Text = invio_dati;
            try
            {
                dati_ricevuti = MONT.ReadExisting();
                if (dati_ricevuti.Equals(null))
                    return "---";
                else
                    return dati_ricevuti;
            }
            catch (Exception ex)
            {
                Messaggi.ShowException("Errore in ricevi_dati_MONT", ex);
                return "---";
            }
        }

        private string RiceviDatiARDU(string invio_dati)
        {
            string dati_ricevuti = String.Empty;
            ARDU.WriteLine(invio_dati);
            int nProve = 100, nTest = 0;
            try
            {
                while (String.IsNullOrWhiteSpace(dati_ricevuti) && String.IsNullOrEmpty(dati_ricevuti) && nTest < nProve)
                {
                    dati_ricevuti = ARDU.ReadExisting();
                    nTest++;
                }
                return dati_ricevuti;
            }
            catch (Exception ex)
            {
                Messaggi.ShowException("Errore in ricevi_dati_ARDU", ex);
                return "---";
            }
        }

        private void Muovi()
        {
            try
            {
                RiceviDatiMONT(":PO#:PO#");
            }
            catch (Exception ex)
            {
                Messaggi.ShowException("Errore al Muovi", ex);
            }
        }

        private void Button_piu_Click(object sender, EventArgs e)
        {
            try
            {
                ARDU.WriteLine("d");
                richTextBoxCommunication.Text += Environment.NewLine + "Send d to Arduino. N.:7";
            }
            catch (Exception ex)
            {
                Messaggi.ShowException("Errore al Button_piu_Click", ex);
            }
        }

        private void Button_meno_Click(object sender, EventArgs e)
        {
            try
            {
                ARDU.WriteLine("s");
                richTextBoxCommunication.Text += Environment.NewLine + "Send s to Arduino. N.:8";
            }
            catch (Exception ex)
            {
                Messaggi.ShowException("Errore al Button_meno_Click", ex);
            }
        }

        private void Button_accendi_Click(object sender, EventArgs e)
        {
            try
            {
                AccendiMontatura();
            }
            catch (Exception ex)
            {
                Messaggi.ShowException("Errore al Button_accendi_Click", ex);
            }
        }

        private void AccendiMontatura()
        {
            try
            {
                if (Funzioni.GetStatus("MONTATURA").Equals("OFF"))
                {
                    ARDU.WriteLine("A");
                    if (Messaggi.YesNo("Ricerca satelliti in corso, non sarà possibile agire sul programma...") == DialogResult.Yes)
                        Funzioni.Wait(90000, progressBar);
                    else
                        return;

                    Funzioni.SetStatus("MONTATURA", "ON");
                    button_accendi_pannello.Visible = false;
                    Messaggi.ShowWarning("ATTENZIONE!! Settare la porta seriale della montatura da tastierino.\n\t- Menù\n\t- Impostazioni\n\t- Porta GPS\n\t- Seriale\n\t- OK");
                    ARDU.WriteLine("VG");
                    richTextBoxCommunication.Text += Environment.NewLine + "Send VG to Arduino. N.:9";
                    button_accendi.Text = "Spegni montatura";
                    button_accendi.BackColor = Color.Green;

                    button_muovi.Visible = true;
                    button_cupola.Visible = true;
                    button_piu.Visible = true;
                    button_insegui.Visible = true;
                    button_meno.Visible = true;
                    button_parcheggia.Visible = true;
                }
                else if (Funzioni.GetStatus("MONTATURA").Equals("ON"))
                {
                    if (Messaggi.YesNo("ATTENZIONE!! Settare la porta GPS della montatura da tastierino.\n\t- Menù\n\t- Impostazioni\n\t- Porta GPS\n\t- GPS\n\t- OK\n\nE' stato fatto?") == DialogResult.Yes)
                    {
                        ARDU.WriteLine("A");
                        richTextBoxCommunication.Text += Environment.NewLine + "Send A to Arduino. N.:10";
                        Messaggi.Show("Spegnimento montatura, non sarà possibile agire sul programma...");
                        Funzioni.Wait(20000, progressBar);
                        ARDU.WriteLine("g");
                        richTextBoxCommunication.Text += Environment.NewLine + "Send g to Arduino. N.:11";
                        Funzioni.SetStatus("MONTATURA", "OFF");
                        button_accendi_pannello.Visible = true;
                        button_accendi.Text = "Accendi montatura";
                        button_accendi.BackColor = Color.Red;
                    }
                }
            }
            catch (Exception ex)
            {
                Messaggi.ShowException("Errore all'accensione della montatura", ex);
            }
        }

        private void Button_accendi_pannello_Click(object sender, EventArgs e)
        {
            try
            {
                SpegniPannello();
            }
            catch (Exception ex)
            {
                Messaggi.ShowException("Errore al Button_accendi_pannello_Click", ex);
            }
        }

        private void Insegui()
        {
            try
            {
                double azimut = 0, altezza = 0;
                string datiRicevuti = RiceviDatiMONT(":GZ#:GZ#") + RiceviDatiMONT(":GA#:GA#");

                if (datiRicevuti.Length == 14 && //22
                    Double.TryParse(datiRicevuti.Substring(0, 3), out double azg) &&
                    Double.TryParse(datiRicevuti.Substring(4, 2), out double azp) &&
                    Double.TryParse(datiRicevuti.Substring(7, 3), out double alg) &&
                    Double.TryParse(datiRicevuti.Substring(11, 2), out double alp))
                {
                    azimut = azg + azp / 60;
                    altezza = alg + alp / 60;
                }

                label_risposta_da_montatura.Text = datiRicevuti;
                label_altezza.Text = Math.Round(altezza, 2).ToString();

                string azimutString = String.Empty;
                double posizioneMontatura = Funzioni.P_M(azimut, ref azimutString);
                label_azimut.Text = azimutString;
                label_posizione_montatura.Text = Convert.ToInt32(posizioneMontatura).ToString();

                int posizioneCupola = 0;
                string arduP = RiceviDatiARDU("P").Split('-')[0]; //piedi cupola solo la prima cifra
                if (!arduP.Equals(String.Empty) && Int32.TryParse(arduP, out posizioneCupola))
                    label_posizione_cupola.Text = posizioneCupola.ToString();

                if (posizioneMontatura > posizioneCupola + 2 * Funzioni.GENERAL_OFFSET)
                {
                    ARDU.WriteLine("VD");
                    richTextBoxCommunication.Text += Environment.NewLine + "Send VD to Arduino. N.:12";
                }
                else if (posizioneMontatura < posizioneCupola + 2 * Funzioni.GENERAL_OFFSET && posizioneMontatura > posizioneCupola + Funzioni.GENERAL_OFFSET)
                {
                    ARDU.WriteLine("vD");
                    richTextBoxCommunication.Text += Environment.NewLine + "Send vD to Arduino. N.:13";
                }
                else if (posizioneMontatura < posizioneCupola - 2 * Funzioni.GENERAL_OFFSET)
                {
                    ARDU.WriteLine("VS");
                    richTextBoxCommunication.Text += Environment.NewLine + "Send VS to Arduino. N.:14";
                }
                else if (posizioneMontatura > posizioneCupola - 2 * Funzioni.GENERAL_OFFSET && posizioneMontatura < posizioneCupola - Funzioni.GENERAL_OFFSET)
                {
                    ARDU.WriteLine("vS");
                    richTextBoxCommunication.Text += Environment.NewLine + "Send vS to Arduino. N.:15";
                }
                else if (posizioneMontatura > posizioneCupola - Funzioni.GENERAL_OFFSET && posizioneMontatura < posizioneCupola + Funzioni.GENERAL_OFFSET)
                {
                    ARDU.WriteLine("F");
                    richTextBoxCommunication.Text += Environment.NewLine + "Send F to Arduino. N.:16";
                }
            }
            catch (Exception ex)
            {
                Messaggi.ShowException("Errore in insegui", ex);
            }
        }

        private void Parcheggia()
        {
            try
            {
                timer_refresh.Stop();
                if (Messaggi.YesNo("ATTENZIONE!! In fase di parcheggio non è possibile agire sulla cupola e sulla montatura. Continuare?") == DialogResult.Yes)
                {
                    label_azimut.Text = "---";
                    label_altezza.Text = "---";
                    label_posizione_montatura.Text = "---";
                    label_posizione_cupola.Text = "---";

                    RiceviDatiMONT(":KA#:KA#");
                    //ARDU.WriteLine("Q");
                    richTextBoxCommunication.Text += Environment.NewLine + "Send Q to Arduino. N.:17";
                    Funzioni.Wait(90000, progressBar);
                    Messaggi.Show("Parcheggio avvenuto con successo");
                }
                else Messaggi.ShowWarning("La montatura non è parcheggiata");
                timer_refresh.Start();
                evento_parcheggia = false;
            }
            catch (Exception ex)
            {
                Messaggi.ShowException("Errore al parcheggia", ex);
            }
        }

        private void CheckBox_default_montatura_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(ComboBox_porta_montatura.SelectedItem.ToString()))
                    Funzioni.SetStatus("COM_MONTATURA", ComboBox_porta_montatura.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
                Messaggi.ShowException("Errore al CheckBox_default_montatura_CheckedChanged", ex);
            }
        }

        private void CheckBox_default_arduino_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(ComboBox_porta_arduino.SelectedItem.ToString()))
                    Funzioni.SetStatus("COM_ARDUINO", ComboBox_porta_arduino.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
                Messaggi.ShowException("Errore al CheckBox_default_arduino_CheckedChanged", ex);
            }
        }

        private void CheckBox_default_all_nto_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(ComboBox_all_nto.SelectedItem.ToString()))
                    Funzioni.SetStatus("ALL_NTO", ComboBox_all_nto.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
                Messaggi.ShowException("CheckBox_default_all_nto_CheckedChanged", ex);
            }
        }

        private void Button_home_Click(object sender, EventArgs e)
        {
            try
            {
                webBrowser.Navigate(new Uri(Funzioni.cameraIP));
            }
            catch (Exception ex)
            {
                Messaggi.ShowException("Errore al Button_home_Click", ex);
            }
        }

        private void Button_crossroads_Click(object sender, EventArgs e)
        {
            try
            {
                int cnt = 0;
                for (int i = 0; i < Application.OpenForms.Count; i++)
                    if (Application.OpenForms[i].Name.ToUpper() == "CROSSROADFORM")
                    {
                        Application.OpenForms[i].Close();
                        cnt++;
                    }

                CrossRoadForm crossRoadForm = null;
                if (cnt == 0)
                {
                    crossRoadForm = new CrossRoadForm();
                    crossRoadForm.Show();
                }
            }
            catch (Exception ex)
            {
                Messaggi.ShowException("Error Button_crossroads_Click", ex);
            }
        }

        private string StatoMontatura()
        {
            try
            {
                switch (RiceviDatiMONT(":GSTAT#:GSTAT#"))
                {
                    case "0":
                        return "Montatura in inseguimento";
                    case "1":
                        return "Montatura ferma a causa dell'esecuzione di STOP (tasto o stringa) \n o del completamento della sequenza di homing";
                    case "2":
                        return "Movimento verso la posizione di park";
                    case "3":
                        return "La montatura non è parcheggiata";
                    case "4":
                        return "Movimento verso la posizione di home";
                    case "5":
                        return "Montatura parcheggiata";
                    case "6":
                        return "Montatura in movimento";
                    case "7":
                        return "Inseguimento disattivato e montatura ferma";
                    case "8":
                        return "Motori inibiti a causa della bassa temperatura";
                    case "9":
                        return "Inseguimento attivo ma montatura fuori dai limiti di inseguimento";
                    case "10":
                        return "Inseguimento di un'orbita satellitare precalcolata";
                    case "11":
                        return "Richiesta di intervento per autorizzare il movimento \n a causa di una inconsistenza nei dati";
                    case "98":
                        return "Stato non noto";
                    case "99":
                        return "Errore";
                    default:
                        return "---";
                }
            }
            catch (Exception ex)
            {
                Messaggi.ShowException("Errore in stato montatura", ex);
                return "---";
            }
        }

        private void SpegniPannello()
        {
            string messaggioPannello = String.Empty;
            try
            {
                if (Funzioni.GetStatus("PANNELLO").Equals("ON"))
                    messaggioPannello = "lo spegnimento";
                else if (Funzioni.GetStatus("PANNELLO").Equals("OFF"))
                    messaggioPannello = "l'accensione";

                if (Messaggi.YesNo("ATTENZIONE!! Hai richiesto " + messaggioPannello + " del pannello, procedere?") == DialogResult.Yes)
                {
                    ARDU.WriteLine("x");
                    richTextBoxCommunication.Text += Environment.NewLine + "Send x to Arduino. N.:19";
                    Funzioni.Wait(5000, progressBar);

                    if (Funzioni.GetStatus("PANNELLO").Equals("ON"))
                    {
                        Funzioni.SetStatus("PANNELLO", "OFF");
                        button_accendi_pannello.Text = "Accendi pannello";
                        button_accendi_pannello.BackColor = Color.Red;
                    }
                    else if (Funzioni.GetStatus("PANNELLO").Equals("OFF"))
                    {
                        Funzioni.SetStatus("PANNELLO", "ON");
                        button_accendi_pannello.Text = "Spegni pannello";
                        button_accendi_pannello.BackColor = Color.Green;
                    }
                    button_accendi.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Messaggi.ShowException("Errore in accensione pannello", ex);
            }
        }
    }
}