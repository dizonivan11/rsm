using System;
using System.Threading;

namespace rsm {
    public class MacroThread {
        private readonly Thread thread;

        public MacroThread(Func<int, int> toRun) {
            this.thread = new Thread(() => {
                while (true) {
                    try { toRun(0); }
                    catch (Exception ex) { Console.WriteLine(ex.Message); }
                    finally { Thread.Sleep(5); }
                }
            });
            thread.SetApartmentState(ApartmentState.STA);
        }

        public static void Start(MacroThread macroThread) {
            macroThread.thread.Start();
        }

        public static void Stop(MacroThread macroThread) {
            if (macroThread != null && macroThread.thread.IsAlive) {
                try { macroThread.thread.Suspend(); } catch (Exception ex) { Console.WriteLine(ex.Message); }
            }
        }
    }
}
