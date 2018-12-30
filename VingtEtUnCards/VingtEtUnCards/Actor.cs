using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VingtEtUnCards
{
    class Actor
    {
       
        public List<Card> CardsHaving = new List<Card>();
        public int pointsCount = 0;
        public bool isStand = false;
        public string name;
        public Actor() { }
        public Actor(string s) { name = s; }
        public int calPoints(ref List<Card> actorCards)
        {
            pointsCount = 0;
            List<Card> cA = new List<Card>();
            foreach (Card a in actorCards)
            {
                //try
                //{
                //if(a.CardFace >13 || a.CardFace < 1) { throw new MyCardFaceOutOfRangeException(a.CardFace); }
                if (a.CardFace > 1 && a.CardFace <= 10)
                {
                    pointsCount += a.CardFace;
                }
                else if (a.CardFace > 10 && a.CardFace <= 13)
                {
                    pointsCount += 10;
                }
                else
                {
                    cA.Add(a);
                }
            }   
            foreach(Card a in cA)
            {
                pointsCount += 1;
            }
            if(pointsCount < 12&& cA.Count > 0) { pointsCount += 10; }
                //}
                //catch (MyCardFaceOutOfRangeException e) {
                //    Console.WriteLine(e.Message);
                //    return -1;
                //}

            

            return pointsCount;
        }

        public bool isEnd()
        {
            calPoints(ref CardsHaving);
            if(isVingtEtUn() || isOver())
            {
                return true;
            }
            return false;
        }
        public bool isVingtEtUn() {
            
            if (pointsCount == 21) {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool isOver()
        {
            
            if(pointsCount > 21)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 拿牌
        /// </summary>
        public void hit()
        {
           
        }
        /// <summary>
        /// 停牌
        /// </summary>
        public void stand()
        {

        }
    }
}
