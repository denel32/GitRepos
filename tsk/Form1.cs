using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace tsk
{
    public partial class Form1 : Form
    {

        public static string connectString = "Provider=Microsoft.JET.OLEDB.4.0;Data Source=Database1.mdb;";
        private OleDbConnection myConnection;
        public List<string> true_answers = new List<string>();
        public List<int> usedwords = new List<int>();
        public List<List<TextBox>> list_of_Textboxes = new List<List<TextBox>>();
        public static int CheckLocation(ref List<List<TextBox>> list, Point pos, char werb, List<TextBox> werbs)
        {
            for (int k = 0; k < list.Count; k++)
            {
                for (int l = 0; l < list[k].Count; l++)
                {
                    if (pos.ToString() == list[k][l].Location.ToString())
                    {
                        if (list[k][l].Text == werb.ToString())
                        {
                            werbs.Add(list[k][l]);
                            return 1;
                        }
                        else
                            return -1;
                    }
                }
            }
            return 0;
        }
        public Form1()
        {
            InitializeComponent();
            ClientSize = new Size(800, 800);
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            Paint += (sender, args) =>
            {
                args.Graphics.FillRectangle(Brushes.Black, 150, 150, 500, 500);
            };

            var rand = new Random();

            for (int j = 0; j < 10; j++)
            {

            restart:
                var randword = rand.Next(1, 41);//  [1;41)

                foreach (int i in usedwords)
                {
                    if (randword == i)
                        goto restart;
                }
                usedwords.Add(randword);

                string query = "SELECT werb4 FROM Words WHERE num=" + randword;
                OleDbCommand command = new OleDbCommand(query, myConnection);


                var check = rand.Next(2);//  [0;2)
                List<TextBox> werbs = new List<TextBox>();
                int px = 50, py = 50;
                Point pos = new Point();

                if (check == 1)
                {
                    px *= rand.Next(3, 13 - command.ExecuteScalar().ToString().Length);//150*150=left top angle/600*600=buttom right angle
                    py *= rand.Next(3, 13);
                }
                else
                {
                    px *= rand.Next(3, 13);
                    py *= rand.Next(3, 13 - command.ExecuteScalar().ToString().Length);
                }


                for (int i = 0; i < command.ExecuteScalar().ToString().Length; i++)
                {
                    pos = new Point(px, py);

                    switch (CheckLocation(ref list_of_Textboxes, pos, command.ExecuteScalar().ToString()[i], werbs))
                    {
                        case 1:

                            if (check == 1)
                                px += 50;
                            else
                                py += 50;
                            break;

                        case 0:
                            werbs.Add(new TextBox());
                            werbs[i].Name = "w" + j.ToString() + "k" + i.ToString();
                            werbs[i].Location = new Point(px, py);
                            werbs[i].Size = new Size(50, 50);
                            werbs[i].Multiline = true;
                            werbs[i].MaxLength = 1;
                            werbs[i].TextAlign = HorizontalAlignment.Center;
                            werbs[i].BorderStyle = BorderStyle.Fixed3D;
                            werbs[i].CharacterCasing = CharacterCasing.Upper;
                            werbs[i].Font = new Font("Times New Roman", this.Height / 30);
                            if (check == 1)
                                px += 50;
                            else
                                py += 50;

                            werbs[i].Text = command.ExecuteScalar().ToString()[i].ToString();
                            break;

                        default:
                            goto restart;
                    }
                }
                foreach (TextBox o in werbs)
                    this.Controls.Add(o);

                list_of_Textboxes.Add(werbs);
                true_answers.Add(command.ExecuteScalar().ToString());


            }
            //textBox1.Text = String.Concat(list_of_Textboxes[0][0].Text, "  ", list_of_Textboxes[3][0].Text);
        }
    }
}




