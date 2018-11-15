using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
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
            try
            {
                string date = DateTime.Now.ToString("yyyyMMdd");
                string pattern1 = date +"[0-9]{3}";
                string pattern2 = "[0-9]{11}";
                if (!Regex.IsMatch(textBox3.Text, pattern1))
                {
                    var ex0 = new MyException(MyException.exception[0]);
                    throw ex0;
                }
                if (!Regex.IsMatch(textBox1.Text, "^[a-zA-Z]+"))
                {
                    var ex1 = new MyException(MyException.exception[1]);
                    throw ex1;
                }
                if (!Regex.IsMatch(textBox4.Text, pattern2))
                {
                    var ex2 = new MyException(MyException.exception[2]);
                    throw ex2;

                }
                Order od = new Order(textBox3.Text,textBox1.Text,textBox4.Text);
                if (checkBox3.Checked) od.AddDetails(new OrderDetails(1, new Goods("apple", 5.59), int.Parse(numericUpDown3.Text)));
                if (checkBox2.Checked) od.AddDetails(new OrderDetails(2, new Goods("eggs", 4.99), int.Parse(numericUpDown2.Text)));
                if (checkBox1.Checked) od.AddDetails(new OrderDetails(3, new Goods("milk", 69.9), int.Parse(numericUpDown1.Text)));
                Form1.orders.Add(od);
                textBox2.Text = od.SumReal.ToString("0.00");
            }catch(MyException ex)
            {
                ErrorInput form = new ErrorInput(ex.Message);
                form.Show();
            }
            




        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }

    [Serializable]
    internal class MyException : ApplicationException
    {
        //public int ID;
        public static string[] exception = {"订单号输入有误！！！","非法客户名！！！","电话号码输入有误！！！" };
        public MyException()
        {
        }

        public MyException(string message) : base(message)
        {
            //ID = no;
        }
        public MyException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
