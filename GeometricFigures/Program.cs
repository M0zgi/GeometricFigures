using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricFigures
{

    enum Color
    {
        Black,     
        DarkBlue,    
        DarkGreen,  
        DarkCyan,   
        DarkRed,     
        DarkMagenta,
        DarkYellow,
        Gray,
        DarkGray,
        Blue,
        Green, 
        Cyan,
        Red,
        Magenta,
        Yellow, 
        White
    }


    abstract class Figures
    {
        protected string name;
        protected Color color;
        protected int coordinationX;
        protected int coordinationY;

        public Figures (string name, Color color, int coordinationX, int coordinationY)
        {
            this.name = name;
            this.color = color;
            this.coordinationX = coordinationX;
            this.coordinationY = coordinationY;
        }        

        public static void ResetConsole()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Title = "GeometricFigures";
        }

        public void SetColor(Color color)
        {

            Console.Write($"Введите цвет для фигуры {name}: ");
            string SetColor = Console.ReadLine();
            this.color = Enum.GetNames(typeof(Color)).Contains(SetColor) ? (Color)Enum.Parse(typeof(Color), SetColor) : color = Color.White;
        }

        public abstract void Print();
    }

    abstract class Quadrangle : Figures
    {
        private int SizeA, SizeB;
        public Quadrangle(string name, Color color, int coordinationX, int coordinationY, int SizeA, int SizeB) : base(name, color, coordinationX, coordinationY)        
        {
            this.SizeA = SizeA;
            this.SizeB = SizeB;
        }

        public int ASize { get { return SizeA; } set { SizeA = value; } }
        public int BSize { get { return SizeB; } set { SizeB = value; } }  

    }

    sealed class Rectangle : Quadrangle
    {           
        public Rectangle(string name, Color color, int coordinationX, int coordinationY, int SizeA, int SizeB) : base(name, color, coordinationX, coordinationY, SizeA, SizeB) { }

        public override void Print()
        {
            Console.SetCursorPosition(this.coordinationX, this.coordinationY);
            Console.ForegroundColor = (ConsoleColor)color;
            Console.WriteLine($"Фигура: {name} Цвет: {color} Сторона A: {this.ASize} Сторона B: {this.BSize}");

            for (int i = 1; i < this.ASize + 1; i++)
            {
                Console.SetCursorPosition(this.coordinationX, this.coordinationY + i);
                Console.Write("*");
            }

            for (int i = 1; i < this.ASize + 1; i++)
            {
                Console.SetCursorPosition(this.coordinationX + this.BSize, this.coordinationY + i);
                Console.Write("*");
            }

            for (int i = 1; i < this.BSize + 1; i++)
            {
                Console.SetCursorPosition(this.coordinationX + i, this.coordinationY + 1);
                Console.Write("*");
            }

            for (int i = 1; i < this.BSize + 1; i++)
            {
                Console.SetCursorPosition(this.coordinationX + i, this.coordinationY + this.ASize);
                Console.Write("*");
            }

            Figures.ResetConsole();
        }        
    }

    sealed class Rhombus : Quadrangle
    {
        public Rhombus(string name, Color color, int coordinationX, int coordinationY, int SizeA, int SizeB) : base(name, color, coordinationX, coordinationY, SizeA, SizeB) { }

        public override void Print()
        {
            Console.SetCursorPosition(this.coordinationX, this.coordinationY);
            Console.ForegroundColor = (ConsoleColor)color;
            Console.WriteLine($"Фигура: {name} Цвет: {color} Сторона A: {this.ASize} Сторона B: {this.BSize}");
            Figures.ResetConsole();
        }
    }

    sealed class Trapeze : Quadrangle
    {

        private int SizeC, SizeD;
        public int CSize { get { return SizeC; } set { SizeC = value; } }
        public int DSize { get { return SizeD; } set { SizeD = value; } }

        public Trapeze(string name, Color color, int coordinationX, int coordinationY, int SizeA, int SizeB, int SizeD, int SizeC) : base(name, color, coordinationX, coordinationY, SizeA, SizeB)
        {
            this.SizeC = SizeC;
            this.SizeD = SizeD;
        }
       
        public override void Print()
        {
            Console.SetCursorPosition(this.coordinationX, this.coordinationY);
            Console.ForegroundColor = (ConsoleColor)color;
            Console.WriteLine($"Фигура: {name} Цвет: {color} Сторона A: {this.ASize} Сторона B: {this.BSize} Сторона C:{this.SizeC} Сторона D: {this.SizeD}");
            Figures.ResetConsole();
        }
    }

    sealed class Polygon : Figures
    {
        private int SizeA, SizeB, SizeC, SizeD, SizeE, SizeF;
        public Polygon(string name, Color color, int coordinationX, int coordinationY, int SizeA, int SizeB, int SizeC, int SizeD, int SizeE, int SizeF) : base(name, color, coordinationX, coordinationY) 
        {
            this.SizeA = SizeA;
            this.SizeB = SizeB;
            this.SizeC = SizeC;
            this.SizeD = SizeD;
            this.SizeE = SizeE;
            this.SizeF = SizeF;
        }       

        public override void Print()
        {
            Console.SetCursorPosition(this.coordinationX, this.coordinationY);
            Console.ForegroundColor = (ConsoleColor)color;
            Console.WriteLine($"Фигура: {name} Цвет: {color} Сторона A: {this.SizeA} Сторона B: {this.SizeB} Сторона C:{this.SizeC} Сторона D: {this.SizeD} Сторона E: {this.SizeE} Сторона F: {this.SizeF}");
            Figures.ResetConsole();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Figures.ResetConsole();

            int coordinationX = 0, coordinationY = 0;


            Color color = new Color();

            color = Color.Gray;

            Quadrangle R = new Rectangle("Прямоугольник", color, coordinationX, coordinationY, 0, 0);
            R.SetColor(color);
            R.ASize = 10;
            R.BSize = 5;

            coordinationX = 10;
            coordinationY = 5;

            Quadrangle А = new Rhombus("Ромб", color, coordinationX, coordinationY, 0, 0);

            А.ASize = 7;
            А.BSize = 9;
            А.SetColor(color);

            coordinationX = 17;
            coordinationY = 15;

            Trapeze T = new Trapeze("Трапеция", color, coordinationX, coordinationY, 0, 0, 0, 0);

            T.ASize = 7;
            T.BSize = 9;
            T.CSize = 11;
            T.DSize = 4;
            T.SetColor(color);

            coordinationX = 0;
            coordinationY = 25;

            Figures M = new Polygon("Многоугольник", color, coordinationX, coordinationY, 0, 0, 0, 0, 0, 0);
            M.SetColor(color);
            Console.Clear();          

            Figures[] figures = new Figures[] { R, А, T, M };

            foreach (var item in figures)
            {
                item.Print();
            }

            Console.WriteLine("\n\n\n\n");
        }
    }
}
