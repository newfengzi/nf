using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Web;

namespace QQWinFarm
{
    public partial class FrmFarmLogin : Form
    {
        private System.Net.CookieContainer cookie = new System.Net.CookieContainer(); 
        public FrmFarmLogin()
        {
            InitializeComponent();
        }
        /// <summary> 
        /// 获得验证码 
        /// </summary> 
        private void GgetVerifyImage()
        {
            /*
            System.Drawing.Bitmap bmp = new Bitmap("d:\\getimage.jpg");
            Verify asd = new Verify(bmp);
            asd.writetodata();
            string asdasd = asd.ocrpic();
            string asdasdasd = asd.getchar();
            asd.bp.Save("d:\\1.jpg");
            return;*/
            cookie = new System.Net.CookieContainer();
            Stream s = HttpHelper.GetStream("http://ptlogin2.qq.com/getimage?aid=15000102&0.43878429697395826", cookie);
            if (s == null)
            {
                MessageBox.Show("外挂获取登录码错误，请检查您的网络!", "提示信息");
                Application.ExitThread();
                return;
            }
            picVerify.Image = Image.FromStream(s);
            s.Close();
            // Stream geturlStream =
          
        } 
        /// <summary> 
        /// 登录 
        /// </summary> 
        /// <returns></returns> 
        public void Login()
        {
            this.Invoke((MethodInvoker)delegate
            {
                this.panel1.Enabled = false;
            });
            ChangeMessage("正在登录...");
            string username = txtQQ.Text;
            string userPWD = txtPwd.Text;
            string verifyCode = txtVerify.Text;
            string errorTxt = string.Empty;
            string strRetVal = Utils.getMd5Hash2(Utils.getMd5Hash(userPWD).ToUpper() + verifyCode.ToUpper()).ToUpper();
            string postData = "u=" + username + "&p=" + strRetVal + "&verifycode=" + verifyCode + "&aid=15000101&u1=http%3A%2F%2Fphp.qzone.qq.com%2Findex.php%3Fmod%3Dportal%26act%3Dlogin&fp=loginerroralert&h=1&ptredirect=1&ptlang=0&from_ui=1&dumy=";
            string result = HttpHelper.GetHtml("http://ptlogin2.qq.com/login", postData, true, cookie);
            errorTxt = result;
            result = HttpHelper.GetHtml("http://php.qzone.qq.com/index.php?mod=portal&act=login", cookie);
            bool isLogin = result.Contains("g_iLoginUin = " + username);
            if (!isLogin)
            {
                if (result.Contains("完成跳转"))
                {
                    ChangeMessage("登录成功");
                    isLogin = true;
                }
                else
                {
                    if (!isLogin)
                    {
                        if (result.Contains("g_iLoginUin=" + username))
                        {
                            ChangeMessage("登录成功");
                            isLogin = true;
                        }
                        else
                        {
                            errorTxt = Utils.NoHTML(errorTxt);
                            isLogin = false;
                        }
                    }
                }
            }
            else
            {
                ChangeMessage("登录成功");
                isLogin = true;
            }
            if (isLogin)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    this.Hide();
                    FrmFarmMain fncm = new FrmFarmMain(cookie);
                    fncm.Show();
                });
            }
            else
            {
                this.Invoke((MethodInvoker)delegate
                {
                    this.Text = errorTxt;
                    this.txtVerify.Text = "";
                    MessageBox.Show(errorTxt, "登录失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Invoke((MethodInvoker)delegate
                    {
                        GgetVerifyImage();
                        this.panel1.Enabled = true;
                    });
                    btnLogin.Text = "登录农场";
                });
            }
        }
        private void butVerify_Click(object sender, EventArgs e)
        {
            GgetVerifyImage();
        }

        private void FrmFarmLogin_Load(object sender, EventArgs e)
        {
           // string asdasd = Utils.getMd5Hash2( Utils.getMd5Hash("wwgsxy1113616").ToUpper() +"aaaa").ToUpper();
           // txtVerify.Text = asdasd;
            //MessageBox.Show(Utils.ConvertUnicodeStringToChinese("\u5bd2\u51ac\u6765\u4e34\uff0c\u5316\u80a5\u4f9b\u5e94\u7d27\u5f20\uff0c\u76ee\u524d\u6682\u4e0d\u80fd\u8d2d\u4e70\u5316\u80a5"));
            GgetVerifyImage();
            //int asd = HttpUtility.UrlDecode("274219550%2C314743076%2C513887433%2C393789055%2C412392567%2C383687343%2C31431996%2C501713534%2C19314415%2C375098725%2C1037203778%2C272859849%2C66004972%2C133739699%2C395992151%2C174835435%2C75969483%2C466204965%2C365438983%2C575725040%2C348702205%2C329212797%2C386502%2C360351087%2C410938863%2C124898421%2C7517580%2C455287740%2C609452359%2C903717240%2C97002056%2C154961405%2C443248871%2C969124263%2C715682588%2C8560603%2C498515796%2C25014960%2C417278600%2C269406025%2C413453284%2C381699117%2C328577997%2C305318274%2C383423659%2C475326534%2C376044211%2C76607710%2C87383945%2C444963071%2C361157088%2C278313539%2C413442668%2C20410072%2C490536895%2C165285884%2C964211902%2C417052854%2C605695880%2C29735047%2C670733745%2C278861593%2C215410799%2C289218276%2C514221404%2C472154432%2C513310345%2C541405851%2C81673444%2C44199900%2C545883436%2C776454115%2C664061745%2C835487407%2C646902904%2C835698093%2C380803259%2C303479625%2C350528899%2C153254306%2C501679211%2C527491998%2C364616956%2C670844696%2C937554000%2C285238133%2C53103685%2C412861427%2C182135110%2C454650002%2C517096970%2C308924269%2C415141491%2C377872441%2C717706704%2C43949192%2C77781076%2C294079209%2C554937993%2C517873235%2C380120552%2C505654082%2C19567788%2C382570409%2C461399307%2C281857874%2C736590981%2C31620490%2C850258302%2C441647027%2C729968820%2C522202610%2C1304619321%2C735137618%2C346821509%2C406653107%2C173470964%2C760231716%2C77052110%2C609846483%2C549541136%2C308926828%2C522951420%2C287070081%2C49743302%2C273821141%2C470542808%2C191310611%2C359358188%2C314595028%2C651998448%2C525753549%2C").Split(',').Length;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(Login));
            thread.IsBackground = true;
            thread.Start();
        }
        private void ChangeMessage(string message)
        {
            this.Invoke((MethodInvoker)delegate
            {
                this.Text = message;
            });
        }

        private void txtVerify_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Thread thread = new Thread(new ThreadStart(Login));
                thread.IsBackground = true;
                thread.Start();
            } 
        }

        private void FrmFarmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Dispose();
            System.Environment.Exit(System.Environment.ExitCode);
        }

        private void txtVerify_KeyPress(object sender, KeyPressEventArgs e)
        {
            char asdasd = e.KeyChar;
            if (asdasd == ',')
            { }
        }
    }
}
