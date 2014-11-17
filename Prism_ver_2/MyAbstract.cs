using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Sharp_Prism
{
   public abstract class MyObject
    {
        public abstract Color Color { get; set; }
        public abstract void Draw(PaintEventArgs e);
    }
    public abstract class MoveObject : MyObject
    {
       
        public override abstract Color Color { get; set; }
        public override abstract void Draw(PaintEventArgs e);
        public abstract void MoveBy(int xx, int yy);
    }
   public abstract class CrossObject : MoveObject
    {
        public override abstract Color Color { get; set; }
        public override abstract void Draw(PaintEventArgs e);
        public override abstract void MoveBy(int xx, int yy);
        public abstract bool IsCross(Line CrossLine, out float rezx, out float rezy, out float rezarc, out Line crossline, out int n);
        public abstract System.Collections.Generic.List<Line> GetLineList();
    }
    public class CrossLine
    {
        public float x;
        public float y;
        public double alpha;
        public int type;
        /* enum enumCrossType
          {
              ctParallel=0,    // отрезки лежат на параллельных прямых
              ctSameLine = 1,    // отрезки лежат на одной прямой
              ctOnBounds = 2,    // прямые пересекаются в конечных точках отрезков
              ctInBounds = 3,   // прямые пересекаются в   пределах отрезков
              ctOutBounds =4    // прямые пересекаются вне пределов отрезков
          };
         */
        static public CrossLine Crossing(
         PointF p11, PointF p12,   // координаты первого отрезка
         PointF p21, PointF p22)  // координаты второго отрезка
        {
            CrossLine result = new CrossLine();
            result.alpha = (Math.Atan((p12.Y - p11.Y) / (p12.X - p11.X)) - Math.Atan((p22.Y - p21.Y) / (p22.X - p21.X))) * (180 / Math.PI);
            // знаменатель
            float Z = (p12.Y - p11.Y) * (p21.X - p22.X) - (p21.Y - p22.Y) * (p12.X - p11.X);
            // числитель 1
            float Ca = (p12.Y - p11.Y) * (p21.X - p11.X) - (p21.Y - p11.Y) * (p12.X - p11.X);
            // числитель 2
            float Cb = (p21.Y - p11.Y) * (p21.X - p22.X) - (p21.Y - p22.Y) * (p21.X - p11.X);
            // если числители и знаменатель = 0, прямые совпадают
            if ((Z == 0) && (Ca == 0) && (Cb == 0))
            {
                result.type = 1;
                return result;
            }
            // если знаменатель = 0, прямые параллельны
            if (Z == 0)
            {
                result.type = 0;
                return result;
            }
            float Ua = Ca / Z;
            float Ub = Cb / Z;
            result.x = p11.X + (p12.X - p11.X) * Ub;
            result.y = p11.Y + (p12.Y - p11.Y) * Ub;
            // если 0<=Ua<=1 и 0<=Ub<=1, точка пересечения в пределах отрезков
            if ((0 <= Ua) && (Ua <= 1) && (0 <= Ub) && (Ub <= 1))
            {
                if ((Ua == 0) || (Ua == 1) || (Ub == 0) || (Ub == 1)) result.type = 2; else result.type = 3;
            }
            // иначе точка пересечения за пределами отрезков
            else
            {
                result.type = 4;
            }
            return result;
        }

        private static CrossLine Crossing(PointF p11, int p, PointF p21, PointF p22)
        {
            throw new NotImplementedException();
        }
    }
}
