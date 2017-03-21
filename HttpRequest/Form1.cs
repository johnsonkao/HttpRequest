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
        //static string param = "hl=zh-CN&newwindow=1";
        //byte[] bs = Encoding.ASCII.GetBytes(param);

        private HttpWebRequest req;
        Random _rand = new Random();
        

        public Form1()
        {
            InitializeComponent();



            //    req.Method = "POST";
            //    req.ContentType = "application/x-www-form-urlencoded";
            //    req.ContentLength = bs.Length;
            //
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var watch = Stopwatch.StartNew();
            // the code that you want to measure comes here
            int maxCount;
            maxCount = int.Parse(txtCounts.Text);
            button1.Enabled = false;
            for (int i = 0; i < maxCount; i++)
            {


                RequestSomePage();

                if (chkAppendQuertString.Checked)
                    System.Threading.Thread.Sleep(8000);
                //if ((i % 20) == 0)
                //    System.Threading.Thread.Sleep(300);
                //if ((i % 250) == 0)
                //    System.Threading.Thread.Sleep(30000);

                //if ((i % 1000) == 0)
                //    System.Threading.Thread.Sleep(60000);
            }

            MessageBox.Show("Finished");
            button1.Enabled = true;

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            TimeSpan ts = watch.Elapsed;
            textBox1.Text = ts.ToString("mm\\:ss\\.ff");
        }

        private string GetQueryString()
        {
            string ret;
             DateTime nowDt = DateTime.Now;
             ret = nowDt.Year.ToString() + nowDt.Month.ToString("00") + nowDt.Day.ToString("00")
                   + nowDt.Hour.ToString("00") + nowDt.Minute.ToString("00") + nowDt.Second.ToString("00") +
                   nowDt.Millisecond.ToString();
            // Guid gid;
            //ret = gid.NewGuid();

            return ret= "?a=" +ret;
        }
        private void RequestSomePage()
        {
            string url = txtUrl.Text;

           
            if (chkAppendQuertString.Checked)
            {
                url +=  GetQueryString();
            }

            req =(HttpWebRequest)HttpWebRequest.Create( url);
            req.Date = DateTime.Now;

            HttpRequestCachePolicy noCachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.NoCacheNoStore);
            req.CachePolicy = noCachePolicy;
            req.Credentials = CredentialCache.DefaultCredentials;
            req.KeepAlive = false;
   
            using (WebResponse wr = req.GetResponse())
            {
                //在這裡對接收到的頁面內容進行處理



            }
            req.Abort();
            
            //req = (HttpWebRequest)HttpWebRequest.Create("http://www.google.com/webhp");


            // Define a cache policy for this request only. 


            //using (Stream reqStream = req.GetRequestStream())
            //{
            //   reqStream.Write(bs, 0, bs.Length);
            //}

            //var result = req.RequestUri=(req.RequestUri + "getRandomNum&rubbish=" + _rand.Next(), cookie);


            //req.Abort();
            


        }
    }
}
