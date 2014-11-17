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
    public partial class PenPointSize : Form
    {
        public int PenSize { get { return (int)numericUpDown1.Value; } set{} }
        public int PointSize { get { return (int)numericUpDown2.Value; } set{} }
        public PenPointSize(string title)
        {
            InitializeComponent();
            this.Text = title;
        }
        public PenPointSize(string title,string lb1,string lb2)
        {
            InitializeComponent();
            this.label1.Text = lb1;
            this.label2.Text = lb2;
            this.Text = title;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
