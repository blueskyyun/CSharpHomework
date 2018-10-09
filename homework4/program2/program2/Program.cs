using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program2
{
    public class Order
    {
        public string costumer; //客户名
        public int orNum;   //订单号
        static public int orCnt = 0;
        public Order(){ }
    }
    //public class Good
    //{
    //    public string gooNme;
    //    public int gooCnt;
    //    public Good(string goodsNm, int cnt)
    //    {
    //        gooNme = goodsNm;
    //        gooCnt = cnt;
    //    }
    //    public String toString()
    //    {
    //        return "goods Name:" + gooNme + "\tgoods Count：" + gooCnt;
    //    }

    //}
    public class OrderDetails:Order

    {
        public string goodsNm;
        public int goodsCnt;
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
        public OrderDetails(string cmer, string gdsNm, int gdsCnt)
        {
            costumer = cmer;
            goodsNm = gdsNm;
            goodsCnt = gdsCnt;
        }
        public void showInfo()
        {
            Console.WriteLine("Order【order No：" + orNum + " |costumer：" + costumer + " |goods name：" + goodsNm + " |goods count：" + goodsCnt + "】");
            //for(int i = numSerial[orNum] - numKind[orNum]; i < numKind[orNum] -1 ; i++)
            //     Console.WriteLine(goods[i].toString());

        }
    }
    public class OrderService:OrderDetails
    {
       static List<OrderDetails> orders = new List<OrderDetails>();
        string[] serNo = { "删除", "修改", "查询"};
        int no = 0;
        //public OrderService()
        //{ }
        List<int> indexReal = new List<int>(); //接出所找订单的下标
        public OrderService(int serviceNum)
        {
            switch (serviceNum) {
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
            orders.Add(new OrderDetails(cstmNm, gdsNm, gdsCnt));
            orCnt++;
            orders[orders.Count - 1].orNum = orCnt;

            //bool isContinue = true;
            //string anwsCtnu;
            //while (isContinue)
            //{
           
                
                //numKinds++;
               
                //goods.Add(new Good(gNm, cnt));
            //    Console.WriteLine("是否继续实行订购商品（yes/no）:");
            //    anwsCtnu = Console.ReadLine();
            //    if (anwsCtnu == "yes")
            //    {
            //        isContinue = true;
            //    }
            //    else if (anwsCtnu == "no")
            //    {
            //        isContinue = false;
            //    }
            //    else
            //    {
            //        Console.WriteLine("输入错误");
            //        return;
            //    }
            //}
            //numSer += numKinds;
            //numKind.Add(numKinds);
            //numSerial.Add(numSer);
           
            Console.WriteLine("您已成功订购商品，订单号为" + orCnt);
        }
        /// <summary>
        /// 删除订单
        /// </summary>
        public void deleteOrd()
        {
            no = 0;
            indexReal = findOrd(0);
            for (int i = 0; i < indexReal.Count; i++) {
                orders.RemoveAt(indexReal[i]);
                Console.WriteLine("已删除"+ (indexReal[i]+1) + "订单！");
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
                        break;
                    case 3:
                        Console.WriteLine("请输入，您要修改商品数量为：");
                        while (!(int.TryParse(Console.ReadLine(), out orders[indexReal[i]].goodsCnt) && orders[indexReal[i]].goodsCnt > 0))
                        {
                            Console.WriteLine("你的输入有误，请输入您要" + serNo[no] + "的商品数量：");
                        }
                        break;
                }
            }

        }
        /// <summary>
        /// 查询订单
        /// </summary>
        public List<int> findOrd(int no)
        {
               
            
            int numOrdInfo;
            string[] infoFind = {"订单号", "客户名", "商品名" };
            
            Console.WriteLine("请选择搜索项（1订单号， 2客户名， 3商品名）：");
            while (!(int.TryParse(Console.ReadLine(), out numOrdInfo) && numOrdInfo > 0 && numOrdInfo <= 3))
            {
                Console.WriteLine("输入错误，请选择搜索项（1订单号， 2客户名， 3商品名）：");
            }
            Console.WriteLine("请输入您要搜索的" + infoFind[numOrdInfo-1]);

            int noOrd;
            string nmCostm;
            string nmGds;
            bool isFind = false;
            List<int> index = new List<int>(); //接出所找订单的下标

            switch (numOrdInfo) {
                case 1:
                    while (!(int.TryParse(Console.ReadLine(), out noOrd)))
                    {
                        Console.WriteLine("你的输入有误，请输入您要" + serNo[no] + "的订单号,");
                    }
                    for (int i = 0; i < orders.Count; i++) {
                        if (noOrd == orders[i].orNum) {
                            isFind = true;
                            index.Add(i);
                            break;
                        }
                    }

                    break;
                case 2:
                    nmCostm = Console.ReadLine();
                    for (int i = 0; i < orders.Count; i++) {
                        if (nmCostm == orders[i].costumer) {
                            isFind = true;
                            index.Add(i);
                            break;
                        }
                    }
                    break;
                case 3:
                    nmGds = Console.ReadLine();
                    for (int i = 0; i < orders.Count; i++)
                    {
                        if(orders[i].goodsNm == nmGds) {
                            index.Add(i);
                            isFind = true;
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
            else {
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
                else {
                    Console.WriteLine("输入错误");
                    return;
                }

            }
            Console.WriteLine("程序已退出");
        }
    }
}
