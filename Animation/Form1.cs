using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Animation
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            ClientSize = new Size(800, 800);
            var centerX = ClientSize.Width / 2;
            var centerY = ClientSize.Height / 2;
            var time2 = -1;
            var time = 0;
            var check = 1;
            var timer = new Timer
            {
                Interval = 100
            };
            timer.Tick += (sender, args) =>
              {
                  time2++;
                  time++;
                  Invalidate();
              };
            timer.Start();
            //cube
            var p0x = 200;
            var p0y = 100;

            var p1x = 350;
            var p1y = 100;

            var p2x = 300;
            var p2y = 200;

            var p3x = 150;
            var p3y = 200;

            var change = 150;
            Point[] points1 = new Point[4];
            points1[0] = new Point(p0x, p0y);
            points1[1] = new Point(p1x, p1y);
            points1[2] = new Point(p2x, p2y);
            points1[3] = new Point(p3x, p3y);

            Point[] points2 = new Point[4];
            points2[0] = new Point(p0x, p0y + change);
            points2[1] = new Point(p1x, p1y + change);
            points2[2] = new Point(p2x, p2y + change);
            points2[3] = new Point(p3x, p3y + change);

            Point[] points3 = new Point[4];
            points3[0] = new Point(p3x, p3y);
            points3[1] = new Point(p2x, p2y);
            points3[2] = new Point(p2x, p2y + change);
            points3[3] = new Point(p3x, p3y + change);

            Point[] points4 = new Point[4];
            points4[0] = new Point(p1x, p1y);
            points4[1] = new Point(p2x, p2y);
            points4[2] = new Point(p2x, p2y + change);
            points4[3] = new Point(p1x, p1y + change);

            Point[] points5 = new Point[4];
            points5[0] = new Point(p0x, p0y);
            points5[1] = new Point(p0x, p0y + change);
            points5[2] = new Point(p3x, p3y + change);
            points5[3] = new Point(p3x, p3y);
            //
            Point[] angle7 = new Point[7];
            angle7[0] = new Point(544, 144);
            angle7[1] = new Point(624, 184);
            angle7[2] = new Point(666, 266);
            angle7[3] = new Point(624, 345);
            angle7[4] = new Point(463, 345);
            angle7[5] = new Point(419, 266);
            angle7[6] = new Point(462, 184);
            //
            Paint += (sender, args) =>
              {
                  args.Graphics.FillPie(Brushes.LightCyan, 680, 680, 100, 100, 45 * time, 90);

                  Pen blackPen = new Pen(Color.Black, 1);
                  args.Graphics.DrawPolygon(blackPen, points1);
                  args.Graphics.DrawPolygon(blackPen, points2);
                  args.Graphics.DrawPolygon(blackPen, points3);
                  args.Graphics.DrawPolygon(blackPen, points4);
                  args.Graphics.DrawPolygon(blackPen, points5);

                  args.Graphics.FillEllipse(Brushes.LightGoldenrodYellow, 20, 400, 100, 50);

                  GraphicsPath ang7 = new GraphicsPath();

                  ang7.AddPolygon(angle7);
                  args.Graphics.FillPath(Brushes.LightGreen, ang7);
                  args.Graphics.DrawPolygon(blackPen, angle7);

                  {
                      Point[] triangle1 = new Point[3];
                      Point[] triangle2 = new Point[3];

                      switch (time2)
                      {
                          case 1:
                              triangle1[0] = new Point(400, 600);
                              triangle1[1] = new Point(350 - 5, 700);
                              triangle1[2] = new Point(450 + 5, 700);

                              triangle2[0] = new Point(400, 600);
                              triangle2[1] = new Point(350 - 5, 700);
                              triangle2[2] = new Point(450 - 5 * 2, 700);
                              if (check == 1)
                              {
                                  args.Graphics.FillPolygon(Brushes.LightBlue, triangle1);
                                  args.Graphics.FillPolygon(Brushes.LightCyan, triangle2);
                              }
                              else
                              {
                                  args.Graphics.FillPolygon(Brushes.LightCyan, triangle1);
                                  args.Graphics.FillPolygon(Brushes.LightBlue, triangle2);
                              }
                              args.Graphics.DrawPolygon(blackPen, triangle2);
                              args.Graphics.DrawPolygon(blackPen, triangle1);
                              break;
                          case 2:
                              triangle1[0] = new Point(400, 600);
                              triangle1[1] = new Point(350 - 10, 700);
                              triangle1[2] = new Point(450 + 10, 700);

                              triangle2[0] = new Point(400, 600);
                              triangle2[1] = new Point(350 - 10, 700);
                              triangle2[2] = new Point(450 - 10 * 2, 700);
                              if (check == 1)
                              {
                                  args.Graphics.FillPolygon(Brushes.LightBlue, triangle1);
                                  args.Graphics.FillPolygon(Brushes.LightCyan, triangle2);
                              }
                              else
                              {
                                  args.Graphics.FillPolygon(Brushes.LightCyan, triangle1);
                                  args.Graphics.FillPolygon(Brushes.LightBlue, triangle2);
                              }
                              args.Graphics.DrawPolygon(blackPen, triangle2);
                              args.Graphics.DrawPolygon(blackPen, triangle1);
                              break;
                          case 3:
                              triangle1[0] = new Point(400, 600);
                              triangle1[1] = new Point(350 - 15, 700);
                              triangle1[2] = new Point(450 + 15, 700);

                              triangle2[0] = new Point(400, 600);
                              triangle2[1] = new Point(350 - 15, 700);
                              triangle2[2] = new Point(450 - 15 * 2, 700);
                              if (check == 1)
                              {
                                  args.Graphics.FillPolygon(Brushes.LightBlue, triangle1);
                                  args.Graphics.FillPolygon(Brushes.LightCyan, triangle2);
                              }
                              else
                              {
                                  args.Graphics.FillPolygon(Brushes.LightCyan, triangle1);
                                  args.Graphics.FillPolygon(Brushes.LightBlue, triangle2);
                              }
                              args.Graphics.DrawPolygon(blackPen, triangle2);
                              args.Graphics.DrawPolygon(blackPen, triangle1);
                              break;
                          case 4:
                              triangle1[0] = new Point(400, 600);
                              triangle1[1] = new Point(350 - 20, 700);
                              triangle1[2] = new Point(450 + 20, 700);

                              triangle2[0] = new Point(400, 600);
                              triangle2[1] = new Point(350 - 20, 700);
                              triangle2[2] = new Point(450 - 20 * 2, 700);
                              if (check == 1)
                              {
                                  args.Graphics.FillPolygon(Brushes.LightBlue, triangle1);
                                  args.Graphics.FillPolygon(Brushes.LightCyan, triangle2);
                              }
                              else
                              {
                                  args.Graphics.FillPolygon(Brushes.LightCyan, triangle1);
                                  args.Graphics.FillPolygon(Brushes.LightBlue, triangle2);
                              }
                              args.Graphics.DrawPolygon(blackPen, triangle2);
                              args.Graphics.DrawPolygon(blackPen, triangle1);
                              break;
                          case 5:
                              triangle1[0] = new Point(400, 600);
                              triangle1[1] = new Point(350 - 25, 700);
                              triangle1[2] = new Point(450 + 25, 700);

                              triangle2[0] = new Point(400, 600);
                              triangle2[1] = new Point(350 - 25, 700);
                              triangle2[2] = new Point(450 - 25 * 2, 700);
                              if (check == 1)
                              {
                                  args.Graphics.FillPolygon(Brushes.LightBlue, triangle1);
                                  args.Graphics.FillPolygon(Brushes.LightCyan, triangle2);
                              }
                              else
                              {
                                  args.Graphics.FillPolygon(Brushes.LightCyan, triangle1);
                                  args.Graphics.FillPolygon(Brushes.LightBlue, triangle2);
                              }
                              args.Graphics.DrawPolygon(blackPen, triangle2);
                              args.Graphics.DrawPolygon(blackPen, triangle1);
                              break;

                          case 6:
                              triangle1[0] = new Point(400, 600);
                              triangle1[1] = new Point(350 - 20, 700);
                              triangle1[2] = new Point(450 + 20, 700);

                              triangle2[0] = new Point(400, 600);
                              triangle2[1] = new Point(350 - 20, 700);
                              triangle2[2] = new Point(450 - 35 * 2, 700);
                              if (check == 1)
                              {
                                  args.Graphics.FillPolygon(Brushes.LightBlue, triangle1);
                                  args.Graphics.FillPolygon(Brushes.LightCyan, triangle2);
                              }
                              else
                              {
                                  args.Graphics.FillPolygon(Brushes.LightCyan, triangle1);
                                  args.Graphics.FillPolygon(Brushes.LightBlue, triangle2);
                              }
                              args.Graphics.DrawPolygon(blackPen, triangle2);
                              args.Graphics.DrawPolygon(blackPen, triangle1);
                              break;

                          case 7:
                              triangle1[0] = new Point(400, 600);
                              triangle1[1] = new Point(350 - 15, 700);
                              triangle1[2] = new Point(450 + 15, 700);

                              triangle2[0] = new Point(400, 600);
                              triangle2[1] = new Point(350 - 15, 700);
                              triangle2[2] = new Point(450 - 40 * 2, 700);
                              if (check == 1)
                              {
                                  args.Graphics.FillPolygon(Brushes.LightBlue, triangle1);
                                  args.Graphics.FillPolygon(Brushes.LightCyan, triangle2);
                              }
                              else
                              {
                                  args.Graphics.FillPolygon(Brushes.LightCyan, triangle1);
                                  args.Graphics.FillPolygon(Brushes.LightBlue, triangle2);
                              }
                              args.Graphics.DrawPolygon(blackPen, triangle2);
                              args.Graphics.DrawPolygon(blackPen, triangle1);
                              break;

                          case 8:
                              triangle1[0] = new Point(400, 600);
                              triangle1[1] = new Point(350 - 10, 700);
                              triangle1[2] = new Point(450 + 10, 700);

                              triangle2[0] = new Point(400, 600);
                              triangle2[1] = new Point(350 - 10, 700);
                              triangle2[2] = new Point(450 - 45 * 2, 700);
                              if (check == 1)
                              {
                                  args.Graphics.FillPolygon(Brushes.LightBlue, triangle1);
                                  args.Graphics.FillPolygon(Brushes.LightCyan, triangle2);
                              }
                              else
                              {
                                  args.Graphics.FillPolygon(Brushes.LightCyan, triangle1);
                                  args.Graphics.FillPolygon(Brushes.LightBlue, triangle2);
                              }
                              args.Graphics.DrawPolygon(blackPen, triangle2);
                              args.Graphics.DrawPolygon(blackPen, triangle1);
                              break;

                          case 9:
                              triangle1[0] = new Point(400, 600);
                              triangle1[1] = new Point(350 - 5, 700);
                              triangle1[2] = new Point(450 + 5, 700);

                              triangle2[0] = new Point(400, 600);
                              triangle2[1] = new Point(350 - 5, 700);
                              triangle2[2] = new Point(450 - 50 * 2, 700);
                              if (check == 1)
                              {
                                  args.Graphics.FillPolygon(Brushes.LightBlue, triangle1);
                                  args.Graphics.FillPolygon(Brushes.LightCyan, triangle2);
                              }
                              else
                              {
                                  args.Graphics.FillPolygon(Brushes.LightCyan, triangle1);
                                  args.Graphics.FillPolygon(Brushes.LightBlue, triangle2);
                              }
                              args.Graphics.DrawPolygon(blackPen, triangle2);
                              args.Graphics.DrawPolygon(blackPen, triangle1);
                              break;

                          default:
                              triangle1[0] = new Point(400, 600);
                              triangle1[1] = new Point(350, 700);
                              triangle1[2] = new Point(450, 700);
                              if (check == 1)
                              {
                                  args.Graphics.FillPolygon(Brushes.LightBlue, triangle1);
                              }
                              else
                              {
                                  args.Graphics.FillPolygon(Brushes.LightCyan, triangle1);
                              }
                              args.Graphics.DrawPolygon(blackPen, triangle1);
                              time2 = 0;
                              check *= -1;
                              break;
                      }
                  }
              };
        }

        private void button1_Click(object lol, System.EventArgs e)
        {

            Paint += (sender, args) =>
            {
                args.Graphics.Clear(Color.LightSlateGray);
                button1.Hide();
                Pen blackpen = new Pen(Color.Black, 1);
                Pen whitepen = new Pen(Color.White, 1);
                //table
                {
                    Point[] table_legs = new Point[8];
                    table_legs[0] = new Point(255, 400);
                    table_legs[1] = new Point(250, 400);
                    table_legs[2] = new Point(250, 500);
                    table_legs[3] = new Point(255, 500);
                    table_legs[4] = new Point(255, 400);
                    table_legs[5] = new Point(259, 395);
                    table_legs[6] = new Point(259, 495);
                    table_legs[7] = new Point(255, 500);
                    args.Graphics.FillPolygon(Brushes.Silver, table_legs);
                    args.Graphics.DrawPolygon(blackpen, table_legs);

                    table_legs[0] = new Point(255 + 344, 400);
                    table_legs[1] = new Point(250 + 344, 400);
                    table_legs[2] = new Point(250 + 344, 500);
                    table_legs[3] = new Point(255 + 344, 500);
                    table_legs[4] = new Point(255 + 344, 400);
                    table_legs[5] = new Point(259 + 344, 395);
                    table_legs[6] = new Point(259 + 344, 495);
                    table_legs[7] = new Point(255 + 344, 500);
                    args.Graphics.FillPolygon(Brushes.Silver, table_legs);
                    args.Graphics.DrawPolygon(blackpen, table_legs);

                    table_legs[0] = new Point(255 + 50, 400 - 95);
                    table_legs[1] = new Point(250 + 50, 400 - 95);
                    table_legs[2] = new Point(250 + 50, 500 - 95);
                    table_legs[3] = new Point(255 + 50, 500 - 95);
                    table_legs[4] = new Point(255 + 50, 400 - 95);
                    table_legs[5] = new Point(259 + 50, 395 - 95);
                    table_legs[6] = new Point(259 + 50, 495 - 95);
                    table_legs[7] = new Point(255 + 50, 500 - 95);
                    args.Graphics.FillPolygon(Brushes.Silver, table_legs);
                    args.Graphics.DrawPolygon(blackpen, table_legs);

                    table_legs[0] = new Point(255 + 391, 400 - 95);
                    table_legs[1] = new Point(250 + 391, 400 - 95);
                    table_legs[2] = new Point(250 + 391, 500 - 95);
                    table_legs[3] = new Point(255 + 391, 500 - 95);
                    table_legs[4] = new Point(255 + 391, 400 - 95);
                    table_legs[5] = new Point(259 + 391, 395 - 95);
                    table_legs[6] = new Point(259 + 391, 495 - 95);
                    table_legs[7] = new Point(255 + 391, 500 - 95);
                    args.Graphics.FillPolygon(Brushes.Silver, table_legs);
                    args.Graphics.DrawPolygon(blackpen, table_legs);



                    Point[] table = new Point[4];
                    table[0] = new Point(300, 300);
                    table[1] = new Point(650, 300);
                    table[2] = new Point(600, 400);
                    table[3] = new Point(250, 400);
                    args.Graphics.FillPolygon(Brushes.Sienna, table);
                    args.Graphics.DrawPolygon(blackpen, table);
                }
                //

                //keybord
                {
                    var p0x = 350;
                    var p0y = 350;

                    var p1x = 500;
                    var p1y = 350;

                    var p2x = 480;
                    var p2y = 380;

                    var p3x = 330;
                    var p3y = 380;

                    Point[] keybord = new Point[4];
                    keybord[0] = new Point(p0x, p0y);
                    keybord[1] = new Point(p1x, p1y);
                    keybord[2] = new Point(p2x, p2y);
                    keybord[3] = new Point(p3x, p3y);
                    args.Graphics.FillPolygon(Brushes.Gray, keybord);
                    args.Graphics.DrawPolygon(blackpen, keybord);

                    var x = 6;
                    for (int i = 0; i < 12; i++)
                    {
                        Point[] keybord2 = new Point[4];
                        keybord2[0] = new Point(p0x + 5 + x * i, p0y + 5);
                        keybord2[1] = new Point(p1x - 11 - x * i, p1y + 5);
                        keybord2[2] = new Point(p2x - 5 - x * i, p2y - 5);
                        keybord2[3] = new Point(p3x + 11 + x * i, p3y - 5);
                        args.Graphics.DrawPolygon(whitepen, keybord2);
                    }
                    var x2 = 3;
                    var y = 5;
                    for (int i = 0; i < 3; i++)
                    {
                        Point[] keybord3 = new Point[4];
                        keybord3[0] = new Point(p0x + 5 - x2 * i, p0y + 5 + y * i);
                        keybord3[1] = new Point(p1x - 12 - x2 * i, p1y + 5 + y * i);
                        keybord3[2] = new Point(p2x - 5 + x2 * i, p2y - 5 - y * i);
                        keybord3[3] = new Point(p3x + 11 + x2 * i, p3y - 5 - y * i);
                        args.Graphics.DrawPolygon(whitepen, keybord3);
                    }
                }
                //

                //monitor// 130x90
                {
                    Image screen = Image.FromFile("img/Screen.jpg");
                    blackpen.Width = 7;
                    Point[] monitor = new Point[4];
                    monitor[0] = new Point(360, 330);
                    monitor[1] = new Point(490, 330);
                    monitor[2] = new Point(490, 220);
                    monitor[3] = new Point(360, 220);
                    args.Graphics.FillEllipse(Brushes.Black, 390, 324, 70, 25);
                    args.Graphics.DrawPolygon(blackpen, monitor);
                    args.Graphics.DrawImage(screen, 360, 220, 130, 110);
                }
                //

                //mouse n carpet
                {
                    blackpen.Width = 2;
                    Point[] carpet = new Point[4];
                    carpet[0] = new Point(520, 335);
                    carpet[1] = new Point(570, 335);
                    carpet[2] = new Point(550, 370);
                    carpet[3] = new Point(500, 370);
                    args.Graphics.DrawPolygon(blackpen, carpet);
                    args.Graphics.FillPolygon(Brushes.Black, carpet);
                    args.Graphics.FillEllipse(Brushes.Gray, 528, 336, 15, 30);
                    args.Graphics.DrawLine(blackpen, 536, 340, 536, 345);
                }
                //

                //speakers
                {
                    Point[] speaker = new Point[4];
                    speaker[0] = new Point(320, 320);
                    speaker[1] = new Point(340, 320);
                    speaker[2] = new Point(340, 290);
                    speaker[3] = new Point(320, 290);
                    args.Graphics.FillPolygon(Brushes.Black, speaker);
                    speaker[0] = new Point(323, 315);
                    speaker[1] = new Point(337, 315);
                    speaker[2] = new Point(337, 310);
                    speaker[3] = new Point(323, 310);
                    args.Graphics.FillPolygon(Brushes.Silver, speaker);

                    speaker[0] = new Point(320 + 190, 320);
                    speaker[1] = new Point(340 + 190, 320);
                    speaker[2] = new Point(340 + 190, 290);
                    speaker[3] = new Point(320 + 190, 290);
                    args.Graphics.FillPolygon(Brushes.Black, speaker);
                    speaker[0] = new Point(323 + 190, 315);
                    speaker[1] = new Point(337 + 190, 315);
                    speaker[2] = new Point(337 + 190, 310);
                    speaker[3] = new Point(323 + 190, 310);
                    args.Graphics.FillPolygon(Brushes.Silver, speaker);
                }
                //

                //computer case
                {
                    Point[] computercase = new Point[4];
                    computercase[0] = new Point(530, 410);
                    computercase[1] = new Point(580, 410);
                    computercase[2] = new Point(580, 490);
                    computercase[3] = new Point(530, 490);
                    args.Graphics.DrawPolygon(blackpen, computercase);
                    args.Graphics.FillPolygon(Brushes.Black, computercase);

                    Pen silverpen = new Pen(Brushes.Silver, 3);
                    computercase[0] = new Point(530, 410);
                    computercase[1] = new Point(580, 410);
                    computercase[2] = new Point(580, 465);
                    computercase[3] = new Point(530, 465);
                    args.Graphics.DrawPolygon(silverpen, computercase);
                    args.Graphics.FillEllipse(Brushes.Silver, 537, 475, 5, 5);
                    args.Graphics.FillEllipse(Brushes.Linen, 557, 472, 12, 12);
                    args.Graphics.DrawEllipse(silverpen, 557, 472, 12, 12);

                    args.Graphics.FillEllipse(Brushes.Silver, 545, 420, 5, 5);
                    args.Graphics.FillEllipse(Brushes.Silver, 560, 420, 5, 5);

                    computercase[0] = new Point(540, 430);
                    computercase[1] = new Point(570, 430);
                    computercase[2] = new Point(570, 433);
                    computercase[3] = new Point(540, 433);
                    args.Graphics.FillPolygon(Brushes.LightGray, computercase);

                }
            };
        }

        private void button2_Click(object lol, System.EventArgs e)
        {
            Paint += (sender, args) =>
            {
                button2.Hide();
                args.Graphics.Clear(Color.Azure);
                Pen brownkpen = new Pen(Color.SaddleBrown, 15);
                Pen graypen = new Pen(Color.Gray, 8);
                Point[] sq = new Point[4];
                sq[0] = new Point(200, 400);
                sq[1] = new Point(500, 400);
                sq[2] = new Point(500, 200);
                sq[3] = new Point(200, 200);
                args.Graphics.FillPolygon(Brushes.DarkRed, sq);
                args.Graphics.FillEllipse(Brushes.Gray, 197, 175, 305, 50);
                args.Graphics.FillEllipse(Brushes.Gray, 197, 380, 305, 50);
                args.Graphics.FillEllipse(Brushes.DarkRed, 200, 370, 300, 50);
                args.Graphics.FillEllipse(Brushes.AntiqueWhite, 250, 185, 200, 25);
                for (int x = 230; x < 500; x += 40)
                    args.Graphics.DrawLine(graypen, x, 215, x, 420);

                args.Graphics.DrawLine(brownkpen, 100, 100, 300, 180);
                args.Graphics.FillEllipse(Brushes.SaddleBrown, 280, 165,50, 30);
                args.Graphics.FillEllipse(Brushes.SaddleBrown, 380, 165, 50, 30);
                args.Graphics.DrawLine(brownkpen, 600, 100, 400, 180);
            };
        }
    }
}
