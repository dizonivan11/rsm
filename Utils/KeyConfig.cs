using System.Windows.Input;

namespace rsm.Utils {
    public class KeyConfig {
        public int DelayAfter { get; set; }
        public Key Key { get; set; }
        public bool ClickActive { get; set; }

        public KeyConfig(Key key, bool clickAtive, int delayAfter = -1) {
            Key = key;
            ClickActive = clickAtive;
            DelayAfter = delayAfter;
        }
    }
}
