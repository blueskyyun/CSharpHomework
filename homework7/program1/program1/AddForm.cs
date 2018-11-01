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
    public partial class AddForm : Form
    {
        public AddForm()
        {
            Goods milk = new Goods("milk", 69.9);
            Goods eggs = new Goods("eggs", 4.99);
            Goods apple = new Goods("apple", 5.59);
            OrderDetails orderDetails1 = new OrderDetails(1, apple, 800);
            OrderDetails orderDetails2 = new OrderDetails(2, eggs, 2);
            OrderDetails orderDetails3 = new OrderDetails(3, milk, 1);
            InitializeComponent();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            Order od = new Order(textBox1.Text);
            if (checkBox3.Checked) od.AddDetails(new OrderDetails(1, new Goods("apple", 5.59), int.Parse(numericUpDown3.Text)));
            if (checkBox2.Checked) od.AddDetails(new OrderDetails(2, new Goods("eggs", 4.99), int.Parse(numericUpDown2.Text)));
            if (checkBox1.Checked) od.AddDetails(new OrderDetails(3, new Goods("milk", 69.9), int.Parse(numericUpDown1.Text)));
            Form1.orders.Add(od);
            textBox2.Text = od.SumReal.ToString("0.00");
            




        }
    }
}
