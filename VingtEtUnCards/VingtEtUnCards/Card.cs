using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VingtEtUnCards
{
    public class Card
    {
        /// <summary>
        /// 牌面
        /// </summary>
        public int CardFace
        {
            get; set;
        }
        /// <summary>
        /// 花色
        /// </summary>
        public string CardSuit
        {
            get; set;
        }
        public Card(int face, string suit)
        {
            CardFace = face;
            CardSuit = suit;
          
        }
        public Card():this(0, "") {

        }

       
    }
}
