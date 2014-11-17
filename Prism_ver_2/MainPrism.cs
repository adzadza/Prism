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
    /// Класс Призмы 
    /// Содержит Источник света 
    /// Нижний приемник 
    /// Призму 
    /// Зеркало 
    /// Массив линий 
    /// </summary>
    class MainPrism : MyObject
    {
        bool IsCross = false;
        Light light;
        Mirror mirror;
        Prism prism;
        Line right;
        LightDetector lightdetector;
        /// <summary>
        /// Лист линий в который добаляеться линии из источника света и
        /// новосгенерированные, в результате пересечения с призмой или зеркалом , линии 
        /// </summary>
        List<Line> Lines = new List<Line>();
        public Color ErrorColor = Color.Red, NormalColor = Color.Yellow;
        Color color = Color.Yellow, linescolor = Color.White;
        private void UpdateByColor()
        {
            light.Color = color;
            light.LineColor = linescolor;
            mirror.Color = color;
            prism.Color = color;
        }
        public override Color Color { get { return color; } set { color = value; } }
        public Color LinesColor { get { return linescolor; } set { linescolor = value; } }
        public string Info()
        {
            if (FromString(this.ToString())) MessageBox.Show("Загруженно ");
            StringBuilder str = new StringBuilder();
            foreach (Line l in Lines)
            {
                str.Append(l.FPoint.ToString() + l.EPoint.ToString() + l.Alpha.ToString() + "\n");
            } return str.ToString();
        }
        public override void Draw(PaintEventArgs e)
        {
            Update();
            light.Draw(e);
            mirror.Draw(e);
            prism.Draw(e);
            lightdetector.Draw(e);
            if (!IsCross) foreach (Line line in Lines)
            {
                    line.Draw(e);
            }

        }
        public List<Line> ReCount(System.Collections.Generic.List<Line> soureline)
        {
            if (IsCross) return null;
            System.Collections.Generic.List<Line> newline = new List<Line>();
            float xm, ym, am; // для зеркала 
            float xp, yp, ap;// для призмы 
            float xd, yd, ad; // для приемника света 
            Line crossline;
            short type = 0;
            double length = 1111110;
            int ntype;
            foreach (Line linefromlight in soureline)
            {
                ntype = -1;
                length = 1111110;
                type = 0;
                int n = 0;
                if (lightdetector.IsCross(linefromlight, out xd, out yd, out ad, out  crossline, out n))
                { // проверка растояния для до приемника  
                    if (Math.Sqrt(Math.Pow(linefromlight.FPoint.X - xd, 2) + Math.Pow(linefromlight.FPoint.Y - yd, 2)) < length)
                    {
                        length = Math.Sqrt(Math.Pow(linefromlight.FPoint.X - xd, 2) + Math.Pow(linefromlight.FPoint.Y - yd, 2));
                        type = 3; ntype = n;
                    }
                }
                if (prism.IsCross(linefromlight, out xp, out yp, out ap, out  crossline, out n))
                { // проверка растояния для до приемника  
                    if (Math.Sqrt(Math.Pow(linefromlight.FPoint.X - xp, 2) + Math.Pow(linefromlight.FPoint.Y - yp, 2)) < length)
                    {
                        length = Math.Sqrt(Math.Pow(linefromlight.FPoint.X - xp, 2) + Math.Pow(linefromlight.FPoint.Y - yp, 2));
                        type = 2; ntype = n;
                    }
                }

                if (mirror.IsCross(linefromlight, out xm, out ym, out am, out  crossline, out n))
                { // проверка растояния для до приемника зеркала 
                    if (Math.Sqrt(Math.Pow(linefromlight.FPoint.X - xm, 2) + Math.Pow(linefromlight.FPoint.Y - ym, 2)) < length)
                    {
                        length = Math.Sqrt(Math.Pow(linefromlight.FPoint.X - xm, 2) + Math.Pow(linefromlight.FPoint.Y - ym, 2));
                        type = 1; ntype = n;
                    }
                }
                // аналогично для призмы и приемника
                switch (type)
                {
                    case 0:
                        break;
                    case 1:
                        linefromlight.SetEndPoint(new PointF(xm, ym));
                        if (n != -1)
                        {
                            
                            newline.Add(new Line(new PointF(xm, ym), linefromlight.Alpha - 2 * am));
                            newline.Last().LineToInfinity();
                            newline.Last().Color = linefromlight.Color;
                            newline.Last().ParentLine = crossline;
                            newline.Last().type = -1;
                            newline.Last().ntype = ntype;
                        }
                        break;
                    case 2:
                           linefromlight.SetEndPoint(new PointF(xp, yp));
                            if (ntype != -1)
                            {
                                //  newline.Add(new Line(new PointF(xp, yp), linefromlight.Alpha - 2 * ap - 180));
                                Line line = new Line(new PointF(xp, yp),linefromlight.Alpha);
                                line.Alpha -= Math.Asin((Math.Sin((linefromlight.Alpha - 2 * ap) * Math.PI / 180) * prism.NAir) / prism.NPrism) * 180 / Math.PI / prism.NPrism; 
                                line.LineToInfinity();
                                line.Color = linefromlight.Color;
                                line.ParentLine = crossline;
                                line.type = 2;
                                line.ntype = ntype;
                                if (linefromlight.type == 2)
                                {
                                    if (line.Color == Color.Green) line.Alpha += ap/100;
                                    if (line.Color == Color.Blue) line.Alpha -= ap/100;
                                    line.LineToInfinity();
                                }
                                if (line.Color == Color.White)
                                {
                                    line.Color = Color.Red;
                                    newline.Add(new Line(new PointF(xp, yp), linefromlight.Alpha));
                                    newline.Last().Alpha -= Math.Asin((Math.Sin((linefromlight.Alpha - 2 * ap - 2) * Math.PI / 180) * prism.NAir) / prism.NPrism) * 180 / Math.PI / prism.NPrism; 
                                    newline.Last().LineToInfinity();
                                    newline.Last().Color = Color.Green;
                                    newline.Last().ParentLine = crossline;
                                    newline.Last().type = 2;
                                    newline.Last().ntype = ntype;
                                    newline.Add(new Line(new PointF(xp, yp), linefromlight.Alpha));
                                    newline.Last().Alpha -=  Math.Asin((Math.Sin((linefromlight.Alpha - 2 * ap + 2) * Math.PI / 180) * prism.NAir) / prism.NPrism) * 180 / Math.PI / prism.NPrism;
                                    newline.Last().LineToInfinity();
                                    newline.Last().Color = Color.Blue;
                                    newline.Last().ParentLine = crossline;
                                    newline.Last().type = 2;
                                    newline.Last().ntype = ntype;
                                }
                                newline.Add(line);
                            }  
                        
                        break;
                    case 3:
                        linefromlight.SetEndPoint(new PointF(xd, yd));
                        lightdetector.AddDetectLine(new PointF(xd, yd), linefromlight.Color);
                        break;
                }
            }
            return newline;
        }
        private void UpdateReCount(System.Collections.Generic.List<Line> line)
        {
            int i = 0;
            while (line.Count != 0)
            {
                i++;
                if (i > 100000) return;
                line = ReCount(line);
                Lines.AddRange(line.ToArray());
            }
        }
        public void Update()
        {
            UpdateByCross();
            lightdetector.Update();
            mirror.Update();
            Lines.Clear();
            lightdetector.Update();
            if (IsCross) return;
            Lines.AddRange(light.GetLinesFromLight().ToList());
            UpdateReCount(Lines);
        }
        /// <summary>
        /// Проверяет c какой стороный находиться точка 
        /// если с разных сторон то 0
        /// если с одной :
        /// 1 - слева
        /// -1 справа
        /// </summary>
        /// <param name="l1">Линия 1</param>
        /// <param name="l2">Линия 2</param>
        /// <param name="p">Точка</param>
        /// <returns>    
        ///  1 - слева
        /// -1 справа
        ///  0 c разных
        /// </returns>
        private int PointByCross(Line l1, Line l2, PointF p)
        {
            float pbl1 = PointNearLine(l1.FPoint, l1.EPoint, p);
            float pbl2 = PointNearLine(l2.FPoint, l2.EPoint, p);
            if (pbl1 > 0 && pbl2 > 0) return 1;
            else if (pbl1 < 0 && pbl2 < 0) return -1;
            if (pbl1 * pbl2 < 0) return 1;
            else return -1;

        }
        /// <summary>
        /// Определение положения точки относительно прямой
        /// </summary>
        /// <param name="line_point1">первая точка задающая линию</param>
        /// <param name="line_point2">вторая точка задающая линию</param>
        /// <param name="testPoint">
        /// точка, положение которой необходимо узнать
        /// </param>
        /// <returns>
        ///  1 - точка слева от прямой
        ///  0 - точка принадлежит прямой
        /// -1 - точка справа от прямой
        /// </returns>
        static public float PointNearLine(PointF line_point1,
                                PointF line_point2,
                                PointF testPoint)
        {
            float tmp = (line_point2.X - line_point1.X) * (testPoint.Y - line_point1.Y) -
                      (line_point2.Y - line_point1.Y) * (testPoint.X - line_point1.X);

            if (tmp > 0)
                return 1;
            else
                if (tmp < 0)
                    return -1;
                else
                    return 0;
        }
        public MainPrism()
        {
            /*
            left = new Line(new PointF(0, 0), new PointF(0, 100)); left.Pensize = 10;
            bottom = new Line(new PointF(0, 100), new PointF(100, 100)); bottom.Pensize = 10;
            right = new Line(new PointF(100, 0), new PointF(100, 100)); right.Pensize = 10;
            top = new Line(new PointF(0, 0), new PointF(100, 0)); top.Pensize = 10;
            */
            right = new Line(new PointF(100, 0), new PointF(100, 100));
            lightdetector = new LightDetector(90, 0, 0);
            prism = new Prism(100, 100);
            light = new Light(100, 150, 10, 9); // добавления источника цвета 
            mirror = new Mirror(100, 100, 3);
            mirror.PenSize = 4;
            prism.PenSize = 4;
            UpdateByColor();
        }
        /// <summary>
        /// Возвращает тот обьект, на который указывает точка с координатами X Y 
        /// </summary>
        /// <param name="x">x координата точки  </param>
        /// <param name="y">y координата точки</param>
        /// <returns></returns>
        public MoveObject ReturnObjectActive(int x, int y, out string ActiveObject)
        {
            MoveObject PrismObjext = prism.IsInPrism(x, y);
            if (PrismObjext != null) { ActiveObject = "Prism"; return PrismObjext; }
            MoveObject LightObject = light.IsInLight(x, y);
            if (LightObject != null) { ActiveObject = "Light"; return LightObject; }
            MoveObject MirrorObject = mirror.IsInMirror(x, y);
            if (MirrorObject != null) { ActiveObject = "Mirror"; return MirrorObject; }
            ActiveObject = "Nothing"; return null;
        }
        public void Resize(Rectangle rect)
        {
            right.FPoint = new PointF(rect.Width, 0);
            right.EPoint = new PointF(rect.Width, rect.Height - lightdetector.BarSize);
            lightdetector.Resize(rect);
        }
        public void UpdateByCross()
        {
            System.Collections.Generic.List<Line> detectline = new List<Line>();
            detectline.AddRange(mirror.GetLineList().ToArray());
            detectline.AddRange(prism.GetLineList().ToArray());
            detectline.AddRange(lightdetector.GetLineList().ToArray());
            detectline.Add(right);
            foreach (Line l1 in detectline)
            {
                foreach (Line l2 in detectline)
                {
                    if (l1.IsCross(l2).type == 3) { IsCross = true; color = ErrorColor; UpdateByColor(); return; }
                }
            }
            IsCross = false; color = NormalColor; UpdateByColor();
        }
        public System.Collections.Generic.List<MovePoint> GetMirrorPoint() { return mirror.Point; }
        public System.Collections.Generic.List<MovePoint> GetPrismPoint() { return prism.Point; }
        public void SetPrismPoint(System.Collections.Generic.List<MovePoint> point) { prism.Point = point; }
        public void SetMirrorPoint(System.Collections.Generic.List<MovePoint> point) { mirror.Point = point; }
        private Color getColorFromWaveLength(int Wavelength)
        {
            double Gamma = 1.00;
            int IntensityMax = 255;
            double Blue;
            double Green;
            double Red;
            double Factor;

            if (Wavelength >= 350 && Wavelength <= 439)
            {
                Red = -(Wavelength - 440d) / (440d - 350d);
                Green = 0.0;
                Blue = 1.0;
            }
            else if (Wavelength >= 440 && Wavelength <= 489)
            {
                Red = 0.0;
                Green = (Wavelength - 440d) / (490d - 440d);
                Blue = 1.0;
            }
            else if (Wavelength >= 490 && Wavelength <= 509)
            {
                Red = 0.0;
                Green = 1.0;
                Blue = -(Wavelength - 510d) / (510d - 490d);

            }
            else if (Wavelength >= 510 && Wavelength <= 579)
            {
                Red = (Wavelength - 510d) / (580d - 510d);
                Green = 1.0;
                Blue = 0.0;
            }
            else if (Wavelength >= 580 && Wavelength <= 644)
            {
                Red = 1.0;
                Green = -(Wavelength - 645d) / (645d - 580d);
                Blue = 0.0;
            }
            else if (Wavelength >= 645 && Wavelength <= 780)
            {
                Red = 1.0;
                Green = 0.0;
                Blue = 0.0;
            }
            else
            {
                Red = 0.0;
                Green = 0.0;
                Blue = 0.0;
            }
            if (Wavelength >= 350 && Wavelength <= 419)
            {
                Factor = 0.3 + 0.7 * (Wavelength - 350d) / (420d - 350d);
            }
            else if (Wavelength >= 420 && Wavelength <= 700)
            {
                Factor = 1.0;
            }
            else if (Wavelength >= 701 && Wavelength <= 780)
            {
                Factor = 0.3 + 0.7 * (780d - Wavelength) / (780d - 700d);
            }
            else
            {
                Factor = 0.0;
            }

            int R = this.factorAdjust(Red, Factor, IntensityMax, Gamma);
            int G = this.factorAdjust(Green, Factor, IntensityMax, Gamma);
            int B = this.factorAdjust(Blue, Factor, IntensityMax, Gamma);

            return Color.FromArgb(R, G, B);
        }
        private int factorAdjust(double Color, double Factor, int IntensityMax,double Gamma)
        {
           if (Color == 0.0)
          {
                return 0;
          }
          else
          {
                return (int)Math.Round(IntensityMax * Math.Pow(Color * Factor, Gamma));
          }
        }
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append("<MainPrism>\n");
            str.Append(prism.ToString()+"\n");
            str.Append(light.ToString() + "\n");
            str.Append(mirror.ToString() + "\n");
            str.Append("\n</MainPrism>");
            return str.ToString();
        }
        public bool FromString(string str)
        {
            try
            {
                if (str.IndexOf("</MainPrism>") == -1) return false;
                if (str.IndexOf("<MainPrism>") == -1) return false;
                if (str.IndexOf("</Mirror>") == -1) return false;
                if (str.IndexOf("<Mirror>") == -1) return false;
                if (str.IndexOf("</Light>") == -1) return false;
                if (str.IndexOf("<Light>") == -1) return false;
                if (str.IndexOf("</Prism>") == -1) return false;
                if (str.IndexOf("<Prism>") == -1) return false;
                mirror.FromString(str.Substring(str.IndexOf("<Mirror>"), str.IndexOf("</Mirror>") - str.IndexOf("<Mirror>")) + "</Mirror>");
                light.FromString(str.Substring(str.IndexOf("<Light>"), str.IndexOf("</Light>") - str.IndexOf("<Light>")) + "</Light>");
                prism.FromString(str.Substring(str.IndexOf("<Prism>"), str.IndexOf("</Prism>") - str.IndexOf("<Prism>")) + "</Prism>");
                return true;
            }
            catch (Exception )
            {
                MessageBox.Show("Ошибка синтаксиса");
                return false;
            }
       }
        public void SetPrismStyle(int pen, int point){prism.SetPenPointSize(pen,point);}
        public void SetMirrorStyle(int pen, int point) { mirror.SetPenPointSize(pen, point); }
        public void SetLightStyle(int pen, int point) { light.FrequencyOfTheLight = pen+1; light.PointSize = point; }
    }
}
