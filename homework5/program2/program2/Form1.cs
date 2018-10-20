using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace program2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private const double DOUBLE_DELTA = 1E-06;
 
        private void button1_Click(object sender, EventArgs e)
        {
            if (graphics == null) graphics = this.CreateGraphics();
            if (!int.TryParse(textBox1.Text, out Th2) || Th2 < 10 || Th2 > 40)//左分支角度
            {
                Th2 = 20;
            }
            if (!int.TryParse(textBox2.Text, out Th1) || Th1 < 10 || Th1 > 40)//右分支角度
            {
                Th1 = 30;
            }
            if (!(double.TryParse(textBox3.Text, out per2) && per2-0.8 < DOUBLE_DELTA && per2 - 0.6 > DOUBLE_DELTA))//左分支长度比
            {
                per2 = 0.7;
            }
            if (!(double.TryParse(textBox4.Text, out per1) && per1 - 0.8 < DOUBLE_DELTA && per1 - 0.6 > DOUBLE_DELTA))//右分支长度比
            {
                per1 = 0.6;
            }
            drawCayleyTree(10, 500, 510, 100, -Math.PI / 2,width);
        }
        private Graphics graphics;
        static int Th1 = 30;
        static int Th2 = 20;
        double th1 = Th1 * Math.PI / 180;
        double th2 = Th2 * Math.PI / 180;
        double per1 = 0.6;
        double per2 = 0.7;
        double k = 0.8;
        float width = 3f;  //树的粗细
        Color[] newColor = new Color[5] {
            Color.Sienna,
            Color.LimeGreen,
            Color.LawnGreen,
            Color.GreenYellow,
            Color.PaleGreen };
        
        void drawCayleyTree(int n, double x0, double y0, double leng, double th,float wth)
        {
            if (n == 0) return;

            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);
            double x2 = x0 + leng * k * Math.Cos(th);
            double y2 = y0 + leng * k * Math.Sin(th);
            
            width = (float)(3 - (10 - n) * 0.25);

            if (n <= 10 && n >= 9)
            {

                drawLine(newColor[0], x0, y0, x1, y1);
            }
            else if (n == 8) {
                drawLine(newColor[1], x0, y0, x1, y1);
            } else if (n == 7) {
                drawLine(newColor[2], x0, y0, x1, y1);
            }
            else
            {
                drawLine(newColor[4 - n%2], x0, y0, x1, y1);
            }

            drawCayleyTree(n - 1, x1, y1, leng * per1, th + th1,width);
            drawCayleyTree(n - 1, x2, y2, leng * per2, th - th2, width);
        }

        void drawLine(Color color,double x0, double y0, double x1, double y1)
        {
           Pen pen = new Pen(color, width);
            graphics.DrawLine(pen, (int)x0, (int)y0, (int)x1, (int)y1);
        }
      
        
        /// <summary>
        /// 绿色+棕色
        /// </summary>
        
        private void radioButton16_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton16.Checked)
            {
                newColor[0] = Color.Sienna;
                newColor[1] = Color.LimeGreen;
                newColor[2] = Color.LawnGreen;
                newColor[3] = Color.GreenYellow;
                newColor[4] = Color.PaleGreen;

            }
        }
        /// <summary>
        /// 绿色+灰白色
        /// </summary>
        private void radioButton13_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton13.Checked)
            {
                newColor[0] = Color.Silver;
                newColor[1] = Color.YellowGreen;
                newColor[2] = Color.LightGreen;
                newColor[3] = Color.PaleGreen;
                newColor[4] = Color.PaleGoldenrod;
            }
        }
        /// <summary>
        /// 金黄色+棕色
        /// </summary>
        private void radioButton15_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton15.Checked)
            {
                newColor[0] = Color.SaddleBrown;
                newColor[1] = Color.Peru;
                newColor[2] = Color.Tan;
                newColor[3] = Color.Gold;
                newColor[4] = Color.Yellow;
            }
        }
        /// <summary>
        /// 枫叶红+棕色
        /// </summary>
        private void radioButton14_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton14.Checked)
            {
                newColor[0] = Color.SaddleBrown;
                newColor[1] = Color.Maroon;
                newColor[2] = Color.Crimson;
                newColor[3] = Color.OrangeRed;
                newColor[4] = Color.Red;
            }
        }
        /// <summary>
        /// 紫红色+棕色
        /// </summary>
        private void radioButton11_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton11.Checked)
            {
                newColor[0] = Color.SaddleBrown;
                newColor[1] = Color.Maroon;
                newColor[2] = Color.MediumVioletRed;
                newColor[3] = Color.Firebrick;
                newColor[4] = Color.DeepPink;
            }
        }
        /// <summary>
        ///  随机
        /// </summary>
        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton10.Checked)
            {
                newColor[0] = Color.FromArgb(new Random(Guid.NewGuid().GetHashCode()).Next(10, 100), new Random(Guid.NewGuid().GetHashCode()).Next(0, 250), new Random(Guid.NewGuid().GetHashCode()).Next(0, 250), new Random(Guid.NewGuid().GetHashCode()).Next(0, 250));
                newColor[1] = Color.FromArgb(new Random(Guid.NewGuid().GetHashCode()).Next(10, 100), new Random(Guid.NewGuid().GetHashCode()).Next(0, 250), new Random(Guid.NewGuid().GetHashCode()).Next(0, 250), new Random(Guid.NewGuid().GetHashCode()).Next(0, 250));
                newColor[2] = Color.FromArgb(new Random(Guid.NewGuid().GetHashCode()).Next(10, 100), new Random(Guid.NewGuid().GetHashCode()).Next(0, 250), new Random(Guid.NewGuid().GetHashCode()).Next(0, 250), new Random(Guid.NewGuid().GetHashCode()).Next(0, 250));
                newColor[3] = Color.FromArgb(new Random(Guid.NewGuid().GetHashCode()).Next(10, 100), new Random(Guid.NewGuid().GetHashCode()).Next(0, 250), new Random(Guid.NewGuid().GetHashCode()).Next(0, 250), new Random(Guid.NewGuid().GetHashCode()).Next(0, 250));
                newColor[4] = Color.FromArgb(new Random(Guid.NewGuid().GetHashCode()).Next(10, 100), new Random(Guid.NewGuid().GetHashCode()).Next(0, 250), new Random(Guid.NewGuid().GetHashCode()).Next(0, 250), new Random(Guid.NewGuid().GetHashCode()).Next(0, 250));

            }
        }
        /// <summary>
        /// 左分支角度
        /// </summary>
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }



}
