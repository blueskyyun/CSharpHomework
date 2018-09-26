using System;

namespace program1
{
    public abstract class Shape {
        public abstract double getArea( );
        public abstract void getData();
    }
    //三角形类
    public class Triangle : Shape
    {
        private static int nDaTri = 3;      //需要获取的数据个数
        private double[] dataTri = new double[nDaTri];

        public override void getData()
        {
            Console.WriteLine("请输入第一条边的边长：");
            double.TryParse(Console.ReadLine(), out dataTri[0]);
            Console.WriteLine("请输入第二条边的边长：");
            double.TryParse(Console.ReadLine(), out dataTri[1]);
            Console.WriteLine("请输入第三条边的边长：");
            double.TryParse(Console.ReadLine(), out dataTri[2]);

           
        }
        public override double getArea( )
        {
            return Math.Sqrt((dataTri[0]/2.0 + dataTri[1]/2.0 + dataTri[2]/2.0)*(dataTri[1]/2.0+dataTri[2]/2.0-dataTri[0]/2.0)*(dataTri[0]/2.0+dataTri[2]/2.0-dataTri[1]/2.0)*(dataTri[0]/2.0+dataTri[1]/2.0-dataTri[2]/2.0));
           
        }
    }
    //圆形
    public class Circle : Shape
    {
        private static int  nDaCir= 1;      //需要获取的数据个数
        private double[] dataCir = new double[nDaCir];

        public override void getData()
        {
            Console.WriteLine("请输入圆的半径：");
            double.TryParse(Console.ReadLine(), out dataCir[0]);
          
           

        }
        public override double getArea()
        {
            return 3.14159*dataCir[0]*dataCir[0];
            
        }
    }
    //正方形
    public class Square : Shape
    {
        private static int nDaSqr = 3;      //需要获取的数据个数
        private double[] dataSqr= new double[nDaSqr];

        public override void getData()
        {
            Console.WriteLine("请输入边长：");
            double.TryParse(Console.ReadLine(), out dataSqr[0]);
            

           

        }
        public override double getArea()
        {
            return dataSqr[0] *dataSqr[0];
           
        }
    }
    //矩形
    public class Rectangle : Shape
    {
        private static int nDaRec = 3;      //需要获取的数据个数
        private double[] dataRec = new double[nDaRec];

        public override void getData()
        {
            Console.WriteLine("请输入长：");
            double.TryParse(Console.ReadLine(), out dataRec[0]);
            Console.WriteLine("请输入宽：");
            double.TryParse(Console.ReadLine(), out dataRec[1]);
           

           

        }

        public override double getArea()
        {
            return dataRec[0]*dataRec[1];
            
        }
    }
    //通过简单工厂模式，创建对象
    public class ShapeFactory{
        public static Shape getShape(string sName) {
            Shape s = null;
            switch (sName) {
                case "Triangle":
                    s = new Triangle();
                    break;
                case "Circle":
                    s = new Circle();
                    break;
                case "Square":
                    s = new Square();
                    break;
                case "Rectangle":
                    s = new Rectangle();
                    break;
                default:
                    break;
            }
            return s;
        }
    }

    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入您要创建的对象(Triangle,Circle,Square,Rectangle):");
            string sNm = Console.ReadLine();
            Console.WriteLine("创建的" + sNm + "的面积为;" + getObj(sNm));

        }
        private static double getObj(string sName)
        {
            Shape sh = ShapeFactory.getShape(sName);
            sh.getData();
            return sh.getArea();
        }
    }
   

}
