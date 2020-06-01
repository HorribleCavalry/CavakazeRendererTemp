using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace CavakazeRenderer
{
    class DirectX12_Test
    {
        [DllImport("DirectX12_Learning", EntryPoint = "MainWnd", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MainWnd();
    }
}
