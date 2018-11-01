using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program1
{

    public class Order
    {
        
        public string Customer { set; get; } //客户名
        public uint OrderNo { set; get; }   //订单号
        public List<OrderDetails> oDetails = new List<OrderDetails>();
        public List<OrderDetails> ODetails { get { return oDetails; }
            set { ODetails = oDetails; } }
        static public uint orCnt = 0;
        public double SumReal
        {
            get { return ODetails.Sum(d => d.goods.Price * d.Quantity); } 
        }
        //public string Sum{ set { this.Sum = SumReal.ToString("0.00"); }
        //    get { return Sum; }

        //}

        

        public Order(string costumer)
        {
            orCnt++;
            this.OrderNo = orCnt;
            this.Customer = costumer;
        }
        public void AddDetails(OrderDetails orderDetail)
        {
            if (this.ODetails.Contains(orderDetail))
            {
                throw new Exception($"orderDetails-{orderDetail.serialNo} is already existed!");
            }
            ODetails.Add(orderDetail);
        }
        public void RemoveDetails(uint serialNo)
        {
            ODetails.RemoveAll(d => d.serialNo == serialNo);
        }


        public Order() { }
        

    }

    public class Goods
    {
        public string GoodsName { set; get; }
        public double Price { set; get; }
        public Goods(string goodsNm, double price)
        {
            this.GoodsName = goodsNm;
            this.Price = price;
        }
        public override string ToString()
        {
            return "Goods Name:" + GoodsName + "\tGoods Price" + Price;
        }
    }

    public class OrderDetails
    {
        public int serialNo { set; get; }
        public Goods goods { set; get; }
        public int Quantity { set; get; }

        public OrderDetails(int seri,Goods gs, int Quantity)
        {
            this.serialNo = seri;
            this.goods = gs;
            this.Quantity = Quantity;
        }
        public override string ToString()
        {
            string result = "";
            result += $"orderDetailId:{serialNo}:  ";
            result += goods + $", quantity:{Quantity}";
            return result;
        }

        public OrderDetails()
        {
        }
    }
    public class OrderService
    {
        public Dictionary<uint, Order> orderDict;
        //static public List<Order> orders = new List<Order>();
        string[] serNo = { "删除", "修改", "查询" };
        int no = 0;
        //public OrderService()
        //{ }
        List<int> indexReal = new List<int>(); //接出所找订单的下标
        public OrderService()
        {
            orderDict = new Dictionary<uint, Order>();
        }
        public OrderService(int serviceNum)
        {


        }
        /// <summary>
        /// 添加订单
        /// </summary>
        public void addOrder(Order order)
        {
            if (orderDict.ContainsKey(order.OrderNo))
                throw new Exception($"order-{order.OrderNo} is already existed!");
            orderDict[order.OrderNo] = order;

        }
        /// <summary>
        /// 删除订单
        /// </summary>

        public void RemoveOrder(uint orderId)
        {
            orderDict.Remove(orderId);
        }
        public Order GetById(uint orderId)
        {
            return orderDict[orderId];
        }
        public List<Order> QueryByGoodsName(string goodsName)
        {
            var query = orderDict.Values.Where(order =>
                    order.ODetails.Where(d => d.goods.GoodsName == goodsName)
                    .Count() > 0
                );
            return query.ToList();

        }
        public List<Order> QueryByCustomerName(string customerName)
        {
            var query = orderDict.Values
                .Where(order => order.Customer == customerName);
            return query.ToList();
        }

        public List<Order> QueryByPrice(double price)
        {
            var query = orderDict.Values
                .Where(order => order.SumReal > price);
            return query.ToList();
        }
        public void UpdateCustomer(uint orderId, string newCustomer)
        {
            if (orderDict.ContainsKey(orderId))
            {
                orderDict[orderId].Customer = newCustomer;
            }
            else
            {
                throw new Exception($"order-{orderId} is not existed!");
            }
        }
    }
}