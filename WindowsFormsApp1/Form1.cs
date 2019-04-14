using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            var bmp = new Bitmap(1000, 1000);
            using (var g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
            }
            drawCircle(bmp, 50, 100, 100);
            pictureBox1.Image = bmp;
        }

        private void drawCircle(Bitmap bmp, int r, int x, int y)
        {
            int rSquared = r * r;

            int error((int x, int y) point)
            {
                return Math.Abs((point.x - x) * (point.x - x) + (point.y - y) * (point.y - y) - rSquared);
            };

            (int x, int y) top = (x, y + r);
            (int x, int y) left = (x - r, y);

            var current = top;

            do
            {
                bmp.SetPixel(current.x, current.y, Color.Red);
                bmp.SetPixel(x - current.x + 2 * r, current.y, Color.Blue);
                bmp.SetPixel(current.x, y - current.y + 2 * r, Color.Green);
                bmp.SetPixel(x - current.x + 2 * r, y - current.y + 2 * r, Color.Purple);

                (int x, int y) nextLeft = (current.x - 1, current.y);
                (int x, int y) nextDown = (current.x, current.y - 1);
                (int x, int y) nextDownLeft = (current.x - 1, current.y - 1);

                current = nextLeft;
                if (error(nextDown) < error(current))
                    current = nextDown;
                if (error(nextDownLeft) < error(current))
                    current = nextDownLeft;

            } while (current.x >= left.x && current.y >= left.y);
        }
    }
}
