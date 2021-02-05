using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tims_1
{
    public partial class Form1 : Form
    {
        Pen pen1, pen2;
        Bitmap bmp;
        Graphics gp;
        Color col;
        Random rand;
        int x = 0, y = 0;
        double r = 0;
        int n = 0;
        double k = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitStartSpace();
            col = Color.Red;
            rand = new Random(0);
            textBox_count.Text = Convert.ToString(100);
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            InitStartSpace();
            textBox_count.Text = "0";
            textBox_result.Text = "0";
            n = 0; k = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            x = rand.Next(1, pictureBox1.Width - 1);
            y = rand.Next(1, pictureBox1.Height - 1);
            r = Math.Sqrt(Convert.ToDouble(Math.Pow(x - pictureBox1.Width / 2, 2) + Math.Pow(y - pictureBox1.Height / 2, 2)));
            if (r > pictureBox1.Width / 2)
            {
                col = Color.Green;
            }
            else
            {
                col = Color.Red;
                k++;
            }
            n++;
            bmp.SetPixel(x, y, col);
            bmp.SetPixel(x + 1, y, col);
            bmp.SetPixel(x, y + 1, col);
            bmp.SetPixel(x + 1, y + 1, col);
            pictureBox1.Image = bmp;
            textBox_result.Text = Convert.ToString(k / n);
            textBox_count.Text = Convert.ToString(n);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            n = 0; k = 0;
            try
            {
                n = Convert.ToInt32(textBox_count.Text);
            }
            catch (Exception)
            {
                textBox_count.Text = "Помилка";
            }
            InitStartSpace();
            
            for (int i = 0; i < n; i++)
            {
                x = rand.Next(1, pictureBox1.Width - 1);
                y = rand.Next(1, pictureBox1.Height - 1);
                r = Math.Sqrt(Convert.ToDouble(Math.Pow(x - pictureBox1.Width / 2, 2) + Math.Pow(y - pictureBox1.Height / 2, 2)));
                if (r > pictureBox1.Width / 2)
                {
                    col = Color.Green;
                }
                else
                {
                    col = Color.Red;
                    k++;
                }
                bmp.SetPixel(x, y, col);
                bmp.SetPixel(x + 1, y, col);
                bmp.SetPixel(x, y + 1, col);
                bmp.SetPixel(x + 1, y + 1, col);
                pictureBox1.Image = bmp;
            }
            
            textBox_result.Text = Convert.ToString(Convert.ToDouble(k / n));
        }


        private void InitStartSpace()
        {
            pen1 = new Pen(Color.Black, 4);
            pen2 = new Pen(Color.Black, 2);
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            gp = Graphics.FromImage(bmp);
            gp.DrawRectangle(pen1, 0, 0, pictureBox1.Width, pictureBox1.Height);
            gp.DrawEllipse(pen2, 2, 2, pictureBox1.Width - 2, pictureBox1.Height - 2);
            pictureBox1.Image = bmp;
        }
    }
}
