using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace program1
{
    public partial class ErrorInput : Form
    {
        public ErrorInput(string text)
        {
            InitializeComponent();
            label1.Text = text;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ErrorInput_Load(object sender, EventArgs e)
        {

        }
    }
}
