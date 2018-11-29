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
        public static OrderService orderService = new OrderService();
        List<OrderItem> items = new List<OrderItem>() {
                    new OrderItem("1", "apple", 10.0, 20),
                    new OrderItem("2", "egg", 2.0, 100),
                    new OrderItem("3", "milk", 5.0, 100)
            };


        List<Order> orders = orderService.GetAllOrders();





        public Form1()
        {

            InitializeComponent();
           
            Order order = new Order("001", "tomson", /*DateTime.Now,*/ items, 100.1);
            Order order1 = new Order("002", "steven", /*DateTime.Now,*/ items, 100.1);
            Order order2 = new Order("003", "william", /*DateTime.Now,*/ items, 100.1);
            orderService.Add(order);
            orderService.Add(order1);
            orderService.Add(order2);

            orderBindingSource.DataSource = orders;
            textBox1.DataBindings.Add("Text", this, "KeyWord");





        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            orderBindingSource.DataSource =
                    orders.Where(s => s.Id != null);

            if (comboBox1.SelectedIndex == 0)
            {
                orderBindingSource.DataSource =
                    orders.Where(s => s.Id != null);
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                orderBindingSource.DataSource =
               orderService.QueryById(KeyWord);
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                orderBindingSource.DataSource =
                orderService.QueryByCustormer(KeyWord);
               
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                orderBindingSource.DataSource =
                orderService.QueryByGoods(KeyWord);
               
            }
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                int orderIndex
                        = e.RowIndex;
                if (orderIndex >= 0 && orderIndex < orders.Count)
                    if (orders[orderIndex].Items.Count > 0)
                    {
                        orderItemBindingSource.DataSource = orders[orderIndex].Items;
                    }

            }
            if (e.ColumnIndex == 4)
            {
                int orderIndex = e.RowIndex;
                if (orderIndex >= 0 && orderIndex < orders.Count)
                {
                    orders.RemoveAt(orderIndex);
                    orderBindingSource.DataSource = orders.Where(s => s.Id != null);
                    DeleteSuccess ds = new DeleteSuccess();
                    ds.Show();
                }

            }

        }

        private void dataGridView1_CellValuePushed(object sender, DataGridViewCellValueEventArgs e)
        {
            orders[e.RowIndex].Customer = e.Value.ToString();
            Order o = new Order("001", e.Value.ToString(), items, 100.1);
            orderService.Update(o);


        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm();
            addForm.Show();
        }
    }
}
