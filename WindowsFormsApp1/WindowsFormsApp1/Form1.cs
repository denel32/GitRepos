using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public bool Check(string str_, int num_)
        {
            bool res = false;
            string[] answers = new string[6] { "СТАЯ", "АЛИБИ", "НАЙЛОН", "ФААА", "АРКА", "НАЛОГ" };
            if (str_ == answers[num_])
            {
                res = true;
            }
            return res;
        }
        public void True(System.Windows.Forms.TextBox i)
        {
            i.BackColor = System.Drawing.Color.LightGreen;
        }
        public void False(System.Windows.Forms.TextBox i)
        {
            i.BackColor = System.Drawing.Color.LightPink;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel2.Hide();
        }

        private void start_Click(object sender, EventArgs e)
        {
            panel2.Show();
        }

        private void checkBT_Click(object sender, EventArgs e)
        {
            if (!Check(String.Concat(word1_key1.Text, word1_key2.Text, word1_key3_word4_key2.Text, word1_key4.Text), 1 - 1))
            {
                False(word1_key1);
            }
            else
            {
                True(word1_key1);
                word1_key1.Enabled = false;
                word1_key2.Enabled = false;
                word1_key3_word4_key2.Enabled = false;
                word1_key4.Enabled = false;
            }
            //if (!Check(String.Concat(word2_key1, word3_key4_word2_key2, word2_key3, word2_key4, word2_key5), 2 - 1))
            //{
            //    False(word2_key1);
            //}
            //else
            //{
            //    True(word2_key1);
            //    word2_key1.Enabled = false;
            //    word3_key4_word2_key2.Enabled = false;
            //    word2_key3.Enabled = false;
            //    word2_key4.Enabled = false;
            //    word2_key5.Enabled = false;
            //}
        }
        private void key1_TextChanged(object sender, EventArgs e)
        {
            word1_key1.BackColor = System.Drawing.Color.White;
            word1_key4.BackColor = System.Drawing.Color.White;
        }
        private void key1_BackColorChanged(object sender, EventArgs e)
        {
            word1_key2.BackColor = word1_key1.BackColor;
            if (word1_key3_word4_key2.Enabled)
                word1_key3_word4_key2.BackColor = word1_key1.BackColor;
            word1_key4.BackColor = word1_key1.BackColor;
        }

        private void word1_key2_TextChanged(object sender, EventArgs e)
        {
            word1_key1.BackColor = System.Drawing.Color.White;
            word1_key2.BackColor = System.Drawing.Color.White;
            if(word1_key3_word4_key2.Enabled)
            word1_key3_word4_key2.BackColor = System.Drawing.Color.White;
            word1_key4.BackColor = System.Drawing.Color.White;
        }

        private void word1_key3_TextChanged(object sender, EventArgs e)
        {
            word1_key1.BackColor = System.Drawing.Color.White;
            word1_key2.BackColor = System.Drawing.Color.White;
            if (word1_key3_word4_key2.Enabled)
                word1_key3_word4_key2.BackColor = System.Drawing.Color.White;
            word1_key4.BackColor = System.Drawing.Color.White;
        }
        private void word1_key4_TextChanged(object sender, EventArgs e)
        {
            word1_key1.BackColor = System.Drawing.Color.White;
            word1_key2.BackColor = System.Drawing.Color.White;
            if (word1_key3_word4_key2.Enabled)
                word1_key3_word4_key2.BackColor = System.Drawing.Color.White;
            word1_key4.BackColor = System.Drawing.Color.White;

        }

        private void word6_key5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
