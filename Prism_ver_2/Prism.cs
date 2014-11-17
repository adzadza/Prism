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
    /// Класс реализуюший отображения призмы  
    /// </summary>
     public class Prism : CrossObject
     {
         float pensize = 1;
         public int pointsize=7;
         public double NPrism = 1.333;
         public double NAir = 1.000292;
         public override Color Color { get { return color; } set { color = value; foreach (MovePoint point in PointList) point.Color = color; } }
         public float PenSize { get { return pensize; } set { pensize = value; } }
         List<MovePoint> PointList = new List<MovePoint>();
         List<Line> crosslines = new List<Line>();
         public List<MovePoint> Point { get { return PointList; } set { PointList = value; Update(); } }
         Color color = Color.Black;
         public override void Draw(PaintEventArgs e)
         {
             Update();
             Point x = PointList[0].GetCenter();
             foreach (MovePoint point in PointList) point.Draw(e);
             foreach (Line l in crosslines)
             {
                 l.Draw(e);
             }
         }
         public void Add()
         {
             Random rand = new Random(PointList.Last().X + PointList.Last().Y);
             this.Add(PointList[0].X + rand.Next(-50, 100), PointList[0].Y + rand.Next(-100, 100));
         }
         public MoveObject IsInPrism(int x,int y)
         {
            foreach (MovePoint point in PointList) if (point.IsInPoint(x, y)) return point;
            try
            {
                Point[] rez = new Point[PointList.Count];
                int i = 0;
                foreach (MovePoint Mpoint in PointList) rez[i++] = Mpoint.GetCenter();
                GraphicsPath pologon = new GraphicsPath();
                pologon.AddPolygon(rez);
                if (pologon.IsVisible(x, y)) return this;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message); return null;
            }
             return null;
         }
         public override void MoveBy(int xx, int yy)
         {
             foreach (MovePoint x in PointList) x.MoveBy(xx, yy);
         }
         public void Add(int x, int y) { PointList.Add(new MovePoint(x, y, pointsize)); Update(); }
         public override bool IsCross(Line line, out float rezx, out float rezy, out float rezarc, out Line crossline, out int n)
         {
             bool iscross = false;
             float Xmin = 131301111, Ymin = 3131011111, ArcMin = 3131310111;
             Line CL = null; int i = 0;
             int k = 0;
             foreach (Line l in crosslines)
             {
                 i++;
                 CrossLine crosspoint = line.IsCross(l);
                 if (crosspoint.type==2||crosspoint.type == 3)
                 {                   
                     if (i == line.ntype) if (line.type == 2) continue;
                     if (Math.Sqrt(Math.Pow(line.FPoint.X - crosspoint.x, 2) + Math.Pow(line.FPoint.Y - crosspoint.y, 2)) < (Math.Sqrt(Math.Pow(line.FPoint.X - Xmin, 2) + Math.Pow(line.FPoint.Y - Ymin, 2))))
                     {
                         CL = l; k = i;
                         Xmin = crosspoint.x; Ymin = crosspoint.y; ArcMin = (float)crosspoint.alpha; iscross = true;
                     }
                     if (crosspoint.type == 2) k = -1;
                 }
             }
             if (!iscross) { rezx = 0; rezy = 0; rezarc = 0; crossline = null; n = 0; return false; }
             else { rezx = Xmin; rezy = Ymin; rezarc = ArcMin; crossline = CL; n = k; return true; }
         }
         public void SetPenPointSize(int pen, int point) { pointsize = point; pensize = pen; Update(); }
         private void Update()
         {
             foreach (MovePoint p in PointList) p.Size = pointsize;
             crosslines.Clear();
             for (int i = 1; i < PointList.Count; i++)
             {
                 crosslines.Add(new Line(new PointF(PointList[i - 1].GetCenter().X, PointList[i - 1].GetCenter().Y), new PointF(PointList[i].GetCenter().X, PointList[i].GetCenter().Y)));
                 crosslines.Last().SetEndPoint(new PointF(PointList[i].GetCenter().X, PointList[i].GetCenter().Y));
                 crosslines.Last().Color = color;
                 crosslines.Last().Pensize = pensize;
             }
             crosslines.Add(new Line(new PointF(PointList[0].GetCenter().X, PointList[0].GetCenter().Y), new PointF(PointList.Last().GetCenter().X, PointList.Last().GetCenter().Y)));
             crosslines.Last().Color = color;
             crosslines.Last().Pensize = pensize;
         }
         /// <summary>
         /// Создает призму с началокой точкой x,y и две точке около 
         /// </summary>
         /// <param name="x"></param>
         /// <param name="y"></param>
         /// <param name="k"> сколько еще точек помимо 3х основных</param>
         public Prism(int x, int y, int k = 0)
         {
             PointList.Add(new MovePoint(x, y, pointsize));
             for (int i = 0; i < 2+k; i++) Add();
         }
         public override System.Collections.Generic.List<Line> GetLineList()
         {
             Update();
             return crosslines;
         }
         public override string ToString()
         {
             StringBuilder str = new StringBuilder();
             str.Append("<Prism>");
             foreach (MovePoint p in PointList)
                 str.Append("\n" + p.ToString() + ";");
             str.Append("\n</Prism>");
             return str.ToString();
         }
         public void FromString(string str)
         {
             str = str.Replace("\n", string.Empty);
             // MessageBox.Show(str);
             string[] split = str.Split(new Char[] { ';' });
             PointList.Clear();
             foreach (string s in split)
             {
                 if (!s.Equals("</Prism>"))
                 {
                     MovePoint p = new MovePoint(1, 10, pointsize); p.FromString(s);
                     PointList.Add(p);
                 }
             }
         }
     }
 }
