using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Kopyl.BlockPC.App.Sys
{
    class PCLocker
    {
        [DllImport("user32.dll")]
        private static extern bool LockWorkStation();

        public static void Lock()
        {
            LockWorkStation();
        }
    }
}
