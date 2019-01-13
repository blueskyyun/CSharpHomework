using Microsoft.VisualStudio.TestTools.UnitTesting;
using program1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace program1.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {

        //OrderService.orders.Add(new OrderDetails(1, "Tom", "yogurt", 1000, 12000));
        //        OrderService.orders.Add(new OrderDetails(2, "Jane", "cheese", 2000, 8000));
        //        OrderService.orders.Add(new OrderDetails(3, "Jack", "milk", 5000, 22000));
        //        OrderService.orders.Add(new OrderDetails(4, "Steven", "milk powder", 200, 30000));
        //        OrderService.orders.Add(new OrderDetails(5, "Mark", "cream", 1000, 48000));
                OrderService os = new OrderService();
        OrderDetails od1 = new OrderDetails(1, "Tom", "yogurt", 1000, 12000);
        OrderDetails od2 = new OrderDetails(2, "Jane", "cheese", 2000, 8000);
        OrderDetails od3 = new OrderDetails(3, "Jack", "milk", 5000, 22000);
        OrderDetails od4 = new OrderDetails(4, "Steven", "milk powder", 200, 30000);
        OrderDetails od5 = new OrderDetails(5, "Mark", "cream", 1000, 48000);

        [TestMethod()]
        public void addOrdTest()
        {
            OrderService.orders.Add(od1);
            os.addOrd();
            Assert.IsTrue(OrderService.orders.Count == 6);
        }

        [TestMethod()]
        public void deleteOrdTest()
        {
            os.deleteOrd();
            Assert.IsTrue(OrderService.orders.Count == 5);
        }

        [TestMethod()]
        public void changeOrdTest()
        {
            os.changeOrd();
            Assert.IsTrue(OrderService.orders.Count == 5);
        }

        

        [TestMethod()]
        public void findOrdTest()
        {
            os.findOrd(2);
            Assert.IsTrue(OrderService.orders.Count == 5);
        }
    }
}