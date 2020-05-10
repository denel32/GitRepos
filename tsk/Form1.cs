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

        public Panel startpanel = new Panel();
        public Panel diffchoosepanel = new Panel();
        public Button diff1 = new Button();
        public Button diff2 = new Button();
        public Button diff3 = new Button();
        void Buttonsdestroy()
        {
            diff1.Dispose();
            diff2.Dispose();
            diff3.Dispose();
        }

        public static int CheckLocation(ref List<List<TextBox>> list, Point pos, char verb, ref List<TextBox> verbs)
        {
            for (int k = 0; k < list.Count; k++)
            {
                for (int l = 0; l < list[k].Count; l++)
                {
                    if (pos.ToString() == list[k][l].Location.ToString())
                    {
                        if (list[k][l].Text == verb.ToString())
                        {
                            verbs.Add(list[k][l]);
                            return 1;
                        }
                        else
                            return -1;
                    }
                }
            }
            return 0;
        }
        private void diff3_click(object sender, EventArgs e)
        {
            int verb8 = 3;
            int verb7 = 3;
            int verb6 = 3;
            int verb5 = 2;
            int verb4 = 2;
            Buttonsdestroy();
            Main(verb8, verb7, verb6, verb5, verb4);
            diffchoosepanel.Dispose();
        }

        private void diff2_click(object sender, EventArgs e)
        {
            int verb8 = 2;
            int verb7 = 3;
            int verb6 = 2;
            int verb5 = 3;
            int verb4 = 3;
            Buttonsdestroy();
            Main(verb8, verb7, verb6, verb5, verb4);
            diffchoosepanel.Dispose();
        }

        private void diff1_click(object sender, EventArgs e)
        {
            int verb8 = 2;//2,3,0,4,6
            int verb7 = 3;
            int verb6 = 1;
            int verb5 = 4;
            int verb4 = 6;
            Buttonsdestroy();
            Main(verb8, verb7, verb6, verb5, verb4);
            diffchoosepanel.Dispose();
        }
        private void startpanel_Click(object sender, EventArgs e)
        {
            diffchoosepanel.Location = new Point(0, 0);
            diffchoosepanel.Size = new Size(950, 950);
            Image backfont = Image.FromFile("WordsScreen.jpg");
            diffchoosepanel.BackgroundImage = backfont;
            startpanel.Dispose();

            Controls.Add(diff1);
            Controls.Add(diff2);
            Controls.Add(diff3);

            Controls.Add(diffchoosepanel);
        }
        public Form1()
        {
            InitializeComponent();

            startpanel.Location = new Point(0, 0);
            startpanel.Size = new Size(950, 950);
            diff1.Text = "Легкий";
            diff2.Text = "Середній";
            diff3.Text = "Складний";
            diff1.Location = new Point(350, 500);
            diff2.Location = new Point(450, 500);
            diff3.Location = new Point(550, 500);
            diff1.FlatStyle = FlatStyle.Flat;
            diff2.FlatStyle = FlatStyle.Flat;
            diff3.FlatStyle = FlatStyle.Flat;

            diff1.Click += new EventHandler(diff1_click);
            diff2.Click += new EventHandler(diff2_click);
            diff3.Click += new EventHandler(diff3_click);

            Image screen = Image.FromFile("Mainscreen.png");
            Controls.Add(startpanel);
            startpanel.Click += new EventHandler(this.startpanel_Click);


            ClientSize = new Size(950, 950);
            startpanel.BackgroundImage = screen;



        }
        void LoadScreen()
        {
            {
                {
                    int time = -10;
                    var timer = new Timer
                    {
                        Interval = 60
                    };
                    timer.Tick += (sender, args) =>
                    {
                        time++;
                        Invalidate();
                    };
                    timer.Start();

                    Paint += (sender, args) =>
                    {
                        switch (time)
                        {
                            default:
                                BackColor = Color.FromArgb(255, 28, 28, 28);
                                break;
                            case 2:
                                BackColor = Color.FromArgb(255, 192, 192, 192);
                                break;
                            case 3:
                                BackColor = Color.FromArgb(255, 211, 211, 211);
                                break;
                            case 4:
                                BackColor = Color.FromArgb(255, 220, 220, 220);
                                break;
                            case 5:
                                BackColor = Color.FromArgb(255, 245, 245, 245);
                                break;
                            case 6:
                                BackColor = Color.FromArgb(255, 255, 255, 255);
                                timer.Stop();

                                break;
                        }
                    };
                }

            }

        }


        void Main(int verb8, int verb7, int verb6, int verb5, int verb4)
        {
            Panel crosswordpanel = new Panel();
            crosswordpanel.Location = new Point(0, 0);
            crosswordpanel.Size = new Size(950, 950);
            //Controls.Add(crosswordpanel);
            int rangex = 2;//*50-in points
            int rangey = 16;//*50-in points
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            Paint += (sender, args) =>
            {
                args.Graphics.FillRectangle(Brushes.Black, 100, 100, 750, 750);
            };
            var rand = new Random();

            Word(verb8, 8);
            usedwords.Clear();
            Word(verb7, 7);
            usedwords.Clear();
            Word(verb6, 6);
            usedwords.Clear();
            Word(verb5, 5);
            usedwords.Clear();
            Word(verb4, 4);
            //LoadScreen();
            void Word(int num, int lg)
            {

                for (int j = 0; j < num; j++)
                {
                restart:
                    var randword = rand.Next(1, 41);//  [1;41)

                    foreach (int i in usedwords)
                    {
                        if (randword == i)
                            goto restart;
                    }

                    string query = "SELECT verb" + lg + " FROM Words WHERE num=" + randword;
                    OleDbCommand command = new OleDbCommand(query, myConnection);
                    var check = rand.Next(2);//  [0;2)
                    List<TextBox> verbs = new List<TextBox>();
                    int px, py;
                    Point pos = new Point();



                    if (check == 1)
                    {

                        px = rand.Next(rangex, rangey + 1 - command.ExecuteScalar().ToString().Length);//150*150=left top angle/600*600=buttom right angle

                    back_py1:
                        py = rand.Next(rangex, rangey + 1);
                        if (py % 2 == 0)
                            goto back_py1;
                    }
                    else
                    {
                    back_px2:
                        px = rand.Next(rangex, rangey + 1);
                        if (px % 2 == 0)
                            goto back_px2;

                        py = rand.Next(rangex, rangey + 1 - command.ExecuteScalar().ToString().Length);

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

                        switch (CheckLocation(ref list_of_Textboxes, pos, command.ExecuteScalar().ToString()[i], ref verbs))
                        {
                            case 1:
                                if (doublecross)
                                    goto restart;

                                if (check == 1)
                                {
                                    px += 50;
                                    if (i == command.ExecuteScalar().ToString().Length - 1)
                                    {

                                        if (CheckLocation(ref list_of_Textboxes, pos_right, command.ExecuteScalar().ToString()[i], ref verbs) != 0)
                                            goto restart;
                                    }
                                    else
                                        if (i == 0)
                                    {
                                        if (CheckLocation(ref list_of_Textboxes, pos_left, command.ExecuteScalar().ToString()[i], ref verbs) != 0)
                                            goto restart;
                                    }
                                }
                                else
                                {
                                    if (i == command.ExecuteScalar().ToString().Length - 1)
                                    {

                                        if (CheckLocation(ref list_of_Textboxes, pos_buttom, command.ExecuteScalar().ToString()[i], ref verbs) != 0)
                                            goto restart;
                                    }
                                    if (i == 0)
                                    {
                                        if (CheckLocation(ref list_of_Textboxes, pos_top, command.ExecuteScalar().ToString()[i], ref verbs) != 0)
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

                                if (i == 0)//first verb
                                {
                                    if (CheckLocation(ref list_of_Textboxes, pos_top, command.ExecuteScalar().ToString()[i], ref verbs) != 0
                                        || CheckLocation(ref list_of_Textboxes, pos_left, command.ExecuteScalar().ToString()[i], ref verbs) != 0)
                                    {
                                        goto restart;
                                    }
                                }

                                if (check == 1)
                                {
                                    if (CheckLocation(ref list_of_Textboxes, pos_top, command.ExecuteScalar().ToString()[i], ref verbs) != 0 ||
                                        CheckLocation(ref list_of_Textboxes, pos_buttom, command.ExecuteScalar().ToString()[i], ref verbs) != 0)
                                        goto restart;

                                    if (i == command.ExecuteScalar().ToString().Length - 1)//last verb
                                    {
                                        if (CheckLocation(ref list_of_Textboxes, pos_right, command.ExecuteScalar().ToString()[i], ref verbs) != 0)
                                        {
                                            goto restart;
                                        }
                                    }
                                }
                                else
                                {
                                    if (CheckLocation(ref list_of_Textboxes, pos_left, command.ExecuteScalar().ToString()[i], ref verbs) != 0 ||
                                        CheckLocation(ref list_of_Textboxes, pos_right, command.ExecuteScalar().ToString()[i], ref verbs) != 0)
                                        goto restart;

                                    if (i == command.ExecuteScalar().ToString().Length - 1)//last verb
                                    {
                                        if (CheckLocation(ref list_of_Textboxes, pos_buttom, command.ExecuteScalar().ToString()[i], ref verbs) != 0)
                                        {
                                            goto restart;
                                        }
                                    }
                                }
                                verbs.Add(new TextBox());
                                verbs[i].Name = "w" + j.ToString() + "k" + i.ToString();
                                verbs[i].Location = new Point(px, py);
                                verbs[i].Size = new Size(50, 50);
                                verbs[i].Multiline = true;
                                verbs[i].MaxLength = 1;
                                verbs[i].TextAlign = HorizontalAlignment.Center;
                                verbs[i].BorderStyle = BorderStyle.Fixed3D;
                                verbs[i].CharacterCasing = CharacterCasing.Upper;
                                verbs[i].Font = new Font("Times New Roman", this.Height / 30);
                                if (check == 1)
                                    px += 50;
                                else
                                    py += 50;

                                //verbs[i].Text = command.ExecuteScalar().ToString()[i].ToString();
                                break;

                            default:
                                goto restart;
                        }
                    }
                    foreach (TextBox o in verbs)
                    {
                        Controls.Add(o);
                    }

                    usedwords.Add(randword);
                    list_of_Textboxes.Add(verbs);
                    true_answers.Add(command.ExecuteScalar().ToString());


                }
            }



        }


    }


}





