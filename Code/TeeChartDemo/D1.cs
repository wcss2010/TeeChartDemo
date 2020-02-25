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
    public partial class D1 : Form
    {
        public D1()
        {
            InitializeComponent();
        }

        private void D1_Load(object sender, EventArgs e)
        {
            this.tChart1.Series.Clear();
            this.tChart1.Header.Text = "霸道测试";
            this.tChart1.Axes.Bottom.Title.Text = "测试X";  //设置X轴标题
            this.tChart1.Axes.Left.Title.Text = "测试Y";//设置Y轴标题
            this.tChart1.AutoRepaint = true;
            this.tChart1.Aspect.View3D = true;//是否立体显示
            fastLine1 = new Steema.TeeChart.Styles.FastLine();
            this.tChart1.Series.Add(fastLine1);
            double[] yValues = { 10, 15, 20, 2, 23, 63, 33, 1, 33, 77, 94, 65, 45, 23, 32, 4, 54, 2, 18, 21, 80, 67, 45, 32, 3, 10, 56, 13, 52, 23, 72, 66, 32, 54, 74, 21, 86, 15 };
            fastLine1.Add(yValues);

            // Set some nulls - optional demo
            //      fastLine1.SetNull( 13 );
            //      fastLine1.SetNull( 25 );
            //      fastLine1.SetNull( 40 );

            //      fastLine1.IgnoreNulls = true;
            fastLine1.Stairs = true;
        }
    }
}
