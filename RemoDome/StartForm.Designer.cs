namespace RemoDome
{
    partial class StartForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartForm));
            this.button_pannello = new System.Windows.Forms.Button();
            this.button_montatura = new System.Windows.Forms.Button();
            this.button_avvia = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button_chiudi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_pannello
            // 
            this.button_pannello.Location = new System.Drawing.Point(125, 46);
            this.button_pannello.Name = "button_pannello";
            this.button_pannello.Size = new System.Drawing.Size(150, 23);
            this.button_pannello.TabIndex = 0;
            this.button_pannello.Text = "Pannello";
            this.button_pannello.UseVisualStyleBackColor = true;
            this.button_pannello.Click += new System.EventHandler(this.Button_pannello_Click);
            // 
            // button_montatura
            // 
            this.button_montatura.Location = new System.Drawing.Point(125, 92);
            this.button_montatura.Name = "button_montatura";
            this.button_montatura.Size = new System.Drawing.Size(150, 23);
            this.button_montatura.TabIndex = 1;
            this.button_montatura.Text = "Montatura";
            this.button_montatura.UseVisualStyleBackColor = true;
            this.button_montatura.Click += new System.EventHandler(this.Button_montatura_Click);
            // 
            // button_avvia
            // 
            this.button_avvia.Location = new System.Drawing.Point(222, 166);
            this.button_avvia.Name = "button_avvia";
            this.button_avvia.Size = new System.Drawing.Size(150, 23);
            this.button_avvia.TabIndex = 2;
            this.button_avvia.Text = "Avvia il programma";
            this.button_avvia.UseVisualStyleBackColor = true;
            this.button_avvia.Click += new System.EventHandler(this.Button_avvia_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(371, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Definire all\'avvio del programma lo stato iniziale del pannello e della montatura" +
    "";
            // 
            // button_chiudi
            // 
            this.button_chiudi.Location = new System.Drawing.Point(12, 166);
            this.button_chiudi.Name = "button_chiudi";
            this.button_chiudi.Size = new System.Drawing.Size(75, 23);
            this.button_chiudi.TabIndex = 4;
            this.button_chiudi.Text = "Chiudi";
            this.button_chiudi.UseVisualStyleBackColor = true;
            this.button_chiudi.Click += new System.EventHandler(this.Button_chiudi_Click);
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 201);
            this.Controls.Add(this.button_chiudi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_avvia);
            this.Controls.Add(this.button_montatura);
            this.Controls.Add(this.button_pannello);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StartForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Avvio...";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_pannello;
        private System.Windows.Forms.Button button_montatura;
        private System.Windows.Forms.Button button_avvia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_chiudi;
    }
}