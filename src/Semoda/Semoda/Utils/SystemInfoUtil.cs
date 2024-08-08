using System;
using System.IO;
using System.Management;
using System.Runtime.InteropServices;

namespace Semoda.Utils
{
    /// <summary>
    /// Util class to get informations about the system.
    /// </summary>
    public class SystemInfoUtil
    {
        /// <summary>
        /// Gets the total available memory of the system in MB
        /// </summary>
        /// <returns>The total available memory of the system in MB</returns>
        public static ulong GetTotalPhysicalMemoryMB()
        {
            ulong totalPhysicalMemory = 0;

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT TotalPhysicalMemory FROM Win32_ComputerSystem");
                foreach (ManagementObject queryObj in searcher.Get())
                {
                    totalPhysicalMemory += Convert.ToUInt64(queryObj["TotalPhysicalMemory"]);
                }

                return totalPhysicalMemory / (1024 * 1024);
            }
            else
            {
                using (StreamReader reader = new StreamReader("/proc/meminfo"))
                {
                    string? line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.StartsWith("MemTotal:"))
                        {
                            string[] parts = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            if (parts.Length == 3 && parts[2] == "kB")
                            {
                                totalPhysicalMemory = Convert.ToUInt64(parts[1]) / 1024; // Convert from kB to mbytes
                                break;
                            }
                        }
                    }
                }

                return totalPhysicalMemory;
            }
        }
    }
}