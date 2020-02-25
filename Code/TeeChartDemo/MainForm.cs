using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TeeChartDemo
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnXYLineImage_Click(object sender, EventArgs e)
        {
            new D1().ShowDialog();
        }

        private void btnXYLineImage2_Click(object sender, EventArgs e)
        {
            new D2().ShowDialog();
        }
    }
}
