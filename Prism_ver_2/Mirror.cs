using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Sharp_Prism
{
    /// <summary>
    /// Класс Зеркала 
    /// Двусторонне отображение 
    /// Содержит Массив MovePoint 
    /// Можно двигать только через точки 
    /// Метод приемника света  Принимает  линию - Возвращает точки и угол пересечение 
    /// </summary>
    public class Mirror : CrossObject
    {
        float pensize = 1;
        public  int pointsize = 7;
        public float PenSize { get { return pensize; } set { pensize = value; } }
        System.Collections.Generic.List<Line> crosslines = new List<Line>();
        System.Collections.Generic.List<MovePoint> PointList = new List<MovePoint>();
        public System.Collections.Generic.List<MovePoint> Point { get { return PointList; } set { PointList = value; Update(); } }
        Color color = Color.Black;
        /// <summary>
        /// Создает Зеркало с нач координатами и count+1 вершин 
        /// </summary>
        /// <param name="x">X координата Точки создания </param>
        /// <param name="y">Y координата Точки создания </param>
        /// <param name="count">0 зеркало  как точка 
        /// 1 зеркало  как отрезок   
        /// </param>
        public Mirror(int x, int y, int count = 1)
        {
            PointList.Add(new MovePoint(x, y, pointsize));
            for (int i = 0; i < count; i++) Add();
        }
        public void SetPenPointSize(int pen, int point) { pointsize = point; pensize = pen; Update(); }
        public void Add()
        {
            this.Add(PointList.Last().X + 50, PointList.Last().Y + 50);
        }
        public void Add(int x, int y) { PointList.Add(new MovePoint(x, y, 7)); Update(); }
        public override Color Color { get { return color; } set { color = value; foreach (MovePoint point in PointList) point.Color = color; } }
        public override void Draw(PaintEventArgs e)
        {
            // Font drawFont = new Font("Arial", 16);
            // SolidBrush drawBrush = new SolidBrush(Color.Black);


            Point x = PointList[0].GetCenter();
            foreach (MovePoint point in PointList) point.Draw(e);
            foreach (Line l in crosslines)
            {
                //  e.Graphics.DrawString(l.Alpha.ToString(), drawFont, drawBrush, l.FPoint);
                l.Draw(e);
            }
        }
        public override void MoveBy(int xx, int yy)
        {
            foreach (MovePoint x in PointList) x.MoveBy(xx, yy);
        }
        public MoveObject IsInMirror(int x, int y)
        {
            foreach (MovePoint point in PointList) if (point.IsInPoint(x, y)) return point;
            return null;
        }
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append("<Mirror>\n");
            foreach (MovePoint p in PointList)
                str.Append("\n" + p.ToString()+";");
            str.Append("\n</Mirror>");
            return str.ToString();
        }
        public void FromString(string str)
        {
                    str = str.Replace("\n", string.Empty);
                    string [] split = str.Split(new Char [] {';'});
                    PointList.Clear();
                    foreach (string s in split) 
                    {
                        if (!s.Equals("</Mirror>"))
                        {
                            MovePoint p = new MovePoint(1, 10, pointsize); p.FromString(s);
                            PointList.Add(p);
                        }
                    }
        }
        public void Update()
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
        }
        /// <summary>
        /// Возвращает первую точку пересечения с зеркалом 
        /// !!!!!!!!! Точку которая первая пересекла зеркало !!!!!!!!!
        /// </summary>
        /// <param name="CrossLine"> линия для пересечения</param>
        /// <param name="x"> выходной параметр x координата пересечения</param>
        /// <param name="y">выходной параметр y координата пересечения</param>
        /// <param name="arc">выходной параметр угл пересечения</param>
        /// <returns>True если линии пересекаються </returns>
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
                    if (i == line.ntype) if (line.type == -1) continue;
                    
                    if (Math.Sqrt(Math.Pow(line.FPoint.X - crosspoint.x, 2) + Math.Pow(line.FPoint.Y - crosspoint.y, 2)) < (Math.Sqrt(Math.Pow(line.FPoint.X - Xmin, 2) + Math.Pow(line.FPoint.Y - Ymin, 2))))
                    {
                        CL = l; k = i; if (crosspoint.type == 2) k = -1;
                        Xmin = crosspoint.x; Ymin = crosspoint.y; ArcMin = (float)crosspoint.alpha; iscross = true;
                    }
                    
                }
            }
            
            if (!iscross) { rezx = 0; rezy = 0; rezarc = 0; crossline = null; n = 0; return false; }
            else { rezx = Xmin; rezy = Ymin; rezarc = ArcMin; crossline = CL; n = k; return true; }
        }
        public override System.Collections.Generic.List<Line> GetLineList()
        {
            Update();
            return crosslines;
        }
    }
}
