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
    public partial class D2 : Form
    {
        public D2()
        {
            InitializeComponent();
        }

        private void D2_Load(object sender, EventArgs e)
        {
            this.tChart1.Header.Text = "霸道测试";
            this.tChart1.Series.Add(fastLine1);
            fastLine1.Add(DateTime.Now.ToOADate(), 1000);

            fastLine1.GetVertAxis.SetMinMax(0, 1500);
            fastLine1.GetHorizAxis.SetMinMax(DateTime.Now, DateTime.Now.AddSeconds(120));
        }
        Random rnd = new Random();
        private void AnimateSeries(Steema.TeeChart.TChart chart)
        {

            double newX, newY;

            chart.AutoRepaint = false;

            /// <summary>
            /// 绘画坐标点超过50个时将实时更新X时间坐标
            /// </summary>
            while (this.fastLine1.Count > 50)
            {
                this.fastLine1.Delete(0);
                fastLine1.GetHorizAxis.SetMinMax(DateTime.Now.AddSeconds(-50), DateTime.Now.AddSeconds(60));
            }

            newX = DateTime.Now.ToOADate();
            newY = rnd.Next(1500);
            if (Math.Abs(newY) > 1.0e+4) newY = 0.0;
            fastLine1.Add(newX, newY);

            chart.AutoRepaint = true;
            chart.Refresh();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            AnimateSeries(this.tChart1);
        }
    }
}
