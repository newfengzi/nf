using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Json;
namespace QQWinFarm
{
    public partial class FrmBog : Form
    {
        NewsBog newsbog = new NewsBog();
        public FrmBog()
        {
            InitializeComponent();
        }
        public FrmBog(NewsBog bog)
        {
            newsbog = bog;
            InitializeComponent();
        }

        private void FrmBog_Load(object sender, EventArgs e)
        {
            for (int x = 0; x < newsbog.FruitPicking.GetCollection().Count; x++)
            {
                JsonObject json =new JsonObject(newsbog.FruitPicking.GetCollection()[x].GetValue(0));
                if (json != null)
                {
                    lbInfo.Items.Add("采摘（" + Utils.ConvertUnicodeStringToChinese(json.GetValue("name")) +"） "+
                 json.GetValue("num") + "个");
                }
                }
              
        }
    }
}
