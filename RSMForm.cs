using rsm.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using Newtonsoft.Json;
using System.Linq;
using rsm.Dialogs;

namespace rsm {
    public partial class RSMForm : Form {
        const string CONFIG_PATH = @"rsmconfig.json";
        const int MACRO_PADDING = 8;
        MacroThread thread;
        Config config;

        // Import the mouse_event function from the Windows API
        [DllImport("user32.dll")]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, int dwExtraInfo);

        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        public RSMForm() {
            InitializeComponent();

            if (File.Exists(CONFIG_PATH)) {
                // Load saved config
                config = JsonConvert.DeserializeObject<Config>(File.ReadAllText(CONFIG_PATH));
            } else {
                // Generate default config
                config = new Config() {
                    processName = txtProcessName.Text,
                    delay = (int)numDelay.Value,
                    macros = new List<Macro>()
                };
                SaveConfig();
            }

            // Load config
            txtProcessName.Text = config.processName;
            numDelay.Value = config.delay;
            for (int m = 0; m < config.macros.Count; m++) {
                GenerateMacroUI(m);
            }
        }

        public void Start() {
            Client roClient = ClientSingleton.GetClient();

            if (roClient != null) {
                if (thread != null) { MacroThread.Stop(thread); }
                thread = new MacroThread(_ => AHKThreadExecution(roClient));
                MacroThread.Start(thread);
            }
        }

        int AHKThreadExecution(Client roClient) {
            foreach (Macro macro in config.macros) {
                if (macro.Trigger == Key.None || !macro.Enabled) continue;
                while (Keyboard.IsKeyDown(macro.Trigger)) {
                    if (macro.CurrentActionIndex < macro.Actions.Count - 1) macro.CurrentActionIndex++;
                    else macro.CurrentActionIndex = 0;
                    var action = macro.Actions[macro.CurrentActionIndex];
                    Keys thisk = (Keys)Enum.Parse(typeof(Keys), action.Key.ToString());
                    Interop.PostMessage(roClient.process.MainWindowHandle, Constants.WM_KEYDOWN_MSG_ID, thisk, 0);
                    if (action.ClickActive) {
                        Point cursorPos = System.Windows.Forms.Cursor.Position;
                        mouse_event(Constants.MOUSEEVENTF_LEFTDOWN, (uint)cursorPos.X, (uint)cursorPos.Y, 0, 0);
                        Thread.Sleep(1);
                        mouse_event(Constants.MOUSEEVENTF_LEFTUP, (uint)cursorPos.X, (uint)cursorPos.Y, 0, 0);
                    }
                    Thread.Sleep(action.DelayAfter < 0 ? (int)numDelay.Value : action.DelayAfter);
                    Console.WriteLine(thisk);
                }
                macro.CurrentActionIndex = 0;
            }
            return 0;
        }

        void GenerateMacroUI(int index) {
            var macro = config.macros[index];
            GroupBox gboxMacroInstance = new GroupBox {
                Text = macro.Name,
                Size = gboxMacro.Size
            };
            if (index > 0) {
                gboxMacroInstance.Location = new Point(
                    gboxMacro.Location.X,
                    pnlMacros.Controls[index].Bounds.Bottom + MACRO_PADDING);
            } else {
                gboxMacroInstance.Location = new Point(
                    gboxMacro.Location.X,
                    gboxMacro.Location.Y);
            }
            TextBox txtMacroInstance = new TextBox() {
                Multiline = true,
                Size = txtMacro.Size,
                Location = txtMacro.Location,
                Text = macro.Script
            };
            Button btnEnableInstance = new Button() {
                Size = btnEnable.Size,
                Location = btnEnable.Location,
                Text = macro.Enabled ? "Enabled" : "Disabled",
                BackColor = macro.Enabled ? Color.OliveDrab : Color.Crimson,
                ForeColor = btnEnable.ForeColor,
                FlatStyle = btnEnable.FlatStyle
            };
            ComboBox cboxTriggerInstance = new ComboBox() {
                Size = cboxTrigger.Size,
                Location = cboxTrigger.Location,
                DropDownStyle = cboxTrigger.DropDownStyle
            };
            cboxTriggerInstance.Items.AddRange(cboxTrigger.Items.OfType<string>().ToArray());
            cboxTriggerInstance.SelectedIndex = cboxTriggerInstance.Items.IndexOf(Macro.GetKey(macro.Trigger));
            Button btnSaveScriptInstance = new Button() {
                Size = btnSaveScript.Size,
                Location = btnSaveScript.Location,
                Text = btnSaveScript.Text
            };
            Button btnRenameInstance = new Button() {
                Size = btnRename.Size,
                Location = btnRename.Location,
                Text = btnRename.Text
            };
            Button btnDeleteInstance = new Button() {
                Size = btnDelete.Size,
                Location = btnDelete.Location,
                Text = btnDelete.Text
            };

            // Macro Editor Events
            btnEnableInstance.Click += (sender, e) => {
                if (btnEnableInstance.Text == "Enabled") {
                    macro.Enabled = false;
                    btnEnableInstance.Text = "Disabled";
                    btnEnableInstance.BackColor = Color.Crimson;
                } else {
                    macro.Enabled = true;
                    btnEnableInstance.Text = "Enabled";
                    btnEnableInstance.BackColor = Color.OliveDrab;
                }
                SaveConfig();
            };
            cboxTriggerInstance.SelectedIndexChanged += (sender, e) => {
                macro.Trigger = Macro.GetKey(cboxTriggerInstance.Text);
                SaveConfig();
            };
            btnSaveScriptInstance.Click += (sender, e) => {
                macro.Script = txtMacroInstance.Text;
                macro.UpdateActions();
                SaveConfig();
            };
            btnRenameInstance.Click += (sender, e) => {
                var form = new dialogRename(macro.Name);
                var result = form.ShowDialog();

                if (result == DialogResult.OK) {
                    macro.Name = form.Result;
                    gboxMacroInstance.Text = macro.Name;
                    SaveConfig();
                }
            };
            btnDeleteInstance.Click += (sender, e) => {
                MessageBox.Show("Under development...", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };

            gboxMacroInstance.Controls.Add(txtMacroInstance);
            gboxMacroInstance.Controls.Add(btnEnableInstance);
            gboxMacroInstance.Controls.Add(cboxTriggerInstance);
            gboxMacroInstance.Controls.Add(btnSaveScriptInstance);
            gboxMacroInstance.Controls.Add(btnRenameInstance);
            gboxMacroInstance.Controls.Add(btnDeleteInstance);
            pnlMacros.Controls.Add(gboxMacroInstance);
        }

        void SelectProcess(object sender, EventArgs e) {
            ClientSingleton.Instance(new Client(cboxProcesses.Text));
        }

        void AddMacro(object sender, EventArgs e) {
            var newMacro = new Macro("Macro " + (config.macros.Count + 1), Key.None, "");
            config.macros.Add(newMacro);
            SaveConfig();

            GenerateMacroUI(config.macros.IndexOf(newMacro));
        }

        void UpdateProcessList(object sender, EventArgs e) {
            config.processName = txtProcessName.Text;
            SaveConfig();

            var processes = Process.GetProcessesByName(txtProcessName.Text);
            if (processes.Length > 0) cboxProcesses.Items.Clear();
            else {
                cboxProcesses.Enabled = false;
                return;
            }
            cboxProcesses.Enabled = true;
            for (int i = 0; i < processes.Length; i++) {
                cboxProcesses.Items.Add(processes[i].ProcessName + ".exe - " + processes[i].Id);
            }
        }

        void UpdateDelay(object sender, EventArgs e) {
            config.delay = (int)numDelay.Value;
            SaveConfig();
        }

        void ToggleMacro(object sender, EventArgs e) {
            if (btnToggle.Text == "ON") {
                btnToggle.Text = "OFF";
                btnToggle.BackColor = Color.Crimson;
                if (thread != null) { MacroThread.Stop(thread); thread = null; }
            } else {
                Client roClient = ClientSingleton.GetClient();
                if (roClient != null) {
                    if (thread != null) { MacroThread.Stop(thread); }
                    thread = new MacroThread(_ => AHKThreadExecution(roClient));
                    MacroThread.Start(thread);
                    btnToggle.Text = "ON";
                    btnToggle.BackColor = Color.OliveDrab;
                } else {
                    MessageBox.Show("Select process first", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        void SaveConfig() {
            string configContent = JsonConvert.SerializeObject(config, Formatting.Indented);
            File.WriteAllText(CONFIG_PATH, configContent);
        }
    }
}
