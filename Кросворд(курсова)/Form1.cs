using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Кросворд_курсова_
{
    public partial class Form1 : Form
    {
        public static string connectString = "Provider=Microsoft.JET.OLEDB.4.0;Data Source=Database1.mdb;";
        private OleDbConnection myConnection;
        public Form1()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            string query = "SELECT w FROM Words ORDER BY num";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataReader reader = command.ExecuteReader();
            for(int i=1;reader.Read();i++)
            {

            }
                

        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            myConnection.Close();
        }
        public TextBox[][] words = new TextBox[6][];
        public string[] answers = new string[6];
        public string[] true_answers = new string[6] { "СТАЯ", "АЛИБИ", "НАЙЛОН", "ФААА", "АРКА", "НАЛОГ" };
        private void Form1_Load(object sender, EventArgs e)
        {
            panel2.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //words initialisation
            {
                words[0] = new TextBox[4] { w1_k1, w1_k2, w1_k3_h_w4_k2, w1_k4 };
                words[1] = new TextBox[5] { w2_k1, w2_k2_h_w6_k4, w2_k3, w2_k4, w2_k5 };
                words[2] = new TextBox[6] { w3_k1_h_w6_k1, w5_k4_h_w6_k2, w6_k3, w2_k2_h_w6_k4, w6_k5, w6_k6 };
                words[3] = new TextBox[4] { w4_k1, w1_k3_h_w4_k2, w4_k3, w3_k2_h_w4_k4 };
                words[4] = new TextBox[4] { w5_k1, w5_k2, w5_k3, w5_k4_h_w6_k2 };
                words[5] = new TextBox[5] { w3_k1_h_w6_k1, w3_k2_h_w4_k4, w3_k3, w3_k4, w3_k5 };

                for (int i = 0; i < answers.Length; i++)//масив сконкатенированых текстбоксов
                {
                    string tmp = string.Empty;
                    for (int j = 0; j < words[i].Length; j++)
                    {
                        tmp = String.Concat(tmp, words[i][j].Text);
                    }
                    answers[i] = tmp;
                }
            }
            bool end = true;
            for (int i = 0; i < true_answers.Length; i++)
            {
                if (true_answers[i] == answers[i])
                {
                    for (int j = 0; j < words[i].Length; j++)
                    {
                        words[i][j].BackColor = System.Drawing.Color.LightGreen;
                        words[i][j].Enabled = false;
                    }
                }
                else
                {
                    end = false;
                    for (int j = 0; j < words[i].Length; j++)
                    {
                        if (words[i][j].Enabled)
                            words[i][j].BackColor = System.Drawing.Color.LightPink;

                    }
                }
            }
            if (end)
            {
                panel1.Hide();
                panel2.Size = new System.Drawing.Size(809, 455);
                panel2.Show();
                //END
            }
        }


    }
}
