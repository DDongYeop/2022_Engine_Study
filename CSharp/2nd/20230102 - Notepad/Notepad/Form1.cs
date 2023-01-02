using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Notepad
{
    public partial class Form1 : Form
    {
        private bool modifyFlag = false;
        private string fileName = "noname.txt";

        public Form1()
        {
            InitializeComponent();
            this.Text = fileName + " - myNotePad";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            modifyFlag = true;
        }

        private void 새로만들기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileProcessBeforeClose();

            txtMemo.Text = "";
            modifyFlag = false;
            fileName = "noname.txt";
        }

        private void fileProcessBeforeClose()
        {
            if (modifyFlag == true)
            {
                DialogResult ans = MessageBox.Show("변경 사항을 저장하겠습니까?", "저장", MessageBoxButtons.YesNo);

                if (ans == DialogResult.Yes)
                {
                    if (fileName == "noname.txt")
                    {
                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            StreamWriter sw = File.CreateText(saveFileDialog1.FileName);
                            sw.WriteLine(txtMemo.Text);
                            sw.Close();
                        }
                    }
                    else
                    {
                        StreamWriter sw = File.CreateText(fileName);
                        sw.WriteLine(txtMemo.Text);
                        sw.Close();
                    }
                }
            }
        }

        private void 열기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileProcessBeforeClose();
            openFileDialog1.ShowDialog();
            fileName = openFileDialog1.FileName;
            this.Text = fileName + " - NotePad";

            try
            {
                StreamReader r = File.OpenText(fileName);
                txtMemo.Text = r.ReadToEnd();
                modifyFlag = false;
                r.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
