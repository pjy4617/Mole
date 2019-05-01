using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mole
{
    public partial class Form1 : Form
    {
        Mole mole;
        Random random = new Random();
        public Form1()
        {
            InitializeComponent();
            try
            {
                mole = new Mole(random, new Mole.PopUp(MoleCallBack));
                timer1.Interval = random.Next(500, 1000);
                timer1.Start();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                Application.Exit();

            }
            
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            ToggleMole();
        }
        private void ToggleMole()
        {
            if(mole.Hidden == true)
            {
                mole.Show();
            }
            else
            {
                mole.HideAgain();
            }
            timer1.Interval = random.Next(500, 1000);
            timer1.Start();
        }
        private void MoleCallBack(int MoleNumber, bool Show)
        {
            if(MoleNumber < 0)
            {
                timer1.Stop();
                return;
            }
            Button button;
            switch (MoleNumber)
            {
                case 0: button = button1; break;
                case 1: button = button2; break;
                case 2: button = button3; break;
                case 3: button = button4; break;
                default:button = button5; break;
            }
            if(Show == true)
            {
                button.Text = "Hit me!";
                button.BackColor = Color.Red;
            }
            else
            {
                button.Text = "";
                button.BackColor = SystemColors.Control;
            }
            timer1.Interval = random.Next(500, 1000);
            timer1.Start();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            mole.Smacked(0);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            mole.Smacked(1);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            mole.Smacked(2);
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            mole.Smacked(3);
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            mole.Smacked(4);
        }
    }
}
