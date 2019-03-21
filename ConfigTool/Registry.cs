using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConfigTool
{
    class Registry
    {
        public void AddToRegistry(string key, string keyValue)
        {
            RegistryKey rkSubKeyKontrol = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"Software\Kopitek", true);
            if (rkSubKeyKontrol == null)
            {
                RegistryKey rk;
                rk = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(@"Software\Kopitek");

            }
            RegistryKey rkSubKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"Software\Kopitek", true);
            rkSubKey.SetValue(key, keyValue);
        }
    }
}
