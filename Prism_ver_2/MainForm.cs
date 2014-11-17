using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sharp_Prism;
using System.Drawing.Drawing2D;
using System.IO;


namespace Sharp_Prism
{
    public partial class MainForm : Form
    {
        int lpx, lpy;
        MoveObject mobject;
        MainPrism MainPrissm = new MainPrism();
        public MainForm()
        {

            InitializeComponent();
            this.DoubleBuffered = true;
            MainPrissm.Resize(ClientRectangle);
            pictureBox1.BackColor = Color.Black;

        }
        private void MPDown(object sender, MouseEventArgs e)
        {
            string str;
            mobject = MainPrissm.ReturnObjectActive(e.X, e.Y, out str);
            lpx = e.X; lpy = e.Y;
            this.toolStripStatusLabel1.Text = str;
            if (e.Button == MouseButtons.Right)
            {
                mobject = null;
                if(str.Equals("Prism"))
                {
                    PrismContextMenu.Show(pictureBox1,e.X,e.Y);
                }
                if (str.Equals("Mirror"))
                {
                    MirrorContextMenu.Show(pictureBox1, e.X, e.Y);
                }
                if (str.Equals("Light"))
                {
                    LightcontextMenu.Show(pictureBox1, e.X, e.Y);
                }
            }
        }

        private void MPMove(object sender, MouseEventArgs e)
        {
            if (mobject != null)
            {
                if (e.Y < ClientRectangle.Height && e.X < ClientRectangle.Width && e.X > 0 && e.Y > 0)
                    mobject.MoveBy(e.X - lpx, e.Y - lpy);
                lpx = e.X; lpy = e.Y;
                this.pictureBox1.Invalidate();
            }
        }

        private void MPUp(object sender, MouseEventArgs e)
        {            
            mobject = null;
            this.toolStripStatusLabel1.Text = "Nothing";
        }

        private void MPResize(object sender, EventArgs e)
        {
            MainPrissm.Resize(ClientRectangle);
             this.pictureBox1.Invalidate();
        }

        private void MyPaint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            MainPrissm.Draw(e);
        }


        private void настройкиЦветаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PenPointSize ppdlg = new PenPointSize("Призма");
            ppdlg.PenSize = 7; ppdlg.PointSize = 7;
            switch (ppdlg.ShowDialog())
            {
                case DialogResult.OK:
                    MainPrissm.SetPrismStyle(ppdlg.PenSize, ppdlg.PointSize);
                    this.pictureBox1.Invalidate();
                    break;
                case DialogResult.Cancel:
                    break;
            }
        }

        private void настройкиСтиляToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // для зеркала 
            PenPointSize ppdlg = new PenPointSize("Зеркало ");
            ppdlg.PenSize = 7; ppdlg.PointSize = 7;
            switch (ppdlg.ShowDialog())
            {
                case DialogResult.OK:
                    MainPrissm.SetMirrorStyle(ppdlg.PenSize, ppdlg.PointSize);
                    this.pictureBox1.Invalidate();
                    break;
                case DialogResult.Cancel:
                    break;
            }
            this.pictureBox1.Invalidate();
        }

        private void настройкиТочекToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MDlg dlg = new MDlg(MainPrissm.GetMirrorPoint(), 2, "Зеркало");
            switch(dlg.ShowDialog())
            {
                  case System.Windows.Forms.DialogResult.OK:
                    MainPrissm.SetMirrorPoint(dlg.poitnlist);
                    this.pictureBox1.Invalidate();

                    break;
                case DialogResult.Cancel:
                    break;

            }
            this.pictureBox1.Invalidate();
        }

        private void настройкиТочекToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MDlg dlg = new MDlg(MainPrissm.GetPrismPoint(), 3, "Призма");

            switch(dlg.ShowDialog())
            {
                  case System.Windows.Forms.DialogResult.OK:
                    MainPrissm.SetPrismPoint(dlg.poitnlist);
                    this.pictureBox1.Invalidate();
                    break;
                case DialogResult.Cancel:
                    break;

            }
        }

        private void настройкиИсточнакиСветаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PenPointSize ppdlg = new PenPointSize("Свет","Интенсивность","Ширина точек");
            ppdlg.PenSize = 7; ppdlg.PointSize = 7;
            switch (ppdlg.ShowDialog())
            {
                case DialogResult.OK:
                    MainPrissm.SetLightStyle(20-ppdlg.PenSize, ppdlg.PointSize);
                    this.pictureBox1.Invalidate();
                    break;
                case DialogResult.Cancel:
                    break;
            }
        }



        private void сохранитьЧерчежToolStripMenuItem_Click(object sender, EventArgs e)
        {
             SaveFileDialog fdl = new SaveFileDialog();
            fdl.Filter = "Text files (*.txt)|*.txt|MainPrismInfo files (*.mpi)|*.mpi";
            if (fdl.ShowDialog() == DialogResult.OK)
            {
                StreamWriter fs = new StreamWriter(fdl.FileName);
                fs.Write(MainPrissm.ToString());
                pictureBox1.Invalidate();
                fs.Close();
            }
        }

        private void загрузитьЧертежToolStripMenuItem_Click(object sender, EventArgs e)
        {
                 OpenFileDialog ofd = new OpenFileDialog();
               ofd.Filter = "Text files (*.txt)|*.txt| MainPrismInfo files (*.mpi)|*.mpi";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        StreamReader fs = new StreamReader(ofd.FileName);
                        MainPrissm.FromString(fs.ReadToEnd());
                        pictureBox1.Invalidate();
                        fs.Close();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Не удалось загрузить черчеж");
                    }
                }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void настройкиПроектаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PS psd = new PS();
            switch (psd.ShowDialog())
            {
                case DialogResult.OK:
                    MainPrissm.ErrorColor = psd.ErrColor;
                    MainPrissm.NormalColor = psd.NormColor;
                    MainPrissm.Update();
                    this.pictureBox1.Invalidate();
                    break;
                case DialogResult.Cancel:
                    break;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" Богданов Н.Г Призма Lab 30. ", "Info");
        }


     }
}
