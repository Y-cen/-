using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _05_坦克大战
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // 设置窗体的生成位置
            // 焦点屏幕中心
            this.StartPosition = FormStartPosition.CenterScreen;
            // 自定义
            //this.StartPosition = FormStartPosition.Manual;
            //this.Location = new Point(800, 500);    
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = this.CreateGraphics();
            Pen p = new Pen(Color.Black);
            // 绘制线条
            g.DrawLine(p, new Point(0, 0), new Point(100, 100));
            // 绘制字符串
            g.DrawString("Hello WinForm",
                new Font("隶书", 20),
                new SolidBrush(Color.Red),
                new Point(100, 100));
            // 绘制图片
            Image boss = Properties.Resources.Boss;
            g.DrawImage(boss, new Point(150, 150));
            // 去除图片背景
            Bitmap star1 = Properties.Resources.Star1;
            star1.MakeTransparent(Color.Black);
            g.DrawImage(star1, new Point(200, 200));
        }
    }
}
