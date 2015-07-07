using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;//GUID
using System.EnterpriseServices;
using System.Drawing.Imaging;
using System.IO;//引用COM+

namespace SnapShotCom_
{
    public interface ISnapShot
    {
        string Url { get; set; }
        string FileName { get; set; }
        string Dir { get; set; }
        string ExePath { get; set; }
        string oErr { get; set; }
        void Save();

    }
    public class SnapShot : ServicedComponent, ISnapShot
    {

        public string Url { get; set; }
        public string FileName { get; set; }
        public string Dir { get; set; }
        public string oErr { get; set; }
        public string ExePath { get; set; }

        public void Save()
        {
            try
            {
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo.WorkingDirectory = Application.StartupPath;      //啟動路徑             
                p.StartInfo.FileName = ExePath + @"\AutoRunSnapShot.exe";   //啟動程序名稱
                p.StartInfo.Arguments = FileName + " " + Dir + " " + Url;   //參數傳送       
                p.Start();//開始運作      
            }
            catch (Exception ex)
            {
                oErr = ex.Message;
            }
        }
    }
}
