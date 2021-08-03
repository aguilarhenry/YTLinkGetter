using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YTLinkGetter
{
    public partial class Form1 : MaterialForm
    {

        readonly MaterialSkin.MaterialSkinManager materialSkinManager;
        public Form1()
        {
            InitializeComponent();
            materialSkinManager = MaterialSkin.MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = true;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.Indigo500, MaterialSkin.Primary.Indigo700, MaterialSkin.Primary.Indigo100, MaterialSkin.Accent.Teal400, MaterialSkin.TextShade.WHITE);
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            List<string> urls = new List<string>();

            foreach (var item in textBox1.Lines)
            {
                if (item.Contains("href=\"watch?v="))
                {
                    int i = item.IndexOf("watch?v=");
                    string res = item.Substring(i + 8, 11);
                    res = "https://www.youtube.com/watch?v=" + res;
                    if (!urls.Contains(res))
                        urls.Add(res);


                }
            }

            foreach (var item in urls)
            {
                textBox2.Text += item + Environment.NewLine;
            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo psi = new ProcessStartInfo("https://henryanibal.com/youtube-playlist-link-getter/");
            psi.UseShellExecute = true;
            Process.Start(psi);
        }
    }
}
