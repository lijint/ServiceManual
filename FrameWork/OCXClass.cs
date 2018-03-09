using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace ServiceManual
{
    class OCXClass
    {
        #region 动态库注册
        /// <summary>
        /// 执行cmd指令
        /// </summary>
        /// <param name="commandText"></param>
        /// <returns></returns>
        protected static string ExeCommand(string commandText)
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            string strOutput = null;
            try
            {
                p.Start();
                p.StandardInput.WriteLine(commandText);
                p.StandardInput.WriteLine("exit");
                strOutput = p.StandardOutput.ReadToEnd();
                p.WaitForExit();
                p.Close();
            }
            catch (Exception e)
            {
                strOutput = e.Message;
            }
            return strOutput;
        }

        /// <summary>
        /// 判断系统位数
        /// </summary>
        /// <returns></returns>
        protected static string Distinguish64or32System()
        {
            try
            {
                string addressWidth = String.Empty;
                ConnectionOptions mConnOption = new ConnectionOptions();
                ManagementScope mMs = new ManagementScope("//localhost", mConnOption);
                ObjectQuery mQuery = new ObjectQuery("select AddressWidth from Win32_Processor");
                ManagementObjectSearcher mSearcher = new ManagementObjectSearcher(mMs, mQuery);
                ManagementObjectCollection mObjectCollection = mSearcher.Get();
                foreach (ManagementObject mObject in mObjectCollection)
                {
                    addressWidth = mObject["AddressWidth"].ToString();
                }
                return addressWidth;
            }
            catch (Exception ex)
            {
                Log.Error("[Distinguish64or32System]判断系统异常Error", ex);
                return String.Empty;
            }
        }

        public static bool RegsvrStarTrans()
        {
            bool bRet = false;
            try
            {
                //是否是初装机

                if (Distinguish64or32System().Contains("64"))
                {
                    Log.Info("64位操作系统");
                    Register64();
                }
                else
                {
                    Log.Info("32位操作系统");
                    Register32();
                }
                bRet = true;
            }
            catch (Exception ex)
            {
                Log.Error("[RegsvrStarTrans]注册异常Error", ex);
            }
            return bRet;
        }
        /// <summary>
        /// 32位注册dll库
        /// </summary>
        private static void Register32()
        {
            try
            {
                //ExeCommand("del %Windir%\\system32\\msxml4.dll");
                //ExeCommand("del %Windir%\\system32\\msxml4r.dll");
                ExeCommand("copy FOXITREADER_AX_PRO.OCX %Windir%\\system32\\");
                //ExeCommand("copy msxml4r.dll %Windir%\\system32\\");
                ExeCommand("regsvr32 %Windir%\\system32\\FOXITREADER_AX_PRO.OCX /s");
                //ExeCommand("regsvr32 BaseSTARTrans.dll /s");
                //ExeCommand("regsvr32 JhSTARTrans.dll /s");
            }
            catch
            {
                throw;
            }

        }

        /// <summary>
        /// 64位注册dll库
        /// </summary>
        private static void Register64()
        {
            try
            {
                ExeCommand("cd /d %~dp0");
                //ExeCommand("del %Windir%\\SysWOW64\\msxml4.dll");
                //ExeCommand("del %Windir%\\SysWOW64\\msxml4r.dll");
                ExeCommand("copy FOXITREADER_AX_PRO.OCX %Windir%\\SysWOW64\\ /y");
                //ExeCommand("copy msxml4r.dll %Windir%\\SysWOW64\\ /y");
                ExeCommand("%Windir%\\SysWOW64\\regsvr32.exe %windir%\\SysWOW64\\FOXITREADER_AX_PRO.OCX /s");
                //ExeCommand("%Windir%\\SysWOW64\\regsvr32.exe  BaseSTARTrans.dll /s");
                //ExeCommand("%Windir%\\SysWOW64\\regsvr32.exe  JhSTARTrans.dll /s");
            }
            catch
            {
                throw;
            }
        }
        #endregion

    }
}
