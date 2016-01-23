using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.IO;

/// <summary>
///FileService 的摘要说明
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
//若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。 
// [System.Web.Script.Services.ScriptService]
public class FileService : System.Web.Services.WebService
{

    public FileService()
    {

        //如果使用设计的组件，请取消注释以下行 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }

    //将Stream流转换为byte数组的方法。   
    public byte[] ConvertStreamToByteBuffer(Stream s)
    {
        if (!CheckUserRight(null, null))
        {
            throw new Exception("invalid user");
        }


        MemoryStream ms = new MemoryStream();
        int b;
        while ((b = s.ReadByte()) != -1)
        {
            ms.WriteByte((byte)b);
        }
        return ms.ToArray();
    }

    [WebMethod]
    public bool UpFile(byte[] data,string filePath, string fileName)
    {
        if (!CheckUserRight(null, null))
        {
            throw new Exception("invalid user");
        }

        try
        {
            FileStream fs = File.Create(filePath + @"\" + fileName);
            fs.Write(data, 0, data.Length);
            fs.Close();
            return true;
        }
        catch
        {
            return false;
        }
    }

    //下载WebService所在服务器上的文件的方法
    [WebMethod]
    public byte[] DownFile(string filePath,string fileName)
    {
        string filepath = filePath + @"\" + fileName;
        if (File.Exists(filepath))
        {
            try
            {
                FileStream s = File.OpenRead(filepath);
                return ConvertStreamToByteBuffer(s);
            }
            catch
            {
                return new byte[0];
            }
        }
        else
        {
            return new byte[0];
        }
    }

    /// <summary>
    /// 从soap头判断用户名，密码是否ok
    /// </summary>
    /// <param name="userName"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    private bool CheckUserRight(string userName, string password)
    {
        return true;
    }
}

