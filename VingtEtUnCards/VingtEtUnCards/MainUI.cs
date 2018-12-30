using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VingtEtUnCards
{
    public partial class MainUI : Form
    {
        
        static string basePath = AppDomain.CurrentDomain.BaseDirectory;
        private string path;
        private Form1 form1 = null;
        //private MessageToPlayer messageToPlayer;
        private string message = "";
        List<PictureBox> pictureBoxesCard = new List<PictureBox>();
        PictureBox p;

        Player p1 = new Player("Player");
        Banker banker = new Banker("Banker");
        CardTable cardTable = new CardTable();
        List<Card> card1 = new List<Card>();
        List<Card> card2 = new List<Card>();
        List<Card> usingCard = new List<Card>();
        private TimeSpan ts; 
        private bool isClick = false;
        public bool isFinish = false;
        /// <summary>
        /// 记录局数
        /// </summary>
        private int no = 0;
        /// <summary>
        /// 记录停牌次数
        /// </summary>
        private int standNo = 0;
       
        public MainUI()
        {

            // play();
           
            InitializeComponent();
            //this.button1.Visible = false;
            //this.button2.Visible = false;
            //CardTable c = new CardTable();
            //List<Button> deckCards = new List<Button>();
            //c.GenerateADeck(ref deckCards);
            //Player p1 = new Player();
            //Banker banker = new Banker();
            //p1.GenerateInitialCards(ref deckCards, ref p1.CardsHaving, ref panel2);
            //banker.GenerateInitialCards(ref deckCards, ref p1.CardsHaving, ref panel2);

        }

        public MainUI(Form1 frm1)
        {
            InitializeComponent();
            this.form1 = frm1;
        }
        /// <summary>
        /// 要牌
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //p1.isOper = true;
            isClick = true;
            cardTable.SendACard(p1.CardsHaving, card1);
            drawCards(ref p1.CardsHaving, p1.CardsHaving.Count,flowLayoutPanel2);
            p1.pointsCount = p1.calPoints(ref p1.CardsHaving);
            label5.Text = Convert.ToString(p1.pointsCount);
           if(p1.isOver())
            {
                message = p1.name + " Burst!!!";
                GerMessageToPlayer(message);
            }
            else
            {
                BankerPlay();
            }

            
        }
      
        public void BankerPlay()
        {
            if(banker.pointsCount < 17)
            {
                cardTable.SendACard(banker.CardsHaving,  card1);
                banker.pointsCount = banker.calPoints(ref banker.CardsHaving);
                drawCards(ref banker.CardsHaving, banker.CardsHaving.Count, flowLayoutPanel1);
            }
            else
            {
                standNo += 1;
                drawCards(ref banker.CardsHaving, banker.CardsHaving.Count, flowLayoutPanel1);
            }

            if (isFinAGame(banker, p1))
            {
                GerMessageToPlayer(message);
            }
            //ts = new TimeSpan(0, 0, 30);
            //timer1.Enabled = true;
            
        }
        private void MainUI_FormClosing(object sender, FormClosingEventArgs e)
        {
           
            this.form1.Visible = true;
           //this.Dispose();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 画牌
        /// </summary>
        /// <param name="c"></param>
        /// <param name="n">传入需要画出的牌数</param>
        /// <param name="panel"></param>
       private void drawCards(ref List<Card> c,int n,  FlowLayoutPanel panel)
        {
            panel.Controls.Clear();
            //int offset = (pC.Count - 2) * 120;
            //pC[pC.Count - 1].PointToScreen(new Point((p.Left+p.Right)/2+offset));
            //p.Controls.Add(pC[pC.Count - 1]);
            //b.RemoveAt(b.Count-1);
            pictureBoxesCard.Clear();
            for (int i = 0; i <n; i++)
            {
                //p.Dispose();
                p = new PictureBox();
                p.Size = new Size(60, 80);
                path = basePath +"pokerImage\\" + c[i].CardFace + c[i].CardSuit + ".jpg";
                //p.Location = new Point(100, 100);
                p.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBoxesCard.Add(p);
                pictureBoxesCard[i].Load(path);

                panel.Controls.Add(pictureBoxesCard[i]);
            }
            //p.Dispose();
        }
        public void drawBack(FlowLayoutPanel pan)
        {
            p = new PictureBox();
            p.Size = new Size(60, 80);
            path = basePath + "pokerImage\\" + "back.PNG";
          
            p.SizeMode = PictureBoxSizeMode.StretchImage;
            p.Load(path);
            pan.Controls.Add(p);


        }
        /// <summary>
        /// 进入游戏
        /// </summary>
        async public void play() {
            if(no % 3 == 1)
            {
                card1 = await cardTable.GenerateADeck(card1);
                //card2 = await cardTable.GenerateADeck(card2);
               
            }
            //if (no % 6 >= 1 && no % 6 <= 3)
            //{
                
            //    if(usingCard.Count <= 10)
            //    {
            //        usingCard.Clear();
            //        foreach(Card c in card1)
            //        {
            //            usingCard.Add(c);
            //        }
            //    }
            //    //usingCard = card1;
            //}
            //else if (no % 6 == 4 || no % 6 == 5 || no % 6 == 0)
            //{
            //    if (usingCard.Count <= 10)
            //    {
            //        usingCard.Clear();
            //        foreach (Card c in card2)
            //        {
            //            usingCard.Add(c);
            //        }
            //    }
            //    //usingCard = card2;
            //}


            cardTable.GenerateInitialCards(p1.CardsHaving, card1);
            p1.pointsCount = p1.calPoints(ref p1.CardsHaving);
            drawCards(ref p1.CardsHaving,p1.CardsHaving.Count, flowLayoutPanel2);
            label5.Text = Convert.ToString(p1.pointsCount);

            cardTable.GenerateInitialCards( banker.CardsHaving, card1);
            banker.calPoints(ref banker.CardsHaving);
            drawCards(ref banker.CardsHaving,banker.CardsHaving.Count-1, flowLayoutPanel1);
            drawBack(flowLayoutPanel1);

            if (p1.pointsCount == 21 || banker.pointsCount == 21)
            {
                if (p1.pointsCount == 21)
                {
                    message = "Black Jack, You Win!!!";
                }
                else
                {
                    message = "You Lose!";
                }
                GerMessageToPlayer(message);
            }
            //ts = new TimeSpan(0, 0, 30);
            //timer1.Enabled = true;
           
        }
        /// <summary>
        /// 一局结束，显示给玩家结果
        /// </summary>
        /// <param name="s"></param>
       private void GerMessageToPlayer(string s)
        {
            //resetSource();
            
            this.label1.Text = message;
            p1.CardsHaving.Clear();
            banker.CardsHaving.Clear();
            //card.Clear();
            this.button1.Visible = false;
            this.button2.Visible = false;
            this.button3.Visible = true;
            this.label5.Text = "";
            message = "";
            
            //messageToPlayer = new MessageToPlayer(s, this);
            //messageToPlayer.Show();
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            no += 1;
            label3.Text = "第" + Convert.ToString(no) + "局";
            this.button3.Visible = false;
            this.button1.Visible = true;
            this.button2.Visible = true;
           
            play();
            resetSource();
            this.label1.Text = "";
            //this.Update();
            ts = new TimeSpan(0, 0, 30);
            timer1.Enabled = true;
            
            
            
          



        }
        private void resetSource()
        {
            //card = new List<Card>();
            //this.Controls.Remove(p);

            //p1.CardsHaving.Clear();
            //p1.pointsCount = 0;
            //label5.Text = Convert.ToString(p1.pointsCount);
            //banker.CardsHaving.Clear();
            //banker.pointsCount = 0;
            //pictureBoxesCard.Clear();
            // p.Dispose();
            //card.Clear();
            //flowLayoutPanel2.Update();
            //flowLayoutPanel1.Update();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string str = ts.Hours.ToString() + ":" + ts.Minutes.ToString() + ":" + ts.Seconds.ToString();
            label1.Text = str;
            ts = ts.Subtract(new TimeSpan(0, 0, 1));
            if (isClick)
            {
                timer1.Enabled = false;
                //timer1.Enabled = true;
                ts = new TimeSpan(0, 0, 30);
            }
            if (ts.TotalSeconds < 0.0)
            {
                timer1.Enabled = false;
                form1.Enabled = false;
                MessageBox.Show("请选择是否要牌", "Warning", MessageBoxButtons.OK);
                ts = new TimeSpan(0, 0, 30);
                timer1.Enabled = true;
                form1.Enabled = true;

            }
        }
        /// <summary>
        /// 停牌
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            p1.isOper = true;
            isClick = true;
            p1.isStand = true;
            standNo += 1;
            BankerPlay();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a">操作的玩家</param>
        /// <param name="b">未操作的玩家</param>
        /// <returns></returns>
        private bool isFinAGame(Actor a, Actor b)
        {
            if (a.pointsCount == 21)
            {
                message = "Vingt Et Un, " + a.name + " Win!!!";
                return true;
            }
            else if(a.pointsCount > 21)
            {
                message = "Burst! " + a.name + " LOSE!";
                return true;
            }
            else if(standNo >= 2)
            {
                if(a.pointsCount > b.pointsCount)
                {
                    message = a.name + " WIN!!!";
                }
                else if(a.pointsCount == b.pointsCount)
                {
                    message = "Same Points, Banker WIN!!!";
                }
                else
                {
                    message = b.name + " WIN!!!";
                }
                return true;
            }
            else
            {
                return false;
            }


            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }

}
