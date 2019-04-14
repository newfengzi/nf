using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
namespace QQWinFarm
{
    public partial class FrmFramVerify : Form
    {
        private System.Net.CookieContainer cookie = new System.Net.CookieContainer();
        string _uid = "";
        public FrmFramVerify(System.Net.CookieContainer _cookieContainer,string uid)
        {
            cookie = _cookieContainer;
            _uid = uid;
            InitializeComponent();
        }
        public FrmFramVerify()
        {
            InitializeComponent();
        }
        
        #region 获得验证码
        /// <summary> 
        /// 获得验证码 
        /// </summary> 
        private void GgetVerifyImage()
        {
            Stream s = HttpHelper.GetStream("http://ptlogin2.qq.com/getimage?aid=353&0.49157994566485286", cookie);
            if (s == null)
            {
                MessageBox.Show("外挂获取登陆码错误，请检查您的网络!", "提示信息");
                Application.ExitThread();
                return;
            }
            picVerify.Image = Image.FromStream(s);
            s.Close();
        }
        #endregion

        private void FrmFramVerify_Load(object sender, EventArgs e)
        {
            GgetVerifyImage();
        }
        private void butVerify_Click(object sender, EventArgs e)
        {
            GgetVerifyImage();
        }

        private void btnsubmit_Click(object sender, EventArgs e)
        {
            Thread thread1 = new Thread(new ThreadStart(PostVerify));
            thread1.IsBackground = false;
            thread1.Start();
        }
        private void PostVerify()
        {
            this.Invoke((MethodInvoker)delegate
            {
                panel1.Enabled = false;
                string verifyCode = txtVerify.Text;
                string url = "http://nc.qzone.qq.com/cgi-bin/cgi_farm_index?mod=user&act=run&ownerId="+_uid+"&validatemsg=" + verifyCode;
                //string url = "http://happyfarm.qzone.qq.com/api.php?mod=friend";
                
                string farmtime = FarmKey.GetFarmTime();
                //validatemsg=swnw&uIdx=361157088&cIds=31%2C40%2C41%2C101&farmTime=1259974536&uId=361157088&farmKey=94500a55ae0a93b960df291449238a1c
                string postData = "uIdx=" + _uid + "&validatemsg=" + verifyCode + "&farmTime=" + farmtime + "&farmKey=" + FarmKey.GetFarmKey(farmtime);
                string asd = HttpHelper.GetHtml(url,cookie);
                if (asd != "")
                {
 
                }
                this.Dispose();
                this.Close();
            });
        }
        private void txtVerify_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                EventArgs es=new EventArgs();
                btnsubmit_Click(sender, es);
            } 
        }
    }
}
