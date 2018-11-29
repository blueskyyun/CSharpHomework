using System;
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
            InitializeComponent();
        }

        private void AddForm_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                List<OrderItem> oI = new List<OrderItem>();
                if (checkBox3.Checked) oI.Add(new OrderItem("10", "apple", 10.0,int.Parse(numericUpDown3.Text)));
                if (checkBox2.Checked) oI.Add(new OrderItem("11","egg", 12.8,int.Parse(numericUpDown2.Text)));
                if (checkBox1.Checked) oI.Add(new OrderItem("12", "milk",13.9, int.Parse(numericUpDown1.Text)));
               
                Order od = new Order(textBox3.Text, textBox1.Text,oI,208.9 );
                Form1.orderService.Add(od);
               // textBox2.Text = od.SumReal.ToString("0.00");
            }
            catch (MyException ex)
            {
                ErroInput form = new ErroInput(ex.Message);
                form.Show();
            }
        }
        [Serializable]
        internal class MyException : ApplicationException
        {
            //public int ID;
            public static string[] exception = { "订单号输入有误！！！", "非法客户名！！！", "电话号码输入有误！！！" };
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
}
