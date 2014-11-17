using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Sharp_Prism
{
    /// <summary>
    /// Класс линии 
    /// 
    /// </summary>
    public class Line : MyObject
    {
        public short type = -1;
        // -1 линия пораждена от источника 
        // 1 от зеркала 
        // 2 линия от призмы
        public int ntype = -1;
        // номер линии от который произошло она рождена 
        Line pline = null;
        public Line ParentLine { get { if (pline == null)return null; else return pline; } set { pline = value; } }
        public double a, b, c;
        double alpha;
        PointF FirstPoint, EndPoint;
        const int K = 500; // шаг для получения x2 y2  
        Color color = Color.White;
        float pensize = 1;
        public PointF FPoint { get { return FirstPoint; } set { FirstPoint = value; } }
        public PointF EPoint { get { return EndPoint; } set { EndPoint = value; } }
        public double Alpha
        {
            get { return alpha; }
            set
            {
                alpha = value;
                EndPoint.X = this.FirstPoint.X + K * (float)Math.Cos(((Math.PI * alpha) / 180));
                EndPoint.Y = this.FirstPoint.Y + K * (float)Math.Sin(((Math.PI * alpha) / 180));
                ReCount();
            }
        }
        public Line(PointF FirstPoint, PointF EndPoint)
        {
            this.FirstPoint = FirstPoint;
            this.EndPoint = EndPoint;
            ReCount();
            alpha = -(Math.Atan(Convert.ToDouble(a / b))) * 180 / Math.PI;
        }
        private void ReCount()
        {
            a = FirstPoint.Y - EndPoint.Y;
            b = EndPoint.X - FirstPoint.X;
            c = FirstPoint.X * EndPoint.Y - EndPoint.X * FirstPoint.Y;
        }
        public void LineToInfinity(float max = 1000000)
        {
            EndPoint.X = this.FirstPoint.X + max * (float)Math.Cos(((Math.PI * alpha) / 180));
            EndPoint.Y = this.FirstPoint.Y + max * (float)Math.Sin(((Math.PI * alpha) / 180));
        }
        public void SetEndPoint(PointF EndPoint)
        {
            this.EndPoint = EndPoint; ReCount();
        }
        public Line(PointF FirstPoint, double alpha)
        {
            this.FirstPoint = FirstPoint;
            this.alpha = alpha;
            EndPoint.X = this.FirstPoint.X + K * (float)Math.Cos(((Math.PI * alpha) / 180));
            EndPoint.Y = this.FirstPoint.Y + K * (float)Math.Sin(((Math.PI * alpha) / 180));
            ReCount();
            
        }
        public float Pensize { get { return pensize; } set { pensize = value; } }
        public override Color Color { get { return color; } set { color = value; } }
        public override void Draw(PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(color, pensize), FirstPoint, EndPoint);
        }
        public CrossLine IsCross(Line line)
        {
            return CrossLine.Crossing(this.FirstPoint, this.EndPoint, line.FirstPoint, line.EndPoint);
        }
        static CrossLine IsCross(Line line1, Line line2)
        {
            return line1.IsCross(line2);
        }
     }
}
