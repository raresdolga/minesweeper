using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {

        public Form1()
        {

            InitializeComponent();
        }
        Random rnd = new Random();
        int z = 0;
        private void Form1_Load(object sender, EventArgs e)
        {


        }
        private int exist_neighbour(int p)
        {
            int s = 0;



            if (Convert.ToInt32(b[p % 10 - 1, p / 10 - 1].Tag) == 0) s = s + 1;

                if (Convert.ToInt32(b[p % 10 - 1, p / 10].Tag)==0) s = s + 1;
            if (Convert.ToInt32(b[p % 10 - 1, p / 10 + 1].Tag)==0) s = s + 1;
            if (Convert.ToInt32(b[p % 10, p / 10 - 1].Tag)==0 ) s = s + 1;
            if (Convert.ToInt32(b[p % 10, p / 10 + 1].Tag) ==0  ) s = s + 1;
            if (Convert.ToInt32(b[p % 10 + 1, p / 10 - 1].Tag) == 0) s = s + 1;
            if (Convert.ToInt32(b[p % 10 + 1, p / 10].Tag) ==0 ) s = s + 1;
            if (Convert.ToInt32(b[p % 10 + 1, p / 10 + 1].Tag) == 0) s = s + 1;

            return s;
        }
        private void down(int p)
        {
            
            int c;
            int i = p % 10;
            int j = p / 10;
            int k = j;
           while(Convert.ToInt32(b[i, k].Tag) > 1&&k<= n)
            {
                 c = k * 10 + i;
                if (exist_neighbour(c) == 0 && Convert.ToInt32(b[i, k].Tag) != 0)
                {
                    b[i, k].Enabled = false;
                    b[i, k].BackColor = Color.Azure;
                }

                else
                if (Convert.ToInt32(b[i, k].Tag) > 1)
                {
                    b[i, k].BackColor = Color.Azure;


                    b[i, k].Enabled = false;
                    b[i, k].Text = Convert.ToString(exist_neighbour(c));

                }
                k++;
                c = 1;
            }
            k = j; textBox3.Text = Convert.ToString(z);
            while (Convert.ToInt32(b[i, k].Tag) >1 && k >= 1)
            {


                c = k * 10 + i;
                if (exist_neighbour(c) == 0 && Convert.ToInt32(b[i, k].Tag) != 0)
                {
                    b[i, k].Enabled = false;
                    b[i, k].BackColor = Color.Azure;
                }


                else
                if (Convert.ToInt32(b[i, k].Tag) > 1)
                {
                    b[i, k].BackColor = Color.Azure;
                    b[i, k].Text = Convert.ToString(exist_neighbour(c));
                    b[i, k].Enabled = false;

                }
                k--;
            }
            if (i>1)
            {
                p = (p / 10) * 10 + (i - 1);
                down(p);
            }
        }
        private void up(int p)
        {
          
            int c;
            int i = p % 10;
            int j = p / 10;
            int k = j;
         
            while (Convert.ToInt32(b[i, k].Tag) >1 && k <= n)
            {
                c = k * 10 + i;
                if (exist_neighbour(c) == 0 && Convert.ToInt32(b[i, k].Tag) != 0)
                {
                    b[i, k].Enabled = false;
                    b[i, k].BackColor = Color.Azure;
                }


                else
                if (Convert.ToInt32(b[i, k].Tag) > 1)
                {

                    b[i, k].Enabled = false;
                    b[i, k].Text = Convert.ToString(exist_neighbour(c));
                    b[i, k].BackColor = Color.Azure;

                }
                k++;
            }
            k = j;
            while (Convert.ToInt32(b[i, k].Tag) >1 && k >= 1 )
            {


                c = k * 10 + i;
                if (exist_neighbour(c) == 0 && Convert.ToInt32(b[i, k].Tag) > 1)
                {
                    b[i, k].Enabled = false;
                    b[i, k].BackColor = Color.Azure;
                }

                else
                if (Convert.ToInt32(b[i, k].Tag) > 1)
                {
                    b[i, k].Text = Convert.ToString(exist_neighbour(c));
                    b[i, k].Enabled = false; b[i, k].BackColor = Color.Azure;

                }
                k--;
            }
            if (i < n)
            {
                p = (p / 10) * 10 + (i + 1);
                up(p);
            }
        }
        private void button_click(object sender, EventArgs e)
        {
            ((Button)sender).Enabled = false;

            if (Convert.ToInt32(((Button)sender).Tag) == 0) MessageBox.Show("you lost");
            else
            {
               
                
                   
                    int p = Convert.ToInt16(((Button)sender).Tag);
                int bombs = 0;
                down(p);
                up(p);
                z = 0;
                for (int i = 1; i <= n; i++)
                    for (int j = 1; j <= n; j++)
                        if (b[i, j].Enabled == false) z++;
                        else
                            bombs++;
                if (bombs == m)
                {
                    MessageBox.Show("you won");
                    Application.Exit();
                }
                textBox3.Text = Convert.ToString(z);
            }
        }
            
        
       
                         
                        
        
        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            n = Convert.ToInt32(textBox1.Text);
            m = Convert.ToInt32(textBox2.Text);
            if(n>9||m>n||m>9)
            {
                MessageBox.Show("incorrect values");
                Application.Exit();
            }
            for (int i=1;i<= n;i++)
                for(int j=1;j<= n;j++)
                {  b[i,j] = new Button();

                    b[i, j].BackColor = Color.Aqua;
                    b[i,j].Top = 40 * i + 20;
                    b[i, j].Left = 40 *j + 20;
                    b[i, j].Width = 40;
                    b[i, j].Height = 40;
                    Controls.Add(b[i,j]);
                    b[i, j].Click += new EventHandler(button_click);
                    b[i, j].Tag = j * 10 + i;
                }
            for (int i = 0; i <= n+1 ; i++)
            {
                b[i, 0] = new Button();

                b[i, 0].BackColor = Color.Aqua;
                b[i, 0].Top = 40 * i + 20;
                b[i, 0].Left =  20;
                b[i, 0].Width = 40;
                b[i, 0].Height = 40;
                Controls.Add(b[i, 0]);
                b[i, 0].Tag = 1;
                b[i, 0].Visible = false;
            }
            for (int j = 1; j <= n+1 ; j++)
            {
                b[0, j] = new Button();

                b[0, j].BackColor = Color.Aqua;
                b[0, j].Left = 40 * j + 20;
                b[0, j].Top = 20;
                b[0, j].Width = 40;
                b[0, j].Height = 40;
                Controls.Add(b[0, j]);
                b[0, j].Tag = 1;
                b[0, j].Visible = false;
            }


            for (int i = 0; i <= n+1 ; i++)
            {
                b[i, n+1] = new Button();

                b[i, n+1].BackColor = Color.Aqua;
                b[i, n+1].Top = 40 * i + 20;
                b[i, n+1].Left = 20;
                b[i, n+1].Width = 40;
                b[i, n+1].Height = 40;
                Controls.Add(b[i, n+1]);
                b[i, n + 1].Tag = 1;
                b[i, n+1].Visible = false;
            }
            for (int j = 1; j <= n+1; j++)
            {
                b[n+1, j] = new Button();

                b[n + 1, j].BackColor = Color.Aqua;
                b[n + 1, j].Left = 40 * j + 20;
                b[n + 1, j].Top = 20;
                b[n + 1, j].Width = 40;
                b[n + 1, j].Height = 40;
                Controls.Add(b[n + 1, j]);
                b[n + 1, j].Tag = 1;
                b[n + 1, j].Visible = false;
            }
           
           
            int a, k = 1, c;
            while(k<=m)
                {
                a = rnd.Next(1, n *n);
                if (a % n == 0)
                {
                    while (Convert.ToInt32(b[(a - 1) / n + 1, n].Tag) == 0)
                        a = rnd.Next(11, n *n);
                        b[(a - 1) / n + 1, n].Tag=0;

                }
                else
                {
                    c = a;
                    while (Convert.ToInt32(b[(a / n + 1), c%n].Tag) == 0)
                        a = rnd.Next(11, n * n);
                    b[(a / n + 1), c % n].Tag = 0; 

                }
                k++; 
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
