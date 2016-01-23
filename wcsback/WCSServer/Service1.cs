using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WCSServer
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
            InitService();
        }

        /// <summary>
        /// 初始化服务参数
        /// </summary>
        private void InitService()
        {
            base.AutoLog = false;
            base.CanShutdown = true;
            base.CanStop = true;
            base.CanPauseAndContinue = true;
            base.ServiceName = "WCSServer";  //这个名字很重要，设置不一致会产生错误哦！
        }

        protected override void OnStart(string[] args)
        {
            WriteLog.WriteServerLogs("Start..");
            SendCmd sc = new SendCmd();
            sc.Start();
            
        }

        protected override void OnStop()
        {
            WriteLog.WriteServerLogs("Stop..");
        }

        protected override void OnPause()
        {
            base.OnPause();
            SendCmd sc = new SendCmd();
            sc.Start();
        }



       
    }
}
