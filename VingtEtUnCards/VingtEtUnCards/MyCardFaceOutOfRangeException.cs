using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VingtEtUnCards
{
    class MyCardFaceOutOfRangeException:ApplicationException
    {
        private int faceValue;
        public MyCardFaceOutOfRangeException(int face): base("牌面值超出范围:"+face) { 
            faceValue = face;
        }
    }
}
