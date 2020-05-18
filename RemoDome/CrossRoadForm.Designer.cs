namespace RemoDome
{
    partial class CrossRoadForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CrossRoadForm));
            this.trackBarOpacity = new System.Windows.Forms.TrackBar();
            this.trackBarRadius = new System.Windows.Forms.TrackBar();
            this.panelCrossRoad = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOpacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRadius)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBarOpacity
            // 
            this.trackBarOpacity.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.trackBarOpacity.Location = new System.Drawing.Point(0, 231);
            this.trackBarOpacity.Name = "trackBarOpacity";
            this.trackBarOpacity.Size = new System.Drawing.Size(292, 42);
            this.trackBarOpacity.TabIndex = 0;
            this.trackBarOpacity.Scroll += new System.EventHandler(this.TrackBarOpacity_Scroll);
            // 
            // trackBarRadius
            // 
            this.trackBarRadius.Dock = System.Windows.Forms.DockStyle.Right;
            this.trackBarRadius.Location = new System.Drawing.Point(250, 0);
            this.trackBarRadius.Name = "trackBarRadius";
            this.trackBarRadius.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarRadius.Size = new System.Drawing.Size(42, 231);
            this.trackBarRadius.TabIndex = 1;
            this.trackBarRadius.Scroll += new System.EventHandler(this.TrackBarRadius_Scroll);
            // 
            // panelCrossRoad
            // 
            this.panelCrossRoad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCrossRoad.Location = new System.Drawing.Point(0, 0);
            this.panelCrossRoad.Name = "panelCrossRoad";
            this.panelCrossRoad.Size = new System.Drawing.Size(250, 231);
            this.panelCrossRoad.TabIndex = 2;
            // 
            // CrossRoadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.panelCrossRoad);
            this.Controls.Add(this.trackBarRadius);
            this.Controls.Add(this.trackBarOpacity);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CrossRoadForm";
            this.Text = "CrossRoadForm";
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOpacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRadius)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trackBarOpacity;
        private System.Windows.Forms.TrackBar trackBarRadius;
        private System.Windows.Forms.Panel panelCrossRoad;
    }
}