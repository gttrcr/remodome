namespace UpdateManager
{
    partial class Form1
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
            this.checkedListBox_appList = new System.Windows.Forms.CheckedListBox();
            this.button_update = new System.Windows.Forms.Button();
            this.button_update_list = new System.Windows.Forms.Button();
            this.timer_update = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // checkedListBox_appList
            // 
            this.checkedListBox_appList.FormattingEnabled = true;
            this.checkedListBox_appList.Location = new System.Drawing.Point(12, 33);
            this.checkedListBox_appList.Name = "checkedListBox_appList";
            this.checkedListBox_appList.Size = new System.Drawing.Size(506, 259);
            this.checkedListBox_appList.TabIndex = 0;
            // 
            // button_update
            // 
            this.button_update.Location = new System.Drawing.Point(12, 301);
            this.button_update.Name = "button_update";
            this.button_update.Size = new System.Drawing.Size(250, 23);
            this.button_update.TabIndex = 1;
            this.button_update.Text = "AGGIORNA SELEZIONATI";
            this.button_update.UseVisualStyleBackColor = true;
            this.button_update.Click += new System.EventHandler(this.button_update_Click);
            // 
            // button_update_list
            // 
            this.button_update_list.Location = new System.Drawing.Point(268, 301);
            this.button_update_list.Name = "button_update_list";
            this.button_update_list.Size = new System.Drawing.Size(250, 23);
            this.button_update_list.TabIndex = 2;
            this.button_update_list.Text = "AGGIORNA LISTA PROGRAMMI";
            this.button_update_list.UseVisualStyleBackColor = true;
            this.button_update_list.Click += new System.EventHandler(this.button_update_list_Click);
            // 
            // timer_update
            // 
            this.timer_update.Enabled = true;
            this.timer_update.Interval = 5000;
            this.timer_update.Tick += new System.EventHandler(this.timer_update_Tick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 351);
            this.Controls.Add(this.button_update_list);
            this.Controls.Add(this.button_update);
            this.Controls.Add(this.checkedListBox_appList);
            this.Name = "Form1";
            this.Text = "Program Update Manager - R. Gatti";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBox_appList;
        private System.Windows.Forms.Button button_update;
        private System.Windows.Forms.Button button_update_list;
        private System.Windows.Forms.Timer timer_update;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}

