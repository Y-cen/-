using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _06_坦克大战_正式
{
    public partial class Form1 : Form
    {
        private Thread t;

        private static Graphics windowG;

        private static Bitmap tempBm;

        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            windowG = this.CreateGraphics();

            tempBm = new Bitmap(450, 450);
            Graphics tempBmG = Graphics.FromImage(tempBm);
            GameFramework.g = tempBmG;

            t = new Thread(new ThreadStart(GameMainThread));
            t.Start();
        }

        private static void GameMainThread()
        {
            GameFramework.Start();

            int sleepTime = 1000 / 60; // 60帧

            while (true)
            {
                GameFramework.g.Clear(Color.Black); 

                GameFramework.Update();

                windowG.DrawImage(tempBm, 0, 0);

                Thread.Sleep(sleepTime);
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            // 主线程会等待子线程关闭
            t.Abort();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            GameObjectManager.KeyDown(e);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            GameObjectManager.KeyUp(e);
        }
    }
}
