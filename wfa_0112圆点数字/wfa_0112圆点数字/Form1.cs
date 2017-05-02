using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wfa_0112圆点数字
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.pictureBox2.Image = TextToBitmap("9", this.Font, Rectangle.Empty, Brushes.DarkBlue, Color.Transparent);
        }

        /// <summary>
        /// 把文字转换才Bitmap
        /// </summary>
        /// <param name="text"></param>
        /// <param name="font"></param>
        /// <param name="rect">用于输出的矩形，文字在这个矩形内显示，为空时自动计算</param>
        /// <param name="fontcolor">字体颜色</param>
        /// <param name="backColor">背景颜色</param>
        /// <returns></returns>
        private Bitmap TextToBitmap(string text, Font font, Rectangle rect, Brush brush, Color backColor)
        {
            Graphics g;
            Bitmap bmp;
            StringFormat format = new StringFormat(StringFormatFlags.NoClip);
            if (rect == Rectangle.Empty)
            {
                bmp = new Bitmap(1, 1);
                g = Graphics.FromImage(bmp);
                //计算绘制文字所需的区域大小（根据宽度计算长度），重新创建矩形区域绘图
                SizeF sizef = g.MeasureString(text, font, PointF.Empty, format);

                int width = (int)(sizef.Width + 1);
                int height = (int)(sizef.Height + 1);
                rect = new Rectangle(0, 0, width, height);
                bmp.Dispose();

                bmp = new Bitmap(width, height);
            }
            else
            {
                bmp = new Bitmap(rect.Width, rect.Height);
            }

            g = Graphics.FromImage(bmp);

            //使用ClearType字体功能
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            g.FillRectangle(new SolidBrush(backColor), rect);
            g.DrawString(text, font, brush, rect, format);
            return bmp;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Graphics gra = this.pictureBox2.CreateGraphics();
            gra.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Pen pen = new Pen(Color.Pink);//画笔颜色 
            gra.DrawEllipse(pen, 0, 0, 100, 100);//画椭圆的方法，x坐标、y坐标、宽、高，如果是100，则半径为50

            //Graphics gra = this.pictureBox1.CreateGraphics();
            Font myFont = new Font("宋体", 60, FontStyle.Bold);
            Brush bush = new SolidBrush(Color.Red);//填充的颜色
            gra.DrawString("测试", myFont, bush, 0, 0);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.pictureBox2.Image = Properties.Resources.Image48;
            using (Graphics g = Graphics.FromImage(this.pictureBox2.Image))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.FillEllipse(new SolidBrush(Color.Red), 0, 0, 20, 20);
            };
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Graphics gra = this.pictureBox1.CreateGraphics();
            Graphics gra = Graphics.FromImage(this.pictureBox1.Image);
            gra.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Brush bush = new SolidBrush(Color.Red);//填充的颜色
            gra.FillEllipse(bush, 0, 0, 20, 20);//画填充椭圆的方法，x坐标、y坐标、宽、高，如果是100，则半径为50

            int iLeft = this.textBox1.Text.Length == 2 ? 3 : 6;
            gra.DrawString(this.textBox1.Text, new Font("宋体",9), new SolidBrush(Color.White), iLeft, 4);

            this.pictureBox1.Refresh();

            using (Graphics g = Graphics.FromImage(this.button5.Image))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.FillEllipse(new SolidBrush(Color.Red), 0, 0, 20, 20);
                g.DrawString(this.textBox1.Text, new Font("宋体", 9), new SolidBrush(Color.White), iLeft, 4);
                this.button5.Refresh();
            };

            using (Graphics g = Graphics.FromImage(this.toolStripButton1.Image))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.FillEllipse(new SolidBrush(Color.Red), 0, 0, 20, 20);
                g.DrawString(this.textBox1.Text, new Font("宋体", 9), new SolidBrush(Color.White), iLeft, 4);
                this.toolStrip1.Refresh();
            };
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(string.Format("Width:{0}; Height:{1}", toolStripButton1.Width, toolStripButton1.Height));
        }

     
    }
}

