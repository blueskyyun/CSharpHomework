using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VingtEtUnCards
{
    public class CardTable
    {
        // public Dictionary<int, int> CardFaceTag = new Dictionary<int, int>();
        public static List<int> CardFaceTag = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
        public static List<int> fa = new List<int>(){ 1, 2, 3, 4, 5,6 ,7 ,8, 9, 10, 11, 12, 13};
        public static List<string> cardSuit = new List<string>() {"bl", "bp", "pl", "rp" };
        public Random r = new Random(Guid.NewGuid().GetHashCode());

        //protected void GenerDic() {
        //    CardFaceTag.Add(1, 0);
        //    CardFaceTag.Add(2, 0);
        //    CardFaceTag.Add(3, 0);
        //    CardFaceTag.Add(4, 0);
        //    CardFaceTag.Add(5, 0);
        //    CardFaceTag.Add(6, 0);
        //    CardFaceTag.Add(7, 0);
        //    CardFaceTag.Add(8, 0);
        //    CardFaceTag.Add(9, 0);
        //    CardFaceTag.Add(10,0);
        //    CardFaceTag.Add(11, 0);
        //    CardFaceTag.Add(12, 0);
        //    CardFaceTag.Add(13, 0);

        //}




        public CardTable()
        {
            //GenerDic();
        }

        
        /// <summary>
        /// 生成初始牌面
        /// </summary>
        public void GenerateInitialCards(List<Card> pC, List<Card> b) {
            SendACard(pC,b);
            SendACard(pC, b);

        }
        /// <summary>
        /// 生成一副牌,洗牌
        /// </summary>
            public Task<List<Card>> GenerateADeck(List<Card> b) {
            
                return Task<List<Card>>.Run(() =>
                {
                   
                        b.Clear();
                        
                        int f = 0;
                        while (true)
                        {
                            f = r.Next(0, 13);

                            if (CardFaceTag[f] < 4)
                            {
                                Card card = new Card(f + 1, cardSuit[CardFaceTag[f]]);
                                b.Add(card);
                                CardFaceTag[f] += 1;
                            }
                            if (b.Count == 52)
                            {
                                break;
                            }

                        }
                    return b;
                });
            
           
            
            //if (b.Count == 52) return true;
            //return false;

        }
        /// <summary>
        /// 发一张牌
        /// </summary>
        public void SendACard(List<Card> pC, List<Card> b) {
            //if (b.Count <= 0)
            //{
            //    b = await GenerateADeck(b);
            //}
            pC.Add(b[b.Count - 1]);
                b.RemoveAt(b.Count - 1);
            //int offset = (pC.Count - 2) * 120;
            //pC[pC.Count - 1].PointToScreen(new Point((p.Left+p.Right)/2+offset));
            //p.Controls.Add(pC[pC.Count - 1]);
            //b.RemoveAt(b.Count-1);
        }

        
    }
    


  


}
