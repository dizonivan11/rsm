using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace rsm.Utils {
    public class Macro {
        public Key Trigger { get; set; }
        public List<KeyConfig> Actions { get; set; } = new List<KeyConfig>();
        public int CurrentActionIndex { get; set; }

        public Macro(Key trigger, List<KeyConfig> actions) {
            Trigger = trigger;
            Actions = actions;
        }

        public static List<KeyConfig> GetActions(string macroContent) {
            List<KeyConfig> KeyConfigs = new List<KeyConfig>();
            int currentCharIndex = 0;
            ParseMode currentMode = ParseMode.None;
            KeyConfig previousKeyConfig = null;
            bool currentClickActive = false;
            StringBuilder stringBuffer = new StringBuilder();
            while (currentCharIndex < macroContent.Length) {
                char currentChar = macroContent[currentCharIndex];
                switch (currentMode) {
                    case ParseMode.None:
                        switch (currentChar) {
                            default:
                                // Storing delay
                                stringBuffer.Append(currentChar);
                                break;
                            case '{':
                                // Saving delay for previous keyconfig
                                if (stringBuffer.Length > 0) {
                                    try { previousKeyConfig.DelayAfter = int.Parse(stringBuffer.ToString()); } catch (Exception) { }
                                    stringBuffer.Clear();
                                    previousKeyConfig = null;
                                }
                                currentMode = ParseMode.Key;
                                break;
                        }
                        break;
                    case ParseMode.Key:
                        switch (currentChar) {
                            default:
                                // Storing key
                                stringBuffer.Append(currentChar);
                                break;
                            case '}':
                                // Saving keyconfig
                                var kc = new KeyConfig(GetKey(stringBuffer.ToString()), currentClickActive);
                                previousKeyConfig = kc;
                                KeyConfigs.Add(kc);
                                stringBuffer.Clear();
                                currentClickActive = false;
                                currentMode = ParseMode.None;
                                break;
                            case ' ':
                                currentMode = ParseMode.Click;
                                break;
                        }
                        break;
                    case ParseMode.Click:
                        switch (currentChar) {
                            default: break;
                            case 'c':
                                currentClickActive = true;
                                break;
                            case '}':
                                // Saving keyconfig
                                var kc = new KeyConfig(GetKey(stringBuffer.ToString()), currentClickActive);
                                previousKeyConfig = kc;
                                KeyConfigs.Add(kc);
                                stringBuffer.Clear();
                                currentClickActive = false;
                                currentMode = ParseMode.None;
                                break;
                        }
                        break;
                    default: break;
                }
                currentCharIndex++;
            }
            return KeyConfigs;
        }

        public static Key GetKey(string key) {
            switch (key.ToLower().Trim()) {
                default: return Key.None;
                case "escape": return Key.Escape;
                case "f1": return Key.F1;
                case "f2": return Key.F2;
                case "f3": return Key.F3;
                case "f4": return Key.F4;
                case "f5": return Key.F5;
                case "f6": return Key.F6;
                case "f7": return Key.F7;
                case "f8": return Key.F8;
                case "f9": return Key.F9;
                case "f10": return Key.F10;
                case "f11": return Key.F11;
                case "f12": return Key.F12;
                case "printscreen": return Key.PrintScreen;
                case "pause": return Key.Pause;
                case "delete": return Key.Delete;
                case "`": return Key.OemTilde;
                case "1": return Key.D1;
                case "2": return Key.D2;
                case "3": return Key.D3;
                case "4": return Key.D4;
                case "5": return Key.D5;
                case "6": return Key.D6;
                case "7": return Key.D7;
                case "8": return Key.D8;
                case "9": return Key.D9;
                case "0": return Key.D0;
                case "-": return Key.OemMinus;
                case "=": return Key.OemPlus;
                case "backspace": return Key.Back;
                case "home": return Key.Home;
                case "tab": return Key.Tab;
                case "[": return Key.OemOpenBrackets;
                case "]": return Key.OemCloseBrackets;
                case "\\": return Key.OemBackslash;
                case "end": return Key.End;
                case "capslock": return Key.CapsLock;
                case "enter": return Key.Enter;
                case "pageup": return Key.PageUp;
                case "leftshift": return Key.LeftShift;
                case "rightshift": return Key.RightShift;
                case "up": return Key.Up;
                case "pagedown": return Key.PageDown;
                case "leftctrl": return Key.LeftCtrl;
                case "leftwin": return Key.LWin;
                case "space": return Key.Space;
                case "rightalt": return Key.RightAlt;
                case "rightwin": return Key.RWin;
                case "rightctrl": return Key.RightCtrl;
                case "left": return Key.Left;
                case "down": return Key.Down;
                case "right": return Key.Right;
                case "a": return Key.A;
                case "b": return Key.B;
                case "c": return Key.C;
                case "d": return Key.D;
                case "e": return Key.E;
                case "f": return Key.F;
                case "g": return Key.G;
                case "h": return Key.H;
                case "i": return Key.I;
                case "j": return Key.J;
                case "k": return Key.K;
                case "l": return Key.L;
                case "m": return Key.M;
                case "n": return Key.N;
                case "o": return Key.O;
                case "p": return Key.P;
                case "q": return Key.Q;
                case "r": return Key.R;
                case "s": return Key.S;
                case "t": return Key.T;
                case "u": return Key.U;
                case "v": return Key.V;
                case "w": return Key.W;
                case "x": return Key.X;
                case "y": return Key.Y;
                case "z": return Key.Z;
            }
        }
    }
}

public enum ParseMode {
    None, Key, Click
}