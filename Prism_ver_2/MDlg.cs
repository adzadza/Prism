using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Sharp_Prism
{
    public partial class MDlg : Form
    {
        int Count = 0;
        public List<MovePoint> last;
        Button bt = new Button();
        Button btclose = new Button();
        const int groupboxsizeX = 300, groupboxsizeY = 60;
        public List<MovePoint> poitnlist;
        public List<MovePoint> PoitnList { get { Update(); return poitnlist; } set { poitnlist = value; UpdateControll(); } }
        private List<GroupBox> ControllList= new List<GroupBox>();
        private List<Control[]> controll = new List<Control[]>();
        public MDlg(List<MovePoint> pl,int min,string title)
        {
           this.Text = title;
            Count = min;
            last = pl;
            poitnlist = pl;
            btclose.Text = "Close";
            btclose.Width = 100;
            btclose.Click += Close_Click;
            bt.Text = "Add";
            bt.Width = 100;
            bt.Click += button1_Click;
            this.Controls.Add(bt);
            this.Controls.Add(btclose);
            this.DoubleBuffered = true;
            InitializeComponent();
            int i = 0;
            foreach (MovePoint p in poitnlist) { AddControll(i.ToString(), p, i); i++; }

            this.Height = i * groupboxsizeY + 75;
            bt.Left = 225 - bt.Width - 75;
            bt.Top = this.Height - bt.Height - 15;
            btclose.Left = 325 - btclose.Width - 75;
            btclose.Top = this.Height - btclose.Height - 15;
        }
        private void AddControll(string text, MovePoint point,int pos)
        {
            Control[] controll = new Control[4];
            GroupBox group = new GroupBox();
            group.Size = new System.Drawing.Size(groupboxsizeX, groupboxsizeY);
            group.Location = new System.Drawing.Point(12, 12 + groupboxsizeY * pos);
            group.TabIndex = 0;
            group.TabStop = false;
            NumericUpDown numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            NumericUpDown numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            CheckBox checkBox1 = new System.Windows.Forms.CheckBox();
            Label label1 = new System.Windows.Forms.Label();
            group.Controls.Add(label1);
            group.Controls.Add(checkBox1);
            group.Controls.Add(numericUpDown2);
            group.Controls.Add(numericUpDown1);

            checkBox1.AutoSize = true;
            checkBox1.Location = new System.Drawing.Point(224, 25);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new System.Drawing.Size(57, 17);
            checkBox1.TabIndex = 2;
            checkBox1.Text = "Delete";
            checkBox1.UseVisualStyleBackColor = true;

            numericUpDown2.Maximum = 100000;
            numericUpDown2.Location = new System.Drawing.Point(98, 36 );
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new System.Drawing.Size(120, 20);
            numericUpDown2.TabIndex = 1;
            numericUpDown2.Value =(decimal) point.X;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Maximum = 100000;
            numericUpDown1.Location = new System.Drawing.Point(98, 13 );
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new System.Drawing.Size(120, 20);
            numericUpDown1.TabIndex = 0;
            numericUpDown1.Value = (decimal)point.Y;


            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(6, 16 );
            label1.Name = pos.ToString();
            label1.Text = text;
            label1.Size = new System.Drawing.Size(0, 13);
            label1.TabIndex = 5;
            ControllList.Add(group);
            controll[0] = label1;
            controll[1] = checkBox1;
            controll[2] = numericUpDown1;
            controll[3] = numericUpDown2;
            this.controll.Add(controll);
            this.Controls.Add(group);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int i = ControllList.Count;
            AddControll(i.ToString(), new MovePoint(0,0,7), i);
            this.Height = (i+1) * groupboxsizeY + 75;
            bt.Left = 225 - bt.Width - 75;
            bt.Top = this.Height - bt.Height - 15;
            btclose.Left = 325 - btclose.Width - 75;
            btclose.Top = bt.Top;
        }
        private void Close_Click(object sender, EventArgs e)
        {
            switch (MessageBox.Show("Сохранить изменения  ",
                 "Свойства  Зеркала ",
                 MessageBoxButtons.YesNoCancel))
            {
                case System.Windows.Forms.DialogResult.Yes:
                     Update();
                     if (poitnlist.Count < Count)
                     {
                         MessageBox.Show("Ошибка\n В Обьекте  должно быть как минимум "+Count.ToString()+"точки","Ошибка");
                         poitnlist = last;
                         return;
                     }
                     DialogResult = DialogResult.OK;
                     return ;
                case System.Windows.Forms.DialogResult.No:
                     poitnlist= last;
                     DialogResult = DialogResult.OK;
                     return ;
                case System.Windows.Forms.DialogResult.Cancel:
                    return ;
            }
         }
        private void Update()
        {
            poitnlist.Clear();
            foreach (Control[] box in controll)
            {
                if ((box[1] as CheckBox).Checked) continue;
                else poitnlist.Add(new MovePoint((int)(box[2] as NumericUpDown).Value,(int)(box[3] as NumericUpDown).Value,7));
            }
        }
        private void UpdateControll()
        {
            this.Controls.Clear();
            int i = 0;
            foreach (MovePoint p in poitnlist) { AddControll(i.ToString(), p, i); i++; }
        }

        private void MDlg_Load(object sender, EventArgs e)
        {

        }

        private void MDlg_FormClosed(object sender, FormClosedEventArgs e)
        {
            poitnlist = last;
            DialogResult =  System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
