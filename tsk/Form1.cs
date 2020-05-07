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
        public static int CheckLocation(ref List<List<TextBox>> list, Point pos, char werb, ref List<TextBox> werbs)
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
            for (int j = 0; j < 8; j++)
            {
            restart:
                var randword = rand.Next(1, 41);//  [1;41)

                foreach (int i in usedwords)
                {
                    if (randword == i)
                        goto restart;
                }

                string query = "SELECT werb4 FROM Words WHERE num=" + randword;
                OleDbCommand command = new OleDbCommand(query, myConnection);
                var check = rand.Next(2);//  [0;2)
                List<TextBox> werbs = new List<TextBox>();
                int px, py;
                Point pos = new Point();

                if (check == 1)
                {

                    px = rand.Next(3, 13 - command.ExecuteScalar().ToString().Length);//150*150=left top angle/600*600=buttom right angle

                back_py1:
                    py = rand.Next(3, 13);
                    if (py % 2 == 0)
                        goto back_py1;
                }
                else
                {
                back_px2:
                    px = rand.Next(3, 13);
                    if (px % 2 == 0)
                        goto back_px2;

                    py = rand.Next(3, 13 - command.ExecuteScalar().ToString().Length);

                }
                px *= 50; py *= 50;
                bool doublecross = false;
                for (int i = 0; i < command.ExecuteScalar().ToString().Length; i++)
                {

                    pos = new Point(px, py);

                    Point pos_top = new Point(px, py - 50);
                    Point pos_left = new Point(px - 50, py);
                    Point pos_right = new Point(px + 50, py);
                    Point pos_buttom = new Point(px, py + 50);

                    switch (CheckLocation(ref list_of_Textboxes, pos, command.ExecuteScalar().ToString()[i], ref werbs))
                    {
                        case 1:
                            if (doublecross)
                                goto restart;



                            if (check == 1)
                            {
                                px += 50;
                                if (i == command.ExecuteScalar().ToString().Length - 1)
                                {

                                    if (CheckLocation(ref list_of_Textboxes, pos_right, command.ExecuteScalar().ToString()[i], ref werbs) != 0)
                                        goto restart;
                                }
                                else
                                    if (i == 0)
                                {
                                    if (CheckLocation(ref list_of_Textboxes, pos_left, command.ExecuteScalar().ToString()[i], ref werbs) != 0)
                                        goto restart;
                                }
                            }
                            else
                            {
                                if (i == command.ExecuteScalar().ToString().Length - 1)
                                {

                                    if (CheckLocation(ref list_of_Textboxes, pos_buttom, command.ExecuteScalar().ToString()[i], ref werbs) != 1)
                                        goto restart;
                                }
                                if (i == 0)
                                {
                                    if (CheckLocation(ref list_of_Textboxes, pos_top, command.ExecuteScalar().ToString()[i], ref werbs) != 0)
                                        goto restart;
                                }
                                py += 50;
                            }

                            doublecross = true;
                            break;

                        case 0:
                            doublecross = false;
                            pos_top = new Point(px, py - 50);
                            pos_left = new Point(px - 50, py);
                            pos_right = new Point(px + 50, py);
                            pos_buttom = new Point(px, py + 50);

                            Point pos_top2 = new Point(px, py - 100);
                            Point pos_left2 = new Point(px - 100, py);
                            Point pos_right2 = new Point(px + 100, py);
                            Point pos_buttom2 = new Point(px, py + 100);
                            if (i == 0)//first werb
                            {
                                if (CheckLocation(ref list_of_Textboxes, pos_top, command.ExecuteScalar().ToString()[i], ref werbs) != 0
                                    || CheckLocation(ref list_of_Textboxes, pos_left, command.ExecuteScalar().ToString()[i], ref werbs) != 0)
                                {
                                    goto restart;
                                }
                                //if (check==1)
                                //{
                                //    if(CheckLocation(ref list_of_Textboxes, pos_left, command.ExecuteScalar().ToString()[i], ref werbs) != 0
                                //    && CheckLocation(ref list_of_Textboxes, pos_left2, command.ExecuteScalar().ToString()[i], ref werbs) != 0)
                                //}
                            }

                            if (check == 1)
                            {
                                if (CheckLocation(ref list_of_Textboxes, pos_top, command.ExecuteScalar().ToString()[i], ref werbs) != 0 ||
                                    CheckLocation(ref list_of_Textboxes, pos_buttom, command.ExecuteScalar().ToString()[i], ref werbs) != 0)
                                    goto restart;

                                if (i == command.ExecuteScalar().ToString().Length - 1)//last werb
                                {
                                    if (CheckLocation(ref list_of_Textboxes, pos_right, command.ExecuteScalar().ToString()[i], ref werbs) != 0)
                                    {
                                        goto restart;
                                    }
                                }
                            }
                            else
                            {
                                if (CheckLocation(ref list_of_Textboxes, pos_left, command.ExecuteScalar().ToString()[i], ref werbs) != 0 ||
                                    CheckLocation(ref list_of_Textboxes, pos_right, command.ExecuteScalar().ToString()[i], ref werbs) != 0)
                                    goto restart;

                                if (i == command.ExecuteScalar().ToString().Length - 1)//last werb
                                {
                                    if (CheckLocation(ref list_of_Textboxes, pos_buttom, command.ExecuteScalar().ToString()[i], ref werbs) != 0)
                                    {
                                        goto restart;
                                    }
                                }
                            }
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
                {
                    this.Controls.Add(o);
                    textBox1.Text = String.Concat(textBox1.Text, o.Text);
                }
                textBox1.Text = String.Concat(textBox1.Text, "   ");


                usedwords.Add(randword);
                list_of_Textboxes.Add(werbs);
                true_answers.Add(command.ExecuteScalar().ToString());


            }
            //textBox1.Text = String.Concat(list_of_Textboxes[0][0].Text, "  ", list_of_Textboxes[3][0].Text);
        }


    }
}




