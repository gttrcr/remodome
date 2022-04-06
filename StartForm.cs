using System.Text;

namespace RemoDome
{
    public partial class StartForm : Form
    {
        bool pannello = false;
        bool montatura = false;

        public StartForm()
        {
            InitializeComponent();

            Funzioni.CheckForAnotherIstance();
            Funzioni.CheckForInternetConnection();

            if (!File.Exists(Funzioni.CONFIG_FILE_NAME))
            {
                Messaggi.ShowError("Non è stato trovato il file di configurazione nella cartella dell'eseguibile." + Environment.NewLine +
                    "E' stato creato un file con le impostazioni di default!");
                FileStream fs = File.Create(Funzioni.CONFIG_FILE_NAME);
                string msgToWrite = @"PANNELLO=OFF
MONTATURA=OFF
COM_MONTATURA=COM3
COM_ARDUINO=COM4
ALL_NTO=Astro-Physics
TEXT_COLOR_START_UP=R";
                fs.Write(Encoding.ASCII.GetBytes(msgToWrite), 0, msgToWrite.Length);
                fs.Close();
            }

            pannello = false;
            montatura = false;
            button_pannello.BackColor = Color.Red;
            button_montatura.BackColor = Color.Red;
        }

        private void Button_chiudi_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button_avvia_Click(object sender, EventArgs e)
        {
            if (pannello)
                Funzioni.SetStatus("PANNELLO", "ON");
            else
                Funzioni.SetStatus("PANNELLO", "OFF");

            if (montatura)
                Funzioni.SetStatus("MONTATURA", "ON");
            else
                Funzioni.SetStatus("MONTATURA", "OFF");

            Thread.Sleep(1000);

            FrontEnd frontEnd = new FrontEnd();
            frontEnd.Show();
            Hide();
        }

        private void Button_pannello_Click(object sender, EventArgs e)
        {
            pannello = !pannello;

            if (pannello)
                button_pannello.BackColor = Color.Green;
            else
                button_pannello.BackColor = Color.Red;
        }

        private void Button_montatura_Click(object sender, EventArgs e)
        {
            montatura = !montatura;

            if (montatura)
                button_montatura.BackColor = Color.Green;
            else
                button_montatura.BackColor = Color.Red;
        }
    }
}