using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace tsk
{
    public partial class Form1 : Form
    {
        public static string connectString = "Provider=Microsoft.JET.OLEDB.4.0;Data Source=Database1.mdb;";
        private OleDbConnection myConnection;
        public Form1()
        {
            InitializeComponent();
            ClientSize = new Size(800, 800);
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            string query = "SELECT w FROM Words ORDER BY num";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataReader reader = command.ExecuteReader();


            


            //List<string> werb4 = new List<string>();
            //List<string> werb5 = new List<string>();
            //List<string> werb6 = new List<string>();
            //List<string> werb7 = new List<string>();

            int px = 150;
            for (int j = 0; j < 10; j++)
            {
                int py = 150;
                for (int i = 0; i < 10; i++)
                {
                    this.Controls.Add(new TextBox()
                    {
                        Name = "w" + i.ToString() + "(" + px.ToString() + ";" + py.ToString() + ")",
                        Location = new Point(px, py),
                        Size = new Size(50, 50),
                        Multiline = true,
                        MaxLength = 1,
                        TextAlign = HorizontalAlignment.Center,
                        BorderStyle = BorderStyle.Fixed3D,
                        CharacterCasing = CharacterCasing.Upper,
                        Font = new Font("Times New Roman", this.Height / 30),




                    });
                    py += 50;
                    //textBox1.Text = Controls["w" + i.ToString()].Text;//обращение
                }
                px += 50;
            }


        }

        private void Form1_Load(object sender, System.EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, System.EventArgs e)
        {

        }
    }
}
