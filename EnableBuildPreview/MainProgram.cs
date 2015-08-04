using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnableBuildPreview
{
    class MainProgram
    {
        static void Main(string[] args)
        {
            string enabled;

            do
            {
                Console.Write("Do you want Preview Build? (Y/N): ");
                enabled = Convert.ToString(Console.ReadLine());

                switch (enabled)
                {
                    case "Y":
                        EnableBP(true);
                        break;
                    case "N":
                        EnableBP(false);
                        break;
                }
            } while (enabled != "Y" && enabled != "N");

            enabled = string.Empty;

            do
            {
                Console.Write("Restart computer? (Y/N): ");
                enabled = Convert.ToString(Console.ReadLine());
                switch (enabled)
                {
                    case "Y":
                        RestartComputer(true);
                        break;
                    case "N":
                        RestartComputer(false);
                        break;
                }
            } while (enabled != "Y" && enabled != "N");
        }

        private static void EnableBP(bool enable)
        {
            Microsoft.Win32.RegistryKey HKLM = Microsoft.Win32.Registry.LocalMachine;
            Microsoft.Win32.RegistryKey key = HKLM.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\BuildAndTel");
            key.SetValue("EnableBuildPreview", enable ? 1 : 0, Microsoft.Win32.RegistryValueKind.DWord);
        }

        private static void RestartComputer(bool enable)
        {
            if (enable == true)
            {
                System.Diagnostics.Process.Start("shutdown.exe", "-r -t 0");
            }
            else
            {
                Environment.Exit(0);
            }
            
        }
    }
}
