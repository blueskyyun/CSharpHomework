using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VingtEtUnCards
{

    public partial class Form1 : Form
    {

        private MainUI mainUI;
        public Form1()
        {
            InitializeComponent();
            button1.Font = new Font("隶书",16.0f);
            button1.ForeColor = Color.Blue;
            button1.BackColor = Color.LightYellow;
            button2.Font = new Font("隶书", 16.0f);
            button2.ForeColor = Color.Blue;
            button2.BackColor = Color.LightYellow;
            //button1.FlatStyle = FlatStyle.Flat;
            //button1.FlatAppearance.BorderSize = 1;
            //button1.FlatAppearance.BorderColor = Color.White;
            //button2.FlatAppearance.BorderSize = 1;
            button1.Width = 160;
            button1.Height = 50;
            button2.Width = 160; 
            button2.Height = 50;

        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            mainUI = new MainUI(this);

            this.Hide();

            mainUI.Show();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            System.Environment.Exit(0);
        }
    }
}
