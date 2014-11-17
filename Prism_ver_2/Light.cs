using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Sharp_Prism
{
    /// <summary>
    /// Класс излучателя света 
    /// Имеет список лучей 
    /// Список поражденных лучей(на более поздних версиях)
    /// Умеет расщирятся по х оси 
    /// Имеет Две точки расширенияе 
    /// Может быть передвинут и захвачен только по оси х 
    /// Имеет интенсивность появления луча (через сколько пикселей появиться луч стандарт 10)
    /// </summary>
    class Light : MoveObject
    {
        int K = 20;
        Color color = Color.Black;
        Color Linecolor = Color.White;
        public Color LineColor { get { return Linecolor; } set { Linecolor = value; Update(); } }
        System.Collections.Generic.List<Line> Lines = new List<Line>();
        MoveXPoint x, y;
        public int PointSize { get { return this.x.Size; } set { this.x.Size = value; this.y.Size = value; } }
        public int FrequencyOfTheLight { get { return K; } set { K = value; } }
        int Length()
        {
            return Math.Abs(x.X - y.X);
        }
        public System.Collections.Generic.List<Line> GetLinesFromLight() 
        { 
            Update(); 
            return Lines; 
        }
        public Light(int x, int y, int height, int size = 5)
        {
            this.x = new MoveXPoint(x, height, size); this.x.IscanmoveP = true; this.x.IscanmoveM = true;
            this.y = new MoveXPoint(y, height, size); this.y.IscanmoveP = true; this.y.IscanmoveM = true;
        }
        public void Update()
        {
            Lines.Clear();
            for (int i = 2; i < Length() / (K) + 1; i += 4)
            {
                Lines.Add(new Line
                    (new PointF(this.x.X + i * K, this.y.Y + this.y.Size - this.y.Size / 3), 90));
                Lines.Last().Color = Linecolor;
                Lines.Last().LineToInfinity();
            }
        }
        public override Color Color { get { return color; } set { color = value; x.Color = color; y.Color = color; } }
        public MoveObject IsInLight(int x, int y)
        {
            GraphicsPath pologon = new GraphicsPath();
            pologon.AddPolygon(new PointF[]
            {
                new PointF((float)this.x.X + (float)this.x.Size, this.x.Y),
                new PointF((float)this.y.X, this.y.Y + (float)this.y.Size / (float)3),
                new PointF( this.x.X + (float)this.x.Size, this.x.Y + (float)this.y.Size ),
                new PointF( this.y.X, this.y.Y + (float)this.y.Size )
            });
            if (pologon.IsVisible(x, y)) return this;
            else
                if (this.x.IsInPoint(x, y)) return this.x;
                else
                    if (this.y.IsInPoint(x, y)) return this.y;
                    else return null;
        }
        public override void Draw(PaintEventArgs e)
        {
            if ((y.X - x.X) < K * 7 + x.Size)
            {
                x.IscanmoveP = false;
                y.IscanmoveM = false;
            }
            else { x.IscanmoveP = true; y.IscanmoveM = true; }
            x.Draw(e);
            y.Draw(e);
            // foreach (Line line in Lines) { line.Draw(e); }
            //e.Graphics.DrawRectangle(new Pen(color), x.X + (float)x.Size, x.Y + (float)x.Size / (float)3, x.X - y.X - x.Size, x.Size / 2);
            e.Graphics.DrawLine(new Pen(color, 3), x.X + (float)x.Size, x.Y + (float)x.Size / (float)4, y.X, y.Y + (float)y.Size / (float)4);
            e.Graphics.DrawLine(new Pen(color, 3), x.X + (float)x.Size, x.Y + (float)y.Size - (float)x.Size / (float)3, y.X, y.Y + (float)y.Size - (float)y.Size / (float)3);
        }
        /// <summary>
        /// Передвигаеться только по x координате 
        /// </summary>
        /// <param name="xx"></param>
        /// <param name="yy"></param>
        public override void MoveBy(int xx, int yy)
        {
            x.IscanmoveP = true;
            y.IscanmoveM = true;
            x.MoveBy(xx, yy);
            y.MoveBy(xx, yy);
        }
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append("<Light>");
            str.Append("\n" + x.ToString()+ ";");
            str.Append("\n" + y.ToString() + ";");
            str.Append("\n</Light>");
            return str.ToString();
        }
        public void FromString(string str)
        {
            int i = 0;
            str = str.Replace("\n", string.Empty);
            string[] split = str.Split(new Char[] { ';' });
           
            foreach (string s in split)
            {
                if (!s.Equals("</Light>"))
                {
                    i++;
                    switch (i)
                    {
                        case 1:
                            x.FromString(s);
                            break;
                        case 2:
                            y.FromString(s);
                            break;
                    }
                }
            }
        }
    }
}
