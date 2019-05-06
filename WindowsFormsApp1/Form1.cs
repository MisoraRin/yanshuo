using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;

namespace WindowsFormsApp1
{
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        static int x = 0, y = 0, h = 1368, w = 768;

        private void button3_Click(object sender, EventArgs e)
        {
            string url = "https://api.gushi.ci/all.txt";
            string res = GetHttpResponse(url, 6000);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap(1920, 1080);
            Graphics g = Graphics.FromImage(bitmap);
            SolidBrush mybrush = new SolidBrush(Color.FromArgb(230, 230, 230));
            g.FillRectangle(mybrush,new Rectangle(0,0,1920,1080));
            // g.Clear(Color.Transparent);
           
           // g.Dispose();
            Font myfont;
            myfont = new Font("方正细金陵简体", 50);         //设置默认字体格式

            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            SolidBrush newbrush = new SolidBrush(Color.FromArgb(1, 1, 1));
            g.DrawString(getShi(), myfont, newbrush, new Rectangle(0, 0, 1920,1080-150), sf);

            bitmap.Save("C:\\Users\\zwt\\Desktop\\h.png", ImageFormat.Png);
            WinAPI.SystemParametersInfo(20, 1, "C:\\Users\\zwt\\Desktop\\h.png", 0x1 | 0x2);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Image a= Image.FromFile("C:\\Users\\zwt\\Desktop\\timg.jpg");
            
            Graphics g = Graphics.FromImage(a);
            SolidBrush mybrush;
            mybrush = new SolidBrush(Color.Lime);  //设置默认画刷颜色
            Font myfont;
            myfont = new Font("方正细金陵简体", 14);         //设置默认字体格式
            g.DrawString("厉害了word歌", myfont, mybrush, new Rectangle(0, 0, 500, 500));
            StringFormat sf=new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            g.DrawString("哈哈哈哈哈哈", myfont, mybrush, new Rectangle(0, 0, a.Height-100, a.Width), sf);
            
            
            a.Save("C:\\Users\\zwt\\Desktop\\timg1.jpg");
        }

        public static string getShi()
        {
            string url = "https://api.gushi.ci/all.txt";
            string res = GetHttpResponse(url, 6000);
            return res;
        }
        public static string GetHttpResponse(string url, int Timeout)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";
            request.UserAgent = null;
            request.Timeout = Timeout;

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();

            return retString;
        }
    }
    public class WinAPI
    {
        [DllImport("user32.dll", EntryPoint = "SystemParametersInfo")]
        public static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);
    }
}
