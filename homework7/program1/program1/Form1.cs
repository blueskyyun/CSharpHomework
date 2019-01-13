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
   

    public partial class Form1 : Form
    {
        public string KeyWord { set; get; }
        public static List<Order> orders = new List<Order>();
        Goods milk = new Goods("milk", 69.9);
        Goods eggs = new Goods("eggs", 4.99);
        Goods apple = new Goods("apple", 5.59);
        public int orderIndex = 0;
        public Form1()
        {
           
            //OrderService os = new OrderService();
            //os.addOrder(order1);
            //os.addOrder(order2);
            //os.addOrder(order3);
            InitializeComponent();
            
            OrderDetails orderDetails1 = new OrderDetails(1, apple, 800);
            OrderDetails orderDetails2 = new OrderDetails(2, eggs, 2);
            OrderDetails orderDetails3 = new OrderDetails(3, milk, 1);

            Order order1 = new Order("customer1");
            Order order2 = new Order("customer2");
            Order order3 = new Order("customer3");
            order1.AddDetails(orderDetails1);
            order1.AddDetails(orderDetails2);
            order1.AddDetails(orderDetails3);
            //order1.AddOrderDetails(orderDetails3);
            order2.AddDetails(orderDetails2);
            order2.AddDetails(orderDetails3);
            order3.AddDetails(orderDetails3);
            orders.Add(order1);
            orders.Add(order2);
            orders.Add(order3);





            orderBindingSource.DataSource = orders;
          

            queryInput.DataBindings.Add("Text", this, "KeyWord");
            //AppendDataToGrid(dataGridView2, orders);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
           

        }
        
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm();
            addForm.Show();
        }

        

       
        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged_2(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            orderBindingSource.DataSource =
                    orders.Where(s => s.OrderNo >= 0);

            if (comboBox1.SelectedIndex == 0) {
                orderBindingSource.DataSource =
                    orders.Where(s => s.OrderNo == int.Parse(KeyWord));
            }else if(comboBox1.SelectedIndex == 1)
            {
                orderBindingSource.DataSource =
                orders.Where(s => s.Customer == KeyWord);
            }else if(comboBox1.SelectedIndex == 2)
            {
                orderBindingSource.DataSource =
                orders.Where(order =>
                    order.ODetails.Where(d => d.goods.GoodsName == KeyWord)
                    .Count() > 0
                );
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm();
            addForm.Show();
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 3) {
                orderIndex
                        = int.Parse(dataGridView1[0, e.RowIndex].Value.ToString()) - 1;
                if (orders[orderIndex].ODetails.Count > 0)
                {
                    orderDetailsBindingSource.DataSource = orders[orderIndex].ODetails;
                }
                
            }
            if(e.ColumnIndex == 4)
            {
                orderIndex = int.Parse(dataGridView1[0, e.RowIndex].Value.ToString()) - 1;
                if (orderIndex > 0 && orderIndex < orders.Count)
                {
                    orders.RemoveAt(orderIndex);
                    orderBindingSource.DataSource = orders.Where(s => s.OrderNo > 0);
                    DeleteSuccess ds = new DeleteSuccess();
                    ds.Show();
                }

            }
            
           

        }
        
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        
       

        private void dataGridView1_CellValuePushed(object sender, DataGridViewCellValueEventArgs e)
        {
            orders[e.RowIndex].Customer = e.Value.ToString();
        }

        private void dataGridView1_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {

        }

        private void dataGridView2_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {

        }

        private void dataGridView2_CellValuePushed(object sender, DataGridViewCellValueEventArgs e)
        {
            orders[orderIndex].oDetails[e.RowIndex].Quantity = int.Parse(e.Value.ToString());
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    
}
