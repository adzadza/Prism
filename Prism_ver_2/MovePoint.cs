using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Sharp_Prism
{
    public class MovePoint : MoveObject
    {
        protected int x, y, size;
        protected Color color;
        protected int maxX, maxY, minX, minY;
        public int MaxX { get { return maxX; } set { maxX = value; } }
        public int MaxY { get { return maxY; } set { maxY = value; } }
        public int MinX { get { return minX; } set { minX = value; } }
        public int MinY { get { return minY; } set { minY = value; } }
        public override Color Color { get { return color; } set { color = value; } }
        public MovePoint(int x, int y, int size = 10)
        {
            this.x = x; this.y = y; this.size = size; color = new Color();
            color = Color.Black; maxX = 1000000; maxY = 1000000; minX = 0; minY = 20;
        }
        public int X { get { return x; } set { x = value; } }
        public int Y { get { return y; } set { y = value; } }
        public int Size { get { return size; } set { size = value; } }
        public override void MoveBy(int xx, int yy)
        {
            x += xx;
            y += yy;
            if (x > MaxX) x = maxX - 5;
            if (x < minX) x = minX;
            if (y > MaxY) y = maxY - 5;
            if (y < MinY) y = minY;
        }
        public override void Draw(PaintEventArgs e)
        {
            e.Graphics.DrawEllipse(new Pen(color, 2), x, y, size, size);
        }
        public bool IsInPoint(int xx, int yy)
        {
            double mx = xx - x, my = yy - y;
            if (Math.Sqrt(mx * mx + my * my) <= size) return true;
            else return false;
        }
        public Point GetCenter() { return new Point(x + size / 2, y + size / 2); }
        public override string ToString()
        {
            return ("{X["+ x.ToString() + "]Y[" + y.ToString()+"]}");
            
            //return base.ToString();
        }
        public void FromString(string str)
        {
            this.x=0;
            this.y=0;
            bool innum=false;
            short type = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '['){innum = true; type++;}else
                if (str[i] == ']') innum = false;else
                if(Char.IsDigit(str[i]))
                   {
                       switch(type)
                       {
                           case 1:
                               this.x *=10;
                               this.x += str[i] - '0';
                               break;
                          case 2:
                               this.y *=10;
                               this.y += str[i] - '0';
                               break;
                       }
                   }
               }
            }
    }
    class MoveXPoint : MovePoint
    {
        bool iscanmoveP = false;
        bool iscanmoveM = false;
        public bool IscanmoveP { get { return iscanmoveP; } set { iscanmoveP = value; } }
        public bool IscanmoveM { get { return iscanmoveM; } set { iscanmoveM = value; } }
        public MoveXPoint(int x, int y, int size = 5) : base(x, y, size) { }
        public override void MoveBy(int xx, int yy)
        {
            if (xx > 0 && !iscanmoveP) return;
            if (xx < 0 && !iscanmoveM) return;
            this.X += xx;

            if (x > MaxX) x = this.MaxX - 5;
            if (x < minX) x = minX;

        }
    }
}
