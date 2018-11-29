using System;
using MySql.Data.EntityFramework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace program1
{
    public class Order
    {
        [Key]
        public String Id { get; set; }
        public String Customer { get; set; }
        //public DateTime CreateTime { get; set; }
        public List<OrderItem> Items { get; set; }
        public double Sum { get; set;}

        public Order()
        {
            Items = new List<OrderItem>();
        }

        public Order(string id, string customer, /*DateTime createTime,*/ List<OrderItem> items, double sum)
        {
            Id = id;
            Customer = customer;
            //CreateTime = createTime;
            Items = items;
            Sum = sum;
        }
    }
}
