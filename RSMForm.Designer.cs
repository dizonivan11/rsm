namespace rsm {
    partial class RSMForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.cboxProcesses = new System.Windows.Forms.ComboBox();
            this.numDelay = new System.Windows.Forms.NumericUpDown();
            this.lblDelay = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numDelay)).BeginInit();
            this.SuspendLayout();
            // 
            // cboxProcesses
            // 
            this.cboxProcesses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxProcesses.FormattingEnabled = true;
            this.cboxProcesses.Location = new System.Drawing.Point(12, 12);
            this.cboxProcesses.Name = "cboxProcesses";
            this.cboxProcesses.Size = new System.Drawing.Size(278, 21);
            this.cboxProcesses.TabIndex = 0;
            this.cboxProcesses.SelectedIndexChanged += new System.EventHandler(this.cboxProcesses_SelectedIndexChanged);
            // 
            // numDelay
            // 
            this.numDelay.Location = new System.Drawing.Point(52, 39);
            this.numDelay.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numDelay.Name = "numDelay";
            this.numDelay.Size = new System.Drawing.Size(120, 20);
            this.numDelay.TabIndex = 1;
            this.numDelay.ValueChanged += new System.EventHandler(this.numDelay_ValueChanged);
            // 
            // lblDelay
            // 
            this.lblDelay.AutoSize = true;
            this.lblDelay.Location = new System.Drawing.Point(12, 41);
            this.lblDelay.Name = "lblDelay";
            this.lblDelay.Size = new System.Drawing.Size(34, 13);
            this.lblDelay.TabIndex = 2;
            this.lblDelay.Text = "Delay";
            // 
            // RSMForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblDelay);
            this.Controls.Add(this.numDelay);
            this.Controls.Add(this.cboxProcesses);
            this.Name = "RSMForm";
            this.Text = "Ragnarok Skill Macro";
            ((System.ComponentModel.ISupportInitialize)(this.numDelay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboxProcesses;
        private System.Windows.Forms.NumericUpDown numDelay;
        private System.Windows.Forms.Label lblDelay;
    }
}

