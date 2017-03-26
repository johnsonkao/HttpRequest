using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
//using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace HttpRequest
{
    public partial class Form1 : Form
    {

        private HttpWebRequest _req; 
        Random _rand = new Random();
       
        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            var watch = Stopwatch.StartNew();//計數用
            int maxCount; //尋訪最大數
            maxCount = int.Parse(txtCounts.Text);

            button1.Enabled = false;//不可再重複送出
            for (int i = 0; i < maxCount; i++)
            {
                RequestSomePage();

                if (chkSleep.Checked)
                    System.Threading.Thread.Sleep(8000);//休息8秒
            }

            MessageBox.Show("Finished");
            button1.Enabled = true;

            watch.Stop();//Stop計數
            var elapsedMs = watch.ElapsedMilliseconds;
            TimeSpan ts = watch.Elapsed;
            textBox1.Text = ts.ToString("mm\\:ss\\.ff");//顯示費時
        }

        private string GetQueryString()
        {
            string ret;
             DateTime nowDt = DateTime.Now;
             ret = nowDt.Year.ToString() + nowDt.Month.ToString("00") + nowDt.Day.ToString("00")
                   + nowDt.Hour.ToString("00") + nowDt.Minute.ToString("00") + nowDt.Second.ToString("00") +
                   nowDt.Millisecond.ToString();
            return ret= "?a=" +ret;
        }
        private void RequestSomePage()
        {
            string url = txtUrl.Text;   //設定URL       
            if (chkAppendQuertString.Checked)
            {
                url +=  GetQueryString(); //加入字串
            }

            _req =(HttpWebRequest)HttpWebRequest.Create( url); //建立HttpWebRequest
            _req.Date = DateTime.Now;

            //HttpRequestCachePolicy noCachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.NoCacheNoStore);
            //req.CachePolicy = noCachePolicy;
            //req.Credentials = CredentialCache.DefaultCredentials;
            //req.KeepAlive = false;
   
            using (WebResponse wr = _req.GetResponse())
            {
                //在這裡對接收到的頁面內容進行處理
                //這裡不做任何事
            }
            _req.Abort();
            
        }
    }
}
