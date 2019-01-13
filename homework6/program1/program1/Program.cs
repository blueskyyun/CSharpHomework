using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace program1
{
    public class Order
    {
        public string costumer; //客户名
        public int orNum;   //订单号
        static public int orCnt = 5;
        public Order() { }
    }
    public class Costumer
    {

    }
    public class Good
    {
        public string gooNme;
        public int gooCnt;
        public Good(string goodsNm, int cnt)
        {
            gooNme = goodsNm;
            gooCnt = cnt;
        }
        //    public String toString()
        //    {
        //        return "goods Name:" + gooNme + "\tgoods Count：" + gooCnt;
        //    }

        //}
    }
        public class OrderDetails : Order

    {
        public string goodsNm;
        public int goodsCnt;
        public double sum;
        //public int numKinds = 0; //商品种类数
        //static public int numSer = 0; //订单最后一个商品序列+1
        //static public List<int> numKind = new List<int>();
        //static public List<int> numSerial = new List<int>();
        //static public List<Good> goods = new List<Good>();
        //public bool findGood(string nmGds) {
        //    bool isFindGood = false;

        //    for (int i = 0; i < goods.Count; i++)
        //    {
        //        if (nmGds == goods[i].gooNme)
        //        {
        //            isFindGood = true;

        //            break;
        //        }
        //    }
        //    return isFindGood;

        //}
        public OrderDetails()
        {
        }
        public OrderDetails(string cmer, string gdsNm, int gdsCnt, int sumMoney)
        {
            costumer = cmer;
            goodsNm = gdsNm;
            goodsCnt = gdsCnt;
            sum = sumMoney;
        }
        public OrderDetails(int ordNo, string cmer, string gdsNm, int gdsCnt, int sumMoney)
        {
            costumer = cmer;
            goodsNm = gdsNm;
            goodsCnt = gdsCnt;
            sum = sumMoney;
            orNum = ordNo;

        }
        public void showInfo()
        {
            Console.WriteLine("Order【order No：" + orNum + " |costumer：" + costumer + " |goods name：" + goodsNm + " |goods count：" + goodsCnt + " |sum of goods：" + sum + "】");
            //for(int i = numSerial[orNum] - numKind[orNum]; i < numKind[orNum] -1 ; i++)
            //     Console.WriteLine(goods[i].toString());

        }
    }
    public class OrderService : OrderDetails
    {
        static public List<OrderDetails> orders = new List<OrderDetails>();
        string[] serNo = { "删除", "修改", "查询" };
        int no = 0;
        //public OrderService()
        //{ }
        List<int> indexReal = new List<int>(); //接出所找订单的下标
        public OrderService() { }
        public OrderService(int serviceNum)
        {
            switch (serviceNum)
            {
                case 1:
                    Console.WriteLine("添加订单");
                    addOrd();
                    break;
                case 2:
                    Console.WriteLine("删除订单");
                    deleteOrd();
                    break;
                case 3:
                    Console.WriteLine("修改订单");
                    changeOrd();
                    break;
                case 4:
                    Console.WriteLine("查询订单");
                    findOrd(2);
                    break;

            }

        }
        /// <summary>
        /// 添加订单
        /// </summary>
        public void addOrd()
        {

            Console.WriteLine("请输入您的名字：");
            string cstmNm = Console.ReadLine();
            Console.WriteLine("请输入您要订购的商品名称：");
            string gdsNm = Console.ReadLine();
            int gdsCnt;
            Console.WriteLine("请输入您要订购的商品数量：");
            while (!(int.TryParse(Console.ReadLine(), out gdsCnt) && gdsCnt >= 0))
            {
                Console.WriteLine("你的输入有误，请输入您要订购的商品数量：");
            }
            int sumMoney = new Random(Guid.NewGuid().GetHashCode()).Next(5000, 50000);
            orders.Add(new OrderDetails(cstmNm, gdsNm, gdsCnt, sumMoney));
            orCnt++;
            orders[orders.Count - 1].orNum = orCnt;


            Console.WriteLine("您已成功订购商品，订单号为" + orCnt);
        }
        /// <summary>
        /// 删除订单
        /// </summary>
        public void deleteOrd()
        {
            no = 0;
            indexReal = findOrd(0);
            for (int i = 0; i < indexReal.Count; i++)
            {
                orders.RemoveAt(indexReal[i]);
                Console.WriteLine("已删除" + (indexReal[i] + 1) + "订单！");
            }

        }
        /// <summary>
        /// 修改订单
        /// </summary>
        public void changeOrd()
        {

            indexReal = findOrd(1);
            Console.WriteLine("请输入您要修改的选项（1客户名， 2商品名，3商品数量）");
            int choice;
            while (!(int.TryParse(Console.ReadLine(), out choice) && choice > 0 && choice <= 3))
            {
                Console.WriteLine("输入错误，请选择（1客户名， 2商品名，3商品数量）：");
            }

            for (int i = 0; i < indexReal.Count; i++)
            {
                switch (choice)
                {

                    case 1:
                        Console.WriteLine("请输入，您要修改客户名为：");
                        orders[indexReal[i]].costumer = Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("请输入，您要修改商品名为：");
                        orders[indexReal[i]].goodsNm = Console.ReadLine();
                        orders[indexReal[i]].sum = new Random(Guid.NewGuid().GetHashCode()).Next(5000, 50000);

                        break;
                    case 3:
                        Console.WriteLine("请输入，您要修改商品数量为：");
                        while (!(int.TryParse(Console.ReadLine(), out orders[indexReal[i]].goodsCnt) && orders[indexReal[i]].goodsCnt > 0))
                        {
                            Console.WriteLine("你的输入有误，请输入您要" + serNo[no] + "的商品数量：");
                        }
                        orders[indexReal[i]].sum = new Random(Guid.NewGuid().GetHashCode()).Next(5000, 50000);
                        break;
                }
            }

        }
        /// <summary>
        /// 查询总额大于10000的订单
        /// </summary>

        public void chckOrTenThsd()
        {
            IEnumerable<OrderDetails> orderQuery =
                       from ord in orders
                       where ord.sum >= 10000
                       select ord;

            foreach (OrderDetails ord in orderQuery)
            {
                ord.showInfo();
            }

        }
        /// <summary>
        /// 查询订单
        /// </summary>

        public List<int> findOrd(int no)
        {



            int numOrdInfo;
            string[] infoFind = { "订单号", "客户名", "商品名", "订单总额的范围" };

            Console.WriteLine("您想通过什么查找（1订单号， 2客户名， 3商品名, 4订单总额的范围）：");
            while (!(int.TryParse(Console.ReadLine(), out numOrdInfo) && numOrdInfo > 0 && numOrdInfo <= 4))
            {
                Console.WriteLine("输入错误，请选择搜索项（1订单号， 2客户名， 3商品名，4订单总额的范围）：");
            }
            if (numOrdInfo > 0 && numOrdInfo <= 3)
            {
                Console.WriteLine("请输入您要搜索的" + infoFind[numOrdInfo - 1]);
            }


            int noOrd;
            int ordSumMin = 0;
            int ordSumMax = 0;
            string nmCostm;
            string nmGds;
            bool isFind = false;
            List<int> index = new List<int>(); //接出所找订单的下标

            switch (numOrdInfo)
            {
                case 1:
                    while (!(int.TryParse(Console.ReadLine(), out noOrd)))
                    {
                        Console.WriteLine("你的输入有误，请输入您要" + serNo[no] + "的订单号,");
                    }
                    IEnumerable<OrderDetails> orderQuery =
                        from ord in orders
                        where ord.orNum == noOrd
                        select ord;
                    if (orderQuery.Count() != 0)
                    {
                        isFind = true;
                        foreach (OrderDetails ord in orderQuery)
                        {
                            index.Add(ord.orNum - 1);
                        }
                    }

                    break;
                case 2:
                    nmCostm = Console.ReadLine();
                    orderQuery =
                       from ord in orders
                       where ord.costumer == nmCostm
                       select ord;
                    if (orderQuery.Count() != 0)
                    {
                        isFind = true;
                        foreach (OrderDetails ord in orderQuery)
                        {
                            index.Add(ord.orNum - 1);
                        }
                    }
                    break;
                case 3:
                    nmGds = Console.ReadLine();
                    orderQuery =
                        from ord in orders
                        where ord.goodsNm == nmGds
                        select ord;
                    if (orderQuery.Count() != 0)
                    {
                        isFind = true;
                        foreach (OrderDetails ord in orderQuery)
                        {
                            index.Add(ord.orNum - 1);
                        }
                    }
                    break;
                case 4:
                    Console.WriteLine("请输入订单总额范围的下限(>= 5000)：");
                    while (!(int.TryParse(Console.ReadLine(), out ordSumMin) && ordSumMin >= 5000))
                    {
                        Console.WriteLine("你的输入有误，请输入您要" + serNo[no] + "的订单总额下限,");
                    }
                    Console.WriteLine("请输入订单总额范围的上限(<= 50000)：");
                    while (!(int.TryParse(Console.ReadLine(), out ordSumMax) && ordSumMax <= 50000 && ordSumMax >= ordSumMin))
                    {
                        Console.WriteLine("你的输入有误，请输入您要" + serNo[no] + "的订单总额下限,");
                    }

                    orderQuery =
                       from ord in orders
                       where ord.sum >= ordSumMin && ord.sum <= ordSumMax
                       select ord;
                    if (orderQuery.Count() != 0)
                    {
                        isFind = true;
                        foreach (OrderDetails ord in orderQuery)
                        {
                            index.Add(ord.orNum - 1);
                        }
                    }

                    break;
            }
            if (isFind)
            {
                for (int i = 0; i < index.Count; i++)
                {
                    orders[index[i]].showInfo();
                }
            }
            else
            {
                Console.WriteLine("订单不存在！");
            }
            indexReal = index;
            return indexReal;
        }



    }
    class Program
    {
        static void Main(string[] args)
        {
            int servNum;
            bool isContinue = true;
            string anwsCtnu;
            while (isContinue)
            {
                OrderService.orders.Add(new OrderDetails(1, "Tom", "yogurt", 1000, 12000));
                OrderService.orders.Add(new OrderDetails(2, "Jane", "cheese", 2000, 8000));
                OrderService.orders.Add(new OrderDetails(3, "Jack", "milk", 5000, 22000));
                OrderService.orders.Add(new OrderDetails(4, "Steven", "milk powder", 200, 30000));
                OrderService.orders.Add(new OrderDetails(5, "Mark", "cream", 1000, 48000));
                OrderService os = new OrderService();
                Console.WriteLine("订单总额大于10000的订单如下：");
                os.chckOrTenThsd();

                Console.WriteLine("==================================================================");
                Console.WriteLine("请选择您要实行的业务（1添加订单、2删除订单、3修改订单、4查询订单）");
                if (int.TryParse(Console.ReadLine(), out servNum))
                {
                    if (servNum < 1 || servNum > 4) { Console.WriteLine("输入错误"); return; }
                }
                else { Console.WriteLine("输入错误"); return; }
                OrderService orderService = new OrderService(servNum);

                Console.WriteLine("是否继续实行业务（yes/no）:");
                anwsCtnu = Console.ReadLine();
                if (anwsCtnu == "yes")
                {
                    isContinue = true;
                }
                else if (anwsCtnu == "no")
                {
                    isContinue = false;
                }
                else
                {
                    Console.WriteLine("输入错误");
                    return;
                }

            }

            Console.WriteLine("程序已退出");
        }

        
    }
    public class SerializeDemo
    {
        //public static void Main(String[] args)
        //{
        //    Person[] people = { new Person("李明", 18), new Person("王强", 19) };
        //    //二进制序列化
        //    BinaryFormatter binary = new BinaryFormatter();
        //    string fileName = "s.temp";
        //    BinarySerialize(binary, fileName, people);
        //    //二进制反序列化
        //    Person[] people2 = BinaryDeserialize(binary, fileName) as Person[];
        //    foreach (Person p in people)
        //        Console.WriteLine(p);


        //    //xml序列化
        //    people[0].Name = "Jack";
        //    people[0].Age = 25;

        //    XmlSerializer xmlser = new XmlSerializer(typeof(Person[]));
        //    string xmlFileName = "s.xml";
        //    XmlSerialize(xmlser, xmlFileName, people);

        //    //显示xml文本
        //    string xml = File.ReadAllText(xmlFileName);
        //    Console.WriteLine(xml);

        //    //xml反序列化
        //    Person[] people3 = XmlDeserialize(xmlser, xmlFileName) as Person[];
        //    foreach (Person p in people3)
        //        Console.WriteLine(p);
        //}

        public static void BinarySerialize(IFormatter formatter, string fileName, object obj)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create);
            formatter.Serialize(fs, obj);
            fs.Close();
        }

        public static object BinaryDeserialize(IFormatter formatter, string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open);
            object obj = formatter.Deserialize(fs);
            fs.Close();
            return obj;

        }
        public static void XmlSerialize(XmlSerializer ser, string fileName, object obj)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create);
            ser.Serialize(fs, obj);
            fs.Close();
        }
        public static object XmlDeserialize(XmlSerializer ser, string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open);
            object obj = ser.Deserialize(fs);
            fs.Close();
            return obj;
        }
    }
}

