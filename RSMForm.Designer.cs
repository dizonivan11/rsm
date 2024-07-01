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
            this.txtProcessName = new System.Windows.Forms.TextBox();
            this.lblProcessName = new System.Windows.Forms.Label();
            this.lblProcesses = new System.Windows.Forms.Label();
            this.gboxMacro = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.cboxTrigger = new System.Windows.Forms.ComboBox();
            this.btnRename = new System.Windows.Forms.Button();
            this.btnSaveScript = new System.Windows.Forms.Button();
            this.btnEnable = new System.Windows.Forms.Button();
            this.txtMacro = new System.Windows.Forms.TextBox();
            this.pnlMacros = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnToggle = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numDelay)).BeginInit();
            this.gboxMacro.SuspendLayout();
            this.pnlMacros.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboxProcesses
            // 
            this.cboxProcesses.DropDownHeight = 100;
            this.cboxProcesses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxProcesses.DropDownWidth = 250;
            this.cboxProcesses.Enabled = false;
            this.cboxProcesses.FormattingEnabled = true;
            this.cboxProcesses.IntegralHeight = false;
            this.cboxProcesses.Location = new System.Drawing.Point(12, 32);
            this.cboxProcesses.Name = "cboxProcesses";
            this.cboxProcesses.Size = new System.Drawing.Size(250, 21);
            this.cboxProcesses.TabIndex = 0;
            this.cboxProcesses.SelectedIndexChanged += new System.EventHandler(this.SelectProcess);
            // 
            // numDelay
            // 
            this.numDelay.Location = new System.Drawing.Point(85, 59);
            this.numDelay.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numDelay.Name = "numDelay";
            this.numDelay.Size = new System.Drawing.Size(120, 20);
            this.numDelay.TabIndex = 1;
            this.numDelay.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numDelay.ValueChanged += new System.EventHandler(this.UpdateDelay);
            // 
            // lblDelay
            // 
            this.lblDelay.AutoSize = true;
            this.lblDelay.Location = new System.Drawing.Point(12, 61);
            this.lblDelay.Name = "lblDelay";
            this.lblDelay.Size = new System.Drawing.Size(67, 13);
            this.lblDelay.TabIndex = 2;
            this.lblDelay.Text = "Delay (in ms)";
            // 
            // txtProcessName
            // 
            this.txtProcessName.Location = new System.Drawing.Point(268, 32);
            this.txtProcessName.Name = "txtProcessName";
            this.txtProcessName.Size = new System.Drawing.Size(204, 20);
            this.txtProcessName.TabIndex = 3;
            this.txtProcessName.Text = "RagnarokOnline";
            this.txtProcessName.TextChanged += new System.EventHandler(this.UpdateProcessList);
            // 
            // lblProcessName
            // 
            this.lblProcessName.AutoSize = true;
            this.lblProcessName.Location = new System.Drawing.Point(265, 13);
            this.lblProcessName.Name = "lblProcessName";
            this.lblProcessName.Size = new System.Drawing.Size(76, 13);
            this.lblProcessName.TabIndex = 4;
            this.lblProcessName.Text = "Process Name";
            // 
            // lblProcesses
            // 
            this.lblProcesses.AutoSize = true;
            this.lblProcesses.Location = new System.Drawing.Point(12, 13);
            this.lblProcesses.Name = "lblProcesses";
            this.lblProcesses.Size = new System.Drawing.Size(56, 13);
            this.lblProcesses.TabIndex = 5;
            this.lblProcesses.Text = "Processes";
            // 
            // gboxMacro
            // 
            this.gboxMacro.Controls.Add(this.btnDelete);
            this.gboxMacro.Controls.Add(this.cboxTrigger);
            this.gboxMacro.Controls.Add(this.btnRename);
            this.gboxMacro.Controls.Add(this.btnSaveScript);
            this.gboxMacro.Controls.Add(this.btnEnable);
            this.gboxMacro.Controls.Add(this.txtMacro);
            this.gboxMacro.Location = new System.Drawing.Point(0, 0);
            this.gboxMacro.Name = "gboxMacro";
            this.gboxMacro.Size = new System.Drawing.Size(430, 100);
            this.gboxMacro.TabIndex = 0;
            this.gboxMacro.TabStop = false;
            this.gboxMacro.Text = "Macro";
            this.gboxMacro.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(401, -1);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(23, 23);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "🗑";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // cboxTrigger
            // 
            this.cboxTrigger.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxTrigger.FormattingEnabled = true;
            this.cboxTrigger.Items.AddRange(new object[] {
            "none",
            "escape",
            "f1",
            "f2",
            "f3",
            "f4",
            "f5",
            "f6",
            "f7",
            "f8",
            "f9",
            "f10",
            "f11",
            "f12",
            "printscreen",
            "pause",
            "delete",
            "`",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "0",
            "-",
            "=",
            "backspace",
            "home",
            "tab",
            "[",
            "]",
            "\\",
            "end",
            "capslock",
            "enter",
            "pageup",
            "leftshift",
            "rightshift",
            "up",
            "pagedown",
            "leftctrl",
            "leftwin",
            "space",
            "rightalt",
            "rightwin",
            "rightctrl",
            "left",
            "down",
            "right",
            "a",
            "b",
            "c",
            "d",
            "e",
            "f",
            "g",
            "h",
            "i",
            "j",
            "k",
            "l",
            "m",
            "n",
            "o",
            "p",
            "q",
            "r",
            "s",
            "t",
            "u",
            "v",
            "w",
            "x",
            "y",
            "z"});
            this.cboxTrigger.Location = new System.Drawing.Point(112, 72);
            this.cboxTrigger.Name = "cboxTrigger";
            this.cboxTrigger.Size = new System.Drawing.Size(100, 21);
            this.cboxTrigger.TabIndex = 12;
            // 
            // btnRename
            // 
            this.btnRename.Location = new System.Drawing.Point(324, 71);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(100, 23);
            this.btnRename.TabIndex = 11;
            this.btnRename.Text = "Rename";
            this.btnRename.UseVisualStyleBackColor = true;
            // 
            // btnSaveScript
            // 
            this.btnSaveScript.Location = new System.Drawing.Point(218, 71);
            this.btnSaveScript.Name = "btnSaveScript";
            this.btnSaveScript.Size = new System.Drawing.Size(100, 23);
            this.btnSaveScript.TabIndex = 10;
            this.btnSaveScript.Text = "Save";
            this.btnSaveScript.UseVisualStyleBackColor = true;
            // 
            // btnEnable
            // 
            this.btnEnable.BackColor = System.Drawing.Color.Crimson;
            this.btnEnable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnable.ForeColor = System.Drawing.Color.White;
            this.btnEnable.Location = new System.Drawing.Point(6, 71);
            this.btnEnable.Name = "btnEnable";
            this.btnEnable.Size = new System.Drawing.Size(100, 23);
            this.btnEnable.TabIndex = 8;
            this.btnEnable.Text = "Disabled";
            this.btnEnable.UseVisualStyleBackColor = false;
            // 
            // txtMacro
            // 
            this.txtMacro.Location = new System.Drawing.Point(6, 19);
            this.txtMacro.Multiline = true;
            this.txtMacro.Name = "txtMacro";
            this.txtMacro.Size = new System.Drawing.Size(418, 50);
            this.txtMacro.TabIndex = 0;
            // 
            // pnlMacros
            // 
            this.pnlMacros.AutoScroll = true;
            this.pnlMacros.Controls.Add(this.gboxMacro);
            this.pnlMacros.Location = new System.Drawing.Point(12, 85);
            this.pnlMacros.Name = "pnlMacros";
            this.pnlMacros.Size = new System.Drawing.Size(460, 364);
            this.pnlMacros.TabIndex = 8;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(211, 58);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 23);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "Add Macro";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.AddMacro);
            // 
            // btnToggle
            // 
            this.btnToggle.BackColor = System.Drawing.Color.Crimson;
            this.btnToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggle.ForeColor = System.Drawing.Color.White;
            this.btnToggle.Location = new System.Drawing.Point(317, 58);
            this.btnToggle.Name = "btnToggle";
            this.btnToggle.Size = new System.Drawing.Size(100, 23);
            this.btnToggle.TabIndex = 10;
            this.btnToggle.Text = "OFF";
            this.btnToggle.UseVisualStyleBackColor = false;
            this.btnToggle.Click += new System.EventHandler(this.ToggleMacro);
            // 
            // RSMForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.btnToggle);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.pnlMacros);
            this.Controls.Add(this.lblProcesses);
            this.Controls.Add(this.lblProcessName);
            this.Controls.Add(this.txtProcessName);
            this.Controls.Add(this.lblDelay);
            this.Controls.Add(this.numDelay);
            this.Controls.Add(this.cboxProcesses);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "RSMForm";
            this.Text = "Ragnarok Skill Macro";
            ((System.ComponentModel.ISupportInitialize)(this.numDelay)).EndInit();
            this.gboxMacro.ResumeLayout(false);
            this.gboxMacro.PerformLayout();
            this.pnlMacros.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboxProcesses;
        private System.Windows.Forms.NumericUpDown numDelay;
        private System.Windows.Forms.Label lblDelay;
        private System.Windows.Forms.TextBox txtProcessName;
        private System.Windows.Forms.Label lblProcessName;
        private System.Windows.Forms.Label lblProcesses;
        private System.Windows.Forms.GroupBox gboxMacro;
        private System.Windows.Forms.TextBox txtMacro;
        private System.Windows.Forms.Button btnEnable;
        private System.Windows.Forms.Panel pnlMacros;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSaveScript;
        private System.Windows.Forms.Button btnRename;
        private System.Windows.Forms.ComboBox cboxTrigger;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnToggle;
    }
}

