using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _10102_경동엽
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            EXcar(5);
        }

        private void Line1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            /*if (e.KeyCode == Keys.Left)
                if (Car.Location.X >= 0)
                    Car.Location.X += 5;*/
        }

        int x;
        Random r = new Random();

        void EXcar(int speed)
        {
            if (RamBo1.Location.Y >= 500)
            {

            }
            else
            {
                //RamBo1.Location.Y += speed;
            }
        }


        void coins()
        {
            
        }
    }
}
// 제 멘탈좀 돌려주세요 