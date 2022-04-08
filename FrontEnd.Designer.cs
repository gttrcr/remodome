namespace RemoDome
{
    partial class FrontEnd
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrontEnd));
            this.MONT = new System.IO.Ports.SerialPort(this.components);
            this.ARDU = new System.IO.Ports.SerialPort(this.components);
            this.timer_refresh = new System.Windows.Forms.Timer(this.components);
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.button_crossroads = new System.Windows.Forms.Button();
            this.button_home = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label10 = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.label_altezza = new System.Windows.Forms.Label();
            this.label_az_cupola = new System.Windows.Forms.Label();
            this.button_connetti = new System.Windows.Forms.Button();
            this.button_accendi_pannello = new System.Windows.Forms.Button();
            this.Label20 = new System.Windows.Forms.Label();
            this.label_azimut = new System.Windows.Forms.Label();
            this.checkBox_default_all_nto = new System.Windows.Forms.CheckBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.button_parcheggia = new System.Windows.Forms.Button();
            this.Label6 = new System.Windows.Forms.Label();
            this.checkBox_default_arduino = new System.Windows.Forms.CheckBox();
            this.button_accendi = new System.Windows.Forms.Button();
            this.button_piu = new System.Windows.Forms.Button();
            this.ComboBox_porta_montatura = new System.Windows.Forms.ComboBox();
            this.button_cupola = new System.Windows.Forms.Button();
            this.label_posizione_montatura = new System.Windows.Forms.Label();
            this.button_insegui = new System.Windows.Forms.Button();
            this.label_risposta_da_montatura = new System.Windows.Forms.Label();
            this.checkBox_default_montatura = new System.Windows.Forms.CheckBox();
            this.label_pioggia = new System.Windows.Forms.Label();
            this.button_meno = new System.Windows.Forms.Button();
            this.ComboBox_porta_arduino = new System.Windows.Forms.ComboBox();
            this.button_muovi = new System.Windows.Forms.Button();
            this.Label14 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.label_posizione_cupola = new System.Windows.Forms.Label();
            this.label_invio_a_montatura = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label12 = new System.Windows.Forms.Label();
            this.button_stop = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.ComboBox_all_nto = new System.Windows.Forms.ComboBox();
            this.Label16 = new System.Windows.Forms.Label();
            this.label_stato_montatura = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageSystemState = new System.Windows.Forms.TabPage();
            this.richTextBox_computerStatus = new System.Windows.Forms.RichTextBox();
            this.tabPageWebBrowser = new System.Windows.Forms.TabPage();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.richTextBoxCommunication = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageSystemState.SuspendLayout();
            this.tabPageWebBrowser.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer_refresh
            // 
            this.timer_refresh.Interval = 800;
            this.timer_refresh.Tick += new System.EventHandler(this.Timer_refresh_Tick);
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.richTextBoxCommunication);
            this.splitContainer2.Panel1.Controls.Add(this.button_crossroads);
            this.splitContainer2.Panel1.Controls.Add(this.button_home);
            this.splitContainer2.Panel1.Controls.Add(this.Label1);
            this.splitContainer2.Panel1.Controls.Add(this.Label10);
            this.splitContainer2.Panel1.Controls.Add(this.progressBar);
            this.splitContainer2.Panel1.Controls.Add(this.label_altezza);
            this.splitContainer2.Panel1.Controls.Add(this.label_az_cupola);
            this.splitContainer2.Panel1.Controls.Add(this.button_connetti);
            this.splitContainer2.Panel1.Controls.Add(this.button_accendi_pannello);
            this.splitContainer2.Panel1.Controls.Add(this.Label20);
            this.splitContainer2.Panel1.Controls.Add(this.label_azimut);
            this.splitContainer2.Panel1.Controls.Add(this.checkBox_default_all_nto);
            this.splitContainer2.Panel1.Controls.Add(this.Label8);
            this.splitContainer2.Panel1.Controls.Add(this.button_parcheggia);
            this.splitContainer2.Panel1.Controls.Add(this.Label6);
            this.splitContainer2.Panel1.Controls.Add(this.checkBox_default_arduino);
            this.splitContainer2.Panel1.Controls.Add(this.button_accendi);
            this.splitContainer2.Panel1.Controls.Add(this.button_piu);
            this.splitContainer2.Panel1.Controls.Add(this.ComboBox_porta_montatura);
            this.splitContainer2.Panel1.Controls.Add(this.button_cupola);
            this.splitContainer2.Panel1.Controls.Add(this.label_posizione_montatura);
            this.splitContainer2.Panel1.Controls.Add(this.button_insegui);
            this.splitContainer2.Panel1.Controls.Add(this.label_risposta_da_montatura);
            this.splitContainer2.Panel1.Controls.Add(this.checkBox_default_montatura);
            this.splitContainer2.Panel1.Controls.Add(this.label_pioggia);
            this.splitContainer2.Panel1.Controls.Add(this.button_meno);
            this.splitContainer2.Panel1.Controls.Add(this.ComboBox_porta_arduino);
            this.splitContainer2.Panel1.Controls.Add(this.button_muovi);
            this.splitContainer2.Panel1.Controls.Add(this.Label14);
            this.splitContainer2.Panel1.Controls.Add(this.Label3);
            this.splitContainer2.Panel1.Controls.Add(this.label_posizione_cupola);
            this.splitContainer2.Panel1.Controls.Add(this.label_invio_a_montatura);
            this.splitContainer2.Panel1.Controls.Add(this.Label4);
            this.splitContainer2.Panel1.Controls.Add(this.Label12);
            this.splitContainer2.Panel1.Controls.Add(this.button_stop);
            this.splitContainer2.Panel1.Controls.Add(this.Label2);
            this.splitContainer2.Panel1.Controls.Add(this.ComboBox_all_nto);
            this.splitContainer2.Panel1.Controls.Add(this.Label16);
            this.splitContainer2.Panel1.Controls.Add(this.label_stato_montatura);
            this.splitContainer2.Panel1.Controls.Add(this.Label5);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tabControl);
            this.splitContainer2.Size = new System.Drawing.Size(942, 565);
            this.splitContainer2.SplitterDistance = 333;
            this.splitContainer2.TabIndex = 96;
            // 
            // button_crossroads
            // 
            this.button_crossroads.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_crossroads.Location = new System.Drawing.Point(223, 202);
            this.button_crossroads.Name = "button_crossroads";
            this.button_crossroads.Size = new System.Drawing.Size(50, 52);
            this.button_crossroads.TabIndex = 96;
            this.button_crossroads.Text = "Cross";
            this.button_crossroads.UseVisualStyleBackColor = true;
            this.button_crossroads.Click += new System.EventHandler(this.Button_crossroads_Click);
            // 
            // button_home
            // 
            this.button_home.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_home.Location = new System.Drawing.Point(167, 202);
            this.button_home.Name = "button_home";
            this.button_home.Size = new System.Drawing.Size(50, 52);
            this.button_home.TabIndex = 95;
            this.button_home.Text = "Home";
            this.button_home.UseVisualStyleBackColor = true;
            this.button_home.Click += new System.EventHandler(this.Button_home_Click);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(4, 7);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(64, 13);
            this.Label1.TabIndex = 41;
            this.Label1.Text = "Montatura";
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.BackColor = System.Drawing.Color.Transparent;
            this.Label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label10.Location = new System.Drawing.Point(287, 89);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(52, 13);
            this.Label10.TabIndex = 51;
            this.Label10.Text = "Altezza:";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(7, 260);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(266, 23);
            this.progressBar.TabIndex = 94;
            this.progressBar.Visible = false;
            // 
            // label_altezza
            // 
            this.label_altezza.AutoSize = true;
            this.label_altezza.BackColor = System.Drawing.Color.Transparent;
            this.label_altezza.Location = new System.Drawing.Point(394, 89);
            this.label_altezza.Name = "label_altezza";
            this.label_altezza.Size = new System.Drawing.Size(16, 13);
            this.label_altezza.TabIndex = 52;
            this.label_altezza.Text = "---";
            // 
            // label_az_cupola
            // 
            this.label_az_cupola.AutoSize = true;
            this.label_az_cupola.BackColor = System.Drawing.Color.Transparent;
            this.label_az_cupola.Location = new System.Drawing.Point(394, 207);
            this.label_az_cupola.Name = "label_az_cupola";
            this.label_az_cupola.Size = new System.Drawing.Size(16, 13);
            this.label_az_cupola.TabIndex = 65;
            this.label_az_cupola.Text = "---";
            // 
            // button_connetti
            // 
            this.button_connetti.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_connetti.Location = new System.Drawing.Point(7, 86);
            this.button_connetti.Name = "button_connetti";
            this.button_connetti.Size = new System.Drawing.Size(130, 23);
            this.button_connetti.TabIndex = 44;
            this.button_connetti.Text = "Connetti";
            this.button_connetti.UseVisualStyleBackColor = true;
            this.button_connetti.Click += new System.EventHandler(this.Button_connetti_Click);
            // 
            // button_accendi_pannello
            // 
            this.button_accendi_pannello.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_accendi_pannello.Location = new System.Drawing.Point(143, 86);
            this.button_accendi_pannello.Name = "button_accendi_pannello";
            this.button_accendi_pannello.Size = new System.Drawing.Size(130, 23);
            this.button_accendi_pannello.TabIndex = 82;
            this.button_accendi_pannello.Text = "Accendi pannello";
            this.button_accendi_pannello.UseVisualStyleBackColor = true;
            this.button_accendi_pannello.Click += new System.EventHandler(this.Button_accendi_pannello_Click);
            // 
            // Label20
            // 
            this.Label20.AutoSize = true;
            this.Label20.BackColor = System.Drawing.Color.Transparent;
            this.Label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label20.Location = new System.Drawing.Point(287, 207);
            this.Label20.Name = "Label20";
            this.Label20.Size = new System.Drawing.Size(67, 13);
            this.Label20.TabIndex = 66;
            this.Label20.Text = "Az cupola:";
            // 
            // label_azimut
            // 
            this.label_azimut.AutoSize = true;
            this.label_azimut.BackColor = System.Drawing.Color.Transparent;
            this.label_azimut.Location = new System.Drawing.Point(394, 60);
            this.label_azimut.Name = "label_azimut";
            this.label_azimut.Size = new System.Drawing.Size(16, 13);
            this.label_azimut.TabIndex = 50;
            this.label_azimut.Text = "---";
            // 
            // checkBox_default_all_nto
            // 
            this.checkBox_default_all_nto.AutoSize = true;
            this.checkBox_default_all_nto.Location = new System.Drawing.Point(258, 62);
            this.checkBox_default_all_nto.Name = "checkBox_default_all_nto";
            this.checkBox_default_all_nto.Size = new System.Drawing.Size(15, 14);
            this.checkBox_default_all_nto.TabIndex = 89;
            this.checkBox_default_all_nto.UseVisualStyleBackColor = true;
            this.checkBox_default_all_nto.CheckedChanged += new System.EventHandler(this.CheckBox_default_all_nto_CheckedChanged);
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.BackColor = System.Drawing.Color.Transparent;
            this.Label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label8.Location = new System.Drawing.Point(287, 118);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(96, 13);
            this.Label8.TabIndex = 53;
            this.Label8.Text = "Pos. montatura:";
            // 
            // button_parcheggia
            // 
            this.button_parcheggia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_parcheggia.Location = new System.Drawing.Point(143, 173);
            this.button_parcheggia.Name = "button_parcheggia";
            this.button_parcheggia.Size = new System.Drawing.Size(130, 23);
            this.button_parcheggia.TabIndex = 63;
            this.button_parcheggia.Text = "Parcheggia";
            this.button_parcheggia.UseVisualStyleBackColor = true;
            this.button_parcheggia.Click += new System.EventHandler(this.Button_parcheggia_Click);
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.BackColor = System.Drawing.Color.Transparent;
            this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.Location = new System.Drawing.Point(287, 60);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(48, 13);
            this.Label6.TabIndex = 49;
            this.Label6.Text = "Azimut:";
            // 
            // checkBox_default_arduino
            // 
            this.checkBox_default_arduino.AutoSize = true;
            this.checkBox_default_arduino.Location = new System.Drawing.Point(258, 35);
            this.checkBox_default_arduino.Name = "checkBox_default_arduino";
            this.checkBox_default_arduino.Size = new System.Drawing.Size(15, 14);
            this.checkBox_default_arduino.TabIndex = 88;
            this.checkBox_default_arduino.UseVisualStyleBackColor = true;
            this.checkBox_default_arduino.CheckedChanged += new System.EventHandler(this.CheckBox_default_arduino_CheckedChanged);
            // 
            // button_accendi
            // 
            this.button_accendi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_accendi.Location = new System.Drawing.Point(7, 115);
            this.button_accendi.Name = "button_accendi";
            this.button_accendi.Size = new System.Drawing.Size(130, 23);
            this.button_accendi.TabIndex = 81;
            this.button_accendi.Text = "Accendi montatura";
            this.button_accendi.UseVisualStyleBackColor = true;
            this.button_accendi.Click += new System.EventHandler(this.Button_accendi_Click);
            // 
            // button_piu
            // 
            this.button_piu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_piu.Location = new System.Drawing.Point(73, 173);
            this.button_piu.Name = "button_piu";
            this.button_piu.Size = new System.Drawing.Size(64, 23);
            this.button_piu.TabIndex = 67;
            this.button_piu.Text = "Destra";
            this.button_piu.UseVisualStyleBackColor = true;
            this.button_piu.Click += new System.EventHandler(this.Button_piu_Click);
            // 
            // ComboBox_porta_montatura
            // 
            this.ComboBox_porta_montatura.FormattingEnabled = true;
            this.ComboBox_porta_montatura.Location = new System.Drawing.Point(74, 3);
            this.ComboBox_porta_montatura.Name = "ComboBox_porta_montatura";
            this.ComboBox_porta_montatura.Size = new System.Drawing.Size(178, 21);
            this.ComboBox_porta_montatura.TabIndex = 39;
            // 
            // button_cupola
            // 
            this.button_cupola.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_cupola.Location = new System.Drawing.Point(7, 144);
            this.button_cupola.Name = "button_cupola";
            this.button_cupola.Size = new System.Drawing.Size(130, 23);
            this.button_cupola.TabIndex = 43;
            this.button_cupola.Text = "Cupola";
            this.button_cupola.UseVisualStyleBackColor = true;
            this.button_cupola.Click += new System.EventHandler(this.Button_cupola_Click);
            // 
            // label_posizione_montatura
            // 
            this.label_posizione_montatura.AutoSize = true;
            this.label_posizione_montatura.BackColor = System.Drawing.Color.Transparent;
            this.label_posizione_montatura.Location = new System.Drawing.Point(394, 118);
            this.label_posizione_montatura.Name = "label_posizione_montatura";
            this.label_posizione_montatura.Size = new System.Drawing.Size(16, 13);
            this.label_posizione_montatura.TabIndex = 54;
            this.label_posizione_montatura.Text = "---";
            // 
            // button_insegui
            // 
            this.button_insegui.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_insegui.Location = new System.Drawing.Point(143, 142);
            this.button_insegui.Name = "button_insegui";
            this.button_insegui.Size = new System.Drawing.Size(130, 23);
            this.button_insegui.TabIndex = 62;
            this.button_insegui.Text = "Insegui";
            this.button_insegui.UseVisualStyleBackColor = true;
            this.button_insegui.Click += new System.EventHandler(this.Button_insegui_Click);
            // 
            // label_risposta_da_montatura
            // 
            this.label_risposta_da_montatura.AutoSize = true;
            this.label_risposta_da_montatura.BackColor = System.Drawing.Color.Transparent;
            this.label_risposta_da_montatura.Location = new System.Drawing.Point(394, 31);
            this.label_risposta_da_montatura.Name = "label_risposta_da_montatura";
            this.label_risposta_da_montatura.Size = new System.Drawing.Size(16, 13);
            this.label_risposta_da_montatura.TabIndex = 48;
            this.label_risposta_da_montatura.Text = "---";
            // 
            // checkBox_default_montatura
            // 
            this.checkBox_default_montatura.AutoSize = true;
            this.checkBox_default_montatura.Location = new System.Drawing.Point(258, 6);
            this.checkBox_default_montatura.Name = "checkBox_default_montatura";
            this.checkBox_default_montatura.Size = new System.Drawing.Size(15, 14);
            this.checkBox_default_montatura.TabIndex = 87;
            this.checkBox_default_montatura.UseVisualStyleBackColor = true;
            this.checkBox_default_montatura.CheckedChanged += new System.EventHandler(this.CheckBox_default_montatura_CheckedChanged);
            // 
            // label_pioggia
            // 
            this.label_pioggia.AutoSize = true;
            this.label_pioggia.BackColor = System.Drawing.Color.Transparent;
            this.label_pioggia.Location = new System.Drawing.Point(394, 236);
            this.label_pioggia.Name = "label_pioggia";
            this.label_pioggia.Size = new System.Drawing.Size(16, 13);
            this.label_pioggia.TabIndex = 80;
            this.label_pioggia.Text = "---";
            // 
            // button_meno
            // 
            this.button_meno.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_meno.Location = new System.Drawing.Point(7, 173);
            this.button_meno.Name = "button_meno";
            this.button_meno.Size = new System.Drawing.Size(64, 23);
            this.button_meno.TabIndex = 68;
            this.button_meno.Text = "Sinistra";
            this.button_meno.UseVisualStyleBackColor = true;
            this.button_meno.Click += new System.EventHandler(this.Button_meno_Click);
            // 
            // ComboBox_porta_arduino
            // 
            this.ComboBox_porta_arduino.FormattingEnabled = true;
            this.ComboBox_porta_arduino.Location = new System.Drawing.Point(74, 32);
            this.ComboBox_porta_arduino.Name = "ComboBox_porta_arduino";
            this.ComboBox_porta_arduino.Size = new System.Drawing.Size(178, 21);
            this.ComboBox_porta_arduino.TabIndex = 40;
            // 
            // button_muovi
            // 
            this.button_muovi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_muovi.Location = new System.Drawing.Point(143, 115);
            this.button_muovi.Name = "button_muovi";
            this.button_muovi.Size = new System.Drawing.Size(130, 23);
            this.button_muovi.TabIndex = 61;
            this.button_muovi.Text = "Muovi";
            this.button_muovi.UseVisualStyleBackColor = true;
            this.button_muovi.Click += new System.EventHandler(this.Button_muovi_Click);
            // 
            // Label14
            // 
            this.Label14.AutoSize = true;
            this.Label14.BackColor = System.Drawing.Color.Transparent;
            this.Label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label14.Location = new System.Drawing.Point(287, 147);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(78, 13);
            this.Label14.TabIndex = 55;
            this.Label14.Text = "Pos. cupola:";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.BackColor = System.Drawing.Color.Transparent;
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(4, 63);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(47, 13);
            this.Label3.TabIndex = 72;
            this.Label3.Text = "All. nto";
            // 
            // label_posizione_cupola
            // 
            this.label_posizione_cupola.AutoSize = true;
            this.label_posizione_cupola.BackColor = System.Drawing.Color.Transparent;
            this.label_posizione_cupola.Location = new System.Drawing.Point(394, 147);
            this.label_posizione_cupola.Name = "label_posizione_cupola";
            this.label_posizione_cupola.Size = new System.Drawing.Size(16, 13);
            this.label_posizione_cupola.TabIndex = 56;
            this.label_posizione_cupola.Text = "---";
            // 
            // label_invio_a_montatura
            // 
            this.label_invio_a_montatura.AutoSize = true;
            this.label_invio_a_montatura.BackColor = System.Drawing.Color.Transparent;
            this.label_invio_a_montatura.Location = new System.Drawing.Point(394, 3);
            this.label_invio_a_montatura.Name = "label_invio_a_montatura";
            this.label_invio_a_montatura.Size = new System.Drawing.Size(16, 13);
            this.label_invio_a_montatura.TabIndex = 47;
            this.label_invio_a_montatura.Text = "---";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.BackColor = System.Drawing.Color.Transparent;
            this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(287, 3);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(79, 13);
            this.Label4.TabIndex = 45;
            this.Label4.Text = "A montatura:";
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.BackColor = System.Drawing.Color.Transparent;
            this.Label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label12.Location = new System.Drawing.Point(287, 233);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(78, 13);
            this.Label12.TabIndex = 78;
            this.Label12.Text = "Piove piove:";
            // 
            // button_stop
            // 
            this.button_stop.BackColor = System.Drawing.Color.Salmon;
            this.button_stop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.button_stop.Location = new System.Drawing.Point(7, 202);
            this.button_stop.Name = "button_stop";
            this.button_stop.Size = new System.Drawing.Size(154, 52);
            this.button_stop.TabIndex = 59;
            this.button_stop.Text = "STOP";
            this.button_stop.UseVisualStyleBackColor = false;
            this.button_stop.Click += new System.EventHandler(this.Button_stop_Click);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(4, 36);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(50, 13);
            this.Label2.TabIndex = 42;
            this.Label2.Text = "Arduino";
            // 
            // ComboBox_all_nto
            // 
            this.ComboBox_all_nto.FormattingEnabled = true;
            this.ComboBox_all_nto.Items.AddRange(new object[] {
            "Astro-Physics",
            "Ritchey-Chrétien"});
            this.ComboBox_all_nto.Location = new System.Drawing.Point(74, 59);
            this.ComboBox_all_nto.Name = "ComboBox_all_nto";
            this.ComboBox_all_nto.Size = new System.Drawing.Size(178, 21);
            this.ComboBox_all_nto.TabIndex = 71;
            // 
            // Label16
            // 
            this.Label16.AutoSize = true;
            this.Label16.BackColor = System.Drawing.Color.Transparent;
            this.Label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label16.Location = new System.Drawing.Point(287, 177);
            this.Label16.Name = "Label16";
            this.Label16.Size = new System.Drawing.Size(101, 13);
            this.Label16.TabIndex = 57;
            this.Label16.Text = "Stato montatura:";
            // 
            // label_stato_montatura
            // 
            this.label_stato_montatura.AutoSize = true;
            this.label_stato_montatura.BackColor = System.Drawing.Color.Transparent;
            this.label_stato_montatura.Location = new System.Drawing.Point(394, 177);
            this.label_stato_montatura.Name = "label_stato_montatura";
            this.label_stato_montatura.Size = new System.Drawing.Size(16, 13);
            this.label_stato_montatura.TabIndex = 58;
            this.label_stato_montatura.Text = "---";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.BackColor = System.Drawing.Color.Transparent;
            this.Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.Location = new System.Drawing.Point(287, 31);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(87, 13);
            this.Label5.TabIndex = 46;
            this.Label5.Text = "Da montatura:";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageSystemState);
            this.tabControl.Controls.Add(this.tabPageWebBrowser);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(938, 224);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageSystemState
            // 
            this.tabPageSystemState.Controls.Add(this.richTextBox_computerStatus);
            this.tabPageSystemState.Location = new System.Drawing.Point(4, 22);
            this.tabPageSystemState.Name = "tabPageSystemState";
            this.tabPageSystemState.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSystemState.Size = new System.Drawing.Size(930, 198);
            this.tabPageSystemState.TabIndex = 0;
            this.tabPageSystemState.Text = "Stato sistema";
            this.tabPageSystemState.UseVisualStyleBackColor = true;
            // 
            // richTextBox_computerStatus
            // 
            this.richTextBox_computerStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox_computerStatus.Location = new System.Drawing.Point(3, 3);
            this.richTextBox_computerStatus.Name = "richTextBox_computerStatus";
            this.richTextBox_computerStatus.Size = new System.Drawing.Size(924, 192);
            this.richTextBox_computerStatus.TabIndex = 4;
            this.richTextBox_computerStatus.Text = "";
            // 
            // tabPageWebBrowser
            // 
            this.tabPageWebBrowser.Controls.Add(this.webBrowser);
            this.tabPageWebBrowser.Location = new System.Drawing.Point(4, 22);
            this.tabPageWebBrowser.Name = "tabPageWebBrowser";
            this.tabPageWebBrowser.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageWebBrowser.Size = new System.Drawing.Size(506, 198);
            this.tabPageWebBrowser.TabIndex = 1;
            this.tabPageWebBrowser.Text = "Web Browser";
            this.tabPageWebBrowser.UseVisualStyleBackColor = true;
            // 
            // webBrowser
            // 
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser.Location = new System.Drawing.Point(3, 3);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(500, 192);
            this.webBrowser.TabIndex = 93;
            this.webBrowser.Url = new System.Uri("", System.UriKind.Relative);
            // 
            // richTextBoxCommunication
            // 
            this.richTextBoxCommunication.Location = new System.Drawing.Point(561, 3);
            this.richTextBoxCommunication.Name = "richTextBoxCommunication";
            this.richTextBoxCommunication.ReadOnly = true;
            this.richTextBoxCommunication.Size = new System.Drawing.Size(364, 310);
            this.richTextBoxCommunication.TabIndex = 97;
            this.richTextBoxCommunication.Text = "";
            // 
            // FrontEnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 565);
            this.Controls.Add(this.splitContainer2);
            //this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrontEnd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RemoDome";
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPageSystemState.ResumeLayout(false);
            this.tabPageWebBrowser.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.IO.Ports.SerialPort MONT;
        private System.IO.Ports.SerialPort ARDU;
        private System.Windows.Forms.Timer timer_refresh;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button button_home;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label10;
        private System.Windows.Forms.ProgressBar progressBar;
        internal System.Windows.Forms.Label label_altezza;
        internal System.Windows.Forms.Label label_az_cupola;
        internal System.Windows.Forms.Button button_connetti;
        internal System.Windows.Forms.Button button_accendi_pannello;
        internal System.Windows.Forms.Label Label20;
        internal System.Windows.Forms.Label label_azimut;
        private System.Windows.Forms.CheckBox checkBox_default_all_nto;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.Button button_parcheggia;
        internal System.Windows.Forms.Label Label6;
        private System.Windows.Forms.CheckBox checkBox_default_arduino;
        internal System.Windows.Forms.Button button_accendi;
        internal System.Windows.Forms.Button button_piu;
        internal System.Windows.Forms.ComboBox ComboBox_porta_montatura;
        internal System.Windows.Forms.Button button_cupola;
        internal System.Windows.Forms.Label label_posizione_montatura;
        internal System.Windows.Forms.Button button_insegui;
        internal System.Windows.Forms.Label label_risposta_da_montatura;
        private System.Windows.Forms.CheckBox checkBox_default_montatura;
        internal System.Windows.Forms.Label label_pioggia;
        internal System.Windows.Forms.Button button_meno;
        internal System.Windows.Forms.ComboBox ComboBox_porta_arduino;
        internal System.Windows.Forms.Button button_muovi;
        internal System.Windows.Forms.Label Label14;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label label_posizione_cupola;
        internal System.Windows.Forms.Label label_invio_a_montatura;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label12;
        internal System.Windows.Forms.Button button_stop;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.ComboBox ComboBox_all_nto;
        internal System.Windows.Forms.Label Label16;
        internal System.Windows.Forms.Label label_stato_montatura;
        internal System.Windows.Forms.Label Label5;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageSystemState;
        private System.Windows.Forms.RichTextBox richTextBox_computerStatus;
        private System.Windows.Forms.TabPage tabPageWebBrowser;
        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.Button button_crossroads;
        private System.Windows.Forms.RichTextBox richTextBoxCommunication;
    }
}