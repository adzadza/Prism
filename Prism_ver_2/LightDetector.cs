using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Sharp_Prism
{
    class DetectLine:MyObject
    {
        PointF pos;
        Color color;
        int height;
        int size=2;
        public DetectLine(PointF p, int height, int size = 5) { pos = p; this.height = height; this.size = size; }
        public override Color Color { get { return color; } set { color = value; } }
        public override void Draw(PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(color, size), pos, new PointF(pos.X, pos.Y + height));
        }
    }
    class LightDetector:CrossObject
    {
        int barsize = 10;
        int height; // высота от 0 x
        int width; // ширина от 0 y 
        Line line;
        Color color = Color.LightGray;
        System.Collections.Generic.List<DetectLine> detectlines = new List<DetectLine>();
        public void AddDetectLine(PointF p,Color color)
        {
            detectlines.Add(new DetectLine(p,barsize));
            detectlines.Last().Color = color;
        }
        public override Color Color { get { return color; } set { color = value; } }
        public LightDetector(int barsize , int height, int width)
        {
            this.barsize = barsize;
            this.height = height;
            this.width = width;
            Update();
        }
        public int BarSize { get { return barsize; } set { barsize = value; } }
        public void Resize(Rectangle rect)
        {
            width = rect.Width;
            height = rect.Height - barsize;
            Update();
        }
        public void Update()
        {
            detectlines.Clear();
            line = null;
            line = new Line(new PointF(0, height), new PointF(width, height));
            line.Color = color;
            line.Pensize = 5;
        }
        public override bool IsCross(Line line, out float rezx, out float rezy, out float rezarc, out Line crossline, out int n)
        {
            CrossLine cr = this.line.IsCross(line);
            if (cr.type == 3 || cr.type == 2)
            {
                rezx = cr.x; rezy = cr.y; rezarc = (float)cr.alpha; crossline = this.line; n = 0; return true;
            }
            else { rezx = 0; rezy = 0; rezarc = 0; crossline = null; n = 0; return false; }
        }
        public override void MoveBy(int xx, int yy){}
        public override void Draw(PaintEventArgs e)
        {
            line.Draw(e);
            foreach (DetectLine l in detectlines) l.Draw(e);
        }
        public override System.Collections.Generic.List<Line> GetLineList()
        {
            System.Collections.Generic.List<Line> L = new List<Line>();
            L.Add(line);
            return L;
        }
    }
}
