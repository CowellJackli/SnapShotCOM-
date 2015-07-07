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
    /*      科威資訊股份有限公司 Cowell Infromation Ltd.
     *      [版權所有 請勿盜用程式碼 本公司保有智慧財產權的相關追朔權利]
     *      元件名稱 : SnapShotCOM
     *      元件用途 : 提供截圖功能使用
     *      作    者 : Jackli
     *      日    期 : 2014/04/28
     *      修改紀錄 :
     *      ==============================================================================     
     *      ==============================================================================      
     * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
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
                p.StartInfo.WorkingDirectory = Application.StartupPath;    //要启动程序路径                
                p.StartInfo.FileName = ExePath + @"\AutoRunSnapShot.exe";//需要启动的程序名   
                p.StartInfo.Arguments = FileName + " " + Dir + " " + Url;//传递的参数       
                p.Start();//启动      
            }
            catch (Exception ex)
            {
                oErr = ex.Message;
            }
        }
    }
}
