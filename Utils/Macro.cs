using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace rsm.Utils {
    public class Macro {
        public string Name;
        public Key Trigger;
        string _script;
        public List<KeyConfig> Actions { get; private set; } = new List<KeyConfig>();
        public string Script { get { return _script; } set { _script = value; Actions.Clear(); Actions = GetActions(value); } }
        [JsonIgnore]
        public int CurrentActionIndex;
        public bool Enabled;

        public Macro(string name, Key trigger, string script, bool enabled = false) {
            Name = name;
            Trigger = trigger;
            Script = script;
            CurrentActionIndex = 0;
            Enabled = enabled;
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

        public static string GetKey(Key key) {
            switch (key) {
                default: return "none";
                case Key.Escape: return "escape";
                case Key.F1: return "f1";
                case Key.F2: return "f2";
                case Key.F3: return "f3";
                case Key.F4: return "f4";
                case Key.F5: return "f5";
                case Key.F6: return "f6";
                case Key.F7: return "f7";
                case Key.F8: return "f8";
                case Key.F9: return "f9";
                case Key.F10: return "f10";
                case Key.F11: return "f11";
                case Key.F12: return "f12";
                case Key.PrintScreen: return "printscreen";
                case Key.Pause: return "pause";
                case Key.Delete: return "delete";
                case Key.OemTilde: return "`";
                case Key.D1: return "1";
                case Key.D2: return "2";
                case Key.D3: return "3";
                case Key.D4: return "4";
                case Key.D5: return "5";
                case Key.D6: return "6";
                case Key.D7: return "7";
                case Key.D8: return "8";
                case Key.D9: return "9";
                case Key.D0: return "0";
                case Key.OemMinus: return "-";
                case Key.OemPlus: return "=";
                case Key.Back: return "backspace";
                case Key.Home: return "home";
                case Key.Tab: return "tab";
                case Key.OemOpenBrackets: return "[";
                case Key.OemCloseBrackets: return "]";
                case Key.OemBackslash: return "\\";
                case Key.End: return "end";
                case Key.CapsLock: return "capslock";
                case Key.Enter: return "enter";
                case Key.PageUp: return "pageup";
                case Key.LeftShift: return "leftshift";
                case Key.RightShift: return "rightshift";
                case Key.Up: return "up";
                case Key.PageDown: return "pagedown";
                case Key.LeftCtrl: return "leftctrl";
                case Key.LWin: return "leftwin";
                case Key.Space: return "space";
                case Key.RightAlt: return "rightalt";
                case Key.RWin: return "rightwin";
                case Key.RightCtrl: return "rightctrl";
                case Key.Left: return "left";
                case Key.Down: return "down";
                case Key.Right: return "right";
                case Key.A: return "a";
                case Key.B: return "b";
                case Key.C: return "c";
                case Key.D: return "d";
                case Key.E: return "e";
                case Key.F: return "f";
                case Key.G: return "g";
                case Key.H: return "h";
                case Key.I: return "i";
                case Key.J: return "j";
                case Key.K: return "k";
                case Key.L: return "l";
                case Key.M: return "m";
                case Key.N: return "n";
                case Key.O: return "o";
                case Key.P: return "p";
                case Key.Q: return "q";
                case Key.R: return "r";
                case Key.S: return "s";
                case Key.T: return "t";
                case Key.U: return "u";
                case Key.V: return "v";
                case Key.W: return "w";
                case Key.X: return "x";
                case Key.Y: return "y";
                case Key.Z: return "z";
            }
        }
    }
}

public enum ParseMode {
    None, Key, Click
}