using Microsoft.Win32;
using System.Diagnostics;

namespace KHOpenApi.NET.Helpers
{
    internal class OcxPathHelper
    {
        public static string GetOcxPathFromClassID(string classID)
        {
            var regPath = @"\CLSID\" + classID + @"\InProcServer32\";
            return GetDefaultRegistryValue(Registry.ClassesRoot, regPath);
        }

        public static string GetClassIDFromProgID(string progID)
        {
            var regPath = progID + @"\CLSID\";
            return GetDefaultRegistryValue(Registry.ClassesRoot, regPath);
        }

        private static string GetDefaultRegistryValue(RegistryKey rootKey, string regPath)
        {
            try
            {
                //var regPermission = new RegistryPermission(RegistryPermissionAccess.Read,
                //                                           @"HKEY_CLASSES_ROOT\" + regPath);
                //regPermission.Demand();
                using var regKey = rootKey.OpenSubKey(regPath);
                if (regKey != null)
                {
                    if (regKey.GetValue("") is string defaultValue)
                    {
                        return defaultValue;
                    }
                }
            }
            catch
            {
                //log error
            }
            return string.Empty;
        }

        public static string GetOcxPathFromWOW6432NodeClassID(string classID)
        {
            var regPath = @"\WOW6432Node\CLSID\" + classID + @"\InProcServer32\";
            return GetDefaultRegistryValue(Registry.ClassesRoot, regPath);
        }

        public static int RegisterOCX(string OcxPath, bool isRegist)
        {
            // https://pcheruku.wordpress.com/2008/09/15/c-sample-to-register-dll-files-programatically/

            int result = 0;
            try
            {
                //'/s' : indicates regsvr32.exe to run silently.
                string fileinfo = (isRegist ? "/s" : "/u /s") + " " + "\"" + OcxPath + "\"";

                Process reg = new Process();
                reg.StartInfo.FileName = "regsvr32.exe";
                reg.StartInfo.Arguments = fileinfo;
                reg.StartInfo.UseShellExecute = false;
                reg.StartInfo.CreateNoWindow = true;
                reg.StartInfo.RedirectStandardOutput = true;
                reg.Start();
                reg.WaitForExit();
                reg.Close();
            }
            catch
            {
                result = -1;
            }

            return result;
        }
        public static async Task<bool> ReqisterOCXAsync(string path)
        {
            var task = Task.Factory.StartNew(() =>
            {
                return RegisterOCX(path, true);
            });

            int result = await task.ConfigureAwait(true);
            return result >= 0;
        }
    }
}
