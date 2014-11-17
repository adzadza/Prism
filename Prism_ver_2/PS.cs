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
    public partial class PS : Form
    {
        public PS()
        {
            InitializeComponent();
            this.panel2.BackColor = Color.Yellow;
            this.panel3.BackColor = Color.Red;
        }
        public Color ErrColor { get { return panel3.BackColor; } set { } }
        public Color NormColor { get { return panel2.BackColor; } set { } }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }


        private void button7_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void Clic1(object sender, EventArgs e)
        {
            ColorDialog cld = new ColorDialog();
            switch (cld.ShowDialog())
            {
                case
                DialogResult.OK:
                    panel3.BackColor = cld.Color;
                    panel3.Invalidate();
                    break;
            }
        }

        private void clic_2(object sender, EventArgs e)
        {
            ColorDialog cld = new ColorDialog();
            switch (cld.ShowDialog())
            {
                case
                DialogResult.OK:
                    panel2.BackColor = cld.Color;
                    panel2.Invalidate();
                    break;
            }
        }

    }
}
