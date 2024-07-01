using rsm.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace rsm {
    public partial class RSMForm : Form {
        private MacroThread thread;
        public List<Macro> macros { get; set; } = new List<Macro>();
        public int Delay { get; set; } = 50;

        // Import the mouse_event function from the Windows API
        [DllImport("user32.dll")]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, int dwExtraInfo);

        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        public RSMForm() {
            InitializeComponent();
            numDelay.Value = Delay;

            macros.Add(new Macro(Key.F3, Macro.GetActions("{9}{F3 c}{delete}")));
            macros.Add(new Macro(Key.F4, Macro.GetActions("{9}{y c}{u c}")));
            macros.Add(new Macro(Key.D5, Macro.GetActions("{5 c}{delete}")));

            var processes = Process.GetProcessesByName("RenegadeRO");
            for (int i = 0; i < processes.Length; i++) {
                cboxProcesses.Items.Add(processes[i].ProcessName + ".exe - " + processes[i].Id);
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

        private int AHKThreadExecution(Client roClient) {
            foreach (Macro macro in macros) {
                while (Keyboard.IsKeyDown(macro.Trigger)) {
                    if (macro.CurrentActionIndex < macro.Actions.Count - 1) macro.CurrentActionIndex++;
                    else macro.CurrentActionIndex = 0;
                    var action = macro.Actions[macro.CurrentActionIndex];
                    Keys thisk = (Keys)Enum.Parse(typeof(Keys), action.Key.ToString());
                    Point cursorPos = System.Windows.Forms.Cursor.Position;
                    Interop.PostMessage(roClient.process.MainWindowHandle, Constants.WM_KEYDOWN_MSG_ID, thisk, 0);

                    if (action.ClickActive) {
                        mouse_event(Constants.MOUSEEVENTF_LEFTDOWN, (uint)cursorPos.X, (uint)cursorPos.Y, 0, 0);
                        Thread.Sleep(1);
                        mouse_event(Constants.MOUSEEVENTF_LEFTUP, (uint)cursorPos.X, (uint)cursorPos.Y, 0, 0);
                    }
                    Thread.Sleep(action.DelayAfter < 0 ? Delay : action.DelayAfter);
                    Console.WriteLine(thisk);
                }
                macro.CurrentActionIndex = 0;
            }
            return 0;
        }

        private void cboxProcesses_SelectedIndexChanged(object sender, EventArgs e) {
            ClientSingleton.Instance(new Client(cboxProcesses.Text));
            Start();
        }

        private void numDelay_ValueChanged(object sender, EventArgs e) {
            Delay = (int)numDelay.Value;
        }
    }
}
