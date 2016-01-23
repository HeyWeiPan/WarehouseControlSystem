using EntpClass.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCSServer
{
   public class WriteLog
    {
       public static string LogFile
       {
           get
           {

               return Fn.ToString(System.Configuration.ConfigurationSettings.AppSettings["LogFile"]);

           }
       }


       public static void WriteServerLogs(string s)
       {
           FileStream fs = new FileStream(LogFile, FileMode.OpenOrCreate, FileAccess.Write);
           StreamWriter m_streamWriter = new StreamWriter(fs);
           m_streamWriter.BaseStream.Seek(0, SeekOrigin.End);
           m_streamWriter.WriteLine("WCSServer: "+s+"  Datetime:"+ DateTime.Now.ToString() + "\n");
           m_streamWriter.Flush();
           m_streamWriter.Close();
           fs.Close();
       }

    }
}
