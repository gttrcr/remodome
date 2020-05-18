using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace UpdateManager
{
    public partial class Form1 : Form
    {
        private static readonly string DIR_FOLDER_PROGRAMS = "C:\\Programs";
        private static readonly string DATA_URL = "https://sites.google.com/view/testdownloadtextfromweb/home";
        private static readonly string[] START_STOP_MESSAGE = { "[[##**--__--**##]]" };
        private static readonly string[] START_STOP_STRING = { "[#*-_-*#]" };
        private static readonly byte[] BYTE_VECTOR = new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 };
        List<CompleteAppInfo> appList = new List<CompleteAppInfo>();

        public Form1()
        {
            try
            {
                InitializeComponent();
                CheckInternetConnectionFileAndFolder();
                LoadList();
            }
            catch (Exception ex)
            {
                Messaggi.ShowError("Errore al caricamento del programma: " + ex.Message);
            }
        }

        public void LoadList()
        {
            try
            {
                string webText = String.Empty;
                using (var webClient = new System.Net.WebClient())
                {
                    webText = webClient.DownloadString(DATA_URL).ToString();
                }

                webText = webText.Split(START_STOP_MESSAGE, StringSplitOptions.None)[1];
                webText = webText.Split(START_STOP_MESSAGE, StringSplitOptions.None)[0];

                string dataSet = String.Empty;
                for (int i = 0; i < webText.Split(START_STOP_STRING, StringSplitOptions.None).Count(); i++)
                {
                    if (i % 2 != 0) dataSet += webText.Split(START_STOP_STRING, StringSplitOptions.None)[i].Trim() + "\n";
                }

                string[] temp = dataSet.Replace("\n", "").Replace("\r", "").Replace("\t", "").Split(';');
                temp = temp.Take(temp.Count() - 1).ToArray();

                appList.Clear();
                foreach (string appString in temp)
                {
                    CompleteAppInfo compName = new CompleteAppInfo();
                    compName.AppName = Decrypt(appString.Split(',')[0].Trim());
                    compName.Url = Decrypt(appString.Split(',')[1].Trim());
                    compName.FileVersion = Decrypt(appString.Split(',')[2].Trim());
                    //compName.Message = Decrypt(appString.Split(',')[3].Trim());
                    appList.Add(compName); //Lista di tutte le applicazione trovate nel sito
                }

                DirectoryInfo d = new DirectoryInfo(DIR_FOLDER_PROGRAMS);
                List<CompleteAppInfo> listAppInFolder = new List<CompleteAppInfo>();
                foreach (var file in d.GetFiles("*.exe"))
                {
                    FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(file.FullName);
                    CompleteAppInfo appInFolder = new CompleteAppInfo();
                    appInFolder.AppName = file.Name.Replace(".exe", "");
                    appInFolder.FileVersion = fileVersionInfo.FileVersion;
                    listAppInFolder.Add(appInFolder); //Lista di tutte le applicazione trovate nella cartella del pc
                }

                checkedListBox_appList.Items.Clear();
                foreach (CompleteAppInfo siteApp in appList)
                {
                    int index = 0;
                    checkedListBox_appList.Items.Add(siteApp.AppName + " - versione: " + siteApp.FileVersion + " - news: " + siteApp.Message);
                    foreach (CompleteAppInfo pcApp in listAppInFolder)
                    {
                        if (pcApp.AppName.Equals(siteApp.AppName))
                        {
                            if (!siteApp.FileVersion.Equals(pcApp.FileVersion)) checkedListBox_appList.SetItemChecked(index, true);
                        }
                        index++;
                    }
                }
            }
            catch (Exception ex)
            {
                Messaggi.ShowError("Errore al LoadItems: " + ex.Message);
            }
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            try
            {
                List<int> indexToUpdate = new List<int>();
                for (int i = 0; i < checkedListBox_appList.Items.Count; i++)
                {
                    if (checkedListBox_appList.GetItemCheckState(i).Equals(CheckState.Checked)) indexToUpdate.Add(i);
                }

                if (indexToUpdate.Count() > 0)
                {
                    foreach (int index in indexToUpdate)
                    {
                        if (!String.IsNullOrEmpty(appList[index].Url) && !String.IsNullOrWhiteSpace(appList[index].Url)) Process.Start(appList[index].Url);
                        else Messaggi.ShowWarning("Nessun link valido per " + appList[index].AppName);
                    }
                }
                else Messaggi.ShowWarning("Nessuna App da aggiornare");
            }
            catch (Exception ex)
            {
                Messaggi.ShowError("Errore all'update: " + ex.Message);
            }
        }

        private void button_update_list_Click(object sender, EventArgs e)
        {
            LoadList();
        }

        private string Decrypt(string cipherword)
        {
            try
            {
                string Password = "azbugnezvn";
                byte[] cipherBytes = Convert.FromBase64String(cipherword);
                PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password, BYTE_VECTOR);
                MemoryStream ms = new MemoryStream();
                Rijndael alg = Rijndael.Create();
                alg.Key = pdb.GetBytes(32);
                alg.IV = pdb.GetBytes(16);
                CryptoStream cs = new CryptoStream(ms, alg.CreateDecryptor(), CryptoStreamMode.Write);
                cs.Write(cipherBytes, 0, cipherBytes.Length);
                cs.Close();
                byte[] decryptedData = ms.ToArray();
                return Encoding.Unicode.GetString(decryptedData);
            }
            catch (Exception)
            {
                return "---";
            }
        }

        private void timer_update_Tick(object sender, EventArgs e)
        {
            LoadList();
        }

        private void CheckInternetConnectionFileAndFolder()
        {
            try
            {
                try
                {
                    using (var client = new WebClient())
                    {
                        using (var stream = client.OpenRead("http://www.google.com"))
                        {

                        }
                    }
                }
                catch
                {
                    Messaggi.ShowError("Controllare la connessione internet e riprovare");
                    Environment.Exit(0);
                }

                if (!Directory.Exists(DIR_FOLDER_PROGRAMS))
                {
                    Directory.CreateDirectory(DIR_FOLDER_PROGRAMS);
                    Messaggi.ShowWarning("Cartella programmi non trovata all'indirizzo " + DIR_FOLDER_PROGRAMS + ". Cartella creata");
                }
            }
            catch (Exception ex)
            {
                Messaggi.ShowError("Errore al controllo iniziale: " + ex.Message);
            }
        }
    }
}