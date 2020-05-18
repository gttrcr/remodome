using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace ScriptGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            label_title.Text = "  SELEZIONARE NELL'ORDINE" + Environment.NewLine +
                               "DESIDERATO, LE OPERAZIONI" + Environment.NewLine +
                               "CHE SI INTENDE EFFETTUARE" + Environment.NewLine +
                               "  ALL'ESECUZIONE DELLO" + Environment.NewLine +
                               "SCRIPT CHE VERRA' CREATO" + Environment.NewLine;

            checkForInternetConnection();
            checkValidDropBoxFolder();
            updateComboBox();
        }

        private void updateComboBox()
        {
            try
            {
                List<String> possibiliScelte = new List<String>();
                possibiliScelte.Clear();
                possibiliScelte.Add("");
                possibiliScelte.Add("Parcheggia montatura");
                possibiliScelte.Add("Parcheggia cupola");
                possibiliScelte.Add("Chiudi specola");
                possibiliScelte.Add("Apri specola");
                possibiliScelte.Add("Muovi montatura");
                possibiliScelte.Add("Spegni montatura");
                possibiliScelte.Add("Spegni pannello");
                possibiliScelte.Add("Accendi montatura");
                possibiliScelte.Add("Accendi pannello");
                possibiliScelte.Add("Blocca tutto");
                possibiliScelte.Add("Sblocca tutto");

                if (File.Exists(Funzioni.CONFIG_FILE))
                {
                    List<String> addScriptCommand = File.ReadAllLines(Funzioni.CONFIG_FILE).ToList();
                    addScriptCommand.RemoveAll(line => line.Split('=')[0] != "ADD_SCRIPT_COMMAND");
                    foreach (string option in addScriptCommand)
                    {
                        possibiliScelte.Add(Funzioni.extractValue(option));
                    }
                }

                foreach (Control control in this.Controls)
                {
                    if (control is ComboBox)
                    {
                        ((ComboBox)control).Items.Clear();
                        ((ComboBox)control).Items.AddRange(possibiliScelte.ToArray());
                        ((ComboBox)control).SelectedIndex = 0;
                    }
                }
                textBox_command.Text = String.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore all'updateComboBox: " + ex.Message);
            }
        }

        private void button_crea_script_Click(object sender, EventArgs e)
        {
            try
            {
                string resultingScriptPath = Funzioni.getStatus("SCRIPT_FOLDER");
                richTextBox_stat.Text = "CONTROLLO CREAZIONE SCRIPT" + Environment.NewLine;
                List<ComboBox> comboBoxInForm = new List<ComboBox>();

                List<String> listChoices = new List<String>();
                foreach (Control control in this.Controls)
                {
                    if (control is ComboBox)
                    {
                        comboBoxInForm.Add((ComboBox)control);
                    }
                }

                comboBoxInForm = comboBoxInForm.OrderBy(cmb => cmb.Name).ToList<ComboBox>();

                int i = 0, azioniScartate = 0, azioniValide = 0;
                foreach (ComboBox cmb in comboBoxInForm)
                {
                    i++;
                    object obj = cmb.SelectedItem;
                    if (Object.ReferenceEquals(obj, null) || Object.ReferenceEquals(obj, String.Empty))
                    {
                        richTextBox_stat.Text += "Nessuna scelta per l'azione n° " + i + ". Azione scartata" + Environment.NewLine;
                        azioniScartate++;
                    }
                    else
                    {
                        string choice = obj.ToString();
                        richTextBox_stat.Text += "Azione n° " + i + ": " + choice + ". Azione valida" + Environment.NewLine;
                        listChoices.Add(choice);
                        azioniValide++;
                    }
                }

                richTextBox_stat.Text += "Scartate " + azioniScartate + " azioni su " + (azioniScartate + azioniValide) + Environment.NewLine;
                richTextBox_stat.Text += Environment.NewLine;

                if (listChoices.Count() == 0)
                {
                    richTextBox_stat.Text += "Nessuna azione valida trovata" + Environment.NewLine;
                    richTextBox_stat.Text += "Nessuno script verrà creato" + Environment.NewLine;
                }
                else
                {
                    richTextBox_stat.Text += "Inizio creazione script" + Environment.NewLine;
                    richTextBox_stat.Text += Environment.NewLine;

                    string scriptName = resultingScriptPath + "\\TODOScript" + DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace(" ", "") + ".gttbntt";
                    StreamWriter sw = File.CreateText(scriptName);

                    richTextBox_stat.Text += "Creato il file " + scriptName + Environment.NewLine;

                    foreach (string singleChoice in listChoices)
                    {
                        sw.WriteLine(singleChoice);
                    }

                    richTextBox_stat.Text += "Azioni caricate nel file" + Environment.NewLine;

                    sw.Close();
                    sw.Dispose();

                    //Process prc = new Process();
                    //prc.StartInfo.FileName = resultingScriptPath;
                    //prc.Start();
                }

                richTextBox_stat.Text += "Processo terminato con successo";
            }
            catch (Exception ex)
            {
                richTextBox_stat.Text = "ERRORE al button_crea_script" + Environment.NewLine;
                richTextBox_stat.Text += ex.Message;
            }
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox_command.Text != String.Empty)
                {
                    File.AppendAllText(Funzioni.CONFIG_FILE, "\n\nADD_SCRIPT_COMMAND=\"" + textBox_command.Text + "\"");
                    updateComboBox();
                }
            }
            catch (Exception ex)
            {
                richTextBox_stat.Text = "ERRORE al button_add_click" + Environment.NewLine;
                richTextBox_stat.Text += ex.Message;
            }
        }

        private void button_remove_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(Funzioni.CONFIG_FILE))
                {
                    List<String> fileText = new List<String>();

                    foreach (String fileLine in File.ReadAllLines(Funzioni.CONFIG_FILE))
                    {
                        if (fileLine != "ADD_SCRIPT_COMMAND=\"" + textBox_command.Text + "\"") fileText.Add(fileLine);
                    }

                    File.WriteAllLines(Funzioni.CONFIG_FILE, fileText.ToArray());
                    updateComboBox();
                }
            }
            catch (Exception ex)
            {
                richTextBox_stat.Text = "ERRORE al button_remove_click" + Environment.NewLine;
                richTextBox_stat.Text += ex.Message;
            }
        }

        private void button_confirm_Click(object sender, EventArgs e)
        {
            if (!Object.ReferenceEquals(textBox_dropBox.Text, null))
            {
                Funzioni.setStatus("SCRIPT_FOLDER", textBox_dropBox.Text.ToString());
            }
        }

        private void checkValidDropBoxFolder()
        {
            string scriptFolder = Funzioni.findDropBoxFolder();  //Funzioni.getStatus("SCRIPT_FOLDER");
            if (String.IsNullOrEmpty(scriptFolder) || String.IsNullOrWhiteSpace(scriptFolder))
            {
                MessageBox.Show("Inserire un indirizzo valido per la cartella di destinazione: cartella di Dropbox");
            }
            else
            {
                textBox_dropBox.Text = scriptFolder;
            }
        }

        private void checkForInternetConnection()
        {

        }
    }
}