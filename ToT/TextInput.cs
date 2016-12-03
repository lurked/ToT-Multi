using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace ToT
{
    class TextInput
    {
        static KeyboardState ActualKeyState,
                             LastKeyState;
        public static string text = ""; //This string is important to us, because we want to call this in the Game1 class
        static string _char;

        static Keys[] keysToCheck = new Keys[] 
        { 
               Keys.D0, Keys.D1, Keys.D2, Keys.D3,
               Keys.D4, Keys.D5, Keys.D6, Keys.D7,
               Keys.D8, Keys.D9,

               Keys.Space,

               Keys.A, Keys.B, Keys.C, Keys.D, Keys.E,
               Keys.F, Keys.G, Keys.H, Keys.I, Keys.J,
               Keys.K, Keys.L, Keys.M, Keys.N, Keys.O,
               Keys.P, Keys.Q, Keys.R, Keys.S, Keys.T,
               Keys.U, Keys.V, Keys.W, Keys.X, Keys.Y,
               Keys.Z, Keys.Back, Keys.OemPeriod 
        };

        public static void Update()
        {
            LastKeyState = ActualKeyState;
            ActualKeyState = Keyboard.GetState();

            foreach (Keys key in keysToCheck)
            {
                if (ActualKeyState.IsKeyDown(key) && LastKeyState.IsKeyUp(key))
                {
                    _char = null;

                    switch (key)
                    {
                        case Keys.D0:
                            _char += "0";
                            break;
                        case Keys.D1:
                            _char += "1";
                            break;
                        case Keys.D2:
                            _char += "2";
                            break;
                        case Keys.D3:
                            _char += "3";
                            break;
                        case Keys.D4:
                            _char += "4";
                            break;
                        case Keys.D5:
                            _char += "5";
                            break;
                        case Keys.D6:
                            _char += "6";
                            break;
                        case Keys.D7:
                            _char += "7";
                            break;
                        case Keys.D8:
                            _char += "8";
                            break;
                        case Keys.D9:
                            _char += "9";
                            break;


                        case Keys.Space:
                            _char += " ";
                            break;
                            

                        case Keys.A:
                            _char += "a";
                            break;
                        case Keys.B:
                            _char += "b";
                            break;
                        case Keys.C:
                            _char += "c";
                            break;
                        case Keys.D:
                            _char += "d";
                            break;
                        case Keys.E:
                            _char += "e";
                            break;
                        case Keys.F:
                            _char += "f";
                            break;
                        case Keys.G:
                            _char += "g";
                            break;
                        case Keys.H:
                            _char += "h";
                            break;
                        case Keys.I:
                            _char += "i";
                            break;
                        case Keys.J:
                            _char += "j";
                            break;
                        case Keys.K:
                            _char += "k";
                            break;
                        case Keys.L:
                            _char += "l";
                            break;
                        case Keys.M:
                            _char += "m";
                            break;
                        case Keys.N:
                            _char += "n";
                            break;
                        case Keys.O:
                            _char += "o";
                            break;
                        case Keys.P:
                            _char += "p";
                            break;
                        case Keys.Q:
                            _char += "q";
                            break;
                        case Keys.R:
                            _char += "r";
                            break;
                        case Keys.S:
                            _char += "s";
                            break;
                        case Keys.T:
                            _char += "t";
                            break;
                        case Keys.U:
                            _char += "u";
                            break;
                        case Keys.V:
                            _char += "v";
                            break;
                        case Keys.W:
                            _char += "w";
                            break;
                        case Keys.X:
                            _char += "x";
                            break;
                        case Keys.Y:
                            _char += "y";
                            break;
                        case Keys.Z:
                            _char += "z";
                            break;
                        case Keys.OemPeriod:
                            _char += ".";
                            break;
                        case Keys.Back:
                            if (text.Length != 0)
                            {
                                text = text.Remove(text.Length - 1);
                            }
                            break;
                    }
                    if (key != Keys.Back)
                    {
                        if (ActualKeyState.IsKeyDown(Keys.LeftShift) ||
                            ActualKeyState.IsKeyDown(Keys.RightShift))
                        {
                            _char = _char.ToUpper();
                        }
                    }
                    if (text.Length < 140)
                        text += _char;
                }
            }
        }
    }
}
